using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mRemoteNG.Config
{
    /// <summary>
    /// HTTP 伺服器設定
    /// </summary>
    [Serializable]
    public class HttpServerConfig : INotifyPropertyChanged
    {
        private bool _enabled;
        private int _port = 8080;
        private string _bindAddress = "127.0.0.1";
        private string _username = "";
        private string _password = "";

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 是否啟用 HTTP 伺服器
        /// </summary>
        [XmlElement("Enabled")]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged(nameof(Enabled));
                }
            }
        }

        /// <summary>
        /// HTTP 伺服器連接埠
        /// </summary>
        [XmlElement("Port")]
        public int Port
        {
            get => _port;
            set
            {
                if (_port != value)
                {
                    _port = value;
                    OnPropertyChanged(nameof(Port));
                }
            }
        }

        /// <summary>
        /// HTTP 伺服器綁定位址
        /// </summary>
        [XmlElement("BindAddress")]
        public string BindAddress
        {
            get => _bindAddress;
            set
            {
                if (_bindAddress != value)
                {
                    _bindAddress = value;
                    OnPropertyChanged(nameof(BindAddress));
                }
            }
        }

        /// <summary>
        /// HTTP 伺服器認證使用者名稱
        /// </summary>
        [XmlElement("Username")]
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        /// <summary>
        /// HTTP 伺服器認證密碼（加密儲存）
        /// </summary>
        [XmlElement("Password")]
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 建立預設設定
        /// </summary>
        public static HttpServerConfig CreateDefault()
        {
            return new HttpServerConfig
            {
                Enabled = false,
                Port = 8080,
                BindAddress = "127.0.0.1",
                Username = "",
                Password = ""
            };
        }
    }
}
