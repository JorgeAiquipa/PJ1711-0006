using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Win28etug
{
    public class ET_M19
    {
        public delegate void MensajeEventHandler(Object sender, ET_M19 e);

        public string _TM19_ID { get; set; }
        public string _TM19_TM2_ID { get; set; }
        public string _TM19_TM75_ID { get; set; }
        public string _TM19_DESCRIP1 { get; set; }
        public string _TM19_DESCRIP2 { get; set; }
        public string _TM19_TM21_ID { get; set; }
        public string _TM19_UCREA { get; set; }
        public DateTime _TM19_FCREA { get; set; }
        public string _TM19_UACTUALIZA { get; set; }
        public DateTime _TM19_FACTUALIZA { get; set; }
        public string _filtro { get; set; }
        public DateTime _fecha_Inicio { get; set; }
        public DateTime _fecha_Fin { get; set; }

    }
}
