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
using System.Data.SqlClient;
using StoreApp.models;

namespace StoreApp
{
    public partial class FrmStok : Form
    {
        string id;
        public FrmStok()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Stok_Load(object sender, EventArgs e)
        {
            Listele();
          

           // connection.Open();
            //label1.Text = connection.State.ToString();
            // Veri tabanına baglandı
            // kodlarrr......


            //connection.Close();

        }


        private void dataStok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id= dataStok.CurrentRow.Cells[0].Value.ToString();
            txtUrunAdi.Text = dataStok.CurrentRow.Cells[1].Value.ToString();
            txtKategori.SelectedItem = dataStok.CurrentRow.Cells[2].Value.ToString();
            txtAdet.Text = dataStok.CurrentRow.Cells[3].Value.ToString();
            txtFiyat.Text = dataStok.CurrentRow.Cells[4].Value.ToString();
        }

        void Listele()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM StokTB", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataStok.DataSource = table;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click_1(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From StokTB where UrunAdi=@UrunAdi", connection);
            cmd.Parameters.AddWithValue("UrunAdi", txtUrunAdi.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataStok.DataSource = dt;
        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into StokTB values(@UrunAdi, @Kategori, @Adet, @Fiyat)", connection);
            cmd.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text);
            cmd.Parameters.AddWithValue("@Kategori", txtKategori.SelectedItem);
            cmd.Parameters.AddWithValue("@Adet", int.Parse(txtAdet.Text));
            cmd.Parameters.AddWithValue("@Fiyat", int.Parse(txtFiyat.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Eklendi!");




            Urun urun = new Urun();
            urun.UrunAdi = "deneme";
            urun.UrunAdet = 12;
            


        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete StokTB where UrunId=@UrunId", connection);
            cmd.Parameters.AddWithValue("@UrunId", int.Parse(id)); // ürün id dışarıdan gelecek deneme amaçlı 4 verdim
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Silindi!");
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update StokTB set UrunAdi=@UrunAdi, Kategori=@Kategori, Adet=@Adet, Fiyat=@Fiyat Where UrunId=@UrunId", connection);
            cmd.Parameters.AddWithValue("@UrunId", int.Parse(id)); // id yi dışarıdan almak lazım
            cmd.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text);
            cmd.Parameters.AddWithValue("@Kategori", txtKategori.SelectedItem);
            cmd.Parameters.AddWithValue("@Adet", int.Parse(txtAdet.Text));
            cmd.Parameters.AddWithValue("@Fiyat", int.Parse(txtFiyat.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Güncellendi!");
        }
    }
}
