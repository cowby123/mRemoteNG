using System;
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
            UpdateFieldsVisibility();
        }

        public override string PageName
        {
            get => "API Server";
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();
            chkEnableApiServer.Text = "Enable API server";
            lblUrl.Text = "URL:";
            lblUsername.Text = "Username:";
            lblPassword.Text = "Password:";
        }

        public override void LoadSettings()
        {
            // TODO: load API server settings
            UpdateFieldsVisibility();
        }

        public override void SaveSettings()
        {
            // TODO: save API server settings
        }

        private void ChkEnableApiServer_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFieldsVisibility();
        }

        private void UpdateFieldsVisibility()
        {
            tblSettings.Visible = chkEnableApiServer.Checked;
        }
    }
}
