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
            dataGridView1.ClearSelection();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            button3.Visible = false;

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                button3.Visible = true; // Butonu göster
            }
            else
            {
                button3.Visible = false; // Butonu gizle
            }
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                button1.Visible = true; // Butonu göster
            }
            else
            {
                button1.Visible = false; // Butonu gizle
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                if (selectedRow.Selected)
                {
                    dataGridView1.ClearSelection();
                }
                else
                {
                    dataGridView1.ClearSelection();
                    selectedRow.Selected = true;
                }
            }
        }
    }
}
