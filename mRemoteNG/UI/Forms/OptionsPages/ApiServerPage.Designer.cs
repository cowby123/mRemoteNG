using mRemoteNG.UI.Controls;

namespace mRemoteNG.UI.Forms.OptionsPages
{
    public sealed partial class ApiServerPage : OptionsPage
    {
        private System.ComponentModel.IContainer components = null;
        private MrngLabel lblInfo;

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
            lblInfo = new MrngLabel();
            SuspendLayout();
            //
            // lblInfo
            //
            lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            lblInfo.Name = "lblInfo";
            lblInfo.Text = "API server settings will appear here.";
            lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ApiServerPage
            //
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(lblInfo);
            Name = "ApiServerPage";
            ResumeLayout(false);
        }
    }
}
