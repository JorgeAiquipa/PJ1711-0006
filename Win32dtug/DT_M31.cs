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
    public class DT_M31
    {

        ET_globales _global = new ET_globales();
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_M31 _etm31 = new ET_M31();
        List<ET_M31> _lista_m31 = new List<ET_M31>();

        //OBTENER LA LISTA DE CARGOS 

        public ET_entidad filter_list(ET_M31 objEntity)
        {

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGAP.Properties.Settings.ConectionString"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_tm31_get_001", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    _lista_m31 = new List<ET_M31>();

                    cmd.Parameters.Add("@p_TM31_TM2_ID", SqlDbType.VarChar, 50).Value = _global._TM2_ID;
                    cmd.Parameters.Add("@p_filtro", SqlDbType.VarChar, 50).Value = objEntity._filtro;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        _etm31 = new ET_M31();

                        _etm31._TM31_ID = fila["TM31_ID"].ToString(); //CODIGO
                        _etm31._TM31_TM2_ID = fila["TM31_TM2_ID"].ToString();
                        _etm31._TM31_DESCRIP = fila["TM31_DESCRIP"].ToString(); //NOMBRE

                        _etm31._TM31_TM33_ID = fila["TM31_TM33_ID"].ToString(); //MARCA
                        _etm31._TM31_TM72_ID = fila["TM31_TM72_ID"].ToString(); //UND
                        _etm31._TM31_PRECIO = fila["TM31_PRECIO"].ToString(); //PRECIO UNITARIO
                        _etm31._TM31_TM34_ID = fila["TM31_TM34_ID"].ToString(); //CATEGORIA,TIPO
                        //_etm31._TM31_UCREA = fila["TM31_UCREA"].ToString();
                        //_etm31._TM31_FCREA = fila["TM31_FCREA"].ToString();
                        //_etm31._TM31_UACTUALIZA = fila["TM31_UACTUALIZA"].ToString();
                        //_etm31._TM31_FACTUALIZA = fila["TM31_FACTUALIZA"].ToString();

                        _lista_m31.Add(_etm31);
                    }
                    _Entidad._lista_et_m31 = _lista_m31;
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
