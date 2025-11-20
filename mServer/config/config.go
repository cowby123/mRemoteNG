package config

import (
	"encoding/json"
	"os"
)

// Config 應用程式設定
type Config struct {
	Server   ServerConfig   `json:"server"`
	Database DatabaseConfig `json:"database"`
	JWT      JWTConfig      `json:"jwt"`
}

// ServerConfig HTTP 伺服器設定
type ServerConfig struct {
	Host string `json:"host"`
	Port string `json:"port"`
}

// DatabaseConfig 資料庫設定
type DatabaseConfig struct {
	Host     string `json:"host"`
	Port     string `json:"port"`
	Username string `json:"username"`
	Password string `json:"password"`
	Database string `json:"database"`
	SSLMode  string `json:"sslmode"`
}

// JWTConfig JWT 設定
type JWTConfig struct {
	SecretKey     string `json:"secret_key"`
	ExpirationMin int    `json:"expiration_min"` // Token 過期時間（分鐘）
}

// LoadConfig 從檔案載入設定
func LoadConfig(filepath string) (*Config, error) {
	file, err := os.Open(filepath)
	if err != nil {
		return nil, err
	}
	defer file.Close()

	config := &Config{}
	decoder := json.NewDecoder(file)
	if err := decoder.Decode(config); err != nil {
		return nil, err
	}

	return config, nil
}

// GetDSN 取得 PostgreSQL 連線字串
func (c *DatabaseConfig) GetDSN() string {
	return "host=" + c.Host +
		" user=" + c.Username +
		" password=" + c.Password +
		" dbname=" + c.Database +
		" port=" + c.Port +
		" sslmode=" + c.SSLMode
}

// GetDSNWithoutDB 取得不指定資料庫的 PostgreSQL 連線字串（用於建立資料庫）
func (c *DatabaseConfig) GetDSNWithoutDB() string {
	return "host=" + c.Host +
		" user=" + c.Username +
		" password=" + c.Password +
		" port=" + c.Port +
		" sslmode=" + c.SSLMode
}
