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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult onay;
                onay = MessageBox.Show("Bu işlemi yapmak istediğinize emin misiniz? ", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    string isim, soyisim, telefon, adres;


                    isim = textBox2.Text;
                    soyisim = textBox3.Text;
                    telefon = textBox4.Text;
                    adres = textBox5.Text;

                    if (textBox4.Text.Length < 10)
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

                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";

                        this.Close();
                        
                    }
                
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Tekrar Deneyiniz.");
            }
        }
    }
}
