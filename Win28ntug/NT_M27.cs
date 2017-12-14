using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
using Win32dtug;
namespace Win28ntug
{
    public class NT_M27 //: ET_generic<ET_M27>
    {
        DT_M27 _dtm27 = new DT_M27();

        public ET_entidad obtener_locales_por_cliente(ET_M19 objEntity)
        {
            return _dtm27.sel_001(objEntity);
        }

    }
}
