﻿namespace Disconnected_Environment
{
    partial class FormDataProdi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGriedView1 = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.nmProdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nmp = new System.Windows.Forms.Label();
            this.idp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGriedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGriedView1
            // 
            this.dataGriedView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGriedView1.Location = new System.Drawing.Point(146, 33);
            this.dataGriedView1.Name = "dataGriedView1";
            this.dataGriedView1.RowHeadersWidth = 51;
            this.dataGriedView1.RowTemplate.Height = 24;
            this.dataGriedView1.Size = new System.Drawing.Size(461, 213);
            this.dataGriedView1.TabIndex = 0;
            this.dataGriedView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.CadetBlue;
            this.btnOpen.Location = new System.Drawing.Point(623, 73);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 30);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAdd.Location = new System.Drawing.Point(485, 264);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 35);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSave.Location = new System.Drawing.Point(283, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.CadetBlue;
            this.btnClear.Location = new System.Drawing.Point(391, 344);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.button4_Click);
            // 
            // nmProdi
            // 
            this.nmProdi.Location = new System.Drawing.Point(283, 273);
            this.nmProdi.Name = "nmProdi";
            this.nmProdi.Size = new System.Drawing.Size(183, 22);
            this.nmProdi.TabIndex = 5;
            this.nmProdi.TextChanged += new System.EventHandler(this.nmProdi_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 276);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nama Prodi";
            // 
            // nmp
            // 
            this.nmp.AutoSize = true;
            this.nmp.Location = new System.Drawing.Point(199, 308);
            this.nmp.Name = "nmp";
            this.nmp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nmp.Size = new System.Drawing.Size(55, 16);
            this.nmp.TabIndex = 7;
            this.nmp.Text = "ID Prodi";
            this.nmp.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // idp
            // 
            this.idp.AutoSize = true;
            this.idp.Location = new System.Drawing.Point(280, 308);
            this.idp.Name = "idp";
            this.idp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.idp.Size = new System.Drawing.Size(55, 16);
            this.idp.TabIndex = 8;
            this.idp.Text = "ID Prodi";
            this.idp.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // FormDataProdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.idp);
            this.Controls.Add(this.nmp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmProdi);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.dataGriedView1);
            this.Name = "FormDataProdi";
            this.Text = "Data Prodi";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGriedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGriedView1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox nmProdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nmp;
        private System.Windows.Forms.Label idp;
    }
}