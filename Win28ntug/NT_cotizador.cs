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
    public class NT_cotizador
    {
        ET_entidad Entidad_ = new ET_entidad();

        #region Métodos
        // Ahora traemos y contruimos una lista de conceptos que tienen como padre un servicio
        /*
         * Servicio Padre
         *  Concepto 1
         *  Concepto 2
         *  Concepto n
         * */

        public DataSet Lista() //por default ** prueba
        {
            var respuesta = DT_CNX._DT_MAIN.TraerDataSet("SP_CONCEPTOS_DEFAULT");
            return respuesta;
        }
        #endregion

        #region Multitarea
        #endregion

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
