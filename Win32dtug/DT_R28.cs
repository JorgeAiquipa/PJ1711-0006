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
    public class DT_R28
    {
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_globales _globales = new ET_globales();
        ET_R28 _et_r28 = new ET_R28();
        List<ET_R28> _lista_et_r28 = new List<ET_R28>();


        // registramos el servicio padre
        public ET_entidad set_001(ET_R28 objEntity)
        {
            _Entidad = new ET_entidad();
            _Entidad._entity_r28= new ET_R28();

            string Msg_respuesta;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr28set_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_TR28_PADRE", SqlDbType.Int ).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@P_MENSAJE_RESPUESTA", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@p_TR28_TM39_ID", SqlDbType.VarChar, 300).Value = objEntity._TR28_TM39_ID;
                    cmd.Parameters.Add("@p_TR28_TM41_ID", SqlDbType.VarChar, 300).Value = objEntity._TR28_TM41_ID;
                    cmd.Parameters.Add("@p_TR28_DESCRIP", SqlDbType.VarChar, 300).Value = objEntity._TR28_DESCRIP;
                    cmd.Parameters.Add("@p_TR28_PERIODO", SqlDbType.VarChar, 300).Value = objEntity._TR28_PERIODO;
                    cmd.Parameters.Add("@p_TR28_UCREA", SqlDbType.VarChar, 300).Value = _globales._U_CREA;
                    cmd.Parameters.Add("@p_TR28_TM2_ID", SqlDbType.VarChar, 20).Value = _globales._TM2_ID;
                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();

                    Msg_respuesta = cmd.Parameters["@P_MENSAJE_RESPUESTA"].Value.ToString();

                    _Entidad._entity_r28._TR28_PADRE = Convert.ToInt32(cmd.Parameters["@p_TR28_PADRE"].Value.ToString());
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
        // registramos el servicio hijo

        public ET_entidad set_002(ET_R28 objEntity)
        {
            _Entidad = new ET_entidad();
            _Entidad._entity_r28 = new ET_R28();

            string Msg_respuesta;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr28set_002", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@P_MENSAJE_RESPUESTA", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@p_TR28_PADRE", SqlDbType.Int).Value = objEntity._TR28_PADRE;
                    cmd.Parameters.Add("@p_TR28_TM39_ID", SqlDbType.VarChar, 300).Value = objEntity._TR28_TM39_ID;
                    cmd.Parameters.Add("@p_TR28_TM41_ID", SqlDbType.Int).Value = objEntity._TR28_TM41_ID;//servicio
                    cmd.Parameters.Add("@p_TR28_DESCRIP", SqlDbType.VarChar, 300).Value = objEntity._TR28_DESCRIP;
                    cmd.Parameters.Add("@p_TR28_PERIODO", SqlDbType.Int).Value = objEntity._TR28_PERIODO;
                    cmd.Parameters.Add("@p_TR28_UCREA", SqlDbType.VarChar, 20).Value = _globales._U_CREA;
                    cmd.Parameters.Add("@p_TR28_TM2_ID", SqlDbType.VarChar, 50).Value = _globales._TM2_ID;
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
        //OBTENER LISTA DE SERVICIOS QUE POSEE UNA COTIZACIÓN
        public ET_entidad get_001(ET_R28 objEntity)
        {
            string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr28Get_002", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    _lista_et_r28 = new List<ET_R28>();

                    cmd.Parameters.Add("@P_TR28_TM39_ID", SqlDbType.VarChar, 10).Value = objEntity._TR28_TM39_ID;
                    cmd.Parameters.Add("@P_TR28_TM2_ID", SqlDbType.VarChar, 50).Value = _globales._TM2_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _et_r28 = new ET_R28();

                        _et_r28._TR28_ID = Convert.ToInt32(fila["TR28_ID"].ToString());
                        _et_r28._TR28_PADRE = Convert.ToInt32(fila["TR28_PADRE"].ToString());
                        _et_r28._TR28_TM39_ID = fila["TR28_TM39_ID"].ToString();
                        _et_r28._TR28_TM41_ID = Convert.ToInt32(fila["TR28_TM41_ID"].ToString());//servicio
                        _et_r28._TR28_PERIODO = Convert.ToInt32(fila["TR28_PERIODO"].ToString());
                        _et_r28._TR28_DESCRIP = fila["TR28_DESCRIP"].ToString();
                        _et_r28._TR28_ST = Convert.ToInt32(fila["TR28_ST"].ToString());
                        _et_r28._TR28_FLG_ELIMINADO = Convert.ToInt32(fila["TR28_FLG_ELIMINADO"].ToString());
                        _et_r28._TR28_UCREA = fila["TR28_UCREA"].ToString();
                        _et_r28._TR28_FCREA = Convert.ToDateTime(fila["TR28_FCREA"].ToString());
                        _et_r28._TR28_UACTUALIZA = fila["TR28_UACTUALIZA"].ToString();
                        _et_r28._TR28_FACTUALIZA = Convert.ToDateTime(fila["TR28_FACTUALIZA"].ToString());
                        _et_r28._TR28_TM2_ID = fila["TR28_TM2_ID"].ToString();

                        _lista_et_r28.Add(_et_r28);
                    }

                    _Entidad._lista_et_r28 = _lista_et_r28;
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

        ////
    }
}
