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
    public class DT_R31
    {
        ET_globales _global = new ET_globales();
        ET_entidad _Entidad = new ET_entidad();
        ET_R31 _et_r31 = new ET_R31();
        List<ET_R31> _lista_et_r31 = new List<ET_R31>();

        // REGISTRAMOS LOS DATOS DE MANO DE OBRA
        public ET_entidad set_001(ET_R31 objEntity)
        {
            _Entidad = new ET_entidad();

            string Mensaje_error;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr31_set_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@P_MENSAJE_RESPUESTA", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@p_TR31_TR29_ID", SqlDbType.Int).Value = objEntity._TR31_TR29_ID;
                    cmd.Parameters.Add("@p_TR31_TR27_ID", SqlDbType.Int).Value = objEntity._TR31_TR27_ID;
                    cmd.Parameters.Add("@p_TR31_TR28_ID", SqlDbType.Int).Value = objEntity._TR31_TR28_ID;
                    cmd.Parameters.Add("@p_TR31_CANT_PERSONAS", SqlDbType.Int).Value = objEntity._TR31_CANT_PERSONAS;
                    cmd.Parameters.Add("@p_TR31_DESCRIP", SqlDbType.VarChar, 3000).Value = objEntity._TR31_DESCRIP;
                    cmd.Parameters.Add("@p_TR31_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    cmd.Parameters.Add("@p_TR31_UCREA", SqlDbType.VarChar, 20).Value = _global._U_CREA;

                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();

                    _Entidad._hubo_error = false;
                }
                catch (SqlException exsql)
                {
                    Mensaje_error = exsql.Message;
                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Mensaje_error = exRollback.Message;
                    }

                    Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + exsql.Message.ToString()));
                    if (exsql.InnerException != null)
                        Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + "Inner exception: " + exsql.InnerException.Message));
                    Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + "Stack trace: " + exsql.StackTrace));

                    _Entidad._hubo_error = true;
                    _Entidad._contenido_mensaje = Mensaje_error;
                    _Entidad._titulo_mensaje = "Error!";

                }
                finally
                {
                    cn.Close();
                }
            }
            return _Entidad;

        }

        //OBTENER LISTA DE SERVICIO MANO DE OBRA
        public ET_entidad sel_001(ET_R31 objEntity)
        {
            string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr31_sel_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    _lista_et_r31 = new List<ET_R31>();
                                        
                    cmd.Parameters.Add("@p_TR31_TR28_ID", SqlDbType.Int).Value = objEntity._TR31_TR28_ID;
                    cmd.Parameters.Add("@p_TM2_ID", SqlDbType.VarChar, 10).Value = objEntity._TR31_TM2_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _et_r31 = new ET_R31();

                        _et_r31._TR31_ID = Convert.ToInt32(fila["TR31_ID"].ToString());
                        _et_r31._TR31_TR29_ID = Convert.ToInt32(fila["TR31_TR29_ID"].ToString());
                        _et_r31._TR31_TR27_ID = Convert.ToInt32(fila["TR31_TR27_ID"].ToString());
                        _et_r31._TR31_TR28_ID = Convert.ToInt32(fila["TR31_TR28_ID"].ToString());
                        _et_r31._TR31_CANT_PERSONAS = Convert.ToInt32(fila["TR31_CANT_PERSONAS"].ToString());
                        _et_r31._TR31_DESCRIP = fila["TR31_DESCRIP"].ToString();
                        _et_r31._TR31_TM2_ID = fila["TR31_TM2_ID"].ToString();
                        _et_r31._TR31_ST = Convert.ToInt32(fila["TR31_ST"].ToString());
                        _et_r31._TR31_FLG_ELIMINADO = Convert.ToInt32(fila["TR31_FLG_ELIMINADO"].ToString());
                        _et_r31._TR31_UCREA = fila["TR31_UCREA"].ToString();
                        _et_r31._TR31_FCREA = Convert.ToDateTime(fila["TR31_FCREA"].ToString());
                        _et_r31._TR31_UACTUALIZA = fila["TR31_UACTUALIZA"].ToString();
                        _et_r31._TR31_FACTUALIZA = Convert.ToDateTime(fila["TR31_FACTUALIZA"].ToString());

                        _lista_et_r31.Add(_et_r31);
                    }

                    _Entidad._lista_et_r31 = _lista_et_r31;
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

        //Actualizamos la contidad de personas de mano de obra//
        public ET_entidad set_002(ET_R31 objEntity)
        {
            _Entidad = new ET_entidad();
            _Entidad._entity_r28 = new ET_R28();

            string Msg_respuesta;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr31_set_002", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_TR31_ID", SqlDbType.Int).Value = objEntity._TR31_ID;
                    cmd.Parameters.Add("@p_TR31_CANT_PERSONAS", SqlDbType.Int).Value = objEntity._TR31_CANT_PERSONAS;
                    cmd.Parameters.Add("@p_TR31_UACTUALIZA", SqlDbType.Int).Value = objEntity._TR31_UACTUALIZA;
                    cmd.Parameters.Add("@p_TM2_ID", SqlDbType.VarChar, 10).Value = objEntity._TR31_TM2_ID;
                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();

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

    }
    }
