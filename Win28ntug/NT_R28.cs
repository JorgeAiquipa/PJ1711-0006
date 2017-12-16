using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
using Win32dtug;

namespace Win28ntug
{
    public class NT_R28
    {
        ET_entidad _entidad = new ET_entidad();
        ET_R28 _et_r28 = new ET_R28();
        DT_R28 _dt_r28 = new DT_R28();

        //Registramos el servicio seleccionado para una cotizacion

        public ET_entidad set_001(ET_R28 objEntity)
        {
            return _dt_r28.set_001(objEntity); ;
        }
    }
}
