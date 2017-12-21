using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win28etug;
using Win32dtug;

namespace Win28ntug
{
    public class NT_M40
    {

        ET_entidad _entidad = new ET_entidad();
        DT_M40 _dt_m40 = new DT_M40();
        ET_M40 _et_m40 = new ET_M40();

        //obtenemos los conceptos remunerativos disponibles
        public ET_entidad get_001()
        {

            var result = _dt_m40.get_001();

            if (result._hubo_error)
            {
                _entidad = result;
                Mensaje(_entidad);
            }

            return result;
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
