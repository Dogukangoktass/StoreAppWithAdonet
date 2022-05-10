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
    public partial class FrmStokSiparis : Form
    {
        string id;
        string tarih;
        public FrmStokSiparis()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into StokSiparisTB values(@StokSiparisAdi, @Aciklama, @TedarikciAdi, @ÜrünAdi, @UrunAdet, @SiparisTarihi)", connection);


            cmd.Parameters.AddWithValue("@StokSiparisAdi", txtSiparisAdi.Text);
            cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
            cmd.Parameters.AddWithValue("@TedarikciAdi", cmbxTedarikci.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@ÜrünAdi", cmbxUrünler.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@UrunAdet", int.Parse(txtAdet.Text));
            cmd.Parameters.AddWithValue("@SiparisTarihi", dtTarih.Value);
            cmd.ExecuteNonQuery();
            connection.Close();

            Listele();
            MessageBox.Show("Eklendi!");
            Temizle();
        }

        #region Listele
        void TedarikciListele()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;";
            SqlCommand komut = new SqlCommand();

            komut.CommandText = "SELECT *FROM TedarikciTB";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbxTedarikci.Items.Add(dr["TedarikciAdi"]);
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM StokSiparisTB", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataSiparis.DataSource = table;
        }

        #endregion

        private void FrmStokSiparis_Load(object sender, EventArgs e)
        {
            TedarikciListele();
            UrünListele();
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * From StokSiparisTB where ÜrünAdi=@ÜrünAdi", connection);
            cmd.Parameters.AddWithValue("ÜrünAdi", cmbxUrünler.SelectedItem);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataSiparis.DataSource = dt;
        }

        private void dataSiparis_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            id = dataSiparis.CurrentRow.Cells[0].Value.ToString();
            txtSiparisAdi.Text = dataSiparis.CurrentRow.Cells[1].Value.ToString();
            txtAciklama.Text = dataSiparis.CurrentRow.Cells[2].Value.ToString();
            cmbxTedarikci.SelectedItem = dataSiparis.CurrentRow.Cells[3].Value.ToString();
            cmbxUrünler.SelectedItem = dataSiparis.CurrentRow.Cells[4].Value.ToString();
            txtAdet.Text = dataSiparis.CurrentRow.Cells[5].Value.ToString();
            
            //dtTarih.Value = dataSiparis.CurrentRow.Cells[6].ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Update StokSiparis set StokSiparisAdi=@StokSiparisAdi, Aciklama=@Aciklama, TedarikciAdi=@TedarikciAdi , ÜrünAdi=@ÜrünAdi  Where StokSiparisId=@StokSiparisId", connection);
            cmd.Parameters.AddWithValue("@StokSiparisId", int.Parse(id));
            cmd.Parameters.AddWithValue("@StokSiparisAdi", txtSiparisAdi.Text);
            cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
            cmd.Parameters.AddWithValue("@TedarikciAdi", cmbxTedarikci.SelectedItem);
            cmd.Parameters.AddWithValue("@ÜrünAdi", cmbxUrünler.SelectedItem);
            
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Güncellendi!");
            Temizle();
        }

        private void Temizle()
        {
            txtAciklama.Text = "";
            txtAdet.Text = "";
            txtSiparisAdi.Text = "";
            cmbxTedarikci.SelectedIndex = 0;
            cmbxUrünler.SelectedIndex = 0;
            dtTarih.Value = DateTime.Now;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("Delete StokSiparisTB where StokSiparisId=@StokSiparisId", connection);
            cmd.Parameters.AddWithValue("@StokSiparisId", int.Parse(id));
            cmd.ExecuteNonQuery();
            connection.Close();
            Listele();
            MessageBox.Show("Silindi!");
            Temizle();
        }


        Font baslik = new Font("Arial", 12, FontStyle.Bold);
        Font govde = new Font("Arial", 12);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void btnFatura_Click(object sender, EventArgs e)
        {
            ppDialog.ShowDialog();
        }

        private void pdYazici_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from StokSiparisTB where StokSiparisId=@StokSiparisId", connection);

            cmd.Parameters.AddWithValue("@StokSiparisId", id);
            SqlDataReader dr = cmd.ExecuteReader();
           
            
            if (dr.Read())
            {
                tarih= dr["SiparisTarihi"].ToString();
            
            connection.Close();
            dr.Close();

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Göktaş Giyim" + " Sipariş Fatura Özeti", baslik, sb, 200, 100);
            e.Graphics.DrawString("Fatura Tarihi :  " + DateTime.Now.ToShortDateString(), baslik, sb, 200, 150);
            e.Graphics.DrawString("Ürün Adı            Tedarikçi Adı           Adet             Tarih      ", baslik, sb, 70, 200);
            e.Graphics.DrawString("_________________________________________________________________________", baslik, sb, 70, 200);
            e.Graphics.DrawString(cmbxUrünler.SelectedItem.ToString(), govde, sb, 70, 250); 
            e.Graphics.DrawString(cmbxTedarikci.SelectedItem.ToString(), govde, sb, 200, 250);
            e.Graphics.DrawString(txtAdet.Text.ToString(), govde, sb, 360, 250);
            e.Graphics.DrawString(tarih, govde, sb, 450, 250);
            }

        }
    }
}
