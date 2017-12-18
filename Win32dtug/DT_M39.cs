using System;
using System.Collections;
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
    public class DT_M39
    {

        ET_globales _global = new ET_globales();
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_M39 _etm39 = new ET_M39();
        ET_M19 _et_m19 = new ET_M19();

        List<ET_M39> _lista_m39 = new List<ET_M39>();

        //OBTENER LISTA DE COTIZACIONES
        public ET_entidad get_001()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm39get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_TM39_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    _lista_m39.Clear();

                    foreach (DataRow fila in dt.Rows)
                    {
                        _etm39 = new ET_M39();
                        _et_m19 = new ET_M19();

                        _etm39._TM39_ID = fila["TM39_ID"].ToString();
                        _etm39._TM39_DESCRIP = fila["TM39_DESCRIP"].ToString();
                        _etm39._TM39_ST = Convert.ToInt32(fila["TM39_ST"].ToString());
                        _etm39._TM39_FLG_ELIMINADO = fila["TM39_FLG_ELIMINADO"].ToString();
                        _etm39._TM39_UCREA = fila["TM39_UCREA"].ToString();
                        _etm39._TM39_FCREA = Convert.ToDateTime(fila["TM39_FCREA"].ToString());
                        _etm39._TM39_UACTUALIZA = fila["TM39_UACTUALIZA"].ToString();
                        _etm39._TM39_FACTUALIZA = Convert.ToDateTime(fila["TM39_FACTUALIZA"].ToString());
                        _etm39._TM39_TM19_ID = fila["TM39_TM19_ID"].ToString();
                        _etm39._TM39_TM2_ID = fila["TM39_TM2_ID"].ToString();
                        _etm39._TM39_tm27_count = Convert.ToInt32(fila["_TM39_tm27_count"].ToString());


                        _et_m19._TM19_DESCRIP1 = fila["TM19_DESCRIP1"].ToString();
                        _et_m19._TM19_DESCRIP2 = fila["TM19_DESCRIP2"].ToString();
                        _et_m19._TM19_ID = fila["TM19_ID"].ToString();

                        _etm39._entity_et_m19 = _et_m19;

                        _lista_m39.Add(_etm39);
                    }

                    _Entidad._lista_et_m39 = _lista_m39;
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
                    _Entidad._hubo_error = true;
                    _Entidad._contenido_mensaje = "Ocurrio un error al obetener Informacion de la base de datos.\n" + ex.ToString();
                    _Entidad._titulo_mensaje = "Alert!";
                }
                finally
                {
                    cn.Close();

                }
                return _Entidad;
            }
        }

        //OBTENER LISTA DE COTIZACIONES DE ACUERDOA A UN FILTRO
        public ET_entidad get_002(ET_M39 _entity_m39)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm39get_002", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {

                    cmd.Parameters.Add("@p_TM39_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    cmd.Parameters.Add("@p_tm19_filtro", SqlDbType.VarChar, 50).Value = _entity_m39._filtro;
                    cmd.Parameters.Add("@p_Fecha_Inicio", SqlDbType.DateTime).Value = _entity_m39._fecha_Inicio;
                    cmd.Parameters.Add("@p_Fecha_Fin", SqlDbType.DateTime).Value = _entity_m39._fecha_Fin;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    _lista_m39.Clear();

                    foreach (DataRow fila in dt.Rows)
                    {
                        _etm39 = new ET_M39();
                        _et_m19 = new ET_M19();

                        _etm39._TM39_ID = fila["TM39_ID"].ToString();
                        _etm39._TM39_DESCRIP = fila["TM39_DESCRIP"].ToString();
                        _etm39._TM39_ST = Convert.ToInt16(fila["TM39_ST"].ToString());
                        _etm39._TM39_FLG_ELIMINADO = fila["TM39_FLG_ELIMINADO"].ToString();
                        _etm39._TM39_UCREA = fila["TM39_UCREA"].ToString();
                        _etm39._TM39_FCREA = Convert.ToDateTime(fila["TM39_FCREA"].ToString());
                        _etm39._TM39_UACTUALIZA = fila["TM39_UACTUALIZA"].ToString();
                        _etm39._TM39_FACTUALIZA = Convert.ToDateTime(fila["TM39_FACTUALIZA"].ToString());
                        _etm39._TM39_TM19_ID = fila["TM39_TM19_ID"].ToString();
                        _etm39._TM39_TM2_ID = fila["TM39_TM2_ID"].ToString();
                        _etm39._TM39_tm27_count = Convert.ToInt32(fila["_TM39_tm27_count"].ToString());

                        _et_m19._TM19_DESCRIP1 = fila["TM19_DESCRIP1"].ToString();
                        _et_m19._TM19_DESCRIP2 = fila["TM19_DESCRIP2"].ToString();
                        _et_m19._TM19_ID = fila["TM19_ID"].ToString();

                        _etm39._entity_et_m19 = _et_m19;

                        _lista_m39.Add(_etm39);
                    }
                    _Entidad._lista_et_m39 = _lista_m39;
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
                    _Entidad._hubo_error = true;
                    _Entidad._contenido_mensaje = "Ocurrio un error al obetener Informacion de la base de datos.\n" + ex.ToString();
                    _Entidad._titulo_mensaje = "Alert!";
                }
                finally
                {
                    cn.Close();

                }
                return _Entidad;
            }
        }

        //REGISTRAR UNA COTIZACION
        public ET_entidad set_001(ET_M39 objEntity)
        {
            _Entidad = new ET_entidad();
            _Entidad._entity_m39 = new ET_M39();

            string Msg_respuesta;

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm39set_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_Mensaje", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@p_CodigoCotizacion", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@p_TM39_DESCRIP", SqlDbType.VarChar, 300).Value = objEntity._TM39_DESCRIP;
                    cmd.Parameters.Add("@p_TM39_UCREA", SqlDbType.VarChar, 20).Value = _global._U_CREA;
                    cmd.Parameters.Add("@p_TM39_TM19_ID", SqlDbType.VarChar, 10).Value = objEntity._TM39_TM19_ID;
                    cmd.Parameters.Add("@p_TM39_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();

                    Msg_respuesta = cmd.Parameters["@p_Mensaje"].Value.ToString();

                    _Entidad._hubo_error = false;
                    _Entidad._entity_m39._TM39_ID = cmd.Parameters["@p_CodigoCotizacion"].Value.ToString();
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
