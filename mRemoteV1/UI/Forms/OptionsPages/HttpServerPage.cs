using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using mRemoteNG.App;

namespace mRemoteNG.UI.Forms.OptionsPages
{
    public sealed partial class HttpServerPage : OptionsPage
    {
        public HttpServerPage()
        {
            InitializeComponent();
            ApplyTheme();
            // 設定網路/伺服器圖示 - 使用 shell32.dll 的網路圖示
            try
            {
                // 從 shell32.dll 提取網路圖示（索引 13 是網路連線圖示）
                Icon originalIcon = ExtractIconFromDll("shell32.dll", 13);
                // 縮小圖示為原始尺寸的 1/4
                PageIcon = ResizeIcon(originalIcon, originalIcon.Width / 2, originalIcon.Height / 2);
            }
            catch
            {
                // 如果提取失敗，使用系統預設圖示
                PageIcon = SystemIcons.Information;
            }
        }

        private static Icon ExtractIconFromDll(string dllName, int iconIndex)
        {
            IntPtr hIcon = ExtractIcon(IntPtr.Zero, dllName, iconIndex);
            if (hIcon != IntPtr.Zero)
            {
                Icon icon = (Icon)Icon.FromHandle(hIcon).Clone();
                DestroyIcon(hIcon);
                return icon;
            }
            return SystemIcons.Application;
        }

        private static Icon ResizeIcon(Icon originalIcon, int width, int height)
        {
            // 將圖示轉換為 Bitmap，調整大小，然後轉回 Icon
            using (Bitmap bitmap = originalIcon.ToBitmap())
            {
                Bitmap resizedBitmap = new Bitmap(bitmap, new Size(width, height));
                return Icon.FromHandle(resizedBitmap.GetHicon());
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        #region Public Methods

        public override string PageName
        {
            get => "HTTP 伺服器";
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();

            lblHttpServerEnabled.Text = "啟用 HTTP 伺服器";
            lblHttpServerPort.Text = "伺服器連接埠";
            lblHttpServerBindAddress.Text = "綁定位址";
        }

        public override void LoadSettings()
        {
            base.LoadSettings();

            chkHttpServerEnabled.Checked = Settings.Default.HttpServerEnabled;
            numHttpServerPort.Value = Settings.Default.HttpServerPort;
            txtHttpServerBindAddress.Text = Settings.Default.HttpServerBindAddress;
        }

        public override void SaveSettings()
        {
            Settings.Default.HttpServerEnabled = chkHttpServerEnabled.Checked;
            Settings.Default.HttpServerPort = (int)numHttpServerPort.Value;
            Settings.Default.HttpServerBindAddress = txtHttpServerBindAddress.Text;
        }

        #endregion
    }
}
