using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesItextSharp
{
    public class ConsultasSqlHistorico
    {
        private AdmFinanzasDataSet admFinanzasDataSet = new AdmFinanzasDataSet();
        private SqlConnection cadena = new SqlConnection("integrated security=true;Data Source=nas;Initial Catalog=AdmFinanzas");
        
        private DataSet ds = new DataSet();

        public DataTable CargarEjecutivoRutFecha(Int32 Rut, DateTime FechaInicio, DateTime FechaFin)
        {

            cadena.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT CARTERA,format(Round(ISNULL(META, 0), 0, 0), '#,#.#') AS META,format(Round(ISNULL(RECUPERO, 0), 0, 0), '#,#.#') AS RECUPERO,Format(Round(ISNULL(CUMPLIMIENTO, 0), 2, 0), '') + '%' AS CUMPLIMIENTO,Format(Round(ISNULL(FACTORCOMI, 0), 2, 0), '') + '%' AS FACTOR,format(Round(ISNULL(VENTA, 0), 0, 0), '#,#.#') AS VENTA,Format(Round(sum(ISNULL(COMISION, 0)), 2, 0), '#,#.#') AS COMISION from datosenvio t1 inner join RegistroEnvio t2 on t1.IDR_CARGA = t2.IDR where RUT = '{0}' and t2.FECHA between '{1}' and '{2}' group by CARTERA, ISNULL(META, 0), ISNULL(RECUPERO, 0), ISNULL(CUMPLIMIENTO, 0), ISNULL(FACTORCOMI, 0), ISNULL(VENTA, 0)", Rut, FechaInicio, FechaFin), cadena);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            cadena.Close();
            da.Fill(ds, "DATOSENVIO");
            return ds.Tables["DATOSENVIO"];


        }

        public DataTable DatosInforme(Int32 Rut, DateTime FechaInicio, DateTime FechaFin)
        {

            cadena.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT t1.IDR,NOMBRE,EMAIL,RUT,CARTERA,ISNULL(META, 0) AS META,ISNULL(RECUPERO, 0) AS RECUPERO,format(ISNULL(CUMPLIMIENTO, 0), '#,#.#') AS CUMPLIMIENTO,format(ISNULL(FACTORCOMI, 0), '#,#.#') AS FACTOR,format(ISNULL(VENTA, 0), '#,#.#') AS VENTA,format(sum(ISNULL(COMISION, 0)), '#,#.#') AS COMISION,format(sum(ISNULL(BONO, 0)),'#,#.#') AS BONO,format(DATEADD(MONTH,-1, t2.Fecha), 'MMMM,yyyy') AS FECHA, format(t2.Fecha, 'dd/MM/yyyy') AS FECHACOMPLETA from datosenvio t1 inner join RegistroEnvio t2 on t1.IDR_CARGA = t2.IDR where RUT = '{0}' and t2.FECHA between '{1}' and '{2}' group by t1.IDR,NOMBRE,EMAIL,RUT,CARTERA,ISNULL(META, 0),ISNULL(RECUPERO, 0),ISNULL(CUMPLIMIENTO, 0),ISNULL(FACTORCOMI, 0),ISNULL(VENTA, 0),t2.FECHA order by t2.FECHA ", Rut, FechaInicio, FechaFin), cadena);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            cadena.Close();
            da.Fill(ds, "DATOSENVIO");
            return ds.Tables["DATOSENVIO"];


        }






    }
}
