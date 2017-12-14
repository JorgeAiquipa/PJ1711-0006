using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
namespace Win32dtug
{
    public class DT_M38
    {

        ET_globales _global = new ET_globales();
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_M38 _etm38 = new ET_M38();
        List<ET_M38> _lista_m38 = new List<ET_M38>();

        //OBTENER LA LISTA DE CARGOS 

        public ET_entidad filter_list(ET_M38 objEntity)
        {
            try
            {
                DT_CNX.Abrir_conexion();

                DataTable result = DT_CNX._DT_MAIN.TraerDataTable_("pa_tm38_get_001", _global._TM2_ID, objEntity._filtro);

                foreach (DataRow fila in result.Rows)
                {
                    _etm38 = new ET_M38();

                    _etm38._TM38_ID = fila["TM38_ID"].ToString();
                    _etm38._TM38_TM2_ID = fila["TM38_TM2_ID"].ToString();
                    _etm38._TM38_DESCRIP = fila["TM38_DESCRIP"].ToString();
                    //_etm38._TM38_UCREA = fila["TM38_UCREA"].ToString();
                    //_etm38._TM38_FCREA = fila["TM38_FCREA"].ToString();
                    //_etm38._TM38_UACTUALIZA = fila["TM38_UACTUALIZA"].ToString();
                    //_etm38._TM38_FACTUALIZA = fila["TM38_FACTUALIZA"].ToString();

                    _lista_m38.Add(_etm38);
                }


                DT_CNX.Cerrar_conexion();
                _Entidad._lista_et_m38 = _lista_m38;
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
