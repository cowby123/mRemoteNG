using System.Runtime.Versioning;
using mRemoteNG.Properties;

namespace mRemoteNG.UI.Forms.OptionsPages
{
    [SupportedOSPlatform("windows")]
    public sealed partial class ApiServerPage
    {
        public ApiServerPage()
        {
            InitializeComponent();
            ApplyTheme();
            PageIcon = Resources.ImageConverter.GetImageAsIcon(Properties.Resources.Settings_16x);
        }

        public override string PageName
        {
            get => "API Server";
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();
            lblInfo.Text = "Configure API server settings.";
        }

        public override void LoadSettings()
        {
            // TODO: load API server settings
        }

        public override void SaveSettings()
        {
            // TODO: save API server settings
        }
    }
}
