using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win28etug
{
    public class ET_M39
    {
        public string _TM39_ID { get; set; }
        public string _TM39_DESCRIP { get; set; }
        public int _TM39_ST { get; set; }
        public string _TM39_FLG_ELIMINADO { get; set; }
        public string _TM39_UCREA { get; set; }
        public DateTime _TM39_FCREA { get; set; }
        public string _TM39_UACTUALIZA { get; set; }
        public DateTime _TM39_FACTUALIZA { get; set; }
        public string _TM39_TM19_ID { get; set; }
        public string _TM39_TM2_ID { get; set; }

        public ET_M19 _entity_et_m19 { get; set; }
        public string _TM19_ID { get; set; }
        public string _TM19_DESCRIP1 { get; set; }
        public string _TM19_DESCRIP2 { get; set; }
    }
}
