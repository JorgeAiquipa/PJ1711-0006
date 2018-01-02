/**
 * Description: daoConexion.
 * Version: 1.0.0
 * Last update: 2017/12/11
 * Author: User Name <cesar.freitas@actecperu.com>
 *
   ========================================================================== */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win28etug
{
    public delegate void MensajeEventHandler(Object sender, ET_entidad e);
    public class ET_entidad: EventArgs
    {
        public string _titulo_mensaje { get; set; }
        public string _contenido_mensaje { get; set; }
        public bool _hubo_error { get; set; }
        public string _Filtro { get; set; }

        public List<ET_servicio> _servicio { get; set; }


        public List<ET_M19> _lista_et_m19 { get; set; }
        public List<ET_M27> _lista_et_m27 { get; set; }
        public List<ET_M41> _lista_et_m41 { get; set; }
        public List<ET_M38> _lista_et_m38 { get; set; }
        public List<ET_M39> _lista_et_m39 { get; set; }
        public List<ET_M40> _lista_et_m40 { get; set; }
        public List<ET_M42> _lista_et_m42 { get; set; } //DIEGO
        public List<ET_R28> _lista_et_r28 { get; set; }
        public List<ET_R29> _lista_et_r29 { get; set; }
        public List<ET_R27> _lista_et_r27 { get; set; }
        public List<ET_M31> _lista_et_m31 { get; set; }        
        public List<ET_R19> _lista_et_r19 { get; set; }



        public ET_M19 _entity_m19 { get; set; }
        public ET_M41 _entity_m41 { get; set; }
        public ET_M39 _entity_m39 { get; set; }
        public ET_R29 _entity_r29 { get; set; }
        public ET_R28 _entity_r28 { get; set; }
        public ET_R27 _entity_r27 { get; set; }
        public ET_R19 _entity_r19 { get; set; }

        public ET_entidad()
        {
            _entity_r29 = new ET_R29();
            _entity_r28 = new ET_R28();
            _entity_r27 = new ET_R27();
            _entity_m39 = new ET_M39();
            _entity_r19 = new ET_R19();
            _Filtro = "";
        }
    }
 
}
