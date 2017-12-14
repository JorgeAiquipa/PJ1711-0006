using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
namespace Win32dtug
{
    public class DT_M39
    {

        ET_globales _global = new ET_globales();
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_M39 _etm39 = new ET_M39();
        ET_M19 _et_m19 = new ET_M19();

        List<ET_M39> _lista_m39 = new List<ET_M39>();

        public ET_entidad set_001(ET_M39 objEntity)
        {
            try
            {
                DT_CNX.Abrir_conexion();

                var result = DT_CNX._DT_MAIN.TraerValorOutput("pa_tm39_set_001",
                        objEntity._TM39_DESCRIP,
                        objEntity._TM39_UCREA,
                        objEntity._TM39_TM19_ID,
                        _global._TM2_ID,
                        "@p_Mensaje"
                    );

                DT_CNX.Cerrar_conexion();
                _Entidad._hubo_error = false;

            }
            catch (Exception ex)
            {
                _Entidad._hubo_error = true;
                _Entidad._contenido_mensaje = "Ocurrio un error al ingresar Informacion en la base de datos.\n" + ex.ToString();
                _Entidad._titulo_mensaje = "Alert!";
            }

            return _Entidad;
        }

        public ET_entidad get_001()
        {
            try
            {
                DT_CNX.Abrir_conexion();

                DataTable result = DT_CNX._DT_MAIN.TraerDataTable_("pa_tm39_get_001",
                        _global._TM2_ID,
                        "@p_Mensaje"
                    );

                _lista_m39.Clear();

                foreach (DataRow fila in result.Rows)
                {
                    _etm39 = new ET_M39();

                    _etm39._TM39_ID = fila["TM39_ID"].ToString();
                    _etm39._TM39_DESCRIP = fila["TM39_DESCRIP"].ToString();
                    _etm39._TM39_ST = Convert.ToInt16(fila["TM39_ST"].ToString());
                    _etm39._TM39_FLG_ELIMINADO = fila["TM39_FLG_ELIMINADO"].ToString();
                    _etm39._TM39_UCREA = fila["TM39_UCREA"].ToString();
                    _etm39._TM39_FCREA = Convert.ToDateTime(fila["TM39_FCREA"].ToString());
                    _etm39._TM39_UACTUALIZA = fila["TM39_UACTUALIZA"].ToString();
                    _etm39._TM39_FACTUALIZA = Convert.ToDateTime(fila["TM39_FACTUALIZA"].ToString());
                    _etm39._TM39_TM19_ID = fila["TM39_TM19_ID"].ToString();
                    _etm39._TM39_TM2_ID = fila["TM39_TM2_ID"].ToString();

                    _etm39._TM19_DESCRIP1 = fila["TM19_DESCRIP1"].ToString();
                    _etm39._TM19_DESCRIP2 = fila["TM19_DESCRIP2"].ToString();
                    _etm39._TM19_ID = fila["TM19_ID"].ToString();

                    _lista_m39.Add(_etm39);
                }
                

                DT_CNX.Cerrar_conexion();
                _Entidad._lista_et_m39 = _lista_m39;
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
    }
}
