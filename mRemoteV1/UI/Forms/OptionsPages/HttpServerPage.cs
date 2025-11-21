using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using mRemoteNG.App;
using System.Net;
using System.Text;
using System.IO;

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

            // 註冊登入按鈕事件
            btnHttpServerLogin.Click += BtnHttpServerLogin_Click;
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
            Bitmap originalBitmap = originalIcon.ToBitmap();
            Bitmap resizedBitmap = new Bitmap(originalBitmap, new Size(width, height));
            IntPtr hIcon = resizedBitmap.GetHicon();
            Icon newIcon = (Icon)Icon.FromHandle(hIcon).Clone();

            // 清理資源
            DestroyIcon(hIcon);
            originalBitmap.Dispose();
            resizedBitmap.Dispose();

            return newIcon;
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
            lblHttpServerUsername.Text = "帳號";
            lblHttpServerPassword.Text = "密碼";
            btnHttpServerLogin.Text = "登入";
        }

        public override void LoadSettings()
        {
            base.LoadSettings();

            // 從獨立設定檔載入
            var config = Config.HttpServerConfigManager.Instance.Config;
            chkHttpServerEnabled.Checked = config.Enabled;
            numHttpServerPort.Value = config.Port;
            txtHttpServerBindAddress.Text = config.BindAddress;
            txtHttpServerUsername.Text = config.Username;
            txtHttpServerPassword.Text = config.Password;
        }

        public override void SaveSettings()
        {
            // 儲存到獨立設定檔
            var config = Config.HttpServerConfigManager.Instance.Config;
            config.Enabled = chkHttpServerEnabled.Checked;
            config.Port = (int)numHttpServerPort.Value;
            config.BindAddress = txtHttpServerBindAddress.Text;
            config.Username = txtHttpServerUsername.Text;
            config.Password = txtHttpServerPassword.Text;
            Config.HttpServerConfigManager.Instance.SaveConfig();
        }

        #endregion

        #region Private Methods

        private void BtnHttpServerLogin_Click(object sender, EventArgs e)
        {
            // 取得輸入的伺服器資訊
            string bindAddress = txtHttpServerBindAddress.Text.Trim();
            int port = (int)numHttpServerPort.Value;
            string username = txtHttpServerUsername.Text.Trim();
            string password = txtHttpServerPassword.Text;

            // 驗證輸入
            if (string.IsNullOrEmpty(bindAddress))
            {
                MessageBox.Show("請輸入綁定位址", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("請輸入帳號和密碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 建立 API URL
            string apiUrl = $"http://{bindAddress}:{port}/api/login";

            try
            {
                // 準備 POST 資料
                var postData = $"{{\"username\":\"{username}\",\"password\":\"{password}\"}}";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // 建立 HTTP 請求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                // 寫入 POST 資料
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                // 取得回應
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string responseText = reader.ReadToEnd();

                    // 簡單的 JSON 解析（取得 status 和 token）
                    if (responseText.Contains("\"status\":\"success\""))
                    {
                        // 提取 token
                        string token = ExtractJsonValue(responseText, "token");

                        if (!string.IsNullOrEmpty(token))
                        {
                            // 儲存 token
                            var config = Config.HttpServerConfigManager.Instance.Config;
                            config.Token = token;
                            Config.HttpServerConfigManager.Instance.SaveConfig();

                            MessageBox.Show("登入成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("登入成功，但無法取得 Token", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // 提取錯誤訊息
                        string message = ExtractJsonValue(responseText, "message");
                        if (string.IsNullOrEmpty(message))
                        {
                            message = "登入失敗";
                        }
                        MessageBox.Show(message, "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (Stream responseStream = ex.Response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string errorResponse = reader.ReadToEnd();
                        string message = ExtractJsonValue(errorResponse, "message");
                        if (string.IsNullOrEmpty(message))
                        {
                            message = "用戶名或密碼錯誤";
                        }
                        MessageBox.Show(message, "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"無法連線到伺服器：{ex.Message}", "連線錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 從 JSON 字串中提取指定欄位的值（簡易版 JSON 解析）
        /// </summary>
        private string ExtractJsonValue(string json, string key)
        {
            try
            {
                string searchPattern = $"\"{key}\":\"";
                int startIndex = json.IndexOf(searchPattern);
                if (startIndex == -1)
                {
                    return null;
                }

                startIndex += searchPattern.Length;
                int endIndex = json.IndexOf("\"", startIndex);
                if (endIndex == -1)
                {
                    return null;
                }

                return json.Substring(startIndex, endIndex - startIndex);
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
