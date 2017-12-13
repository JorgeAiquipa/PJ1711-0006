using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
namespace Win32dtug
{
    public class DT_M41 //: ET_generic<ET_M41>
    {
        ET_globales _global = new ET_globales();
        ET_entidad _entidad = new ET_entidad();
        ET_M41 _et_m41;
        List<ET_M41> _lista_mtm41 = new List<ET_M41>();

        public ET_entidad get_001()
        {

            try
            {
                DT_CNX.Abrir_conexion();
                DataTable result = DT_CNX._DT_MAIN.TraerDataTable_("pa_tm41_get_001",  _global._TM2_ID);

                foreach (DataRow fila in result.Rows)
                {
                    _et_m41 = new ET_M41();

                    _et_m41._TM41_ID = Convert.ToInt32(fila["TM41_ID"].ToString());
                    _et_m41._TM41_TM2_ID = fila["TM41_TM2_ID"].ToString();
                    _et_m41._TM41_DESCRIP = fila["TM41_DESCRIP"].ToString();
                    //_et_m41._TM41_UCREA = fila["TM41_UCREA"].ToString();
                    //_et_m41._TM41_FCREA = fila["TM41_FCREA"].ToString();
                    //_et_m41._TM41_UACTUALIZA = fila["TM41_UACTUALIZA"].ToString();
                    //_et_m41._TM41_FACTUALIZA = fila["TM41_FACTUALIZA"].ToString();

                    _lista_mtm41.Add(_et_m41);
                }
                DT_CNX.Cerrar_conexion();

                _entidad._hubo_error = false;
                _entidad._lista_et_m41 = _lista_mtm41;

            }
            catch (Exception ex)
            {

                _entidad._hubo_error = true;
                _entidad._contenido_mensaje = "OCURRIO UN ERROR";
            }

            return _entidad;
        }
    }
}
