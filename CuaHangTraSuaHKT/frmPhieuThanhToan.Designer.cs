namespace CuaHangTraSuaHKT
{
    partial class frmPhieuThanhToan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rpvThanhToan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvThanhToan
            // 
            this.rpvThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvThanhToan.Location = new System.Drawing.Point(0, 0);
            this.rpvThanhToan.Name = "rpvThanhToan";
            this.rpvThanhToan.ServerReport.BearerToken = null;
            this.rpvThanhToan.Size = new System.Drawing.Size(1029, 805);
            this.rpvThanhToan.TabIndex = 0;
            // 
            // frmPhieuThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 805);
            this.Controls.Add(this.rpvThanhToan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPhieuThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phiếu thanh toán";
            this.Load += new System.EventHandler(this.frmTToan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvThanhToan;
    }
}