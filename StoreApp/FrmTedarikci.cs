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
    public partial class FrmTedarikci : Form
    {
        string id;
        public FrmTedarikci()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into TedarikciTB values(@TedarikciAdi)", connection);
            cmd.Parameters.AddWithValue("@TedarikciAdi", txtTedarikciAdi.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Eklendi!");
            Temizle();
        }

        void Listele()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TedarikciTB", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataTedarikci.DataSource = table;
        }
        void Temizle()
        {
            txtTedarikciAdi.Text = "";
        }

        private void FrmTedarikci_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataTedarikci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataTedarikci.CurrentRow.Cells[0].Value.ToString();
            txtTedarikciAdi.Text = dataTedarikci.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete TedarikciTB where TedarikciId=@TedarikciId", connection);
            cmd.Parameters.AddWithValue("@TedarikciId", int.Parse(id));
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
            SqlCommand cmd = new SqlCommand("Update TedarikciTB set TedarikciAdi=@TedarikciAdi Where TedarikciId=@TedarikciId", connection);
            cmd.Parameters.AddWithValue("@TedarikciId", int.Parse(id));
            cmd.Parameters.AddWithValue("@TedarikciAdi", txtTedarikciAdi.Text);
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
            SqlCommand cmd = new SqlCommand("Select * From TedarikciTB where TedarikciAdi=@TedarikciAdi", connection);
            cmd.Parameters.AddWithValue("TedarikciAdi", txtTedarikciAdi.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataTedarikci.DataSource = dt;
        }

        
    }
}
