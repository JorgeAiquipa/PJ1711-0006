using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win28etug
{
    public class ET_M40
    {

        public string _TM40_ID { get; set; }
        public string _TM40_DESCRIP { get; set; }
        public string _TM40_DESCRIP2 { get; set; }
        public int _TM40_ST { get; set; }
        public string _TM40_UCREA { get; set; }
        public DateTime _TM40_FCREA { get; set; }
        public string _TM40_UACTUALIZA { get; set; }
        public DateTime _TM40_FACTUALIZA { get; set; }
        public string _TM40_ABREV { get; set; }

        public string _Filtro { get; set; }
        public bool _Seleccionado { get; set; }
        public decimal _TM40_IMPORTE { get; set; }
        public decimal _TM40_PORCENTAJE { get; set; }
        public string _Work { get; set; } // P -> PORCENTAJE , I -> IMPORTE
        public int _fila { get; set; }
    }
}
