﻿namespace ReportesItextSharp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_RutEjecutivo = new System.Windows.Forms.TextBox();
            this.cb_periodo = new System.Windows.Forms.ComboBox();
            this.reporteriaTIDataSet11 = new ReportesItextSharp.ReporteriaTIDataSet1();
            this.reporteriaTIDataSet11BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaTIDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaTIDataSet11BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cargar Datos Grid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Generar Reporte";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rut Ejecutivo";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(361, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Enviar Correo @";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(860, 246);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(671, 371);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Ir a Reportes Historicos";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Periodo";
            // 
            // txt_RutEjecutivo
            // 
            this.txt_RutEjecutivo.Location = new System.Drawing.Point(59, 44);
            this.txt_RutEjecutivo.Name = "txt_RutEjecutivo";
            this.txt_RutEjecutivo.Size = new System.Drawing.Size(100, 20);
            this.txt_RutEjecutivo.TabIndex = 12;
            this.txt_RutEjecutivo.TextChanged += new System.EventHandler(this.txt_RutEjecutivo_TextChanged_1);
            this.txt_RutEjecutivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RutEjecutivo_KeyPress);
            // 
            // cb_periodo
            // 
            this.cb_periodo.FormattingEnabled = true;
            this.cb_periodo.Location = new System.Drawing.Point(290, 43);
            this.cb_periodo.Name = "cb_periodo";
            this.cb_periodo.Size = new System.Drawing.Size(121, 21);
            this.cb_periodo.TabIndex = 13;
            this.cb_periodo.SelectedIndexChanged += new System.EventHandler(this.cb_periodo_SelectedIndexChanged);
            // 
            // reporteriaTIDataSet11
            // 
            this.reporteriaTIDataSet11.DataSetName = "ReporteriaTIDataSet1";
            this.reporteriaTIDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteriaTIDataSet11BindingSource
            // 
            this.reporteriaTIDataSet11BindingSource.DataSource = this.reporteriaTIDataSet11;
            this.reporteriaTIDataSet11BindingSource.Position = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 406);
            this.Controls.Add(this.cb_periodo);
            this.Controls.Add(this.txt_RutEjecutivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Informe Comisiones";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaTIDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteriaTIDataSet11BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_RutEjecutivo;
        private System.Windows.Forms.ComboBox cb_periodo;
        private ReporteriaTIDataSet1 reporteriaTIDataSet11;
        private System.Windows.Forms.BindingSource reporteriaTIDataSet11BindingSource;
        private ReportesItextSharp.ReporteriaTIDataSet reporteriaTIDataSet1;
    }
}

