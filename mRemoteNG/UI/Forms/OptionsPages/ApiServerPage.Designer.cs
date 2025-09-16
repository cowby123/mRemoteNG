using mRemoteNG.UI.Controls;

namespace mRemoteNG.UI.Forms.OptionsPages
{
    public sealed partial class ApiServerPage : OptionsPage
    {
        private System.ComponentModel.IContainer components = null;
        private MrngCheckBox chkEnableApiServer;
        private System.Windows.Forms.TableLayoutPanel tblSettings;
        private MrngLabel lblUrl;
        private MrngTextBox txtUrl;
        private MrngLabel lblUsername;
        private MrngTextBox txtUsername;
        private MrngLabel lblPassword;
        private MrngTextBox txtPassword;

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void InitializeComponent()
        {
            chkEnableApiServer = new MrngCheckBox();
            tblSettings = new System.Windows.Forms.TableLayoutPanel();
            lblUrl = new MrngLabel();
            txtUrl = new MrngTextBox();
            lblUsername = new MrngLabel();
            txtUsername = new MrngTextBox();
            lblPassword = new MrngLabel();
            txtPassword = new MrngTextBox();
            tblSettings.SuspendLayout();
            SuspendLayout();
            //
            // chkEnableApiServer
            //
            chkEnableApiServer.AutoSize = true;
            chkEnableApiServer.Dock = System.Windows.Forms.DockStyle.Top;
            chkEnableApiServer.Name = "chkEnableApiServer";
            chkEnableApiServer.Text = "Enable API server";
            chkEnableApiServer.CheckedChanged += ChkEnableApiServer_CheckedChanged;
            //
            // tblSettings
            //
            tblSettings.AutoSize = true;
            tblSettings.ColumnCount = 2;
            tblSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tblSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblSettings.Controls.Add(lblUrl, 0, 0);
            tblSettings.Controls.Add(txtUrl, 1, 0);
            tblSettings.Controls.Add(lblUsername, 0, 1);
            tblSettings.Controls.Add(txtUsername, 1, 1);
            tblSettings.Controls.Add(lblPassword, 0, 2);
            tblSettings.Controls.Add(txtPassword, 1, 2);
            tblSettings.Dock = System.Windows.Forms.DockStyle.Top;
            tblSettings.Location = new System.Drawing.Point(0, 25);
            tblSettings.Name = "tblSettings";
            tblSettings.Padding = new System.Windows.Forms.Padding(4);
            tblSettings.RowCount = 3;
            tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tblSettings.Visible = false;
            //
            // lblUrl
            //
            lblUrl.AutoSize = true;
            lblUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            lblUrl.Location = new System.Drawing.Point(8, 4);
            lblUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new System.Drawing.Size(38, 23);
            lblUrl.TabIndex = 0;
            lblUrl.Text = "URL:";
            lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtUrl
            //
            txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            txtUrl.Location = new System.Drawing.Point(54, 4);
            txtUrl.Margin = new System.Windows.Forms.Padding(4);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new System.Drawing.Size(344, 22);
            txtUrl.TabIndex = 1;
            //
            // lblUsername
            //
            lblUsername.AutoSize = true;
            lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            lblUsername.Location = new System.Drawing.Point(8, 27);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(74, 23);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtUsername
            //
            txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            txtUsername.Location = new System.Drawing.Point(90, 27);
            txtUsername.Margin = new System.Windows.Forms.Padding(4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(308, 22);
            txtUsername.TabIndex = 3;
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            lblPassword.Location = new System.Drawing.Point(8, 50);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(70, 23);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtPassword
            //
            txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            txtPassword.Location = new System.Drawing.Point(90, 50);
            txtPassword.Margin = new System.Windows.Forms.Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(308, 22);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            //
            // ApiServerPage
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tblSettings);
            Controls.Add(chkEnableApiServer);
            Name = "ApiServerPage";
            tblSettings.ResumeLayout(false);
            tblSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
