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
    public partial class FormDataStatusMahasiswa : Form
    {
        private string stringConnection = "data source=LAPTOP-DKPVN1V3\\FURJIKUN04;" + "database=TI;User ID=sa;Password=12345";
        private SqlConnection koneksi;
        public FormDataStatusMahasiswa()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;

        }

        private void refreshform()
        {
            cbxNama.Enabled = false;
            cbxStatusMahasiswa.Enabled = false;
            cbxTahunMasuk.Enabled = false;
            cbxNama.SelectedIndex = -1;
            cbxStatusMahasiswa.SelectedIndex = -1;
            cbxTahunMasuk.SelectedIndex = -1;
            txtNIM.Visible = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }
        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from dbo.status_mahasiswa";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[8];
            koneksi.Close();
        }
        private void cbNama()
        {
            koneksi.Open();
            string str = "select nama_mahasiswa from dbo.Mahasiswa where " +
                "not EXISTS(select id_status from dbo.status_mahasiswa where " +
                "status_mahasiswa.nim = mahasiswa.nim";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();

            cbxNama.DisplayMember = "nama_mahasiswa";
            cbxNama.ValueMember = "NIM";
            cbxNama.DataSource = ds.Tables[0];

        }

        private void cbTahunMasuk()
        {
            int y = DateTime.Now.Year - 2010;
            string[] type = new string[y];
            int i = 0;
            for (i = 0; i < type.Length; i++)
            {

                if (1 == 0)
                {
                    cbxTahunMasuk.Items.Add("2010");
                }
                else
                {

                    int l = 2010 + i;
                    cbxTahunMasuk.Items.Add(1.ToString());
                }
                
            }
        }

        private void cbxNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = cbxNama.SelectedItem.ToString();


            koneksi.Open();
            string str = "SELECT nim FROM mahasiswa WHERE nama_mahasiswa = @nama_mahasiswa";
            SqlCommand cm = new SqlCommand(str, koneksi);
            cm.Parameters.AddWithValue("@nama_mahasiswa", selectedName);
            SqlDataReader dr = cm.ExecuteReader();

            if (dr.Read())
            {
                string nim = dr.GetString(0);
                txtNIM.Text = nim;
            }
            else
            {
                txtNIM.Text = "";
            }

            dr.Close();
            koneksi.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbxTahunMasuk.Enabled = true;
            cbxNama.Enabled = true;
            cbxStatusMahasiswa.Enabled = true;
            txtNIM.Visible = true;
            cbTahunMasuk();
            cbNama();
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nim = txtNIM.Text;
            string statusMahasiswa = cbxStatusMahasiswa.Text;
            string tahunMasuk = cbxTahunMasuk.Text;
            int count = 0;
            string tempKodeStatus = "";
            string kodeStatus = "";
            koneksi.Open();

            string str = "select count (*) from dbo.status_mahasiswa";
            SqlCommand cm = new SqlCommand(str, koneksi);
            count = (int)cm.ExecuteScalar();
            if (count == 0)
            {
                kodeStatus = "1";
            }
            else
            {
                string queryStrings = "SELECT TOP 1 id_status FROM dbo.status_mahasiswa ORDER BY id_status DESC";
                cm = new SqlCommand(queryStrings, koneksi);
                SqlCommand cmStatusMahasiswa = new SqlCommand(queryStrings, koneksi);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    tempKodeStatus = dr.GetString(0);
                }
                dr.Close();
                int tempKode = int.Parse(tempKodeStatus);
                tempKode++;
                kodeStatus = tempKode.ToString();
            }
            string queryString = "INSERT INTO dbo.status_mahasiswa (id_status, nim, status_mahasiswa, tahun_masuk) VALUES (@id_status, @nim, @status_mahasiswa, @tahun_masuk)";
            SqlCommand cmd = new SqlCommand(queryString, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("id_status", kodeStatus));
            cmd.Parameters.Add(new SqlParameter("NIM", nim));
            cmd.Parameters.Add(new SqlParameter("status_mahasiswa", statusMahasiswa));
            cmd.Parameters.Add(new SqlParameter("tahun_masuk", tahunMasuk));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data berhasil disimpan", "Sukses!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
            dataGridView();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();
        }
        private void FormDataStatusMahasiswa_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormHalamanUtama fm = new FormHalamanUtama();
            fm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxStatusMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxTahunMasuk_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}
