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
    public class DT_M27
    {
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_globales _globales = new ET_globales();
        ET_M27 _etm27 = new ET_M27();
        List<ET_M27> _lista = new List<ET_M27>();
        //Obtener lista de locales que posee un cliente
        public ET_entidad sel_001(ET_M19 objEntity)
        {

            string Mensaje_error = "";

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm27_sel_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_TM27_TM19_ID", SqlDbType.VarChar, 10).Value = objEntity._TM19_ID;
                    cmd.Parameters.Add("@P_TM27_TM2_ID", SqlDbType.VarChar, 20).Value = _globales._TM2_ID;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    _lista = new List<ET_M27>();
                    _lista.Clear();
                    foreach (DataRow fila in dt.Rows)
                    {
                        _etm27 = new ET_M27();

                        _etm27._seleccionado = true;
                        _etm27._TM27_ID = fila["TM27_ID"].ToString();
                        _etm27._TM27_TM19_ID = fila["TM27_TM19_ID"].ToString();
                        _etm27._TM27_TM2_ID = fila["TM27_TM2_ID"].ToString();
                        _etm27._TM27_NOMBRE = fila["TM27_NOMBRE"].ToString();
                        _etm27._TM27_DIRECCION = fila["TM27_DIRECCION"].ToString();
                        //_etm27._TM27_TM9_DIST_CODIGO = fila["TM27_TM9_DIST_CODIGO"].ToString();
                        //_etm27._TM27_TM28_ID = Convert.ToInt32(fila["TM27_TM28_ID"]);
                        //_etm27._TM27_ST = Convert.ToInt32(fila["TM27_ST"].ToString());
                        //_etm27._TM27_FLG_ELIMINADO = Convert.ToInt32(fila["TM27_FLG_ELIMINADO"].ToString());
                        //_etm27._TM27_CODGREEM = fila["TM27_CODGREEM"].ToString();
                        //_etm27._TM27_UCREA = fila["TM27_UCREA"].ToString();
                        // _etm27._TM27_FCREA = Convert.ToDateTime(fila["TM27_FCREA"].ToString());
                        //_etm27._TM27_UACTUALIZA = fila["TM27_UACTUALIZA"].ToString();
                        //_etm27._TM27_FACTUALIZA = Convert.ToDateTime(fila["TM27_FACTUALIZA"].ToString());

                        _lista.Add(_etm27);
                    }

                    _Entidad._lista_et_m27 = _lista;
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
