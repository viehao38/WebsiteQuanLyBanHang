namespace CuaHangTraSuaHKT
{
    partial class uscThongTinMon
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
            this.gunapnlInfoMon = new Guna.UI2.WinForms.Guna2Panel();
            this.gunaptbAnhMonAn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.gunapnlInfoMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaptbAnhMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // gunapnlInfoMon
            // 
            this.gunapnlInfoMon.Controls.Add(this.gunaptbAnhMonAn);
            this.gunapnlInfoMon.Location = new System.Drawing.Point(0, 0);
            this.gunapnlInfoMon.Name = "gunapnlInfoMon";
            this.gunapnlInfoMon.Size = new System.Drawing.Size(139, 126);
            this.gunapnlInfoMon.TabIndex = 1;
            // 
            // gunaptbAnhMonAn
            // 
            this.gunaptbAnhMonAn.ImageRotate = 0F;
            this.gunaptbAnhMonAn.Location = new System.Drawing.Point(16, 16);
            this.gunaptbAnhMonAn.Name = "gunaptbAnhMonAn";
            this.gunaptbAnhMonAn.Size = new System.Drawing.Size(110, 97);
            this.gunaptbAnhMonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaptbAnhMonAn.TabIndex = 0;
            this.gunaptbAnhMonAn.TabStop = false;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Location = new System.Drawing.Point(157, 30);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(71, 20);
            this.lblTenMon.TabIndex = 2;
            this.lblTenMon.Text = "Tên món";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(161, 66);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(64, 20);
            this.lblDonGia.TabIndex = 3;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // uscThongTinMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.gunapnlInfoMon);
            this.Name = "uscThongTinMon";
            this.Size = new System.Drawing.Size(375, 124);
            this.Load += new System.EventHandler(this.uscMon_Load);
            this.MouseEnter += new System.EventHandler(this.uscThongTinMon_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.uscThongTinMon_MouseLeave);
            this.gunapnlInfoMon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaptbAnhMonAn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel gunapnlInfoMon;
        private Guna.UI2.WinForms.Guna2PictureBox gunaptbAnhMonAn;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblDonGia;
    }
}
