package handlers

import (
	"mserver/config"
	"mserver/models"
	"mserver/utils"
	"net/http"
	"time"

	"github.com/gin-gonic/gin"
	"gorm.io/gorm"
)

// AuthHandler 認證處理器
type AuthHandler struct {
	DB     *gorm.DB
	Config *config.Config
}

// RegisterRequest 註冊請求
type RegisterRequest struct {
	Username string `json:"username" binding:"required,min=3,max=50"`
	Email    string `json:"email" binding:"required,email"`
	Password string `json:"password" binding:"required,min=6"`
}

// LoginRequest 登入請求
type LoginRequest struct {
	Username string `json:"username" binding:"required"`
	Password string `json:"password" binding:"required"`
}

// AuthResponse 認證回應
type AuthResponse struct {
	Token string       `json:"token"`
	User  UserResponse `json:"user"`
}

// UserResponse 用戶回應
type UserResponse struct {
	ID       uint   `json:"id"`
	Username string `json:"username"`
	Email    string `json:"email"`
}

// Register 註冊新用戶
func (h *AuthHandler) Register(c *gin.Context) {
	var req RegisterRequest
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, models.NewFailResponse("請求參數錯誤: "+err.Error()))
		return
	}

	// 檢查用戶名是否已存在
	var existingUser models.User
	if err := h.DB.Where("username = ?", req.Username).First(&existingUser).Error; err == nil {
		c.JSON(http.StatusConflict, models.NewFailResponse("用戶名已存在"))
		return
	}

	// 檢查 Email 是否已存在
	if err := h.DB.Where("email = ?", req.Email).First(&existingUser).Error; err == nil {
		c.JSON(http.StatusConflict, models.NewFailResponse("Email 已被使用"))
		return
	}

	// 建立新用戶
	user := models.User{
		Username: req.Username,
		Email:    req.Email,
	}

	if err := user.HashPassword(req.Password); err != nil {
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("密碼加密失敗", 5001))
		return
	}

	if err := h.DB.Create(&user).Error; err != nil {
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("建立用戶失敗", 5002))
		return
	}

	// 產生 Token
	token, err := utils.GenerateToken(
		user.ID,
		user.Username,
		h.Config.JWT.SecretKey,
		h.Config.JWT.ExpirationMin,
	)
	if err != nil {
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("Token 產生失敗", 5003))
		return
	}

	c.JSON(http.StatusCreated, models.NewSuccessResponse(AuthResponse{
		Token: token,
		User: UserResponse{
			ID:       user.ID,
			Username: user.Username,
			Email:    user.Email,
		},
	}))
}

// Login 用戶登入
func (h *AuthHandler) Login(c *gin.Context) {
	var req LoginRequest
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, models.NewFailResponse("請求參數錯誤: "+err.Error()))
		return
	}

	// 查詢用戶
	var user models.User
	if err := h.DB.Where("username = ?", req.Username).First(&user).Error; err != nil {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("用戶名或密碼錯誤"))
		return
	}

	// 驗證密碼
	if !user.CheckPassword(req.Password) {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("用戶名或密碼錯誤"))
		return
	}

	// 產生 Token
	token, err := utils.GenerateToken(
		user.ID,
		user.Username,
		h.Config.JWT.SecretKey,
		h.Config.JWT.ExpirationMin,
	)
	if err != nil {
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("Token 產生失敗", 5003))
		return
	}

	c.JSON(http.StatusOK, models.NewSuccessResponse(AuthResponse{
		Token: token,
		User: UserResponse{
			ID:       user.ID,
			Username: user.Username,
			Email:    user.Email,
		},
	}))
}

// Logout 用戶登出
func (h *AuthHandler) Logout(c *gin.Context) {
	// 從 context 取得 token（由 middleware 設置）
	tokenString, exists := c.Get("token")
	if !exists {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("未提供 Token"))
		return
	}

	// 解析 token 取得過期時間
	claims, err := utils.ParseToken(tokenString.(string), h.Config.JWT.SecretKey)
	if err != nil {
		c.JSON(http.StatusUnauthorized, models.NewFailResponse("無效的 Token"))
		return
	}

	// 將 token 加入黑名單
	blacklistedToken := models.Token{
		Token:     tokenString.(string),
		ExpiresAt: claims.ExpiresAt.Time,
	}

	if err := h.DB.Create(&blacklistedToken).Error; err != nil {
		c.JSON(http.StatusInternalServerError, models.NewErrorResponse("登出失敗", 5004))
		return
	}

	c.JSON(http.StatusOK, models.NewSuccessResponse(gin.H{"message": "登出成功"}))
}

// CleanExpiredTokens 清理過期的黑名單 Token
func (h *AuthHandler) CleanExpiredTokens() {
	h.DB.Where("expires_at < ?", time.Now()).Delete(&models.Token{})
}
