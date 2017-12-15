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
    public class DT_M19 //: ET_generic<ET_M19>
    {
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_M19 _etm19 = new ET_M19();
        ET_M27 _etm27 = new ET_M27();
        List<ET_M19> _lista_m19 = new List<ET_M19>();
        List<ET_M27> _lista_m27 = new List<ET_M27>();
        /*
        public ET_entidad filter_list(ET_M19 objEntity)
        {
            try
            {
                DT_CNX.Abrir_conexion();

                DataTable result = DT_CNX._DT_MAIN.TraerDataTable_("pa_tm19_get_001", objEntity._filtro );

                foreach (DataRow fila in result.Rows)
                {
                    _etm19 = new ET_M19();
                    _etm19._TM19_DESCRIP1 = fila["TM19_DESCRIP1"].ToString();
                    _etm19._TM19_DESCRIP2 = fila["TM19_DESCRIP2"].ToString();
                    //_etm19.TM19_FACTUALIZA = fila["TM19_FACTUALIZA"].ToString();
                    //_etm19.TM19_FCREA = Convert.ToDateTime(fila["TM19_FCREA"].ToString());
                    _etm19._TM19_ID = fila["TM19_ID"].ToString();
                    _etm19._TM19_TM21_ID = fila["TM19_TM21_ID"].ToString();
                    _etm19._TM19_TM2_ID = fila["TM19_TM2_ID"].ToString();
                    _etm19._TM19_TM75_ID = fila["TM19_TM75_ID"].ToString();
                    //_etm19.TM19_UACTUALIZA = fila["TM19_UACTUALIZA"].ToString();
                    //_etm19.TM19_UCREA = fila["TM19_UCREA"].ToString();
                    _lista_m19.Add(_etm19);
                }


                DT_CNX.Cerrar_conexion();
                _Entidad._lista_et_m19 = _lista_m19;
                _Entidad._hubo_error = false;

            }
            catch (Exception ex)
            {
                _Entidad._hubo_error = true;
                _Entidad._contenido_mensaje = "Ocurrio un error al obetener Informacion de la base de datos.\n" + ex.ToString();
                _Entidad._titulo_mensaje = "Alert!";
            }

            return _Entidad;
        }
        */
        //OBTENER LISTA DE CLIENTES MEDIANTE UN FILTRO
        public ET_entidad filter_001(ET_M19 objEntity)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm19_get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cmd.Parameters.Add("@p_filtro", SqlDbType.VarChar, 50).Value = objEntity._filtro;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _etm19 = new ET_M19();
                        _etm19._TM19_DESCRIP1 = fila["TM19_DESCRIP1"].ToString();
                        _etm19._TM19_DESCRIP2 = fila["TM19_DESCRIP2"].ToString();
                        //_etm19.TM19_FACTUALIZA = fila["TM19_FACTUALIZA"].ToString();
                        //_etm19.TM19_FCREA = Convert.ToDateTime(fila["TM19_FCREA"].ToString());
                        _etm19._TM19_ID = fila["TM19_ID"].ToString();
                        _etm19._TM19_TM21_ID = fila["TM19_TM21_ID"].ToString();
                        _etm19._TM19_TM2_ID = fila["TM19_TM2_ID"].ToString();
                        _etm19._TM19_TM75_ID = fila["TM19_TM75_ID"].ToString();
                        //_etm19.TM19_UACTUALIZA = fila["TM19_UACTUALIZA"].ToString();
                        //_etm19.TM19_UCREA = fila["TM19_UCREA"].ToString();
                        _lista_m19.Add(_etm19);
                    }

                    _Entidad._lista_et_m19 = _lista_m19;
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

    }
}
