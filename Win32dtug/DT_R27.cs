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
    public class DT_R27
    {
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_globales _globales = new ET_globales();
        ET_R27 _et_r27 = new ET_R27();
        ET_M27 _et_m27 = new ET_M27();
        List<ET_R27> _lista_et_r27 = new List<ET_R27>();
        List<ET_M27> _lista_et_m27 = new List<ET_M27>();

        public ET_entidad set_001(ET_R27 _entity_tr27)
        {
            _Entidad = new ET_entidad();
            _Entidad._entity_r27= new ET_R27();

            string Msg_respuesta;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr27_set_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {

                    cmd.Parameters.Add("@P_MENSAJE_RESPUESTA", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@p_TM39_ID", SqlDbType.VarChar, 20).Value = _entity_tr27._TR27_TM39_ID;
                    cmd.Parameters.Add("@p_TM27_ID", SqlDbType.VarChar, 20).Value = _entity_tr27._TR27_TM27_ID;
                    cmd.Parameters.Add("@p_TM19_ID", SqlDbType.VarChar, 10).Value = _entity_tr27._TR27_TM19_ID;
                    cmd.Parameters.Add("@p_TM2_ID", SqlDbType.VarChar, 10).Value =_globales._TM2_ID;
                    cmd.Parameters.Add("@p_TR27_DESCRIP", SqlDbType.VarChar, 3000).Value = _entity_tr27._TR27_DESCRIP;
                    cmd.Parameters.Add("@p_TR27_UCREA", SqlDbType.VarChar, 20).Value = _globales._U_CREA;
                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();

                    Msg_respuesta = cmd.Parameters["@P_MENSAJE_RESPUESTA"].Value.ToString();

                    _Entidad._hubo_error = false;
                }
                catch (SqlException exsql)
                {
                    Msg_respuesta = exsql.Message;
                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Msg_respuesta = exRollback.Message;
                    }

                    _Entidad._hubo_error = true;
                    _Entidad._contenido_mensaje = Msg_respuesta;

                }
                finally
                {
                    cn.Close();
                }
            }
            return _Entidad;

        }

        //OBTENEMOS LOS LOCALES QUE POSEE UNA COTIZACION
        public ET_entidad get_001(ET_R27 _entity_tr27)
        {

            string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr27Get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    _lista_et_m27 = new List<ET_M27>();
                    _lista_et_r27 = new List<ET_R27>();

                    cmd.Parameters.Add("@P_TR27_TM39_ID", SqlDbType.VarChar, 20).Value = _entity_tr27._TR27_TM39_ID;
                    cmd.Parameters.Add("@p_TR27_TM19_ID", SqlDbType.VarChar, 50).Value = _entity_tr27._TR27_TM19_ID;
                    cmd.Parameters.Add("@p_TR27_TM2_ID", SqlDbType.VarChar, 50).Value = _globales._TM2_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _et_r27 = new ET_R27();
                        _et_m27 = new ET_M27();

                        _et_r27._TR27_ID = Convert.ToInt32(fila["TR27_ID"].ToString());
                        _et_r27._TR27_TM39_ID = fila["TR27_TM39_ID"].ToString();
                        _et_r27._TR27_TM27_ID = fila["TR27_TM27_ID"].ToString();
                        _et_r27._TR27_DESCRIP = fila["TR27_DESCRIP"].ToString();
                        _et_r27._TR27_ST = Convert.ToInt32(fila["TR27_ST"].ToString());
                        _et_r27._TR27_FLG_ELIMINADO = Convert.ToInt32(fila["TR27_FLG_ELIMINADO"].ToString());
                        _et_r27._TR27_UCREA = fila["TR27_UCREA"].ToString();
                        _et_r27._TR27_FCREA = Convert.ToDateTime(fila["TR27_FCREA"].ToString());
                        _et_r27._TR27_UACTUALIZA = fila["TR27_UACTUALIZA"].ToString();
                        _et_r27._TR27_FACTUALIZA = Convert.ToDateTime(fila["TR27_FACTUALIZA"].ToString());
                        _et_r27._TR27_TM19_ID = fila["TR27_TM19_ID"].ToString();
                        _et_r27._TR27_TM2_ID = fila["TR27_TM2_ID"].ToString();


                        _et_m27._TM27_ID = fila["TR27_TM27_ID"].ToString();
                        _et_m27._TM27_TM19_ID = fila["TR27_TM19_ID"].ToString();
                        _et_m27._TM27_TM2_ID = fila["TR27_TM2_ID"].ToString();
                        _et_m27._TM27_NOMBRE = fila["TR27_DESCRIP"].ToString();
                        _et_m27._TM27_DIRECCION = fila["TR27_TM27_DIRECCION"].ToString();

                        _lista_et_m27.Add(_et_m27);
                        _lista_et_r27.Add(_et_r27);
                    }

                    _Entidad._lista_et_r27 = _lista_et_r27;
                    _Entidad._lista_et_m27 = _lista_et_m27;
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
