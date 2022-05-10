/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2021-2022 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1.Proje
**				ÖĞRENCİ ADI............: Doğukan GÖKTAŞ
**				ÖĞRENCİ NUMARASI.......: B211210301
**                         DERSİN ALINDIĞI GRUP...: 1B
****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreApp
{
    public partial class FrmBilgiSistemi : Form
    {
        public FrmBilgiSistemi()
        {
            InitializeComponent();
        }

        private void sayfa1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void sayfa2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMüsteri frm = new FrmMüsteri();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmBilgiSistemi_Load(object sender, EventArgs e)
        {

        }

        private void TsSatis_Click(object sender, EventArgs e)
        {
            FrmSatis frm = new FrmSatis();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void tlsMagazaGider_Click(object sender, EventArgs e)
        {
            FrmGider frm = new FrmGider();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void tlRaporlar_Click(object sender, EventArgs e)
        {
            FrmRapor frm = new FrmRapor();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void tlsStokSiparis_Click(object sender, EventArgs e)
        {
            FrmStokSiparis frm = new FrmStokSiparis();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void sTOKBİLGİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStok frm = new FrmStok();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void tlsTedarikci_Click(object sender, EventArgs e)
        {
            FrmTedarikci frm = new FrmTedarikci();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
    }
}
