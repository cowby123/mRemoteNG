package middleware

import (
	"mserver/config"
	"mserver/models"
	"mserver/utils"
	"net/http"
	"strings"

	"github.com/gin-gonic/gin"
	"gorm.io/gorm"
)

// AuthMiddleware JWT 驗證中間件
func AuthMiddleware(db *gorm.DB, cfg *config.Config) gin.HandlerFunc {
	return func(c *gin.Context) {
		// 從 Header 取得 Token
		authHeader := c.GetHeader("Authorization")
		if authHeader == "" {
			c.JSON(http.StatusUnauthorized, models.NewFailResponse("未提供認證 Token"))
			c.Abort()
			return
		}

		// 檢查格式是否為 "Bearer <token>"
		parts := strings.SplitN(authHeader, " ", 2)
		if len(parts) != 2 || parts[0] != "Bearer" {
			c.JSON(http.StatusUnauthorized, models.NewFailResponse("Token 格式錯誤"))
			c.Abort()
			return
		}

		tokenString := parts[1]

		// 檢查 Token 是否在黑名單中
		var blacklistedToken models.Token
		if err := db.Where("token = ?", tokenString).First(&blacklistedToken).Error; err == nil {
			c.JSON(http.StatusUnauthorized, models.NewFailResponse("Token 已失效"))
			c.Abort()
			return
		}

		// 解析並驗證 Token
		claims, err := utils.ParseToken(tokenString, cfg.JWT.SecretKey)
		if err != nil {
			c.JSON(http.StatusUnauthorized, models.NewFailResponse("無效的 Token"))
			c.Abort()
			return
		}

		// 將用戶資訊和 token 存入 context
		c.Set("user_id", claims.UserID)
		c.Set("username", claims.Username)
		c.Set("token", tokenString)

		c.Next()
	}
}
