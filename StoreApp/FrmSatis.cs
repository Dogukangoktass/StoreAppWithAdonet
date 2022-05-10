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
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }
        string id;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into Satis_TB values(@SatisFiyat, @SatisUrun, @SatisMüsteri, @SatisUrunAdet, @SatisTarih)", connection);

            int adet = int.Parse(txtAdet.Text);
            float fiyat = float.Parse(txtFiyat.Text);
            float toplam = adet * fiyat;

            cmd.Parameters.AddWithValue("@SatisFiyat", toplam);
            cmd.Parameters.AddWithValue("@SatisUrun", cmbxUrünler.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@SatisMüsteri", cmbxMüsteri.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@SatisUrunAdet", int.Parse(txtAdet.Text));
            cmd.Parameters.AddWithValue("@SatisTarih", DateTime.Now);
            cmd.ExecuteNonQuery();
            connection.Close();

            Listele();
            MessageBox.Show("Eklendi!");
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            txtFiyat.Enabled = false;
            MüsteriListele();
            UrünListele();
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete Satis_TB where SatisId=@SatisId", connection);
            cmd.Parameters.AddWithValue("@SatisId", int.Parse(id)); 
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Silindi!");

        }

        private void cmbxMüsteri_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Fiyat from StokTB where UrunAdi=@UrunAdi", connection);
         
            cmd.Parameters.AddWithValue("@UrunAdi", cmbxUrünler.SelectedItem.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtFiyat.Text = dr["Fiyat"].ToString();
                
            }
            connection.Close();
            dr.Close();
        }

        #region Listele
        void MüsteriListele()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;";
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "SELECT *FROM MüsteriTB";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbxMüsteri.Items.Add(dr["MüsteriAd"]);
            }
            baglanti.Close();
        }
        void UrünListele()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;";
            SqlCommand komut = new SqlCommand();


            komut.CommandText = "SELECT *FROM StokTB";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbxUrünler.Items.Add(dr["UrunAdi"]);
            }
            baglanti.Close();
        }
        void Listele()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Satis_TB", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataSatis.DataSource = table;
        }


        #endregion

        private void dataSatis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                id = dataSatis.CurrentRow.Cells[0].Value.ToString();
                txtFiyat.Text = dataSatis.CurrentRow.Cells[1].Value.ToString();
                cmbxUrünler.SelectedItem = dataSatis.CurrentRow.Cells[2].Value.ToString();
                cmbxMüsteri.SelectedItem = dataSatis.CurrentRow.Cells[3].Value.ToString();
                txtAdet.Text = dataSatis.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update Satis_TB set SatisFiyat=@SatisFiyat, SatisUrun=@SatisUrun, SatisMüsteri=@SatisMüsteri, SatisUrunAdet=@SatisUrunAdet Where SatisId=@SatisId", connection);
            cmd.Parameters.AddWithValue("@SatisId", int.Parse(id));

            int adet = int.Parse(txtAdet.Text);
            float fiyat = float.Parse(txtFiyat.Text);
            float guncelToplam = adet * fiyat;
            cmd.Parameters.AddWithValue("@SatisFiyat", guncelToplam); 
            cmd.Parameters.AddWithValue("@SatisUrun", cmbxUrünler.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@SatisMüsteri",cmbxMüsteri.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@SatisUrunAdet", int.Parse(txtAdet.Text));
        
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Güncellendi!");
        }

       

        #region Fatura Yazdır

        private void btnFatura_Click(object sender, EventArgs e)
        {

            
            ppDialog.ShowDialog();
        }

        Font baslik = new Font("Arial", 12, FontStyle.Bold);
        Font govde = new Font("Arial", 12);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void pdYazici_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int adet = int.Parse(txtAdet.Text);
            float fiyat = float.Parse(txtFiyat.Text);
            float guncelToplam = adet * fiyat;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Göktaş Giyim" + " Satış Fatura Özeti", baslik, sb, 200, 100);
            e.Graphics.DrawString("Ürün Adı           Adet           ", baslik, sb, 70, 150);
            e.Graphics.DrawString("__________________________________________", baslik, sb, 70, 150);
            e.Graphics.DrawString(cmbxUrünler.SelectedItem.ToString(), govde, sb, 70, 200);
            e.Graphics.DrawString(txtAdet.Text.ToString(), govde, sb, 200, 200);


            e.Graphics.DrawString("-------------------------------------------------------------------------------", baslik, sb, 70, 350);
            e.Graphics.DrawString("Müşteri Adı Soyadı : " + cmbxMüsteri.SelectedItem.ToString(), baslik, sb, 70, 370);
            e.Graphics.DrawString("Toplam Bakiye : " + guncelToplam.ToString() + " Türk Lirası", baslik, sb, 70, 400);


        }

        #endregion

        private void btnAra_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From Satis_TB where SatisUrun=@SatisUrun", connection);
            cmd.Parameters.AddWithValue("SatisUrun", cmbxUrünler.SelectedItem);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataSatis.DataSource = dt;
        }
    }
}
