namespace CuaHangTraSuaHKT
{
    partial class uscBan
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
            this.lblTenBan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTenBan
            // 
            this.lblTenBan.AutoSize = true;
            this.lblTenBan.Location = new System.Drawing.Point(32, 63);
            this.lblTenBan.Name = "lblTenBan";
            this.lblTenBan.Size = new System.Drawing.Size(67, 20);
            this.lblTenBan.TabIndex = 0;
            this.lblTenBan.Text = "Tên bàn";
            this.lblTenBan.Click += new System.EventHandler(this.lblTenBan_Click);
            // 
            // uscBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTenBan);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "uscBan";
            this.Size = new System.Drawing.Size(135, 98);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.MouseEnter += new System.EventHandler(this.uscBan_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.uscBan_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenBan;
    }
}
