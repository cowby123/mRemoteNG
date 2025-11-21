package models

import (
	"time"

	"gorm.io/gorm"
)

// UserConf 用戶設定
type UserConf struct {
	ID        uint           `gorm:"primarykey" json:"id"`
	CreatedAt time.Time      `json:"created_at"`
	UpdatedAt time.Time      `json:"updated_at"`
	DeletedAt gorm.DeletedAt `gorm:"index" json:"-"`
	UserID    uint           `gorm:"uniqueIndex;not null" json:"user_id"` // 用戶 ID（唯一）
	Data      string         `gorm:"type:text" json:"data"`               // 設定資料（JSON 格式）
}

// ConConf 連線設定
type ConConf struct {
	ID        uint           `gorm:"primarykey" json:"id"`
	CreatedAt time.Time      `json:"created_at"`
	UpdatedAt time.Time      `json:"updated_at"`
	DeletedAt gorm.DeletedAt `gorm:"index" json:"-"`
	UserID    uint           `gorm:"uniqueIndex;not null" json:"user_id"` // 用戶 ID（唯一）
	Data      string         `gorm:"type:text" json:"data"`               // 設定資料（JSON 格式）
}
