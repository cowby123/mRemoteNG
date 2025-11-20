namespace mRemoteNG.UI.Forms.OptionsPages
{
    sealed partial class HttpServerPage : OptionsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkHttpServerEnabled = new System.Windows.Forms.CheckBox();
            this.lblHttpServerEnabled = new System.Windows.Forms.Label();
            this.lblHttpServerPort = new System.Windows.Forms.Label();
            this.numHttpServerPort = new System.Windows.Forms.NumericUpDown();
            this.lblHttpServerBindAddress = new System.Windows.Forms.Label();
            this.txtHttpServerBindAddress = new System.Windows.Forms.TextBox();
            this.lblHttpServerUsername = new System.Windows.Forms.Label();
            this.txtHttpServerUsername = new System.Windows.Forms.TextBox();
            this.lblHttpServerPassword = new System.Windows.Forms.Label();
            this.txtHttpServerPassword = new System.Windows.Forms.TextBox();
            this.btnHttpServerLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHttpServerPort)).BeginInit();
            this.SuspendLayout();
            //
            // chkHttpServerEnabled
            //
            this.chkHttpServerEnabled.AutoSize = true;
            this.chkHttpServerEnabled.Location = new System.Drawing.Point(3, 3);
            this.chkHttpServerEnabled.Name = "chkHttpServerEnabled";
            this.chkHttpServerEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkHttpServerEnabled.TabIndex = 0;
            this.chkHttpServerEnabled.UseVisualStyleBackColor = true;
            //
            // lblHttpServerEnabled
            //
            this.lblHttpServerEnabled.AutoSize = true;
            this.lblHttpServerEnabled.Location = new System.Drawing.Point(24, 3);
            this.lblHttpServerEnabled.Name = "lblHttpServerEnabled";
            this.lblHttpServerEnabled.Size = new System.Drawing.Size(107, 13);
            this.lblHttpServerEnabled.TabIndex = 1;
            this.lblHttpServerEnabled.Text = "啟用 HTTP 伺服器";
            //
            // lblHttpServerPort
            //
            this.lblHttpServerPort.AutoSize = true;
            this.lblHttpServerPort.Location = new System.Drawing.Point(3, 30);
            this.lblHttpServerPort.Name = "lblHttpServerPort";
            this.lblHttpServerPort.Size = new System.Drawing.Size(67, 13);
            this.lblHttpServerPort.TabIndex = 2;
            this.lblHttpServerPort.Text = "伺服器連接埠";
            //
            // numHttpServerPort
            //
            this.numHttpServerPort.Location = new System.Drawing.Point(27, 46);
            this.numHttpServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numHttpServerPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHttpServerPort.Name = "numHttpServerPort";
            this.numHttpServerPort.Size = new System.Drawing.Size(120, 20);
            this.numHttpServerPort.TabIndex = 3;
            this.numHttpServerPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            //
            // lblHttpServerBindAddress
            //
            this.lblHttpServerBindAddress.AutoSize = true;
            this.lblHttpServerBindAddress.Location = new System.Drawing.Point(3, 75);
            this.lblHttpServerBindAddress.Name = "lblHttpServerBindAddress";
            this.lblHttpServerBindAddress.Size = new System.Drawing.Size(55, 13);
            this.lblHttpServerBindAddress.TabIndex = 4;
            this.lblHttpServerBindAddress.Text = "綁定位址";
            //
            // txtHttpServerBindAddress
            //
            this.txtHttpServerBindAddress.Location = new System.Drawing.Point(27, 91);
            this.txtHttpServerBindAddress.Name = "txtHttpServerBindAddress";
            this.txtHttpServerBindAddress.Size = new System.Drawing.Size(200, 20);
            this.txtHttpServerBindAddress.TabIndex = 5;
            this.txtHttpServerBindAddress.Text = "127.0.0.1";
            //
            // lblHttpServerUsername
            //
            this.lblHttpServerUsername.AutoSize = true;
            this.lblHttpServerUsername.Location = new System.Drawing.Point(3, 120);
            this.lblHttpServerUsername.Name = "lblHttpServerUsername";
            this.lblHttpServerUsername.Size = new System.Drawing.Size(29, 13);
            this.lblHttpServerUsername.TabIndex = 6;
            this.lblHttpServerUsername.Text = "帳號";
            //
            // txtHttpServerUsername
            //
            this.txtHttpServerUsername.Location = new System.Drawing.Point(27, 136);
            this.txtHttpServerUsername.Name = "txtHttpServerUsername";
            this.txtHttpServerUsername.Size = new System.Drawing.Size(200, 20);
            this.txtHttpServerUsername.TabIndex = 7;
            //
            // lblHttpServerPassword
            //
            this.lblHttpServerPassword.AutoSize = true;
            this.lblHttpServerPassword.Location = new System.Drawing.Point(3, 165);
            this.lblHttpServerPassword.Name = "lblHttpServerPassword";
            this.lblHttpServerPassword.Size = new System.Drawing.Size(29, 13);
            this.lblHttpServerPassword.TabIndex = 8;
            this.lblHttpServerPassword.Text = "密碼";
            //
            // txtHttpServerPassword
            //
            this.txtHttpServerPassword.Location = new System.Drawing.Point(27, 181);
            this.txtHttpServerPassword.Name = "txtHttpServerPassword";
            this.txtHttpServerPassword.PasswordChar = '*';
            this.txtHttpServerPassword.Size = new System.Drawing.Size(200, 20);
            this.txtHttpServerPassword.TabIndex = 9;
            //
            // btnHttpServerLogin
            //
            this.btnHttpServerLogin.Location = new System.Drawing.Point(27, 210);
            this.btnHttpServerLogin.Name = "btnHttpServerLogin";
            this.btnHttpServerLogin.Size = new System.Drawing.Size(100, 25);
            this.btnHttpServerLogin.TabIndex = 10;
            this.btnHttpServerLogin.Text = "登入";
            this.btnHttpServerLogin.UseVisualStyleBackColor = true;
            //
            // HttpServerPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnHttpServerLogin);
            this.Controls.Add(this.txtHttpServerPassword);
            this.Controls.Add(this.lblHttpServerPassword);
            this.Controls.Add(this.txtHttpServerUsername);
            this.Controls.Add(this.lblHttpServerUsername);
            this.Controls.Add(this.txtHttpServerBindAddress);
            this.Controls.Add(this.lblHttpServerBindAddress);
            this.Controls.Add(this.numHttpServerPort);
            this.Controls.Add(this.lblHttpServerPort);
            this.Controls.Add(this.lblHttpServerEnabled);
            this.Controls.Add(this.chkHttpServerEnabled);
            this.Name = "HttpServerPage";
            this.Size = new System.Drawing.Size(610, 489);
            ((System.ComponentModel.ISupportInitialize)(this.numHttpServerPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHttpServerEnabled;
        private System.Windows.Forms.Label lblHttpServerEnabled;
        private System.Windows.Forms.Label lblHttpServerPort;
        private System.Windows.Forms.NumericUpDown numHttpServerPort;
        private System.Windows.Forms.Label lblHttpServerBindAddress;
        private System.Windows.Forms.TextBox txtHttpServerBindAddress;
        private System.Windows.Forms.Label lblHttpServerUsername;
        private System.Windows.Forms.TextBox txtHttpServerUsername;
        private System.Windows.Forms.Label lblHttpServerPassword;
        private System.Windows.Forms.TextBox txtHttpServerPassword;
        private System.Windows.Forms.Button btnHttpServerLogin;
    }
}
