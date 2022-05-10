
namespace StoreApp
{
    partial class FrmBilgiSistemi
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sayfa1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsStokSiparis = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOKBİLGİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsSatis = new System.Windows.Forms.ToolStripMenuItem();
            this.sayfa2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsTedarikci = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsMagazaGider = new System.Windows.Forms.ToolStripMenuItem();
            this.tlRaporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sayfa1ToolStripMenuItem,
            this.TsSatis,
            this.sayfa2ToolStripMenuItem,
            this.tlsTedarikci,
            this.tlsMagazaGider,
            this.tlRaporlar,
            this.xToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(976, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sayfa1ToolStripMenuItem
            // 
            this.sayfa1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsStokSiparis,
            this.sTOKBİLGİToolStripMenuItem});
            this.sayfa1ToolStripMenuItem.Name = "sayfa1ToolStripMenuItem";
            this.sayfa1ToolStripMenuItem.Size = new System.Drawing.Size(78, 27);
            this.sayfa1ToolStripMenuItem.Text = "STOK";
            this.sayfa1ToolStripMenuItem.Click += new System.EventHandler(this.sayfa1ToolStripMenuItem_Click);
            // 
            // tlsStokSiparis
            // 
            this.tlsStokSiparis.Name = "tlsStokSiparis";
            this.tlsStokSiparis.Size = new System.Drawing.Size(231, 28);
            this.tlsStokSiparis.Text = "STOK SİPARİŞ";
            this.tlsStokSiparis.Click += new System.EventHandler(this.tlsStokSiparis_Click);
            // 
            // sTOKBİLGİToolStripMenuItem
            // 
            this.sTOKBİLGİToolStripMenuItem.Name = "sTOKBİLGİToolStripMenuItem";
            this.sTOKBİLGİToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.sTOKBİLGİToolStripMenuItem.Text = "STOK BİLGİ";
            this.sTOKBİLGİToolStripMenuItem.Click += new System.EventHandler(this.sTOKBİLGİToolStripMenuItem_Click);
            // 
            // TsSatis
            // 
            this.TsSatis.Name = "TsSatis";
            this.TsSatis.Size = new System.Drawing.Size(80, 27);
            this.TsSatis.Text = "SATIŞ";
            this.TsSatis.Click += new System.EventHandler(this.TsSatis_Click);
            // 
            // sayfa2ToolStripMenuItem
            // 
            this.sayfa2ToolStripMenuItem.Name = "sayfa2ToolStripMenuItem";
            this.sayfa2ToolStripMenuItem.Size = new System.Drawing.Size(151, 27);
            this.sayfa2ToolStripMenuItem.Text = "MÜŞTERİLER";
            this.sayfa2ToolStripMenuItem.Click += new System.EventHandler(this.sayfa2ToolStripMenuItem_Click);
            // 
            // tlsTedarikci
            // 
            this.tlsTedarikci.Name = "tlsTedarikci";
            this.tlsTedarikci.Size = new System.Drawing.Size(129, 27);
            this.tlsTedarikci.Text = "TEDARİKÇİ";
            this.tlsTedarikci.Click += new System.EventHandler(this.tlsTedarikci_Click);
            // 
            // tlsMagazaGider
            // 
            this.tlsMagazaGider.Name = "tlsMagazaGider";
            this.tlsMagazaGider.Size = new System.Drawing.Size(220, 27);
            this.tlsMagazaGider.Text = "MAGAZA GİDERLERİ";
            this.tlsMagazaGider.Click += new System.EventHandler(this.tlsMagazaGider_Click);
            // 
            // tlRaporlar
            // 
            this.tlRaporlar.Name = "tlRaporlar";
            this.tlRaporlar.Size = new System.Drawing.Size(132, 27);
            this.tlRaporlar.Text = "RAPORLAR";
            this.tlRaporlar.Click += new System.EventHandler(this.tlRaporlar_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(43, 33);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // FrmBilgiSistemi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(976, 640);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBilgiSistemi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Bilgi Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBilgiSistemi_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sayfa1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sayfa2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tlsTedarikci;
        private System.Windows.Forms.ToolStripMenuItem tlsMagazaGider;
        private System.Windows.Forms.ToolStripMenuItem tlRaporlar;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TsSatis;
        private System.Windows.Forms.ToolStripMenuItem tlsStokSiparis;
        private System.Windows.Forms.ToolStripMenuItem sTOKBİLGİToolStripMenuItem;
    }
}

