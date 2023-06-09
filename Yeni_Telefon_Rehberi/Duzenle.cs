using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Yeni_Telefon_Rehberi;
using System.Data.SqlClient;

namespace Yeni_Telefon_Rehberi
{
    public partial class Duzenle : Form
    {
        private Form1 form1;

        public Duzenle(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Rehber.mdb");
        OleDbCommand komut = new OleDbCommand();

        DataTable veritablosu = new DataTable();

        public void DataGridViewiGuncelle()
        {
            // DataGridView'i temizle
            Form1 form1 = new Form1();
           form1.dataGridView1.Rows.Clear();

            // Veritabanından verileri al ve DataGridView'e ekle
            bag.Open();
            komut.Connection = bag;
            komut.CommandText = "SELECT * FROM Kisiler";
            OleDbDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                string kisiID = reader["KisiID"].ToString();
                string isim = reader["Isim"].ToString();
                string soyisim = reader["Soyisim"].ToString();
                string telefon = reader["Telefon"].ToString();
                string adres = reader["Adres"].ToString();

                form1.dataGridView1.Rows.Add(kisiID, isim, soyisim, telefon, adres);
            }
            reader.Close();
            bag.Close();
        }


        public void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string yeniIsim = isimtxt.Text;
                string yeniSoyisim = soyisimtxt.Text;
                string yeniTelefon = teltxt.Text;
                string yeniAdres = adrestxt.Text;

                // Verileri Form1'e geri aktarmak için Form1'e referans oluşturun
                Form1 form1 = Application.OpenForms["Form1"] as Form1;
                if (form1 != null)
                {
                    DialogResult onay;
                    onay = MessageBox.Show("Bu işlemi yapmak istediğinize emin misiniz? ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (onay == DialogResult.Yes)
                    {
                        if (form1.dataGridView1.SelectedRows.Count > 0)
                        {
                            DataGridViewRow selectedRow = form1.dataGridView1.SelectedRows[0];
                            int seciliSatirIndex = selectedRow.Index;

                            // Verileri güncelleme
                            selectedRow.Cells["Isim"].Value = yeniIsim;
                            selectedRow.Cells["Soyisim"].Value = yeniSoyisim;
                            selectedRow.Cells["Telefon"].Value = yeniTelefon;
                            selectedRow.Cells["Adres"].Value = yeniAdres;

                            // Veritabanına güncelleme işlemini gerçekleştirin
                            bag.Open();
                            komut.Connection = bag;
                            komut.CommandText = "UPDATE Kisiler SET Isim = @YeniIsim, Soyisim = @YeniSoyisim, Telefon = @YeniTelefon, Adres = @YeniAdres WHERE Telefon = @Telefon";
                            komut.Parameters.AddWithValue("@YeniIsim", yeniIsim);
                            komut.Parameters.AddWithValue("@YeniSoyisim", yeniSoyisim);
                            komut.Parameters.AddWithValue("@YeniTelefon", yeniTelefon);
                            komut.Parameters.AddWithValue("@YeniAdres", yeniAdres);
                            komut.Parameters.AddWithValue("@Telefon", yeniTelefon);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Kişi Güncellendi!");
                            bag.Close();

                            

                            // Form3'ü kapatın
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("İşlem iptal edildi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        internal void SetVeriler(string isim, string soyisim, string telefon, string adres)
        {
            isimtxt.Text = isim;
            soyisimtxt.Text = soyisim;
            teltxt.Text = telefon;
            adrestxt.Text = adres;
        }
    }
}
