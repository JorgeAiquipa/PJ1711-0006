﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win28etug
{
    public class ET_R29
    {
        public int _Fila { get; set; }
        public int _TR29_ID { get; set; }
        public int _TR29_TR28_ID { get; set; }
        public string _TR29_TM38_ID { get; set; }
        public DateTime _TR29_HORA_ENTRADA { get; set; }
        public DateTime _TR29_HORA_SALIDA { get; set; }
        public int _TR29_DIAS_SEMANA { get; set; }
        public string _TR29_DESCRIP { get; set; }
        public int _TR29_ST { get; set; }
        public int _TR29_FLG_ELIMINADO { get; set; }
        public string _TR29_UCREA { get; set; }
        public DateTime _TR29_FCREA { get; set; }
        public string _TR29_UACTUALIZA { get; set; }
        public DateTime _TR29_FACTUALIZA { get; set; }
        public Decimal _TR29_REMUNERACION { get; set; }
        public string _TR29_TM2_ID { get; set; }
        public int _HOURS_DAY { get; set; }
        public List<ET_M40> _lista_et_m40 { get; set; }
        public List<ET_R30> _lista_et_r30 { get; set; }
        public object[] _Locales_por_cargo_cantidad_personal { get; set; }
        public ET_R31 _et_r31 { get; set; }
        public ET_R29()
        {
            _TR29_HORA_ENTRADA = new DateTime(1900, 1, 1, hour: 7, minute: 0, second: 0);
            _TR29_HORA_SALIDA = new DateTime(1900, 1, 1, hour: 15, minute: 0, second: 0);
            _TR29_DIAS_SEMANA = 6;
            _TR29_REMUNERACION = 850;
            _lista_et_m40 = new List<ET_M40>();
            _lista_et_r30 = new List<ET_R30>();
            _et_r31 = new ET_R31();
        }
    }
}
