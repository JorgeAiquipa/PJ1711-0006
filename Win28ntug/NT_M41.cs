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
    public class NT_M41 
    {
        ET_entidad _entidad = new ET_entidad();
        DT_M41 _dt_m41 = new DT_M41();
        List<ET_M41> _lista_tm41 = new List<ET_M41>();


        public ET_entidad get_001() //obtener lista de servicios
        {
            var resultado = _dt_m41.get_001();

            if (resultado._hubo_error)
            {
                _entidad = resultado;
                _entidad._titulo_mensaje = "Título";
                Mensaje(_entidad);
            }
            else
            {
                _entidad._lista_et_m41 = resultado._lista_et_m41.ToList();
            }

            return _entidad;
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
