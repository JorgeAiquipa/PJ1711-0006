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
    public class NT_M31
    {
        ET_entidad _entidad = new ET_entidad();
        DT_M31 _dt_m31 = new DT_M31();
        ET_M31 _et_m31 = new ET_M31();
        

        public ET_entidad gridTextBoxAutocomplete(TextBox _textbox)
        {
            _et_m31 = new ET_M31();
            _et_m31._filtro = _textbox.Text;
            var result = _dt_m31.filter_list(_et_m31);

            if (!result._hubo_error)
            {
                List<ET_M31> _lista_m31 = new List<ET_M31>();
                _lista_m31 = result._lista_et_m31.ToList();
                foreach (ET_M31 row in result._lista_et_m31.ToList())
                {
                    _textbox.AutoCompleteCustomSource.Add(row._TM31_DESCRIP);
                }
            }
            else
            {
                _entidad._hubo_error = true;
                _entidad._titulo_mensaje = "Alert!";
            }
            return result;
        }


        //public void get_001(DataGrid list_view)
        //{
        //    var result = _dt_m31.get_001();
        //    //if (!result._hubo_error)
        //    //{
        //    //    list_view.Items.Clear();

        //    //    foreach (ET_M31 fila in result._lista_et_m31)
        //    //    {
        //    //        string[] row =
        //    //        {
        //    //            fila._TM39_ID,
        //    //            fila._entity_et_m19._TM19_ID,
        //    //            fila._entity_et_m19._TM19_DESCRIP2,
        //    //            fila._entity_et_m19._TM19_DESCRIP1,
        //    //            fila._TM39_tm27_count.ToString(),
        //    //            fila._TM39_UCREA,
        //    //            fila._TM39_FCREA.ToString(),
        //    //            fila._TM39_FACTUALIZA.ToString()
        //    //        };
        //    //        list_view.Items.Add(new ListViewItem(row));
        //    //    }
        //    //}
        //}


    }
}
