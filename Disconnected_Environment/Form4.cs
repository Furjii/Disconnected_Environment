﻿using System;
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
            koneksi.Open();
            string nim = "";
            string strs = "select NIM from dbo.Mahasiswa where nama_mahasiswa = @nm";
            SqlCommand cm = new SqlCommand(strs, koneksi);
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add(new SqlParameter("@nm", cbxNama.Text));
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                nim = dr["NIN"].ToString();

            }
            dr.Close();
            koneksi.Close();

            txtNIM.Text = nim;

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

                string queryStrings = "select Max(id_status) from dbo.status_mahasiswa";
                SqlCommand cmStatusMahasiswaSum = new SqlCommand(str, koneksi);
                int totalStatusMahasiswa = (int)cmStatusMahasiswaSum.ExecuteScalar();
                int finalKodeStatusInt = totalStatusMahasiswa + 1;
                kodeStatus = Convert.ToString(finalKodeStatusInt); 
            }

            string queryString = "insert into dbo.status_mahasiswa (id_status, nim, " +
                "status_mahasiswa, tahun_masuk)" + "values(@ids, @NIM, @sm, @tm)"; 
            SqlCommand cmd = new SqlCommand(queryString, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("ids", kodeStatus));
            cmd.Parameters.Add(new SqlParameter("NIM", nim));
            cmd.Parameters.Add(new SqlParameter("sm", statusMahasiswa));
            cmd.Parameters.Add(new SqlParameter("tm", tahunMasuk));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
    }

}
