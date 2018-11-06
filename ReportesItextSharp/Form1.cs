using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace ReportesItextSharp
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
       
        ConsultasSql con = new ConsultasSql();
        #region crearPDF
        private void To_pdf()
        {
                    DataTable dt = con.BuscaMailNombre(Convert.ToInt32((txt_RutEjecutivo.Text)), cb_periodo.Text);//envio dato a buscar
                         
                    //si encuentra el dato guardo los datos en las variables
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        //guardo datos de la bbdd en variables
                        string nombre = Convert.ToString(row["NOMBRE"]);
                        string mail = Convert.ToString(row["Mails"]);
                        string SumaComi = Convert.ToString(row["SumaComi"]);
                        

                        Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        //saveFileDialog1.InitialDirectory = @"C:";
                        //saveFileDialog1.Title = "Guardar Reporte";
                        //saveFileDialog1.DefaultExt = "pdf";
                        //saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
                        //saveFileDialog1.FilterIndex = 2;
                        //saveFileDialog1.RestoreDirectory = true;
                        string filename = "C:/Users/rebeca.salgado/Documents/UltimoPdf/" + mail+ ".pdf";;
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
                            
                            string envio = "Fecha envío:                                              " + DateTime.Now.ToString();

                            Chunk chunk = new Chunk("Reporte Recursos Humanos ", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD,BaseColor.BLUE));
                            doc.Add(new Paragraph(chunk));
                            doc.Add(new Paragraph("                       "));
                            doc.Add(new Paragraph("------------------------------------------------------------------------------------------" ,FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD,BaseColor.BLUE)));
                            doc.Add(new Paragraph("De:                                                   Comisiones Sicc <gerencia.personas@sicc.cl>"));
                            doc.Add(new Paragraph(envio));
                            doc.Add(new Paragraph("Para:                                                "+mail));
                            doc.Add(new Paragraph("Asunto:                                            Anexo detalle de Comisiones Agosto 2018"));
                            doc.Add(new Paragraph("            "));
                            doc.Add(new Paragraph("Estimado(a):  "+nombre));
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
                            doc.Add(new Paragraph("                                                                                         Total Comisiones: "+SumaComi));
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultasSql consulta = new ConsultasSql();
            
            dataGridView1.DataSource = consulta.cargarPorUsuario(Convert.ToInt32((txt_RutEjecutivo.Text)),cb_periodo.Text);
            //CargarGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con.LlenaCBPeriodo(cb_periodo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void EnviarCorreo()
        {
            DataTable dt = con.BuscaMailNombre(Convert.ToInt32((txt_RutEjecutivo.Text)), cb_periodo.Text);//envio dato a buscar
                                                                                         //si encuentra el dato guardo los datos en las variables
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                //guardo datos de la bbdd en variables
                string nombre = Convert.ToString(row["NOMBRE"]);
                string mail = Convert.ToString(row["Mails"]);


                /*-------------------------MENSAJE DE CORREO----------------------*/
                Attachment data = new Attachment("C:/Users/rebeca.salgado/Documents/UltimoPdf/" + mail + ".pdf", MediaTypeNames.Application.Octet);
                //Creamos un nuevo Objeto de mensaje
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.CC.Add("rebeca.salgado@sicc.cl");
                //Direccion de correo electronico a la que queremos enviar el mensaje
                mmsg.To.Add(mail);

                //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

                //Asunto
                mmsg.Subject = "Comisiones";
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;


                //Cuerpo del Mensaje
                mmsg.Body = "Estimado/a, <br>Adjunto comisiones correspondientes al mes de Agosto.<br><br> Saludos.";
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML
               // mmsg.CC.Add("rebeca.salgado@sicc.cl");
                mmsg.Attachments.Add(data);

                //Correo electronico desde la que enviamos el mensaje
                mmsg.From = new System.Net.Mail.MailAddress("javiera.cotapos@sicc.cl");


                /*-------------------------CLIENTE DE CORREO----------------------*/

                //Creamos un objeto de cliente de correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential("javiera.cotapos@sicc.cl", "Sicc.2030");

                cliente.Port = 587;
                cliente.EnableSsl = true;


                cliente.Host = "deneb.sicc.cl";
                ServicePointManager.ServerCertificateValidationCallback =

                   delegate (object s

                       , X509Certificate certificate

                       , X509Chain chain

                       , SslPolicyErrors sslPolicyErrors)

                   { return true; };

                /*-------------------------ENVIO DE CORREO----------------------*/

                try
                {
                    //Enviamos el mensaje      
                    cliente.Send(mmsg);
                    MessageBox.Show("Mesaje enviado");
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    MessageBox.Show("error al enviar");
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            EnviarCorreo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GenerarHistorico hist = new GenerarHistorico();
            hist.Show();
        }

        private void txt_RutEjecutivo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_RutEjecutivo_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_RutEjecutivo.TextLength > 8)

                MessageBox.Show("El RUT solo puede tener una cantidad de 8 caracteres, sin guíon ni digito!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }

        private void txt_RutEjecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }

        private void cb_periodo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }

    
}
