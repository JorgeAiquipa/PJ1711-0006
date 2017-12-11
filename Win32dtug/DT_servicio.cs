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
    public class DT_servicio 
    {
        List<ET_servicio> LISTA = new List<ET_servicio>();
        ET_entidad _Entidad = new ET_entidad();
        ET_servicio Entidad_servicio;


        public ET_entidad get_list_of_services()
        {
            DT_CNX.Abrir_conexion();

            try
            {
                var result = DT_CNX._DT_MAIN.TraerDataSet("pa_servicioejemplo", "@p_mensaje_respuesta");

                foreach (DataRow fila in result.Tables[0].Rows)
                {
                    Entidad_servicio = new ET_servicio();
                    Entidad_servicio._c_id = Int32.Parse(fila["C_ID"].ToString());
                    Entidad_servicio._c_nombre = fila["C_NOMBRE"].ToString();
                    Entidad_servicio._c_Estado = bool.Parse(fila["C_ESTADO"].ToString());
                    Entidad_servicio._c_default = bool.Parse(fila["C_DEFAULT"].ToString());
                    LISTA.Add(Entidad_servicio);
                }

                DT_CNX.Cerrar_conexion();
                _Entidad._servicio = LISTA;
                _Entidad._hubo_error = false;

            }
            catch (Exception ex)
            {
                _Entidad._hubo_error = true;
                _Entidad._contenido_mensaje = "Ocurrio un error al obetener Informacion de la base de datos.\n"+ ex.ToString();
                _Entidad._titulo_mensaje = "Alert!";
            }

            return _Entidad;
        }

        #region OBSOLETO
        public List<ET_servicio> get_01()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_sql"].ToString()))
            {
                cn.Open();
                SqlTransaction sqlTran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("pa_servicioejemplo", cn, sqlTran);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    //cmd.Parameters.Add("@TM2_ID", SqlDbType.VarChar).Value = _clse.TM19_TM2_ID;
                    //cmd.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
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

                }
                finally
                {
                    cn.Close();
                }
            }

            return LISTA;
        }

        #endregion

        public bool delete_01(ET_servicio objEntity)
        {
            throw new NotImplementedException();
        }

        public List<ET_servicio> filter_list(ET_servicio objEntity)
        {
            throw new NotImplementedException();
        }

        public bool insert_01(ET_servicio objEntity)
        {
            throw new NotImplementedException();
        }

        public ET_servicio search(ET_servicio objEntity)
        {
            throw new NotImplementedException();
        }

        public bool update_01(ET_servicio objEntity)
        {
            throw new NotImplementedException();
        }
    }
}
