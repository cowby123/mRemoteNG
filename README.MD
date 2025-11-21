# 歡迎來到 mRemoteNG 專案！

[![Twitter Follow](https://img.shields.io/twitter/follow/mRemoteNG.svg?style=social&label=Follow)](https://twitter.com/intent/follow?screen_name=mRemoteNG)
[![Join the chat at https://gitter.im/mRemoteNG/PublicChat/](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/mRemoteNG/PublicChat)
[![PayPal](https://img.shields.io/badge/%24-PayPal-blue.svg)](https://www.paypal.me/DavidSparer)

[![CII Best Practices](https://bestpractices.coreinfrastructure.org/projects/529/badge)](https://bestpractices.coreinfrastructure.org/projects/529)

mRemoteNG 是 mRemote 的下一代版本，一個功能完整、多分頁的遠端連線管理工具。

## 功能特色

mRemoteNG 是 mRemote 的分支：一個開源、分頁式、多協定的遠端連線管理器。mRemoteNG 在 mRemote 的基礎上新增了錯誤修正和新功能。

它讓您能夠在一個簡潔而強大的分頁介面中查看所有遠端連線。

mRemoteNG 支援以下協定：

* RDP (遠端桌面/終端伺服器)
* VNC (虛擬網路計算)
* ~~ICA (Citrix 獨立運算架構)~~ **(已移除)**
* SSH (安全殼層)
* Telnet (遠端登入)
* HTTP/HTTPS (超文本傳輸協定)
* rlogin (遠端登入)
* Raw Socket 連線

如需詳細功能列表和一般使用支援，請參閱[使用者手冊](https://github.com/mRemoteNG/mRemoteNG/wiki/User-Manual)。

## 安裝

安裝前請確保您已安裝所有必要的[前置條件](https://github.com/mRemoteNG/mRemoteNG/wiki/Prerequisites)。

mRemoteNG 提供可重新發布的 msi 安裝套件，可從以下位置下載：
* [GitHub](https://github.com/mRemoteNG/mRemoteNG/releases)
* [專案網站](https://mremoteng.org/download)

mRemoteNG 支援 Windows 7 或更新版本。
Windows 7 和 Windows Server 2008 安裝必須確保已安裝並啟用[所需的更新](https://github.com/mRemoteNG/mRemoteNG/wiki/Prerequisites#full-list-of-required-windows-updates-for-windows-7--server-2008-clients)。

## 新增功能：雲端同步 (mServer)

本版本新增了雲端同步功能，讓您可以將連線設定備份到雲端伺服器，並在多台電腦之間同步。

### mServer 伺服器端

mServer 是一個 Go 語言撰寫的 RESTful API 伺服器，提供使用者認證和連線設定儲存功能。

#### 系統需求

- Go 1.19 或更新版本
- PostgreSQL 資料庫

#### 安裝步驟

1. **設定資料庫**

   建立 PostgreSQL 資料庫（或讓程式自動建立）：
   ```bash
   createdb mremoteng
   ```

2. **設定檔**

   在 `mServer` 目錄建立 `config.json`：
   ```json
   {
     "server": {
       "host": "0.0.0.0",
       "port": "8080"
     },
     "database": {
       "host": "localhost",
       "port": "5432",
       "user": "postgres",
       "password": "your_password",
       "database": "mremoteng",
       "sslmode": "disable"
     },
     "jwt": {
       "secret": "your-secret-key-change-this",
       "expiration": 168
     }
   }
   ```

3. **編譯和執行**

   ```bash
   cd mServer
   go mod download
   go build
   ./mServer
   ```

   或直接執行：
   ```bash
   go run main.go
   ```

#### API 端點

**公開端點（無需認證）：**
- `POST /api/register` - 註冊新使用者
- `POST /api/login` - 使用者登入

**需要認證的端點（需要 JWT Token）：**
- `POST /api/logout` - 登出
- `POST /api/user/userconf` - 儲存使用者設定
- `GET /api/user/userconf` - 取得使用者設定
- `POST /api/user/conconf` - 儲存連線設定
- `GET /api/user/conconf` - 取得連線設定

**文件：**
- `GET /swagger` - Swagger UI 互動式 API 文件
- `GET /swagger.yaml` - OpenAPI 規格檔

#### 使用範例

1. **註冊使用者**
   ```bash
   curl -X POST http://localhost:8080/api/register \
     -H "Content-Type: application/json" \
     -d '{"username":"user1","password":"password123"}'
   ```

2. **登入**
   ```bash
   curl -X POST http://localhost:8080/api/login \
     -H "Content-Type: application/json" \
     -d '{"username":"user1","password":"password123"}'
   ```

   回應會包含 JWT token：
   ```json
   {
     "status": "success",
     "data": {
       "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
     }
   }
   ```

3. **儲存連線設定**
   ```bash
   curl -X POST http://localhost:8080/api/user/conconf \
     -H "Content-Type: application/json" \
     -H "Authorization: Bearer YOUR_TOKEN" \
     -d '{"data":"base64_encoded_config"}'
   ```

### mRemoteNG 客戶端設定

1. **開啟設定**
   - 工具 → 選項 → HTTP 伺服器

2. **設定伺服器資訊**
   - 綁定位址：伺服器 IP 或網域名稱（例如：`192.168.1.100` 或 `api.example.com`）
   - 伺服器連接埠：預設 `8080`
   - 帳號：您的使用者名稱
   - 密碼：您的密碼

3. **登入**
   - 點擊「登入」按鈕
   - 成功後會自動儲存 Token

4. **使用雲端同步**
   - **上傳**：在連線樹狀視圖工具列點擊「上傳」按鈕
   - **下載**：在連線樹狀視圖工具列點擊「下載」按鈕
   - 下載後會自動重新載入連線設定

#### 自動重新登入

當 Token 過期時，客戶端會自動使用儲存的帳號密碼重新登入，無需手動操作。

## 貢獻

如果您覺得 mRemoteNG 很有用並希望貢獻，我們將非常感激。當您貢獻時，您讓團隊有能力負擔製作 mRemoteNG 的成本。

### 提交程式碼
查看[維基頁面](https://github.com/mRemoteNG/mRemoteNG/wiki/Development)了解如何設定開發環境並提交 pull request。

### 翻譯
查看[維基頁面](https://github.com/mRemoteNG/mRemoteNG/wiki/How%20to%20Help%20Translating%20mRemoteNG)了解如何幫助 mRemoteNG 成為多語言應用程式。

## 變更記錄

### 本版本新增
- ✨ 新增雲端同步功能（mServer）
- ✨ HTTP 伺服器設定頁面
- ✨ 連線設定上傳/下載功能
- ✨ JWT Token 自動重新登入
- ✨ Token 過期自動處理
- ⚠️ 移除 Citrix ICA 支援

### 技術改進
- 使用 Go + Gin 框架建立 RESTful API
- PostgreSQL 資料庫儲存
- JWT 認證機制
- Swagger API 文件
- 獨立的 HTTP 伺服器設定檔

## 授權

mRemoteNG 採用 GPL 授權。詳見 LICENSE 檔案。

## 致謝

感謝所有貢獻者讓 mRemoteNG 成為更好的工具！

[![Developed with ReSharper](https://raw.githubusercontent.com/mRemoteNG/mRemoteNG/develop/.github/icon_ReSharper.png)](https://www.jetbrains.com/resharper/)
