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
    public class DT_M41
    {
        ET_globales _global = new ET_globales();
        ET_entidad _Entidad = new ET_entidad();
        ET_M41 _et_m41;
        List<ET_M41> _lista_mtm41 = new List<ET_M41>();

        //OBTENER LISTA DE SERVICIOS
        public ET_entidad get_001()
        {
            string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm41_get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_TM41_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _et_m41 = new ET_M41();

                        _et_m41._TM41_ID = Convert.ToInt32(fila["TM41_ID"].ToString());
                        _et_m41._TM41_TM2_ID = fila["TM41_TM2_ID"].ToString();
                        _et_m41._TM41_DESCRIP = fila["TM41_DESCRIP"].ToString();

                        _et_m41._TM41_TIPO = 1;//diego

                        _lista_mtm41.Add(_et_m41);
                    }

                    _Entidad._lista_et_m41 = _lista_mtm41;
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
