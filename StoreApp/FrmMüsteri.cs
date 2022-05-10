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
    public partial class FrmMüsteri : Form
    {
        string id;
        public FrmMüsteri()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into MüsteriTB values(@MüsteriAd, @MüsteriMail, @MüsteriAdres, @MüsteriTelefon)", connection);
            cmd.Parameters.AddWithValue("@MüsteriAd", txtMüsteriAdi.Text);
            cmd.Parameters.AddWithValue("@MüsteriMail", txtMail.Text);
            cmd.Parameters.AddWithValue("@MüsteriAdres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@MüsteriTelefon", txtTelefon.Text);
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Eklendi!");
            Listele();
        }

        private void FrmMüsteri_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM MüsteriTB", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataMüsteri.DataSource = table;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update MüsteriTB set MüsteriAd=@MüsteriAd, MüsteriMail=@MüsteriMail, MüsteriAdres=@MüsteriAdres, MüsteriTelefon=@MüsteriTelefon Where MüsteriId=@MüsteriId", connection);
            cmd.Parameters.AddWithValue("@MüsteriId", int.Parse(id)); 
            cmd.Parameters.AddWithValue("@MüsteriAd", txtMüsteriAdi.Text);
            cmd.Parameters.AddWithValue("@MüsteriMail", txtMail.Text);
            cmd.Parameters.AddWithValue("@MüsteriAdres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@MüsteriTelefon", txtTelefon.Text);
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Güncellendi!");
            Listele();
        }

        private void dataMüsteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataMüsteri.CurrentRow.Cells[0].Value.ToString();
            txtMüsteriAdi.Text = dataMüsteri.CurrentRow.Cells[1].Value.ToString();
            txtMail.Text = dataMüsteri.CurrentRow.Cells[2].Value.ToString();
            txtAdres.Text = dataMüsteri.CurrentRow.Cells[3].Value.ToString();
            txtTelefon.Text = dataMüsteri.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete MüsteriTB where MüsteriId=@MüsteriId", connection);
            cmd.Parameters.AddWithValue("@MüsteriId", int.Parse(id)); 
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Silindi!");
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From MüsteriTB where MüsteriAd=@MüsteriAd", connection);
            cmd.Parameters.AddWithValue("MüsteriAd", txtMüsteriAdi.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataMüsteri.DataSource = dt;
        }
    }
}
