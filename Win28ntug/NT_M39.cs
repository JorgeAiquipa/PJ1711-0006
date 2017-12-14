using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win28etug;
using Win32dtug;
namespace Win28ntug
{
    public class NT_M39
    {
        DT_M39 _dt_m39 = new DT_M39();

        ET_entidad _entity = new ET_entidad();
        ET_M39 _et_m39 = new ET_M39();
        List<ET_M39> _lista_mt39 = new List<ET_M39>();

        public void set_001(ET_M39 obj)
        {
            var result = _dt_m39.set_001(obj);
        }

        public void get_001(DataGridView gridview)
        {
            var result = _dt_m39.get_001();

            if (!result._hubo_error)
            {
                gridview.DataSource = result._lista_et_m39.ToList();
            }
        }
        
    }
}
