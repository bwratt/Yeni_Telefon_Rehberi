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

namespace Yeni_Telefon_Rehberi
{
    public partial class YeniKayit : Form
    {
        public YeniKayit()
        {
            InitializeComponent();
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
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult onay;
                onay = MessageBox.Show("Bu işlemi yapmak istediğinize emin misiniz? ", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    string isim, soyisim, telefon, adres;


                    isim = yeniisimtxt.Text;
                    soyisim = yenisoytxt.Text;
                    telefon = yeniteltxt.Text;
                    adres = yeniadrestxt.Text;

                    if (yeniteltxt.Text.Length < 10)
                    {
                        MessageBox.Show("Telefon numarası 10 haneli olmalı ve 0'la başlamamalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        bag.Open();
                        komut.Connection = bag;
                        komut.CommandText = "insert into Kisiler (Isim,Soyisim,Telefon,Adres) values ('" + isim + "','" + soyisim + "','" + telefon + "','" + adres + "')";
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kişi Kayıt Edildi!");
                        bag.Close();

                        yeniisimtxt.Text = "";
                        yenisoytxt.Text = "";
                        yeniteltxt.Text = "";
                        yeniadrestxt.Text = "";
                        
                        this.Close();

                        DataGridViewiGuncelle();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tekrar Deneyiniz.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void yeniadrestxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void yenisoytxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void yeniisimtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void yeniteltxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void yeniisimtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void yenisoytxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
