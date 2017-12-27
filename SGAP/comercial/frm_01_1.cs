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
    public partial class frm_01_1 : Form
    {
        public ET_entidad _entity = new ET_entidad();
        ET_M19 _et_m19 = new ET_M19();
        ET_M41 _et_m41 = new ET_M41();
        ET_M39 _et_m39 = new ET_M39();
        ET_R28 _et_r28 = new ET_R28();

        NT_M19 _nt_m19 = new NT_M19();
        NT_M27 _nt_m27 = new NT_M27();
        NT_M41 _nt_m41 = new NT_M41();
        NT_M39 _nt_m39 = new NT_M39();
        NT_R28 _nt_r28 = new NT_R28();

        List<ET_M27> _lista_m27 = new List<ET_M27>();
        List<ET_M41> _lista_m41 = new List<ET_M41>();
        List<ET_R19> _lista_R19 = new List<ET_R19>();

        #region Variables
        string _id_tm19;
        int _id_tm41;
        string nombre_cliente;
        string ruc_cliente;
        string tipo_servicio;
        string nombre_de_Servicio;
        int tipo_de_Servicio=1;//diego
        int cantidad_meses = 0;


        string _tm41_id;

        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

        #endregion

        #region Métodos
        public frm_01_1()
        {
            Color background = Color.FromArgb(248, 248, 248);
            //instancias
            InitializeComponent();

            _nt_m19.Mensaje_Alerta += Mensaje_alerta;
            _nt_m41.Mensaje_Alerta += Mensaje_alerta;

            //apariencia
            this.BackColor = background;
            dgv_informacion_locales.BackgroundColor = background;


            txt_nombre_cliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_nombre_cliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _nt_m19.txt_autocomplete(txt_nombre_cliente);

            Metodo_obtener_tipo_servicio();
            
        }
        void Metodo_obtener_tipo_servicio()
        {
            this.cbx_tipo_servicio.Items.Clear();
            ET_M41 _et_41 = new ET_M41();
            _et_41._TM41_TM42_ID = tipo_de_Servicio;
            var entidad = _nt_m41.get_001(_et_41);

            if (!entidad._hubo_error)
            {
                if (entidad._lista_et_r19 != null)
                {

                    _lista_R19 = entidad._lista_et_r19.ToList();
                    foreach (ET_R19 row in entidad._lista_et_r19)
                    {
                        this.cbx_tipo_servicio.Items.Add(row._TR19_TM41_DESCRIP);
                    }

                    this.cbx_tipo_servicio.SelectedIndex = 0;
                }
            }


        }
        void Metodo_obtener_informacion_ingresada()
        {
            //diego
            if (rb_tipo1.Checked == true)
            {
                tipo_de_Servicio = 1;//diego
                //tipo_de_Servicio = rb_tipo1.Text.ToString();//diego
            }
            else if (rb_tipo2.Checked == true)
            {
                tipo_de_Servicio = 4;//diego
                //tipo_de_Servicio = rb_tipo2.Text.ToString();//diego
            }//diego
            nombre_cliente = txt_nombre_cliente.Text;
            ruc_cliente = txt_ruc_cliente.Text;
            tipo_servicio = cbx_tipo_servicio.Text;
            /* contaremos las columnas llenas del gridview 
             * Solo aquellas que tengas los campos llenos
             * Se validara por cada campo ingresado
             */
            int filas_encontradas = dgv_informacion_locales.RowCount;
            cantidad_meses = Convert.ToInt16(nupd_periodo_de_servicio.Value);
        }
        #endregion

        #region Eventos

        static void Mensaje_alerta(object sender, ET_entidad e)
        {
            MessageBox.Show
            (
                e._contenido_mensaje, e._titulo_mensaje,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private void btn_continuar_Click(object sender, EventArgs e)
        {
            Metodo_obtener_informacion_ingresada();

            //DIEGO
            //informacion de locales seleccionados por el usuario
            _entity._lista_et_m27 = _lista_m27.Where(local => local._seleccionado == true).ToList();
            
            //seteamos informacion del cliente
            _et_m19._TM19_DESCRIP1 = ruc_cliente;
            _et_m19._TM19_DESCRIP2 = nombre_cliente;
            _et_m19._TM19_ID = _id_tm19;
            _entity._entity_m19 = _et_m19;

            //seteamos info del servicio seleccionado

            _et_m41._TM41_TM42_ID = tipo_de_Servicio;//diego

            _et_m41._TM41_DESCRIP = nombre_de_Servicio;
            _et_m41._TM41_ID = _id_tm41;
            _entity._entity_m41 = _et_m41;

            //informacion de la cotizacion a registrar
            _et_m39._TM39_DESCRIP = string.Format("{0} Para {1}", nombre_de_Servicio,nombre_cliente);//nombre de la cotizacion
            _et_m39._TM39_TM19_ID = _id_tm19;

            _entity._entity_m39 = _et_m39;
            _entity._entity_r28._TR28_PERIODO = Convert.ToInt32(nupd_periodo_de_servicio.Value);


            var result  = _nt_m39.set_001(_entity);

            _entity._entity_r28._TR28_PADRE = result._entity_r28._TR28_PADRE;
            _entity._entity_m39._TM39_ID = result._entity_m39._TM39_ID;
            _entity._entity_m39._entity_et_m19._TM19_ID = _id_tm19;
            _entity._entity_m39._entity_et_m19._TM19_DESCRIP2 = nombre_cliente; //razon social

            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Este evento valida lo que se ingresa en cada celda
        private void dgv_informacion_locales_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dgv_informacion_locales.Rows[e.RowIndex].IsNewRow)
            {
                String nombre_columna = dgv_informacion_locales.Columns[e.ColumnIndex].Name;
                String cabecra_columna = dgv_informacion_locales.Columns[e.ColumnIndex].HeaderText;
                // evitamos validad el boton de borrar local
                if (nombre_columna.Equals("header_btn_delete_row_dgv_Informacion_locales")) return;

                var msg = string.Format("El campo de nombre {0} esta vacio", cabecra_columna);

                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgv_informacion_locales.Rows[e.RowIndex].ErrorText = msg;
                    dgv_informacion_locales.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSalmon;
                    e.Cancel = true;
                    //dgv_informacion_locales.Rows.Remove(dgv_informacion_locales.Rows[dgv_informacion_locales.Rows.Count - 1]);
                }
            }

        }
        //Limpiamos el error luego de validar
        private void dgv_informacion_locales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv_informacion_locales.Rows[e.RowIndex].ErrorText = string.Empty;
            dgv_informacion_locales.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;


        }

        //Evento para borrar una fila seleccionada
        private void dgv_informacion_locales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgv_informacion_locales.Rows[e.RowIndex].IsNewRow)
            {
                String nombre_columna = dgv_informacion_locales.Columns[e.ColumnIndex].Name;
                DataGridView tabla_locales = (DataGridView)sender;
                if (nombre_columna.Equals("header_btn_delete_row_dgv_Informacion_locales"))
                {
                    DialogResult decision_msg = MessageBox.Show("¿Esta seguro de eliminar la fila?", "Alerta!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (decision_msg == DialogResult.OK)
                        tabla_locales.Rows.RemoveAt(e.RowIndex);

                }
            }
        }

        private void dgv_informacion_locales_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow fila_tabla = dgv_informacion_locales.CurrentRow;
            if (fila_tabla.IsNewRow) return;

            int columns_editables = dgv_informacion_locales.ColumnCount - 1;

            for (int a = 0; a < columns_editables; a++)
            {
                //if(fila_tabla.Cells.)
            }

        }

        void obtener_cliente_info()
        {
            //una vez que deja el control estar en focus
            // carga los locales del cliente
            try
            {
                var entidad_resultado = _nt_m19.sel_001(txt_nombre_cliente.Text);
                txt_ruc_cliente.Text = entidad_resultado._TM19_DESCRIP1.ToString();
                _id_tm19 = entidad_resultado._TM19_ID.ToString();

                _lista_m27.Clear();

                _lista_m27 = _nt_m27.obtener_locales_por_cliente(entidad_resultado)._lista_et_m27;

                dgv_informacion_locales.DataSource = _lista_m27.ToList();

                cbx_tipo_servicio.Focus();
            }
            catch (Exception ex)
            {

                try
                {
                    txt_ruc_cliente.Text = string.Empty;
                    txt_nombre_cliente.Focus();
                    dgv_informacion_locales.Rows.Clear();
                }
                catch (Exception ) { }

            }
        }
        #endregion

        private void txt_nombre_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                obtener_cliente_info();
            }

            if (e.KeyCode == Keys.Tab)
            {
                obtener_cliente_info();
            }
        }
        // cuando cambia el valor de seleccion del combo box
        private void cbx_tipo_servicio_SelectedIndexChanged(object sender, EventArgs e)
        {

            nombre_de_Servicio = cbx_tipo_servicio.Text.ToString();

            var result = _lista_R19.FirstOrDefault(p => p._TR19_TM41_DESCRIP == nombre_de_Servicio);

            _id_tm41 = result._TR19_TM41_ID;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //diego
            if (rb_tipo1.Checked == true)
            {
                tipo_de_Servicio = 1;//diego
                //Listar();
                Metodo_obtener_tipo_servicio();
            }
          
        }

        private void rb_tipo2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tipo2.Checked == true)
            {
                tipo_de_Servicio = 4;//diego
                //Listar();
                Metodo_obtener_tipo_servicio();
            }
        }


    }
}
