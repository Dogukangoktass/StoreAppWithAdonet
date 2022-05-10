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
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreApp
{
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }
        string id;
        private void btnEkle_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into Gider_TB values(@GiderAdi, @GiderTutar, @GiderTarih)", connection);
            cmd.Parameters.AddWithValue("@GiderAdi", txtGiderAdi.Text);
            cmd.Parameters.AddWithValue("@GiderTutar", txtTutar.Text);
            cmd.Parameters.AddWithValue("@GiderTarih", dtTarih.Value);
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Eklendi!");
            Temizle();
        }
        void Listele()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Gider_TB", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGider.DataSource = table;
        }
        void Temizle()
        {
            txtGiderAdi.Text = "";
            txtTutar.Text = "";
            dtTarih.Value = DateTime.Now;
        }

        private void dataGider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGider.CurrentRow.Cells[0].Value.ToString();
            txtGiderAdi.Text = dataGider.CurrentRow.Cells[1].Value.ToString();
            txtTutar.Text = dataGider.CurrentRow.Cells[2].Value.ToString();
            dtTarih.Text = dataGider.CurrentRow.Cells[3].Value.ToString();
        }

        private void FrmGider_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete Gider_TB where GiderId=@GiderId", connection);
            cmd.Parameters.AddWithValue("@GiderId", int.Parse(id));
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Silindi!");
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update Gider_TB set GiderAdi=@GiderAdi, GiderTutar=@GiderTutar, GiderTarih=@GiderTarih  Where GiderId=@GiderId", connection);
            cmd.Parameters.AddWithValue("@GiderId", int.Parse(id));
            cmd.Parameters.AddWithValue("@GiderAdi",txtGiderAdi.Text);
            cmd.Parameters.AddWithValue("@GiderTutar", float.Parse(txtTutar.Text));
            cmd.Parameters.AddWithValue("@GiderTarih", dtTarih.Value);
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Güncellendi!");
            Temizle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From Gider_TB where GiderAdi=@GiderAdi", connection);
            cmd.Parameters.AddWithValue("GiderAdi", txtGiderAdi.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGider.DataSource = dt;
        }

        private void pdYazici_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtGiderAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
