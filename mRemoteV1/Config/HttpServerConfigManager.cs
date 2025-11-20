using System;
using System.IO;
using System.Xml.Serialization;
using mRemoteNG.App;
using mRemoteNG.App.Info;
using mRemoteNG.Messages;

namespace mRemoteNG.Config
{
    /// <summary>
    /// HTTP 伺服器設定管理器
    /// </summary>
    public class HttpServerConfigManager
    {
        private static HttpServerConfigManager _instance;
        private static readonly object LockObject = new object();
        private HttpServerConfig _config;
        private readonly string _configFilePath;

        public static HttpServerConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (LockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new HttpServerConfigManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private HttpServerConfigManager()
        {
            // 設定檔案路徑：使用者設定資料夾/httpserver.config
            string settingsPath = GeneralAppInfo.HomePath;
            _configFilePath = Path.Combine(settingsPath, "httpserver.config");
            LoadConfig();
        }

        /// <summary>
        /// 取得目前的設定
        /// </summary>
        public HttpServerConfig Config
        {
            get
            {
                if (_config == null)
                {
                    _config = HttpServerConfig.CreateDefault();
                }
                return _config;
            }
        }

        /// <summary>
        /// 載入設定
        /// </summary>
        public void LoadConfig()
        {
            try
            {
                if (File.Exists(_configFilePath))
                {
                    using (var reader = new StreamReader(_configFilePath))
                    {
                        var serializer = new XmlSerializer(typeof(HttpServerConfig));
                        _config = (HttpServerConfig)serializer.Deserialize(reader);
                    }
                    Runtime.MessageCollector?.AddMessage(MessageClass.DebugMsg, $"HTTP 伺服器設定已載入: {_configFilePath}");
                }
                else
                {
                    _config = HttpServerConfig.CreateDefault();
                    SaveConfig(); // 建立預設設定檔
                    Runtime.MessageCollector?.AddMessage(MessageClass.DebugMsg, $"已建立預設 HTTP 伺服器設定: {_configFilePath}");
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector?.AddExceptionMessage("載入 HTTP 伺服器設定時發生錯誤", ex);
                _config = HttpServerConfig.CreateDefault();
            }
        }

        /// <summary>
        /// 儲存設定
        /// </summary>
        public void SaveConfig()
        {
            try
            {
                // 確保目錄存在
                string directory = Path.GetDirectoryName(_configFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var writer = new StreamWriter(_configFilePath))
                {
                    var serializer = new XmlSerializer(typeof(HttpServerConfig));
                    serializer.Serialize(writer, _config);
                }
                Runtime.MessageCollector?.AddMessage(MessageClass.DebugMsg, $"HTTP 伺服器設定已儲存: {_configFilePath}");
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector?.AddExceptionMessage("儲存 HTTP 伺服器設定時發生錯誤", ex);
            }
        }

        /// <summary>
        /// 取得設定檔案路徑
        /// </summary>
        public string ConfigFilePath => _configFilePath;
    }
}
