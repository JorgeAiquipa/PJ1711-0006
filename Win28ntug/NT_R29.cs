using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
using Win32dtug;
namespace Win28ntug
{
    public class NT_R29
    {
        DT_R29 _dt_r29 = new DT_R29();
        public void set_001(ET_entidad obj)
        {

            foreach (ET_R29 row in obj._lista_et_r29)
            {
                ET_R29 _et_r29 = new ET_R29();
                _et_r29._TR29_TR28_ID = row._TR29_TR28_ID;
                _et_r29._TR29_TM38_ID = row._TR29_TM38_ID;
                _et_r29._TR29_HORA_ENTRADA = row._TR29_HORA_ENTRADA;
                _et_r29._TR29_HORA_SALIDA = row._TR29_HORA_SALIDA;
                _et_r29._TR29_DIAS_SEMANA = row._TR29_DIAS_SEMANA;

                var result = _dt_r29.set_001(_et_r29);
            }

        }
    }
}
