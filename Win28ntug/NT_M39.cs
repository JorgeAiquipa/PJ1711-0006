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
    public class NT_M39
    {
        DT_M39 _dt_m39 = new DT_M39();
        DT_R27 _dt_r27 = new DT_R27();
        DT_R28 _dt_r28 = new DT_R28();

        ET_globales _globales = new ET_globales();
        ET_entidad _entity = new ET_entidad();
        public ET_M39 _et_m39 = new ET_M39();
        ET_M27 _et_m27 = new ET_M27();
        ET_R27 _et_r27 = new ET_R27();

        ET_R28 _et_r28 = new ET_R28();

        List<ET_M39> _lista_mt39 = new List<ET_M39>();

        public string set_001(ET_entidad _obj)
        {
            var result = _dt_m39.set_001(_obj._entity_m39);
            if (!result._hubo_error)
            {
                string codigo_cotizacion = result._entity_m39._TM39_ID;
                int cant_locales = _obj._lista_et_m27.Count;

                try
                {
                    foreach (ET_M27 row in _obj._lista_et_m27)
                    {
                        //registrar local por local
                        _et_r27 = new ET_R27();
                        _et_r27._TR27_TM39_ID = codigo_cotizacion;
                        _et_r27._TR27_TM27_ID = row._TM27_ID;
                        _et_r27._TR27_TM19_ID = _obj._entity_m19._TM19_ID;
                        _et_r27._TR27_TM2_ID = _globales._TM2_ID;
                        _et_r27._TR27_DESCRIP = row._TM27_NOMBRE;

                        _dt_r27.set_001(_et_r27);
                    }

                    _et_r28 = new ET_R28();
                    //registramos servicio padre
                    _et_r28._TR28_TM39_ID = codigo_cotizacion;
                    _et_r28._TR28_TM41_ID = _obj._entity_m41._TM41_ID;
                    _et_r28._TR28_PERIODO = _obj._entity_r28._TR28_PERIODO;
                    _et_r28._TR28_DESCRIP = _obj._entity_m41._TM41_DESCRIP;

                    _entity = _dt_r28.set_001(_et_r28);

                }
                catch (Exception ex)
                { }

                return codigo_cotizacion;
            }
            return "";
        }

        public void get_001(ListView list_view)
        {
            var result = _dt_m39.get_001();
            if (!result._hubo_error)
            {
                list_view.Items.Clear();

                foreach (ET_M39 fila in result._lista_et_m39)
                {
                    string[] row =
                    {
                        fila._TM39_ID,
                        fila._entity_et_m19._TM19_ID,
                        fila._entity_et_m19._TM19_DESCRIP2,
                        fila._entity_et_m19._TM19_DESCRIP1, 
                        fila._TM39_tm27_count.ToString(),
                        fila._TM39_UCREA,
                        fila._TM39_FCREA.ToString(),
                        //fila._TM39_FACTUALIZA.ToString()
                    };
                    list_view.Items.Add(new ListViewItem(row));
                }
            }
        }

        public void get_002(ListView list_view)
        {
            var result = _dt_m39.get_002(_et_m39);
            if (!result._hubo_error)
            {
                list_view.Items.Clear();

                foreach (ET_M39 fila in result._lista_et_m39)
                {
                    string[] row =
                    {
                        fila._TM39_ID,
                        fila._entity_et_m19._TM19_ID,
                        fila._entity_et_m19._TM19_DESCRIP2,
                        fila._entity_et_m19._TM19_DESCRIP1,
                        fila._TM39_tm27_count.ToString(),
                        fila._TM39_UCREA,
                        fila._TM39_FCREA.ToString(),
                        fila._TM39_FACTUALIZA.ToString()
                    };
                    list_view.Items.Add(new ListViewItem(row));
                }
            }
        }


    }
}
