namespace Axis_Configurator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstDevices;
        private System.Windows.Forms.Button btnScan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstDevices = new System.Windows.Forms.ListBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lstDevices
            this.lstDevices.FormattingEnabled = true;
            this.lstDevices.Location = new System.Drawing.Point(12, 12);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(360, 200);
            this.lstDevices.TabIndex = 0;

            // btnScan
            this.btnScan.Location = new System.Drawing.Point(12, 225);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(360, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan Network";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.lstDevices);
            this.Controls.Add(this.btnScan);
            this.Name = "MainForm";
            this.Text = "Network Scanner";
            this.ResumeLayout(false);
        }
    }
}
