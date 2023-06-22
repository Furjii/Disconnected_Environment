using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Environment
{
    public partial class FormDataProdi : Form
    {
        private string stringConnection = "data source=LAPTOP-DKPVN1V3\\FURJIKUN04;" + "database=TI;User ID=sa;Password=12345";
        private SqlConnection koneksi;
        public FormDataProdi()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGriedView1.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string nmProdi = nmp.Text;
            string idProdi = idp.Text;

            if (nmProdi == "")
            {
                MessageBox.Show("Masukan Nama Prodi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Prodi (id_prodi,nama_prodi)" + "values(@id_prodi, @nama_prodi)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("id_prodi", idProdi));
                cmd.Parameters.Add(new SqlParameter("nama_prodi", nmProdi));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }
        private void refreshform()
        {
            dataGriedView1.Text = "";
            dataGriedView1.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }


        private void dataGridView()
        {
            koneksi.Open();
            string str = "select nama_prodi from dbo.Prodi";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGriedView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FormDataProdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHalamanUtama hu = new FormHalamanUtama();
            hu.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nmProdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }
    }
}