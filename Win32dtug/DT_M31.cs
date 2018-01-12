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
        
        //get002 //listar MQ EQ

        public ET_entidad filter_list(ET_M31 objEntity) //get001 //obtener productos
        {

            string Mensaje_error = "";

           DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_cnx.conexion))
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
