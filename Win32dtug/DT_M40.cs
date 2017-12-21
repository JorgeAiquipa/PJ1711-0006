using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win28etug;

namespace Win32dtug
{
    public class DT_M40
    {
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_M40 _et_m40 = new ET_M40();
        List<ET_M40> _lista_etm40 = new List<ET_M40>();

        public ET_entidad get_001()
        {
            string Mensaje_error = "";
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm40get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    _lista_etm40.Clear();
                    int indice = 0;
                    foreach (DataRow fila in dt.Rows)
                    {
                        _et_m40 = new ET_M40();

                        _et_m40._fila = indice;
                        _et_m40._TM40_ID = fila["TM40_ID"].ToString();
                        _et_m40._TM40_DESCRIP = fila["TM40_DESCRIP"].ToString();
                        _et_m40._TM40_DESCRIP2 = fila["TM40_DESCRIP2"].ToString();
                        //_et_m40._TM40_ST = Convert.ToInt32(fila["TM40_ST"].ToString());
                        //_et_m40._TM40_UCREA = fila["TM40_UCREA"].ToString();
                        //_et_m40._TM40_FCREA = Convert.ToDateTime(fila["TM40_FCREA"].ToString());
                        //_et_m40._TM40_UACTUALIZA = fila["TM40_UACTUALIZA"].ToString();
                        //_et_m40._TM40_FACTUALIZA = Convert.ToDateTime(fila["TM40_FACTUALIZA"].ToString());

                        indice++;
                        _lista_etm40.Add(_et_m40);
                    }

                    _Entidad._lista_et_m40 = _lista_etm40;
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
