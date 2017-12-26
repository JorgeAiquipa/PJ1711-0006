using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win28etug;
using Win32dtug;

namespace Win28ntug
{
    public class NT_M42
    {


        ET_entidad _entidad = new ET_entidad();
        DT_M42 _dt_m42 = new DT_M42();
        List<ET_M42> _lista_tm42 = new List<ET_M42>();


        public ET_entidad get_001() //obtener lista de tipo de servicios
        {
            var resultado = _dt_m42.get_001();

            if (resultado._hubo_error)
            {
                Mensaje(resultado);
                return null;
            }
            else
            {
                return resultado;
            }

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
