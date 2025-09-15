# mRemoteNG UI 模組

本目錄包含 mRemoteNG 的使用者介面 (UI) 組件，包括自訂控制項、視窗、表單、選單、對話框與各種工具類別。下列說明列出目錄中的主要檔案與子目錄，協助了解其功能與用途。

## 目錄

- **Controls/**：包含大量自訂控制項，如 mrngButton、mrngTextBox、CredentialRecordListView 等，並包含數個子目錄：
  - **Adapters/**：將一般介面元素包裝成可插拔的控制項。
  - **ConnectionTree/**：處理連線樹檢視與節點相關控制。
  - **FilteredPropertyGrid/**：實作可篩選的 PropertyGrid 控制項。
  - **ConnectionInfoPropertyGrid/**：提供連線資訊的屬性編輯視窗。
  - **PageSequence/**：用於多步驟流程的頁面控制項。
- **TaskDialog/**：實作類似 Windows Task Dialog 的對話框，包含 `cTaskDialog` 類別與 `frmTaskDialog` 表單。
- **Font/**：存放介面使用的字型檔 `HandelGotDBol.ttf`。
- **Window/**：各種功能視窗，如 `ConnectionWindow`、`ConfigWindow`、`ExternalToolsWindow`、`PortScanWindow`、`UpdateWindow`、`SSHTransferWindow`、`ActiveDirectoryImportWindow` 等。
- **Menu/**：應用程式的選單系統：
  - **msMain/**：檔案、檢視、工具、說明等主選單。
  - **msQuickConnect/**：快速連線選單。
  - **msExternalTools/**：外部工具選單。
  - **msMultiSSH/**：多重 SSH 操作選單。
  - `AdvancedWindowMenu.cs`：進階視窗管理選單。
- **Forms/**：主要視窗與通用對話框，包括 `frmMain` 主視窗、`FrmAbout`、`FrmPassword`、`FrmExport`、`FrmInputBox`、`FrmUnhandledException`、`FrmSplashScreenNew` 等。
  - **OptionsPages/**：設定視窗的各個分頁，如外觀、連線、憑證、啟動/結束、通知、安全性、備份、SQL Server 等。
- **Tabs/**：定義分頁與停駐面板介面，包含 `ConnectionTab`、`DockPaneStripNG`、`FloatWindowNG`、`TabHelper` 等類別。
- **GraphicsUtilities/**：圖形相關工具，提供 `IGraphicsProvider` 介面與 `GdiPlusGraphicsProvider` 實作，用於取得解析度與縮放資訊。
- **Panels/**：面板相關工具，目前包含 `PanelAdder`，協助動態加入面板。

## 檔案

- `FontOverrider.cs`：根據作業系統預設字型，覆寫容器內所有控制項的字型。
- `DPI_Per_Monitor.cs`：處理每個螢幕的 DPI 感知，確保介面在高解析度環境下正確縮放。
- `FormExtensions.cs`：表單的延伸方法，例如將表單相對於其他視窗置中。
- `NotificationMessageListViewItem.cs`：將 `IMessage` 轉換為可顯示於 `ListView` 的項目，並設定圖示與文字。
- `ISelectionTarget.cs`：定義選取目標的泛型介面，包含顯示文字、圖示及對應的設定物件。
- `WindowType.cs`：列舉應用程式中各種視窗類型的識別碼。
- `FullscreenHandler.cs`：提供進入與退出全螢幕模式的處理流程。
- `StatusImageList.cs`：根據連線狀態建立影像清單，動態載入並縮放各種連線圖示。
- `DialogFactory.cs`：集中建立常用對話框的方法，例如載入/儲存連線檔案、資料夾選擇等。
- `DisplayProperties.cs`：計算解析度縮放因子並提供影像縮放與尺寸換算的實用函式。
- `WindowList.cs`：管理 `BaseWindow` 物件的集合，提供新增、移除與依名稱查詢等功能。
- `TextBoxExtensions.cs`：為 `TextBox` 控制項新增設定與取得提示文字 (Cue Banner) 的延伸方法。

