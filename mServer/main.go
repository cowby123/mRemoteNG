package main

import (
	"log"
	"mserver/config"
	"mserver/handlers"
	"mserver/middleware"
	"mserver/models"
	"time"

	"github.com/gin-gonic/gin"
	"gorm.io/driver/postgres"
	"gorm.io/gorm"
)

func main() {
	// 載入設定檔
	cfg, err := config.LoadConfig("config.json")
	if err != nil {
		log.Fatalf("載入設定檔失敗: %v", err)
	}

	// 嘗試連接資料庫
	db, err := gorm.Open(postgres.Open(cfg.Database.GetDSN()), &gorm.Config{})
	if err != nil {
		// 如果連接失敗，嘗試建立資料庫
		log.Printf("資料庫不存在，嘗試建立資料庫: %s", cfg.Database.Database)

		// 連接到 PostgreSQL（不指定資料庫）
		tempDB, err := gorm.Open(postgres.Open(cfg.Database.GetDSNWithoutDB()), &gorm.Config{})
		if err != nil {
			log.Fatalf("連接 PostgreSQL 伺服器失敗: %v", err)
		}

		// 建立資料庫
		sqlDB, err := tempDB.DB()
		if err != nil {
			log.Fatalf("取得資料庫連線失敗: %v", err)
		}

		createDBSQL := "CREATE DATABASE " + cfg.Database.Database
		_, err = sqlDB.Exec(createDBSQL)
		if err != nil {
			log.Fatalf("建立資料庫失敗: %v", err)
		}

		log.Printf("資料庫 %s 建立成功", cfg.Database.Database)
		sqlDB.Close()

		// 重新連接到新建立的資料庫
		db, err = gorm.Open(postgres.Open(cfg.Database.GetDSN()), &gorm.Config{})
		if err != nil {
			log.Fatalf("連接資料庫失敗: %v", err)
		}
	}

	log.Println("資料庫連接成功")

	// 自動遷移資料庫結構
	if err := db.AutoMigrate(&models.User{}, &models.Token{}); err != nil {
		log.Fatalf("資料庫遷移失敗: %v", err)
	}

	log.Println("資料庫遷移完成")

	// 建立 Gin 引擎
	r := gin.Default()

	// 建立處理器
	authHandler := &handlers.AuthHandler{
		DB:     db,
		Config: cfg,
	}

	// 定期清理過期的黑名單 Token
	go func() {
		ticker := time.NewTicker(1 * time.Hour)
		defer ticker.Stop()
		for range ticker.C {
			authHandler.CleanExpiredTokens()
		}
	}()

	// 公開路由（不需要認證）
	public := r.Group("/api")
	{
		public.POST("/register", authHandler.Register)
		public.POST("/login", authHandler.Login)
	}

	// 需要認證的路由
	protected := r.Group("/api")
	protected.Use(middleware.AuthMiddleware(db, cfg))
	{
		protected.POST("/logout", authHandler.Logout)
		// 可以在這裡加入其他需要認證的路由
	}

	// 啟動伺服器
	addr := cfg.Server.Host + ":" + cfg.Server.Port
	log.Printf("伺服器啟動於 %s", addr)
	if err := r.Run(addr); err != nil {
		log.Fatalf("啟動伺服器失敗: %v", err)
	}
}
