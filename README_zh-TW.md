# 歡迎使用 mRemoteNG 專案！

[![Twitter Follow](https://img.shields.io/twitter/follow/mRemoteNG.svg?style=social&label=Follow)](https://twitter.com/intent/follow?screen_name=mRemoteNG)
[![Join the chat at https://gitter.im/mRemoteNG/PublicChat/](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/mRemoteNG/PublicChat)
[![PayPal](https://img.shields.io/badge/%24-PayPal-blue.svg)](https://www.paypal.me/DavidSparer)

[![CII Best Practices](https://bestpractices.coreinfrastructure.org/projects/529/badge)](https://bestpractices.coreinfrastructure.org/projects/529)

[![Issues In Progress](https://badge.waffle.io/mRemoteNG/mRemoteNG.png?label=In%20Progress&title=In%20Progress)](https://waffle.io/mRemoteNG/mRemoteNG)

| 更新通道 | 建置狀態 | 下載次數 |
| -------|---------|---------|
| 穩定版 | [![Build status](https://ci.appveyor.com/api/projects/status/k0sdbxmq90fgdmj6/branch/master?svg=true)](https://ci.appveyor.com/project/mremoteng/mremoteng/branch/master) | [![Github Releases (by Release)](https://img.shields.io/github/downloads/mRemoteNG/mRemoteNG/v1.75.7012/total.svg)](https://github.com/mRemoteNG/mRemoteNG/releases/tag/v1.75.7012) |
| 測試版 | | [![Github Releases (by Release)](https://img.shields.io/github/downloads/mRemoteNG/mRemoteNG/v1.75.7012/total.svg)](https://github.com/mRemoteNG/mRemoteNG/releases/tag/v1.75.7012) |
| 開發版 | [![Build status](https://ci.appveyor.com/api/projects/status/k0sdbxmq90fgdmj6/branch/develop?svg=true)](https://ci.appveyor.com/project/mremoteng/mremoteng/branch/develop) | [![Github Releases (by Release)](https://img.shields.io/github/downloads/mRemoteNG/mRemoteNG/v1.76Alpha5/total.svg)](https://github.com/mRemoteNG/mRemoteNG/releases/tag/v1.76Alpha5) |

## 專案簡介

**mRemoteNG** 是 mRemote 的下一代版本，一個功能齊全、支援多分頁的遠端連線管理工具。

mRemoteNG 是 mRemote 的分支專案：一個開源、多分頁、支援多種協定的遠端連線管理器。mRemoteNG 在 mRemote 的基礎上修復了錯誤並新增了許多新功能。

它讓你能夠在一個簡潔而強大的分頁介面中檢視所有遠端連線。

## 主要功能特色

### 支援的連線協定

mRemoteNG 支援以下協定：

* **RDP** (Remote Desktop Protocol / 遠端桌面協定)
  - 支援 Windows 遠端桌面連線
  - 支援 RDP 8.0 以上版本
  - 支援 RD Gateway 閘道
  - 支援磁碟機、印表機、聲音等重定向功能

* **VNC** (Virtual Network Computing / 虛擬網路計算)
  - 支援多種 VNC 伺服器
  - 提供 SmartSize 自動縮放模式

* **ICA** (Citrix Independent Computing Architecture)
  - Citrix 應用程式與桌面連線
  - 可設定加密強度

* **SSH** (Secure Shell / 安全殼層協定)
  - 支援 SSH1 和 SSH2
  - 整合 PuTTY 終端機
  - 支援 SFTP/SCP 檔案傳輸

* **Telnet** (TELecommunication NETwork)
  - 基於 PuTTY 的 Telnet 連線

* **HTTP/HTTPS** (Hypertext Transfer Protocol)
  - 支援網頁瀏覽
  - 支援 IE 和 Firefox (GeckoFX) 渲染引擎

* **Rlogin** (Remote Login / 遠端登入)

* **RAW Socket** (原始 Socket 連線)

* **IntApp** (整合外部應用程式)

### 核心功能

#### 連線管理
- **樹狀結構組織**：使用資料夾層次結構組織所有連線
- **設定繼承系統**：子連線可從父資料夾繼承設定，方便批次管理
- **多分頁介面**：同時開啟並管理多個連線工作階段
- **快速連線**：透過快速連線工具列立即建立新連線
- **強大的搜尋與篩選**：快速找到需要的連線

#### 安全性功能
- **強大的加密保護**：
  - 使用 AES-GCM (AEAD) 加密保護密碼
  - 相容舊版 Rijndael 加密格式
- **連線檔案密碼保護**：XML 設定檔可設定主密碼
- **憑證管理**：支援憑證儲存庫
- **FIPS 相容性**：可在啟用 FIPS 的系統上執行

#### 彈性的儲存選項
- **XML 檔案**：本機 XML 格式儲存，易於備份與攜帶
- **SQL Server**：支援多使用者團隊環境
  - 即時同步更新
  - 支援唯讀模式
  - 支援本地屬性儲存
- **可攜式模式**：設定儲存在應用程式目錄，可用隨身碟攜帶

#### 豐富的匯入/匯出功能

**支援匯入格式**：
- mRemoteNG XML/CSV 檔案
- Remote Desktop Connection Manager (RDCMan) v2.7
- PuTTY Connection Manager
- PuTTY 已儲存的工作階段
- Active Directory (AD) 電腦清單
- 連接埠掃描結果
- RDP (.rdp) 檔案

**支援匯出格式**：
- mRemoteNG XML
- mRemoteNG CSV
- vRD 2008 CSV

#### 實用工具
- **連接埠掃描器**：非同步網路掃描功能
- **外部工具整合**：
  - 可設定連線前/後執行的外部工具
  - 支援工具列顯示
  - 支援變數替換（如 %hostname%、%username% 等）
- **SSH 檔案傳輸**：內建 SFTP/SCP 支援
- **螢幕截圖管理**：自動擷取與管理連線螢幕截圖

#### 介面功能
- **可停靠面板**：基於 DockPanel Suite，自由調整介面配置
- **豐富的主題系統**：
  - 支援 VS2003、VS2012、VS2013、VS2015 主題風格
  - 可自訂介面顏色配置
- **全螢幕/Kiosk 模式**：提供無邊框全螢幕顯示
- **多顯示器支援**：可將面板移至不同螢幕
- **多語言支援**：支援 22 種語言，包含繁體中文

#### 自動化功能
- **自動重新連線**：RDP/ICA 斷線時自動重新連線
- **啟動時還原連線**：記憶上次開啟的連線工作階段
- **自動儲存**：編輯後自動儲存連線設定
- **自動更新檢查**：
  - 穩定版、測試版、開發版三種更新通道
  - 支援自動更新（包含可攜式版本）

詳細的功能列表與使用說明，請參考[使用手冊](https://github.com/mRemoteNG/mRemoteNG/wiki/User-Manual)。

## 系統需求

### 基本需求
- **作業系統**：Windows 7 或更新版本
- **.NET Framework**：4.0 或更新版本

### 特殊需求
- **Windows 7 / Server 2008**：需要安裝[特定的系統更新](https://github.com/mRemoteNG/mRemoteNG/wiki/Prerequisites#full-list-of-required-windows-updates-for-windows-7--server-2008-clients)
- **RDP 功能**：
  - Windows 7：需要安裝 RDP 8 (KB2592687 或 KB2923545)
  - Windows 8 以上：內建 RDP 8 以上版本
- **Citrix ICA**：需要安裝 Citrix Receiver

完整的系統需求清單請參考[先決條件頁面](https://github.com/mRemoteNG/mRemoteNG/wiki/Prerequisites)。

## 安裝說明

安裝前請確認你的系統已符合所有[必要條件](https://github.com/mRemoteNG/mRemoteNG/wiki/Prerequisites)。

### 下載位置

mRemoteNG 提供 MSI 安裝套件與可攜式 ZIP 壓縮檔，可從以下位置下載：

* [GitHub Releases](https://github.com/mRemoteNG/mRemoteNG/releases)
* [專案官方網站](https://mremoteng.org/download)

### 支援的系統

- **Windows 7 或更新版本**
- Windows 7 和 Windows Server 2008 需確保已安裝並啟用[必要的系統更新](https://github.com/mRemoteNG/mRemoteNG/wiki/Prerequisites#full-list-of-required-windows-updates-for-windows-7--server-2008-clients)

### 安裝方式

1. **標準安裝**：下載並執行 MSI 安裝程式
2. **可攜式版本**：下載 ZIP 壓縮檔並解壓縮至任意位置（如隨身碟）

## 快速開始

1. 啟動 mRemoteNG
2. 在連線樹狀清單中建立新的連線或資料夾
3. 設定連線參數（主機名稱、協定、帳號密碼等）
4. 雙擊連線即可開啟遠端工作階段
5. 使用分頁在不同連線之間切換

詳細的使用教學請參考[使用手冊](https://github.com/mRemoteNG/mRemoteNG/wiki/User-Manual)。

## 參與貢獻

如果你覺得 mRemoteNG 很實用並且願意貢獻，我們會非常感激。你的貢獻能讓團隊有能力負擔 mRemoteNG 的開發與維護成本。

### 提交程式碼

請查看 [Wiki 開發頁面](https://github.com/mRemoteNG/mRemoteNG/wiki/Development)，了解如何設定開發環境並提交 Pull Request。

**貢獻流程**：
1. Fork 本專案並建立功能分支
2. 遵循專案的程式碼風格規範
3. 撰寫或更新相關測試
4. 提交 Pull Request 並詳細說明變更內容

**開發環境**：
- Visual Studio 2017 或更新版本
- .NET Framework 4.6 SDK
- NuGet 套件管理器

### 協助翻譯

mRemoteNG 目前已支援 22 種語言。如果你想協助改進現有翻譯或新增其他語言，請查看 [Wiki 翻譯頁面](https://github.com/mRemoteNG/mRemoteNG/wiki/How%20to%20Help%20Translating%20mRemoteNG)。

**已支援的語言**（包含但不限於）：
- 繁體中文
- 簡體中文
- 英語
- 日語
- 韓語
- 德語、法語、西班牙語、義大利語
- 以及更多...

### 回報問題與建議

- **錯誤回報**：請在 [GitHub Issues](https://github.com/mRemoteNG/mRemoteNG/issues) 建立新的 Issue
- **功能建議**：同樣在 GitHub Issues 提出，並標註為功能請求
- **安全性問題**：請私密回報至 support@mremoteng.org

### 贊助支援

如果你想以金錢方式支持專案開發：
- **PayPal**：[https://www.paypal.me/DavidSparer](https://www.paypal.me/DavidSparer)

你的贊助將用於：
- 支付程式碼簽章憑證費用
- 維護伺服器與網站
- 開發工具授權
- 持續的專案開發

## 專案歷史

### 演進過程

- **mRemote**（2007-2009）
  - 原始作者：Felix Deimel
  - 使用 Visual Basic 開發
  - 奠定遠端連線管理基礎

- **mRemoteNG 第一代**（2010-2013）
  - 作者：Riley McArdle
  - 從 mRemote 分支發展
  - 修復錯誤並新增功能

- **mRemoteNG 當前版本**（2016-至今）
  - 當前開發團隊維護
  - 主要維護者：David Sparer、Sean Kaim
  - **完全轉換為 C# 語言**
  - 持續更新與社群維護

### 重要里程碑

- **v1.74 (2016)**：從 Visual Basic 完全轉換為 C#，全面重構
- **v1.75 (2017)**：引入自動更新機制、發佈通道系統
- **v1.76 (2017-2019)**：可攜式設定支援、主題系統重構、多語言擴充

## 技術架構

### 核心技術
- **開發語言**：C#
- **框架**：.NET Framework 4.6
- **UI 框架**：Windows Forms
- **建置工具**：MSBuild、WiX Toolset

### 主要依賴
- **DockPanel Suite**：可停靠面板系統
- **SSH.NET**：SSH 協定實作
- **GeckoFX**：Firefox 渲染引擎（網頁瀏覽）
- **PuTTY**：終端機整合
- **BouncyCastle**：加密功能
- **log4net**：日誌記錄

### 架構特色
- 分層架構設計
- 插件式協定系統
- 完善的繼承機制
- 模組化與可擴展性

## 授權資訊

### 專案授權
- **授權協議**：GNU General Public License Version 2 (GPL v2)
- **版權聲明**：
  - Copyright © 2019 mRemoteNG Dev Team
  - Copyright © 2010-2013 Riley McArdle
  - Copyright © 2007-2009 Felix Deimel

### 開源元件
本專案使用了多個開源元件，各自遵循其授權條款：
- DockPanel Suite (MIT License)
- GeckoFX (Mozilla Public License)
- PuTTY (MIT License)
- SSH.NET (MIT License)
- log4net (Apache License 2.0)
- 以及其他開源元件

完整的授權資訊請參閱 [COPYING.TXT](COPYING.TXT) 與 [CREDITS.TXT](CREDITS.TXT)。

## 社群與支援

### 專案連結
- **官方網站**：[https://mremoteng.org](https://mremoteng.org)
- **GitHub**：[https://github.com/mRemoteNG/mRemoteNG](https://github.com/mRemoteNG/mRemoteNG)
- **論壇**：[http://forum.mremoteng.org](http://forum.mremoteng.org)
- **Gitter 聊天室**：[https://gitter.im/mRemoteNG/PublicChat](https://gitter.im/mRemoteNG/PublicChat)
- **Twitter**：[@mRemoteNG](https://twitter.com/mRemoteNG)

### 取得協助
- **使用手冊**：[Wiki User Manual](https://github.com/mRemoteNG/mRemoteNG/wiki/User-Manual)
- **常見問題**：[Wiki FAQ](https://github.com/mRemoteNG/mRemoteNG/wiki)
- **一般討論**：Gitter 聊天室或論壇
- **錯誤回報**：GitHub Issues

## 為什麼選擇 mRemoteNG？

### 核心優勢

✅ **完全免費且開源**：GPL v2 授權，永久免費使用

✅ **多協定支援**：9 種協定在單一介面中管理

✅ **企業級功能**：適合個人與企業環境使用

✅ **活躍維護**：持續更新與錯誤修復

✅ **豐富的社群**：活躍的使用者社群與技術支援

✅ **安全可靠**：強大的加密機制保護你的憑證

✅ **高度可自訂**：主題、工具、匯入器皆可擴充

✅ **可攜式選項**：可在隨身碟中執行，隨身攜帶所有設定

✅ **多語言支援**：包含繁體中文在內的 22 種語言

✅ **無廣告無追蹤**：尊重使用者隱私

### 適用場景

- **系統管理員**：管理大量伺服器連線
- **IT 支援人員**：快速存取客戶電腦
- **開發人員**：管理開發、測試、正式環境連線
- **網路工程師**：管理網路設備與伺服器
- **一般使用者**：組織個人遠端連線

## 截圖展示

> 注：實際截圖請參考[官方網站](https://mremoteng.org)或 [Wiki](https://github.com/mRemoteNG/mRemoteNG/wiki)

## 常見問題

**Q: mRemoteNG 與 mRemote 有什麼差別？**
A: mRemoteNG 是 mRemote 的分支專案，修復了原專案的錯誤並新增許多新功能。原始的 mRemote 專案已停止維護，mRemoteNG 持續活躍開發中。

**Q: 我的連線設定檔案儲存在哪裡？**
A: 預設儲存在 `%APPDATA%\mRemoteNG\confCons.xml`。可攜式版本儲存在程式目錄中。

**Q: 如何設定主密碼保護我的連線檔案？**
A: 在「工具」→「選項」→「安全性」中可以設定主密碼。

**Q: 支援 Linux 或 macOS 嗎？**
A: 目前僅支援 Windows 平台。

**Q: 可以在多台電腦間同步連線設定嗎？**
A: 可以透過以下方式：
  - 將 confCons.xml 放在雲端同步資料夾（如 OneDrive、Dropbox）
  - 使用 SQL Server 儲存（適合團隊環境）
  - 使用可攜式版本並存放在隨身碟

**Q: 密碼是如何加密的？**
A: 使用 AES-GCM 加密演算法，確保密碼安全儲存。

更多問題請參考 [Wiki](https://github.com/mRemoteNG/mRemoteNG/wiki) 或在社群中詢問。

## 專案統計

- **支援協定**：9 種
- **支援語言**：22 種
- **開發歷史**：17+ 年（自 mRemote 起算）
- **授權**：開源 GPL v2
- **開發語言**：C#
- **活躍維護**：✅

## 致謝

### 開發團隊
- David Sparer (@sparerd)
- Sean Kaim (@kmscode)
- Bennett Blodinger (@benwa)

### 主要貢獻者
- Joe Cefoli、Tony Lambert、Julien Roncaglia
- Pedro Rodrigues、Brandon Wulf
- 以及眾多社群貢獻者

### 特別感謝
- **JetBrains**：提供 ReSharper 授權支援開發
  [![Developed with ReSharper](https://raw.githubusercontent.com/mRemoteNG/mRemoteNG/develop/.github/icon_ReSharper.png)](https://www.jetbrains.com/resharper/)

- **所有贊助者與貢獻者**：感謝你們的支持讓 mRemoteNG 持續進步

## 相關資源

- [使用手冊](https://github.com/mRemoteNG/mRemoteNG/wiki/User-Manual)
- [開發文件](https://github.com/mRemoteNG/mRemoteNG/wiki/Development)
- [變更日誌](CHANGELOG.TXT)
- [授權資訊](COPYING.TXT)
- [貢獻者名單](CREDITS.TXT)

---

## 法律聲明

本軟體依「現況」提供，不提供任何明示或暗示的保證。在任何情況下，作者或版權持有人均不對任何索賠、損害或其他責任負責，無論是在合約訴訟、侵權行為或其他方面。

使用本軟體即表示你同意 GPL v2 授權條款。

---

**最後更新**：2025-11-20
**文件版本**：1.0
**專案版本**：v1.76.20

**語言版本**：[English](README.MD) | 繁體中文

---

💙 如果 mRemoteNG 對你有幫助，請考慮給我們一個 ⭐ Star，或是[贊助支持](https://www.paypal.me/DavidSparer)專案開發！
