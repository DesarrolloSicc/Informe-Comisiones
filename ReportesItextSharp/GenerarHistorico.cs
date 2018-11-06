using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Net.Mail;
using System.Net.Mime;

namespace ReportesItextSharp
{
    public partial class GenerarHistorico : Form
    {
        ConsultasSqlHistorico con = new ConsultasSqlHistorico();
        public GenerarHistorico()
        {
            InitializeComponent();
        }

        private void GenerarHistorico_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultasSqlHistorico consulta = new ConsultasSqlHistorico();
            dataGridView1.DataSource = consulta.CargarEjecutivoRutFecha(Convert.ToInt32(txt_rutEjecutivo.Text), Convert.ToDateTime(dt_FechaInicio.Text), Convert.ToDateTime(dt_FechaFin.Text));
        }

        #region crearPDF
        private void To_pdf()
        {
            DataTable dt = con.DatosInforme(Convert.ToInt32(txt_rutEjecutivo.Text), Convert.ToDateTime(dt_FechaInicio.Text), Convert.ToDateTime(dt_FechaFin.Text));
            //si encuentra el dato guardo los datos en las variables
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                //guardo datos de la bbdd en variables
                string mail = Convert.ToString(row["EMAIL"]);
                string nombre = Convert.ToString(row["NOMBRE"]);
                string comision = Convert.ToString(row["COMISION"]);
                string fechaEnvio = Convert.ToString(row["FECHA"]);
                string fechaEnvioCompleta = Convert.ToString(row["FECHACOMPLETA"]);
                string id = Convert.ToString(row["IDR"]);

                Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.InitialDirectory = @"C:";
                //saveFileDialog1.Title = "Guardar Reporte";
                //saveFileDialog1.DefaultExt = "pdf";
                //saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                //saveFileDialog1.RestoreDirectory = true;
                string filename = "C:/Users/rebeca.salgado/Documents/UltimoPdf/"+id+"-"+nombre+".pdf"; ;
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    filename = saveFileDialog1.FileName;
                //}
                //System.IO.File.Create("C:/Users/rebeca.salgado/Documents/UltimoPdf/" + filename).Close();
                if (filename.Trim() != "")
                {
                    FileStream file = new FileStream(filename,
                    //FileMode.OpenOrCreate,
                    FileMode.Create,
                    FileAccess.ReadWrite,
                    FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, file);
                    doc.Open();

                    string envio = "Fecha:                                              " + DateTime.Now.ToString();

                    Chunk chunk = new Chunk("Francis Yañez" , FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD, BaseColor.BLUE));
                    doc.Add(new Paragraph(chunk));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("_________________________________________________________________", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD, BaseColor.BLUE)));
                    doc.Add(new Paragraph("De:                                                   Comisiones Sicc <francis.yanez@sicc.cl>"));
                    doc.Add(new Paragraph("Enviado el:                                          " + fechaEnvioCompleta));
                    doc.Add(new Paragraph("Para:                                                "+mail));
                    doc.Add(new Paragraph("Asunto:                                            Anexo detalle de Comisiones " + fechaEnvio));
                    doc.Add(new Paragraph("            "));
                    doc.Add(new Paragraph("Estimado(a):  " + nombre));
                    doc.Add(new Paragraph("            "));
                    doc.Add(new Paragraph("Conforme a lo establecido en nuestra legislación laboral vigente, se informa la determinación de la remuneración variable del trabajador, resultado de la aplicación de lo acordado por las partes en su Contrato de Trabajo o anexos."));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("1.- Se deja constancia que, para los efectos del presente contrato, se entiende por venta el monto total del dinero recuperado durante la vigencia de la asignación multiplicado por el factor de honorarios establecido según contrato de prestación de Servicios entre Sicc Ltda y la empresa mandante que entrega dicha cartera en cobranza, gestionada por el trabajador."));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("2.- La comisión mensual será calculada de acuerdo a lo establecido en el Contrato de Trabajo pudiendo ser esta gestionado como Ejecutivo Manual o Ejecutivo Discador."));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    GenerarDocumento(doc);
                    doc.Add(new Paragraph("                       "));
                    //doc.Add(new Paragraph("                                                                                         Total Comisiones: " + comision));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Declaro recibir conforme el presente anexo, haber revisado sus detalles y resultados.Autorizo en este acto el envío de esta información a mi dirección e.mail, entregada a Recursos Humanos."));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.AddCreationDate();

                    doc.Close();
                    Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                }
            }

        }
        public void GenerarDocumento(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dataGridView1.ColumnCount);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = GetTamañoColumnas(dataGridView1);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 2;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;


            for (i = 0; i < dataGridView1.ColumnCount; i++)
            {
                datatable.AddCell(dataGridView1.Columns[i].HeaderText);
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 0;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(dataGridView1[j, i].Value.ToString()));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }
        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;

        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            To_pdf();
        }
    }
}
