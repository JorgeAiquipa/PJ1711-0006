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


        public ET_entidad set_001(ET_R28 objEntity)
        {
            _Entidad = new ET_entidad();
            _Entidad._entity_r28= new ET_R28();

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
                    //cmd.Parameters.Add("@p_TM39_DESCRIP", SqlDbType.VarChar, 300).Value = objEntity._TM39_DESCRIP;
                    //cmd.Parameters.Add("@p_TM39_UCREA", SqlDbType.VarChar, 20).Value = _global._U_CREA;
                    //cmd.Parameters.Add("@p_TM39_TM19_ID", SqlDbType.VarChar, 10).Value = objEntity._TM39_TM19_ID;
                    //cmd.Parameters.Add("@p_TM39_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    cmd.ExecuteNonQuery();
                    sqlTran.Commit();

                    Msg_respuesta = cmd.Parameters["@p_Mensaje"].Value.ToString();

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
