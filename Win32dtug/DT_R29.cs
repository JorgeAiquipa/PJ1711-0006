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
    public class DT_R29
    {

        ET_globales _global = new ET_globales();
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_R29 _etm38 = new ET_R29();
        List<ET_R29> _lista_m38 = new List<ET_R29>();

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
                SqlCommand cmd = new SqlCommand("pa_tr29set_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@P_MENSAJE_RESPUESTA", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@p_TR29_TR28_ID", SqlDbType.Int).Value = objEntity._TR29_TR28_ID;
                    cmd.Parameters.Add("@p_TR29_TM38_ID", SqlDbType.VarChar, 300).Value = objEntity._TR29_TM38_ID;
                    cmd.Parameters.Add("@p_TR29_HORA_ENTRADA", SqlDbType.DateTime ).Value = objEntity._TR29_HORA_ENTRADA;
                    cmd.Parameters.Add("@p_TR29_HORA_SALIDA", SqlDbType.DateTime ).Value = objEntity._TR29_HORA_SALIDA;
                    cmd.Parameters.Add("@p_TR29_DIAS_SEMANA", SqlDbType.VarChar, 300).Value = objEntity._TR29_DIAS_SEMANA;
                    cmd.Parameters.Add("@p_TR29_UCREA", SqlDbType.VarChar, 300).Value = _global._U_CREA;
                    cmd.Parameters.Add("@p_TR29_TM2_ID", SqlDbType.VarChar, 20).Value = _global._TM2_ID;
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

        ////

    }
}

