﻿using System;
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
    public class DT_R29
    {

        ET_globales _global = new ET_globales();
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_R29 _etr29 = new ET_R29();
        List<ET_R29> _lista_r29 = new List<ET_R29>();

        public ET_entidad get_001(ET_R29 objEntity)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tr29get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    _lista_r29 = new List<ET_R29>();

                    cmd.Parameters.Add("@p_TR29_TR28_ID", SqlDbType.VarChar, 10).Value = objEntity._TR29_TR28_ID;
                    cmd.Parameters.Add("@p_TR29_TM2_ID", SqlDbType.VarChar, 50).Value = _global._TM2_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _etr29 = new ET_R29();

                        _etr29._TR29_ID = Convert.ToInt32(fila["TR29_ID"].ToString());
                        _etr29._TR29_TR28_ID = Convert.ToInt32(fila["TR29_TR28_ID"].ToString());
                        _etr29._TR29_TM38_ID = fila["TR29_TM38_ID"].ToString();
                        _etr29._TR29_HORA_ENTRADA = Convert.ToDateTime(fila["TR29_HORA_ENTRADA"].ToString());
                        _etr29._TR29_HORA_SALIDA = Convert.ToDateTime(fila["TR29_HORA_SALIDA"].ToString());
                        _etr29._TR29_DIAS_SEMANA = Convert.ToInt32(fila["TR29_DIAS_SEMANA"].ToString());
                        _etr29._TR29_DESCRIP = fila["TR29_DESCRIP"].ToString();
                        //_etr29._TR29_ST = fila["TR29_ST"].ToString();
                        //_etr29._TR29_FLG_ELIMINADO = fila["TR29_FLG_ELIMINADO"].ToString();
                        //_etr29._TR29_UCREA = fila["TR29_UCREA"].ToString();
                        //_etr29._TR29_FCREA = fila["TR29_FCREA"].ToString();
                        //_etr29._TR29_UACTUALIZA = fila["TR29_UACTUALIZA"].ToString();
                        //_etr29._TR29_FACTUALIZA = fila["TR29_FACTUALIZA"].ToString();
                        //_etr29._TR29_REMUNERACION = fila["TR29_REMUNERACION"].ToString();
                        //_etr29._TR29_TM2_ID = fila["TR29_TM2_ID"].ToString();

                        _lista_r29.Add(_etr29);
                    }

                    _Entidad._lista_et_r29 = _lista_r29;
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

        //registramos los cargos
        public ET_entidad set_001(ET_R29 objEntity)
        {
            _Entidad = new ET_entidad();
            _Entidad._entity_r28 = new ET_R28();

            string Msg_respuesta;

            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_set54", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@P_MENSAJE_RESPUESTA", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@p_TR29_ID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@p_TR29_TR28_ID", SqlDbType.Int).Value = objEntity._TR29_TR28_ID;
                    cmd.Parameters.Add("@p_TR29_TM38_ID", SqlDbType.VarChar, 300).Value = objEntity._TR29_TM38_ID;
                    cmd.Parameters.Add("@p_TR29_DESCRIP", SqlDbType.VarChar, 300).Value = objEntity._TR29_DESCRIP;
                    cmd.Parameters.Add("@p_TR29_HORA_ENTRADA", SqlDbType.DateTime ).Value = objEntity._TR29_HORA_ENTRADA;
                    cmd.Parameters.Add("@p_TR29_HORA_SALIDA", SqlDbType.DateTime ).Value = objEntity._TR29_HORA_SALIDA;
                    cmd.Parameters.Add("@p_TR29_DIAS_SEMANA", SqlDbType.Int).Value = objEntity._TR29_DIAS_SEMANA;
                    cmd.Parameters.Add("@p_TR29_UCREA", SqlDbType.VarChar, 20).Value = _global._U_CREA;
                    cmd.Parameters.Add("@p_TR29_TM2_ID", SqlDbType.VarChar, 20).Value = _global._TM2_ID;

                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();

                    Msg_respuesta = cmd.Parameters["@P_MENSAJE_RESPUESTA"].Value.ToString();

                    _Entidad._entity_r29._TR29_ID = Convert.ToInt32(cmd.Parameters["@p_TR29_ID"].Value.ToString());
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

        ////

    }
}

