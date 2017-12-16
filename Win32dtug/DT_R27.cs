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
        List<ET_R27> _lista_et_r27 = new List<ET_R27>();
    
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
    }
}
