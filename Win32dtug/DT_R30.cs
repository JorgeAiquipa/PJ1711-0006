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
    public class DT_R30
    {
        ET_globales _global = new ET_globales();
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_R30 _etr30 = new ET_R30();
        List<ET_R30> _lista_r30 = new List<ET_R30>();

        // registramos los conceptos remunerativos de un cargo previamente registrado
        public ET_entidad set_001(ET_R30 objEntity)
        {
            _Entidad = new ET_entidad();

            string Mensaje_error;

            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_set53", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@P_MENSAJE_RESPUESTA", SqlDbType.VarChar, 2000).Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@p_TR30_TR29_ID", SqlDbType.Int).Value = objEntity._TR30_TR29_ID;
                    cmd.Parameters.Add("@p_TR30_TM40_ID", SqlDbType.VarChar, 10).Value = objEntity._TR30_TM40_ID;
                    cmd.Parameters.Add("@p_TR30_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    cmd.Parameters.Add("@p_TR30_DESCRIP", SqlDbType.VarChar, 300).Value = objEntity._TR30_DESCRIP;
                    cmd.Parameters.Add("@p_TR30_UCREA", SqlDbType.VarChar, 10).Value = _global._U_CREA;

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

        // obtenemos registros de los conceptos remunerativos que posee un cargo ya registrado

        public List<ET_R30> get_001( int TR29_ID)
        {
            _lista_r30 = new List<ET_R30>();

            //string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_sel102", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_TR29_ID", SqlDbType.Int).Value = TR29_ID;
                    cmd.Parameters.Add("@p_TM2_ID", SqlDbType.VarChar, 10).Value = _global._TM2_ID;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _etr30 = new ET_R30();
                        _etr30._TR30_ID = Convert.ToInt32(fila["TR30_ID"].ToString());
                        _etr30._TR30_TR29_ID = Convert.ToInt32(fila["TR30_TR29_ID"].ToString());
                        _etr30._TR30_TM40_ID = fila["TR30_TM40_ID"].ToString();
                        //_etr30._TR30_IMPORTE = Convert.ToDecimal(fila["TR30_IMPORTE"].ToString());
                        _etr30._TR30_DESCRIP = fila["TM40_DESCRIP"].ToString();

                        _lista_r30.Add(_etr30);
                    }

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
                    //Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + ex.Message.ToString()));
                    //if (ex.InnerException != null)
                    //    Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + "Inner exception: " + ex.InnerException.Message));
                    //Mensaje_error = string.Format("{1}{0}", Environment.NewLine, (Mensaje_error + "Stack trace: " + ex.StackTrace));

                    //_Entidad._hubo_error = true;
                    //_Entidad._contenido_mensaje = Mensaje_error;
                    //_Entidad._titulo_mensaje = "Error!";
                }
                finally
                {
                    cn.Close();

                }
                return _lista_r30;
            }
        }

    }
}
