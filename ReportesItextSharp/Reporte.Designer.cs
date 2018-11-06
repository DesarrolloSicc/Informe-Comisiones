namespace ReportesItextSharp
{
    partial class Reporte
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReporteriaTIDataSet = new ReportesItextSharp.ReporteriaTIDataSet();
            this.reporteDetalleComisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteDetalleComisionTableAdapter = new ReportesItextSharp.ReporteriaTIDataSetTableAdapters.reporteDetalleComisionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteriaTIDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteDetalleComisionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteDetalleComisionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportesItextSharp.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(674, 302);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReporteriaTIDataSet
            // 
            this.ReporteriaTIDataSet.DataSetName = "ReporteriaTIDataSet";
            this.ReporteriaTIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteDetalleComisionBindingSource
            // 
            this.reporteDetalleComisionBindingSource.DataMember = "reporteDetalleComision";
            this.reporteDetalleComisionBindingSource.DataSource = this.ReporteriaTIDataSet;
            // 
            // reporteDetalleComisionTableAdapter
            // 
            this.reporteDetalleComisionTableAdapter.ClearBeforeFill = true;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 360);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteriaTIDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteDetalleComisionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteDetalleComisionBindingSource;
        private ReporteriaTIDataSet ReporteriaTIDataSet;
        private ReporteriaTIDataSetTableAdapters.reporteDetalleComisionTableAdapter reporteDetalleComisionTableAdapter;
    }
}