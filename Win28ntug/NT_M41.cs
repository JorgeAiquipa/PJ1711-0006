﻿using System;
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

        public ET_entidad get_001(ET_M41 objEntity)
        {
            var result = _dt_m41.get_001(objEntity);
            if (result._hubo_error)
            {
                Mensaje(result);
                return null;
            }
            else
            {
                return result;
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
