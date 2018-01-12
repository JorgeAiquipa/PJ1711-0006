using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;

namespace Win32dtug
{
    public class DT_M42
    {
        DT_CNX _cnx = new DT_CNX();
        ET_globales _global = new ET_globales();
        ET_entidad _Entidad = new ET_entidad();
        ET_M42 _et_m42;
        List<ET_M42> _lista_mtm42 = new List<ET_M42>();

        //OBTENER LISTA DE TIPOS DE SERVICIOS
        public ET_entidad get_001()
        {
            string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm42_get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _et_m42 = new ET_M42();

                        _et_m42._TM42_ID = Convert.ToInt32(fila["TM42_ID"].ToString());
                        _et_m42._TM42_DESCRIP = fila["TM42_DESCRIP"].ToString();
                        
                        _lista_mtm42.Add(_et_m42);
                    }

                    _Entidad._lista_et_m42 = _lista_mtm42;
                    _Entidad._hubo_error = false;
                }
                catch (SqlException exsql)
                {
                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                    }
                }
                catch (Exception ex)
                {
                    Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + ex.Message.ToString()));
                    if (ex.InnerException != null)
                        Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + "Inner exception: " + ex.InnerException.Message));
                    Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + "Stack trace: " + ex.StackTrace));

                    _Entidad._hubo_error = true;
                    _Entidad._contenido_mensaje = Mensaje_error;
                    _Entidad._titulo_mensaje = "Error!";
                }
                finally
                {
                    cn.Close();

                }
                return _Entidad;
            }
        }



    }
}
