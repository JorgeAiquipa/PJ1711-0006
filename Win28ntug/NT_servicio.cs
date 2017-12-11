using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Win28etug;
using Win32dtug;

namespace Win28ntug
{
    public class NT_servicio
    {
        ET_entidad Entidad_ = new ET_entidad();
        DT_servicio daoServicio = new DT_servicio();

        public ET_entidad Listar()
        {
            var resultado =  daoServicio.get_list_of_services();

            if (resultado._hubo_error)
            {
                Entidad_ = resultado;
                Entidad_._titulo_mensaje = "Título";

                Mensaje(Entidad_);

                return Entidad_;
            }

            Entidad_._servicio = resultado._servicio.ToList();

            return Entidad_;

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
