package handlers

import (
	"bytes"
	"io"
	"log"
	"mserver/config"
	"mserver/models"
	"net/http"

	"github.com/gin-gonic/gin"
	"gorm.io/gorm"
)

// ConfigHandler 設定處理器
type ConfigHandler struct {
	DB     *gorm.DB
	Config *config.Config
}

// SaveUserConfRequest 儲存用戶設定請求
type SaveUserConfRequest struct {
	Data string `json:"data" binding:"required"`
}

// SaveConConfRequest 儲存連線設定請求
type SaveConConfRequest struct {
	Data string `json:"data" binding:"required"`
}

// ConfigResponse 設定回應
type ConfigResponse struct {
	Data string `json:"data"`
}

// SaveUserConf 儲存用戶設定
func (h *ConfigHandler) SaveUserConf(c *gin.Context) {
	// 從 context 取得 user_id（由 middleware 設置）
	userID, exists := c.Get("user_id")
	if !exists {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("未提供用戶資訊"))
		return
	}

	var req SaveUserConfRequest
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, models.NewFailResponse("請求參數錯誤: "+err.Error()))
		return
	}

	// 查詢是否已存在設定
	var userConf models.UserConf
	result := h.DB.Where("user_id = ?", userID).First(&userConf)

	if result.Error == gorm.ErrRecordNotFound {
		// 不存在，建立新記錄
		userConf = models.UserConf{
			UserID: userID.(uint),
			Data:   req.Data,
		}
		if err := h.DB.Create(&userConf).Error; err != nil {
			c.JSON(http.StatusInternalServerError, models.NewErrorResponse("儲存用戶設定失敗", 5010))
			return
		}
	} else if result.Error != nil {
		// 其他資料庫錯誤
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("查詢用戶設定失敗", 5011))
		return
	} else {
		// 已存在，更新記錄
		userConf.Data = req.Data
		if err := h.DB.Save(&userConf).Error; err != nil {
			c.JSON(http.StatusInternalServerError, models.NewErrorResponse("更新用戶設定失敗", 5012))
			return
		}
	}

	c.JSON(http.StatusOK, models.NewSuccessResponse(gin.H{
		"message": "用戶設定儲存成功",
		"id":      userConf.ID,
	}))
}

// GetUserConf 取得用戶設定
func (h *ConfigHandler) GetUserConf(c *gin.Context) {
	// 從 context 取得 user_id（由 middleware 設置）
	userID, exists := c.Get("user_id")
	if !exists {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("未提供用戶資訊"))
		return
	}

	var userConf models.UserConf
	result := h.DB.Where("user_id = ?", userID).First(&userConf)

	if result.Error == gorm.ErrRecordNotFound {
		c.JSON(http.StatusNotFound, models.NewFailResponse("用戶設定不存在"))
		return
	} else if result.Error != nil {
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("查詢用戶設定失敗", 5011))
		return
	}

	c.JSON(http.StatusOK, models.NewSuccessResponse(ConfigResponse{
		Data: userConf.Data,
	}))
}

// SaveConConf 儲存連線設定
func (h *ConfigHandler) SaveConConf(c *gin.Context) {
	// 從 context 取得 user_id（由 middleware 設置）
	userID, exists := c.Get("user_id")
	if !exists {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("未提供用戶資訊"))
		return
	}

	// 記錄請求資訊
	log.Printf("[SaveConConf] 收到請求，用戶 ID: %v", userID)

	// 讀取原始請求體進行記錄
	bodyBytes, _ := c.GetRawData()
	log.Printf("[SaveConConf] 請求體內容: %s", string(bodyBytes))

	// 重新設置請求體供後續解析
	c.Request.Body = io.NopCloser(bytes.NewBuffer(bodyBytes))

	var req SaveConConfRequest
	if err := c.ShouldBindJSON(&req); err != nil {
		log.Printf("[SaveConConf] JSON 綁定失敗: %v", err)
		c.JSON(http.StatusBadRequest, models.NewFailResponse("請求參數錯誤: "+err.Error()))
		return
	}

	log.Printf("[SaveConConf] 成功解析請求，資料長度: %d", len(req.Data))

	// 查詢是否已存在設定
	var conConf models.ConConf
	result := h.DB.Where("user_id = ?", userID).First(&conConf)

	if result.Error == gorm.ErrRecordNotFound {
		// 不存在，建立新記錄
		conConf = models.ConConf{
			UserID: userID.(uint),
			Data:   req.Data,
		}
		if err := h.DB.Create(&conConf).Error; err != nil {
			c.JSON(http.StatusInternalServerError, models.NewErrorResponse("儲存連線設定失敗", 5020))
			return
		}
	} else if result.Error != nil {
		// 其他資料庫錯誤
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("查詢連線設定失敗", 5021))
		return
	} else {
		// 已存在，更新記錄
		conConf.Data = req.Data
		if err := h.DB.Save(&conConf).Error; err != nil {
			c.JSON(http.StatusInternalServerError, models.NewErrorResponse("更新連線設定失敗", 5022))
			return
		}
	}

	c.JSON(http.StatusOK, models.NewSuccessResponse(gin.H{
		"message": "連線設定儲存成功",
		"id":      conConf.ID,
	}))
}

// GetConConf 取得連線設定
func (h *ConfigHandler) GetConConf(c *gin.Context) {
	// 從 context 取得 user_id（由 middleware 設置）
	userID, exists := c.Get("user_id")
	if !exists {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("未提供用戶資訊"))
		return
	}

	var conConf models.ConConf
	result := h.DB.Where("user_id = ?", userID).First(&conConf)

	if result.Error == gorm.ErrRecordNotFound {
		c.JSON(http.StatusNotFound, models.NewFailResponse("連線設定不存在"))
		return
	} else if result.Error != nil {
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("查詢連線設定失敗", 5021))
		return
	}

	c.JSON(http.StatusOK, models.NewSuccessResponse(ConfigResponse{
		Data: conConf.Data,
	}))
}
