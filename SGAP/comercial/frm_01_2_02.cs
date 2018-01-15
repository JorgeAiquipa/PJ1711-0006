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

        #region Instancias
        public ET_entidad _entidad = new ET_entidad();
        ET_globales globales = new ET_globales();
        ET_M41 _et_m41 = new ET_M41();
        NT_M42 _nt_m42 = new NT_M42();
        NT_M41 _nt_m41 = new NT_M41();
        NT_R28 _nt_r28 = new NT_R28();
        List<ET_M41> _lista_m41 = new List<ET_M41>();
        List<ET_R28> _lista_r28 = new List<ET_R28>();
        List<ET_M42> _lista_m42 = new List<ET_M42>();
        List<ET_R19> _lista_R19 = new List<ET_R19>();
        #endregion

        #region Variables
        public int Id_Servicio_Padre;
        public string tm39_id;
        public int id_Servicio_seleccionado;
        public string Nombre_Servicio_seleccionado;
        public int Periodo_servicio;
        string nombre_tipo_servicio;

        string nodo_tipo;

        int Id_Servicio_hijo;
        #endregion

        #region Métodos
        public frm_01_2_02(int __id_Servicio_hijo, int __id_Servicio_padre, int _periodo_servicio, string _tm39_id, string nodos)
        {
            InitializeComponent();
            Id_Servicio_hijo = __id_Servicio_hijo;
            Id_Servicio_Padre = __id_Servicio_padre;
            Periodo_servicio = _periodo_servicio;
            tm39_id = _tm39_id;
            nodo_tipo = nodos;
            label10.BackColor = Color.FromArgb(0, 137, 123);
            label10.ForeColor = Color.White;
            label10.Text = Text;
            Metodo_obtener_tipo_servicio();

            //Metodo_cargar_frecuencias();
        }

        void Metodo_obtener_tipo_servicio()
        {
            var resultado_ = _nt_m42.get_001();
            if (resultado_ != null)
            {
                _lista_m42 = resultado_._lista_et_m42;

                _lista_m42.ForEach(x=> {
                    if (Convert.ToInt32(nodo_tipo) > 1)
                    {
                        cb_tipo.Items.Add(x._TM42_DESCRIP);
                    }
                    else
                    {
                        if (x._TM42_ID != Convert.ToInt32(nodo_tipo))
                        {
                            cb_tipo.Items.Add(x._TM42_DESCRIP);
                        }
                    }           
                });
                cb_tipo.SelectedIndex = 0;
            }
        }
        void Metodo_obtener_servicios_por_tipo(ET_M41 entidad)
        {
            cbx_servicio.Items.Clear();
            var resultado = _nt_m41.get_001(entidad);
            if (resultado != null)
            {
                _lista_R19 = new List<ET_R19>();
                _lista_R19 = resultado._lista_et_r19;
                if (_lista_R19.Count > 0)
                {
                    cbx_servicio.Enabled = true;
                    num_frecuencia.Enabled = true;

                    _lista_R19.ForEach(x =>
                    {
                        cbx_servicio.Items.Add(x._TR19_TM41_DESCRIP);
                    });

                    cbx_servicio.SelectedIndex = 0;
                }
                else
                {
                    cbx_servicio.Text = string.Empty;
                    cbx_servicio.Enabled = false;
                    num_frecuencia.Enabled = false;
                }
            }

        }

        #endregion

        #region Eventos
        private void btn_continuar_Click(object sender, EventArgs e)
        {
            Nombre_Servicio_seleccionado = cbx_servicio.Text;
            string frecuencia = num_frecuencia.Text;

            if (cb_tipo.Text != "")
            {
                if (Nombre_Servicio_seleccionado!= "")
                {

                        ET_R19 servicio = _lista_R19.FirstOrDefault(gg => gg._TR19_TM41_DESCRIP == Nombre_Servicio_seleccionado);

                        //agregar servicio nuevo
                        _entidad._entity_r28._TR28_PADRE = Id_Servicio_Padre;
                        _entidad._entity_r28._TR28_TM39_ID = tm39_id;
                        _entidad._entity_r28._TR28_TM41_ID = servicio._TR19_TM41_ID;
                        _entidad._entity_r28._TR28_DESCRIP = Nombre_Servicio_seleccionado;
                        _entidad._entity_r28._TR28_PERIODO = Periodo_servicio;

                        _entidad._entity_r28._TR28_FRECUENCIA = Convert.ToInt32(frecuencia);
                        //tipo
                        //frecuencia

                        _nt_r28.set_002(_entidad);

                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        DialogResult decision_msg = MessageBox.Show("Seleccione un servicio.", "Cotizador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (decision_msg == DialogResult.OK) { }
                    }
                }
                else
                {
                    DialogResult decision_msg = MessageBox.Show("Seleccione un tipo de servicio.", "Cotizador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (decision_msg == DialogResult.OK) { }
                }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombre_tipo_servicio = cb_tipo.Text;
            ET_M42 entidad_m42 = _lista_m42.FirstOrDefault(x => x._TM42_DESCRIP == nombre_tipo_servicio);
            ET_M41 entidad_m41 = new ET_M41();
            entidad_m41._TM41_TM42_ID = entidad_m42._TM42_ID;
            //Listar los servicios de acuerdo al tipo seleccionado
            Metodo_obtener_servicios_por_tipo(entidad_m41);
        }

        private void num_frecuencia_ValueChanged(object sender, EventArgs e)
        {
            if (num_frecuencia.Value == 1)
                label5.Text = "mes";
            else
                label5.Text = "meses";
        }

        #endregion


    }
}
