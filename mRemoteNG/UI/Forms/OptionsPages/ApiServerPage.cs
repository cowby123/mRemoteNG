using System;
using System.Runtime.Versioning;
using mRemoteNG.App;
using mRemoteNG.Properties;
using mRemoteNG.Security.SymmetricEncryption;

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
            chkEnableApiServer.Checked = Properties.OptionsApiServerPage.Default.EnableApiServer;
            txtUrl.Text = Properties.OptionsApiServerPage.Default.ApiServerUrl;
            txtUsername.Text = Properties.OptionsApiServerPage.Default.ApiServerUsername;
            LegacyRijndaelCryptographyProvider cryptographyProvider = new();
            txtPassword.Text = cryptographyProvider.Decrypt(Properties.OptionsApiServerPage.Default.ApiServerPassword, Runtime.EncryptionKey);
            UpdateFieldsVisibility();
        }

        public override void SaveSettings()
        {
            Properties.OptionsApiServerPage.Default.EnableApiServer = chkEnableApiServer.Checked;
            Properties.OptionsApiServerPage.Default.ApiServerUrl = txtUrl.Text;
            Properties.OptionsApiServerPage.Default.ApiServerUsername = txtUsername.Text;
            LegacyRijndaelCryptographyProvider cryptographyProvider = new();
            Properties.OptionsApiServerPage.Default.ApiServerPassword = cryptographyProvider.Encrypt(txtPassword.Text, Runtime.EncryptionKey);
        }

        public override void RevertSettings()
        {
            Properties.OptionsApiServerPage.Default.Reload();
            LoadSettings();
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
