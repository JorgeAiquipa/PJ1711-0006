using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;

namespace Win32dtug
{
    public class DT_R27
    {
        DT_CNX _cnx = new DT_CNX();
        ET_entidad _Entidad = new ET_entidad();
        ET_globales _globales = new ET_globales();
        ET_R27 _et_r27 = new ET_R27();
        List<ET_R27> _lista_et_r27 = new List<ET_R27>();

        public bool set_001(ET_R27 _entity_tr27)
        {
            try
            {
                DT_CNX.Abrir_conexion();

                var result = DT_CNX._DT_MAIN.TraerValorOutput("pa_tr27_set_001",
                        _entity_tr27._TR27_TM39_ID,
                        _entity_tr27._TR27_TM27_ID,
                        _entity_tr27._TR27_TM19_ID,
                        _entity_tr27._TR27_TM2_ID,
                        _entity_tr27._TR27_DESCRIP,
                        _globales._U_CREA,
                        "@p_Mensaje_respuesta"
                    );

                DT_CNX.Cerrar_conexion();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
