using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ContohProject
{
    public partial class Form2 : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public Form2()
        {
            alamat = "server=localhost; database=dbconnection; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                koneksi.Open();

                query = string.Format("select * from student");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[1].HeaderText = "Username";
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "Password";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[0].HeaderText = "Tanggal_Lahir";
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[0].HeaderText = "Prodi";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
