using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportesItextSharp
{
    public class ConsultasSql
    {
        private SqlConnection cadena = new SqlConnection("integrated security=true;Data Source=nas;Initial Catalog=ReporteriaTI");
        
        private DataSet ds = new DataSet();
        public DataTable cargarPorUsuario(Int32 Rut, string Periodo)
        {

            cadena.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select  Distinct CARTERA,META,RECUPERO,Format(Round(([POR_CUMPLIMIENTO] * 100), 2, 0), '') + '%' as POR_CUMPLIMIENTO,Format(Round(CAST(FACTOR AS FLOAT), 2, 0), '') + '%' AS FACTOR,Format(Round(CAST([VENTA] AS FLOAT), 2, 0), '#,#.#') AS VENTA,Format(Round(CAST(COMISION AS FLOAT), 2, 0), '#,#.#') AS COMISION from[ReporteriaTI].[dbo].[InformeComisiones1] where RUT = {0} and PERIODO = '{1}'; ", Rut,Periodo), cadena);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            cadena.Close();
            da.Fill(ds, "InformeComisiones1");
            return ds.Tables["InformeComisiones1"];
            

        }

        public DataTable BuscaMailNombre(Int32 Rut, string Periodo)
        {

            cadena.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(string.Format("select nombre,Mails,  Format(Sum(CAST([COMISION] as float)),'#,#.#') as SumaComi  from [ReporteriaTI].[dbo].[InformeComisiones1] where RUT = {0} and Periodo = {1} group by nombre,Mails;", Rut, Periodo), cadena);
            cmd.Parameters.AddWithValue("@Rut", Rut);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            cadena.Close();
            adap.Fill(dt);

            return dt; 


        }
        public void LlenaCBPeriodo(ComboBox cb)
        {
            cadena.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select PERIODO FROM [ReporteriaTI].[dbo].[InformeComisiones1] group by PERIODO order by PERIODO Desc", cadena);

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cb.Items.Add(dr["PERIODO"].ToString());

            }
            dr.Close();
            cadena.Close();
        }




}
}
