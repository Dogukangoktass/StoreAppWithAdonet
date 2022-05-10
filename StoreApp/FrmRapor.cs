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
    public partial class FrmRapor : Form
    {
        public FrmRapor()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=DESKTOP-QL66EDG\\SQLEXPRESS; Database=MagazaDB; Trusted_Connection=True;");

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            cmbxSecim.SelectedIndex = 0;
            double gelir, gider, sonuc, amount;



            connection.Open();
            SqlCommand cmd = new SqlCommand("select sum(SatisFiyat) from Satis_TB where SatisTarih=@SatisTarih", connection);
            cmd.Parameters.AddWithValue("SatisTarih", DateTime.Now.ToString("yyyy-MM-dd"));
                amount = (double)cmd.ExecuteScalar();
                gelir = amount;
                lblgelir.Text = gelir.ToString();
           
             connection.Close();

            connection.Open();
            SqlCommand cmd2 = new SqlCommand("select sum(GiderTutar) from Gider_TB where GiderTarih=@GiderTarih", connection);
            cmd2.Parameters.AddWithValue("GiderTarih", DateTime.Now.ToString("yyyy-MM-dd"));
            double amount2 = (double)cmd2.ExecuteScalar();
            gider = amount2;
            lblgider.Text = gider.ToString();
            connection.Close();


            sonuc = gelir - gider;
            if (sonuc>0)
            {
                lblsonuc.Text = sonuc + " ₺ Kardasın ";
                lblsonuc.ForeColor = Color.Green;

            }
            else
            {
                lblsonuc.Text = sonuc + " ₺ Zarardasın ";
                lblsonuc.ForeColor = Color.Red;

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string secilen = cmbxSecim.SelectedItem.ToString();

        
           


            switch (secilen)
            {
                case "Günlük Satılan Ürün":
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Satis_TB where SatisTarih=@SatisTarih", connection);
                    cmd.Parameters.AddWithValue("SatisTarih", DateTime.Now.ToString("yyyy-MM-dd"));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGrid.DataSource = dt;
                    connection.Close();

                    break;

                case "Günlük Sipariş Edilen Ürün":
                    connection.Open();
                    SqlCommand cmd2 = new SqlCommand("Select * From StokSiparisTB where SiparisTarihi=@SiparisTarihi", connection);
                    cmd2.Parameters.AddWithValue("SiparisTarihi", DateTime.Now.ToString("yyyy-MM-dd"));
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dataGrid.DataSource = dt2;
                    connection.Close();

                    break;


                case "Depodaki Ürünler":
                    connection.Open();
                    SqlCommand cmd3 = new SqlCommand("Select * From StokTB", connection);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGrid.DataSource = dt3;
                    connection.Close();

                    break;

                case "Raftaki Ürünler":
                    connection.Open();
                    SqlCommand cmd4 = new SqlCommand("Select * From StokTB", connection);
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    dataGrid.DataSource = dt4;
                    connection.Close();
                    break;

                default:
                    break;
            }




        }

        private void btnYazdir_Click(object sender, EventArgs e) 
        {
            string secilen = cmbxSecim.SelectedItem.ToString();


            switch (secilen)
            {
                case "Günlük Satılan Ürün":
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * From Satis_TB where SatisTarih=@SatisTarih", connection);
                    cmd.Parameters.AddWithValue("SatisTarih", DateTime.Now.ToString("yyyy-MM-dd"));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    MessageBox.Show(row["ImagePath"].ToString());
                    //}

                    connection.Close();

                    break;

                case "Günlük Sipariş Edilen Ürün":
                    connection.Open();
                    SqlCommand cmd2 = new SqlCommand("Select * From StokSiparisTB where SiparisTarihi=@SiparisTarihi", connection);
                    cmd2.Parameters.AddWithValue("SiparisTarihi", DateTime.Now.ToString("yyyy-MM-dd"));
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dataGrid.DataSource = dt2;
                    connection.Close();

                    break;

               
                case "Depodaki Ürünler":
                    connection.Open();
                    SqlCommand cmd3 = new SqlCommand("Select * From StokTB", connection);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGrid.DataSource = dt3;
                    connection.Close();

                    break;

                case "Raftaki Ürünler":
                    connection.Open();
                    SqlCommand cmd4 = new SqlCommand("Select * From StokTB", connection);
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    dataGrid.DataSource = dt4;
                    connection.Close();
                    break;

                default:
                    break;
            }

        }
    }
}