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
    public class NT_M31
    {
        ET_entidad _entidad = new ET_entidad();
        DT_M31 _dt_m31 = new DT_M31();
        ET_M31 _et_m31 = new ET_M31();
        

        public ET_entidad gridTextBoxAutocomplete(TextBox _textbox)
        {
            _et_m31 = new ET_M31();
            _et_m31._filtro = _textbox.Text;
            var result = _dt_m31.filter_list(_et_m31);

            if (!result._hubo_error)
            {
                List<ET_M31> _lista_m31 = new List<ET_M31>();
                _lista_m31 = result._lista_et_m31.ToList();
                foreach (ET_M31 row in result._lista_et_m31.ToList())
                {
                    //_textbox.AutoCompleteCustomSource.Add(row._TM31_DESCRIP + " " + row._TM31_TM33_ID + " " + row._TM31_TM72_ID);
                    _textbox.AutoCompleteCustomSource.Add(row._TM31_DESCRIP);
                }
            }
            else
            {
                _entidad._hubo_error = true;
                _entidad._titulo_mensaje = "Alert!";
            }
            return result;
        }


    }
}
