namespace CuaHangTraSuaHKT
{
    partial class frmXemThongKeBaoCao
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
            this.rpvThongKeBaoCao = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvThongKeBaoCao
            // 
            this.rpvThongKeBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvThongKeBaoCao.Location = new System.Drawing.Point(0, 0);
            this.rpvThongKeBaoCao.Name = "rpvThongKeBaoCao";
            this.rpvThongKeBaoCao.ServerReport.BearerToken = null;
            this.rpvThongKeBaoCao.Size = new System.Drawing.Size(1262, 671);
            this.rpvThongKeBaoCao.TabIndex = 0;
            // 
            // frmXemThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 671);
            this.Controls.Add(this.rpvThongKeBaoCao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.Name = "frmXemThongKeBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xem thông kê";
            this.Load += new System.EventHandler(this.frmXemThongKeBaoCao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvThongKeBaoCao;
    }
}