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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Rehber.mdb");
        OleDbCommand komut = new OleDbCommand();

        DataTable veritablosu = new DataTable();

        public void listele()
        {
            try
            {
                veritablosu.Clear();
                OleDbDataAdapter siringa = new OleDbDataAdapter("select * from Kisiler", bag);
                siringa.Fill(veritablosu);
                dataGridView1.DataSource = veritablosu;


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            veritablosu.Clear();

            OleDbDataAdapter siringa = new OleDbDataAdapter("select * from Kisiler where Isim like '" + textBox1.Text + "%'", bag);
            siringa.Fill(veritablosu);
            dataGridView1.DataSource = veritablosu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YeniKayit YeniKayit = new YeniKayit();
            YeniKayit.Show();
        }
    }
}
