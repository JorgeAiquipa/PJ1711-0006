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
    public class NT_M38
    {
        ET_entidad _entidad = new ET_entidad();
        DT_M38 _dt_m38 = new DT_M38();
        ET_M38 _et_m38 = new ET_M38();
        List<ET_M38> _lista_et_m38 = new List<ET_M38>(); //lista de cargos
        

        public List<ET_M38> TexBox_Cargo(TextBox _textbox)
        {
            _et_m38 = new ET_M38();
            _et_m38._filtro = "";//_textbox.Text.ToString();

            var result = _dt_m38.filter_list(_et_m38);

            if (!result._hubo_error)
            {
                _textbox.AutoCompleteCustomSource.Clear();
                _lista_et_m38 = new List<ET_M38>();
                _lista_et_m38 = result._lista_et_m38.ToList();
                foreach (ET_M38 row in result._lista_et_m38.ToList())
                {
                    _textbox.AutoCompleteCustomSource.Add(row._TM38_DESCRIP);
                }
            }
            else
            {
                _entidad = result;
                Mensaje(_entidad);
            }


            return _lista_et_m38;

        }


        #region Mensaje
        protected virtual void Mensaje(ET_entidad e)
        {
            EventHandler<ET_entidad> handler = Mensaje_Alerta;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<ET_entidad> Mensaje_Alerta;
        #endregion
    }
}
