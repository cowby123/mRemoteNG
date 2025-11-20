# mRemoteNG Server

mRemoteNG 設定檔伺服器端，提供用戶認證和設定檔儲存功能。

## 功能特色

- 基於 JWT 的用戶認證系統
- 用戶註冊、登入、登出
- PostgreSQL 資料庫
- **自動建立資料庫**（如果不存在）
- **自動遷移資料表結構**（GORM AutoMigrate）
- RESTful API
- Swagger API 文件

## 技術棧

- **語言**: Go 1.21+
- **Web 框架**: Gin
- **資料庫**: PostgreSQL
- **ORM**: GORM
- **認證**: JWT (golang-jwt/jwt)

## 專案結構

```
mServer/
├── config/          # 設定相關
├── handlers/        # API 處理器
├── middleware/      # 中間件
├── models/          # 資料模型
├── utils/           # 工具函數
├── main.go          # 程式進入點
├── config.example.json  # 設定檔範例
└── swagger.yaml     # API 文件
```

## 快速開始

### 1. 安裝依賴

```bash
go mod download
```

### 2. 設定檔

複製設定檔範例並修改：

```bash
cp config.example.json config.json
```

編輯 `config.json` 設定資料庫連線資訊：

```json
{
  "server": {
    "host": "0.0.0.0",
    "port": "8080"
  },
  "database": {
    "host": "localhost",
    "port": "5432",
    "username": "postgres",
    "password": "your_password",
    "database": "mremoteng",
    "sslmode": "disable"
  },
  "jwt": {
    "secret_key": "your-secret-key-change-this-in-production",
    "expiration_min": 1440
  }
}
```

### 3. 啟動伺服器

```bash
go run main.go
```

或使用編譯後的執行檔：

```bash
./mserver.exe
```

**自動化功能：**
1. 如果資料庫不存在，程式會自動建立
2. 自動執行資料庫遷移（AutoMigrate），建立必要的資料表
3. 無需手動執行任何 SQL 指令

**注意：** 確保 PostgreSQL 伺服器已啟動，且設定檔中的用戶有建立資料庫的權限。

## API 端點

### 公開端點（不需認證）

- `POST /api/register` - 註冊新用戶
- `POST /api/login` - 用戶登入

### 需要認證的端點

需要在 Header 中加入 `Authorization: Bearer <token>`

- `POST /api/logout` - 用戶登出

## API 使用範例

### 註冊

```bash
curl -X POST http://localhost:8080/api/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "john_doe",
    "email": "john@example.com",
    "password": "password123"
  }'
```

### 登入

```bash
curl -X POST http://localhost:8080/api/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "john_doe",
    "password": "password123"
  }'
```

### 登出

```bash
curl -X POST http://localhost:8080/api/logout \
  -H "Authorization: Bearer YOUR_JWT_TOKEN"
```

## 資料庫結構

### users 表

| 欄位 | 型態 | 說明 |
|------|------|------|
| id | SERIAL | 主鍵 |
| created_at | TIMESTAMP | 建立時間 |
| updated_at | TIMESTAMP | 更新時間 |
| deleted_at | TIMESTAMP | 刪除時間（軟刪除） |
| username | VARCHAR | 用戶名（唯一） |
| email | VARCHAR | Email（唯一） |
| password | VARCHAR | 密碼雜湊 |

### tokens 表（黑名單）

| 欄位 | 型態 | 說明 |
|------|------|------|
| id | SERIAL | 主鍵 |
| created_at | TIMESTAMP | 建立時間 |
| deleted_at | TIMESTAMP | 刪除時間（軟刪除） |
| token | TEXT | JWT Token（唯一） |
| expires_at | TIMESTAMP | 過期時間 |

## 安全性

- 密碼使用 bcrypt 加密
- JWT Token 用於身份驗證
- 登出時 Token 加入黑名單
- 定期清理過期的黑名單 Token（每小時）

## Swagger 文件

API 文件請參考 [swagger.yaml](swagger.yaml)

可以使用 Swagger UI 或 Swagger Editor 查看：
- https://editor.swagger.io/
- 將 swagger.yaml 內容貼上即可查看完整 API 文件

## 注意事項

1. **正式環境請務必修改 JWT Secret Key**
2. PostgreSQL 連線建議使用 SSL（sslmode=require）
3. 建議使用環境變數管理敏感資訊
4. 定期備份資料庫

## 授權

MIT License
