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
            // DataGridView'in veri kaynağını temizle
            Form1 form1 = Application.OpenForms["Form1"] as Form1; // Form1'e erişim
            form1.dataGridView1.DataSource = null;
            form1.dataGridView1.Rows.Clear();

            // Veritabanından verileri al ve DataGridView'e ekle
            bag.Open();
            komut.Connection = bag;
            komut.CommandText = "SELECT * FROM Kisiler";
            OleDbDataAdapter adapter = new OleDbDataAdapter(komut);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            form1.dataGridView1.DataSource = dataTable;
            bag.Close();
        }

        private void teltxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            DialogResult onay;
            onay = MessageBox.Show("Bu kişiyi silmek istediğinize emin misiniz?", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                // Seçili kişinin telefon numarasını alın
                string seciliTelefon = form1. dataGridView1.SelectedRows[0].Cells["Telefon"].Value.ToString();

                // Veritabanından kişiyi sil
                bag.Open();
                komut.Connection = bag;
                komut.CommandText = "DELETE FROM Kisiler WHERE Telefon = @Telefon";
                komut.Parameters.AddWithValue("@Telefon", seciliTelefon);
                komut.ExecuteNonQuery();
                bag.Close();

                MessageBox.Show("Kişi silindi!");

                // DataGridView'i güncelle
                
                DataGridViewiGuncelle();

                this.Close();
            }
        }

        private void teltxt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // En fazla 10 karaktere izin ver
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void isimtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void soyisimtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
