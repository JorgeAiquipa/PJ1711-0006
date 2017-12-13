using System;
using System.Collections.Generic;
using System.Data;
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
        ET_M27 _etm27 = new ET_M27();
        List<ET_M27> _lista = new List<ET_M27>();

        public ET_entidad sel_001(ET_M19 objEntity)
        {
            try
            {
                DT_CNX.Abrir_conexion();

                DataTable result = DT_CNX._DT_MAIN.TraerDataTable_("pa_tm27_sel_001", objEntity._TM19_ID);

                foreach (DataRow fila in result.Rows)
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


                DT_CNX.Cerrar_conexion();
                _Entidad._lista_et_m27 = _lista;
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
