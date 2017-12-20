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
    public class NT_M19 //: ET_generic<ET_M19>
    {
        ET_entidad _entidad = new ET_entidad();
        ET_M19 _et_m19;
        ET_M27 _et_m27;
        List<ET_M19> _lista_m19 = new List<ET_M19>();
        List<ET_M27> _lista_m27 = new List<ET_M27>();

        DT_M19 _dt_m19 = new DT_M19();

        public void txt_autocomplete(TextBox _textbox)
        {

            _et_m19 = new ET_M19();
            _et_m19._filtro = _textbox.Text.ToString();

            var result = _dt_m19.filter_001(_et_m19);

            int index = 1;
            if (!result._hubo_error)
            {
                _lista_m19 = result._lista_et_m19.ToList();
                foreach (ET_M19 row in result._lista_et_m19.ToList())
                {
                    _textbox.AutoCompleteCustomSource.Add(row._TM19_DESCRIP2);
                    index++;
                }

            }
            else
            {
                _entidad._contenido_mensaje = result._contenido_mensaje;
                Mensaje(_entidad);
            }


        }

        public ET_M19 sel_001(string cliente)
        {
            _et_m19 = new ET_M19();


            try
            {
                var where_lista = _lista_m19.Where(p => p._TM19_DESCRIP2 == cliente).ToList();
                foreach (ET_M19 unique_row in where_lista)
                {
                    _et_m19._TM19_ID = unique_row._TM19_ID;
                    _et_m19._TM19_DESCRIP1 = unique_row._TM19_DESCRIP1;
                    _et_m19._TM19_DESCRIP2 = unique_row._TM19_DESCRIP2;
                    _et_m19._TM19_TM2_ID = unique_row._TM19_TM2_ID;
                }
            }
            catch (Exception ex)
            {           }

            if (string.IsNullOrEmpty(_et_m19._TM19_ID))
            {
                _entidad._hubo_error = true;
                _entidad._titulo_mensaje = "Alert!";
                string msg = string.Format("Porfavor seleccione un cliente especifico.\nEl cliente {0} no existe.", cliente);
                _entidad._contenido_mensaje = msg;
                Mensaje(_entidad);
            }
            return _et_m19;
        }

        //obtener lista de locales


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
