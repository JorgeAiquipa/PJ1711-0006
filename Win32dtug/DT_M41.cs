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
    public class DT_M41:DT_CNX
    {
        ET_globales _global = new ET_globales();
        ET_entidad _Entidad = new ET_entidad();
        List<ET_M41> _lista_mtm41 = new List<ET_M41>();
        ET_R19 _et_r19 = new ET_R19();
        List<ET_R19> _LISTA_ET_R19 = new List<ET_R19>();

        //OBTENER LISTA DE SERVICIOS POR TIPO
        public ET_entidad get_001(ET_M41 objEntity)
        {
            string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr19_sel001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_TR19_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    cmd.Parameters.Add("@p_TR19_TM42_ID", SqlDbType.VarChar, 10).Value = objEntity._TM41_TM42_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    _LISTA_ET_R19.Clear();
                    foreach (DataRow fila in dt.Rows)
                    {
                        _et_r19 = new ET_R19();

                        _et_r19._T_R19_TM2_ID = fila["T_R19_TM2_ID"].ToString();
                        _et_r19._TR19_TM41_ID = Convert.ToInt32(fila["TR19_TM41_ID"].ToString());
                        _et_r19._TR19_TM42_ID = Convert.ToInt32(fila["TR19_TM42_ID"].ToString());
                        _et_r19._TR19_TM41_DESCRIP = fila["TR19_TM41_DESCRIP"].ToString();
                        //_et_r19._TR19_VALOR = Convert.ToInt32(fila["TR19_VALOR"].ToString());
                        _et_r19._TR19_UCREA = fila["TR19_UCREA"].ToString();
                        _et_r19._TR19_FCREA = Convert.ToDateTime(fila["TR19_FCREA"].ToString());
                        _et_r19._TR19_UACTUALIZA = fila["TR19_UACTUALIZA"].ToString();
                        _et_r19._TR19_FACTUALIZA = Convert.ToDateTime(fila["TR19_FACTUALIZA"].ToString());

                        _LISTA_ET_R19.Add(_et_r19);
                    }

                    _Entidad._lista_et_r19 = _LISTA_ET_R19;
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
