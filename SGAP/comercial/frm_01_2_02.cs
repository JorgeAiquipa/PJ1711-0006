using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win28etug;
using Win28ntug;


namespace SGAP.comercial
{
    public partial class frm_01_2_02 : Form
    {
        public ET_entidad _entidad = new ET_entidad();
        ET_M41 _et_m41 = new ET_M41();
        NT_M41 _nt_m41 = new NT_M41();
        NT_R28 _nt_r28 = new NT_R28();
        List<ET_M41> _lista_m41 = new List<ET_M41>();

        public int Id_Servicio_Padre;
        public int tm39_id;
        public int id_Servicio_seleccionado;
        public string Nombre_Servicio_seleccionado;
        public int Periodo_servicio;

        //_entidad._entity_r28._TR28_PADRE = Id_Servicio_Padre;
        //_entidad._entity_r28._TR28_TM39_ID = tm39_id;
        //_entidad._entity_r28._TR28_TM41_ID = id_Servicio_seleccionado;
        //_entidad._entity_r28._TR28_DESCRIP = Nombre_Servicio_seleccionado;
        //_entidad._entity_r28._TR28_PERIODO = Periodo_servicio;

        int id_Servicio_hijo;
        public frm_01_2_02(int __id_Servicio_hijo)
        {
            InitializeComponent();
            id_Servicio_hijo = __id_Servicio_hijo;
            Metodo_obtener_tipo_servicio();

        }

        void Metodo_obtener_tipo_servicio()
        {
            this.cbx_tipo_servicio2.Items.Clear();
            var entidad = _nt_m41.get_001();

            if (!entidad._hubo_error)
            {
                _lista_m41 = entidad._lista_et_m41.ToList();
                foreach (ET_M41 row in entidad._lista_et_m41)
                {
                    this.cbx_tipo_servicio2.Items.Add(row._TM41_DESCRIP);
                }

                this.cbx_tipo_servicio2.SelectedIndex = 0;
            }

        }



        private void Item_servicio_click()
        {
            //int id_Servicio_seleccionado = Convert.ToInt32(cbx_tipo_servicio2.Name.ToString());
            string Nombre_Servicio_seleccionado = cbx_tipo_servicio2.Text;

            string tm39_id;

            if (string.IsNullOrEmpty(_entidad._entity_r27._TR27_TM39_ID))
                tm39_id = _entidad._entity_m39._TM39_ID;
            else
                tm39_id = _entidad._entity_r27._TR27_TM39_ID;

            //agregar servicio nuevo
            _entidad._entity_r28._TR28_PADRE = Id_Servicio_Padre;
            _entidad._entity_r28._TR28_TM39_ID = tm39_id;
            _entidad._entity_r28._TR28_TM41_ID = id_Servicio_seleccionado;
            _entidad._entity_r28._TR28_DESCRIP = Nombre_Servicio_seleccionado;
            _entidad._entity_r28._TR28_PERIODO = Periodo_servicio;

            _nt_r28.set_002(_entidad);

        }

        private void btn_continuar_Click(object sender, EventArgs e)
        {
            Item_servicio_click();
            this.DialogResult = DialogResult.OK;
        }
    }
}
