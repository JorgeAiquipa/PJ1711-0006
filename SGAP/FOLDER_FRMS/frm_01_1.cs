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

namespace SGAP.FORLDER_FRMS
{
    public partial class frm_01_1 : Form
    {
        NT_servicio _nt_servicio = new NT_servicio();
        
        #region Variables
        string nombre_cliente;
        string ruc_cliente;
        string direccion_cliente;
        string tipo_servicio;
        string nombre_de_Servicio;
        int cantidad_locales = 0;
        int cantidad_meses = 0;

        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        List<string> lista_string_ejemplo = new List<string>();

        #endregion

        #region Métodos
        public frm_01_1()
        {
            Color background = Color.FromArgb(248, 248, 248);
            //instancias
            InitializeComponent();

            _nt_servicio.Mensaje_Alerta += Mensaje_alerta;

            //apariencia
            this.BackColor = background;
            dgv_informacion_locales.BackgroundColor = background;
            /*dgv_informacion_locales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv_informacion_locales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_informacion_locales.DefaultCellStyle.Font = new Font("Calibri", 11f, FontStyle.Regular);
            dgv_informacion_locales.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);
            dgv_informacion_locales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 188, 134);
            dgv_informacion_locales.EnableHeadersVisualStyles = false;
            //dataGridView1.RowHeadersVisible = false;

            dgv_informacion_locales.BackgroundColor = Color.White;
            dgv_informacion_locales.RowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv_informacion_locales.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv_informacion_locales.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv_informacion_locales.DefaultCellStyle.SelectionBackColor = Color.Gray;
            dgv_informacion_locales.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv_informacion_locales.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_informacion_locales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_informacion_locales.AllowUserToResizeColumns = false;
            dgv_informacion_locales.ColumnHeadersDefaultCellStyle.Font = new Font(dgv_informacion_locales.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            */


            //txt cliente or ruc autocomplete

            txt_nombre_cliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_nombre_cliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txt_nombre_cliente.AutoCompleteCustomSource = collection;

            //metodos
            Metodo_obtener_tipo_servicio();
        }
        void Metodo_obtener_tipo_servicio()
        {
            this.cbx_tipo_servicio.Items.Clear();
            var entidad = _nt_servicio.Listar();

            if (!entidad._hubo_error)
            {
                // Ahora llenamos el combo con los tipos de servicios
                foreach (ET_servicio row in entidad._servicio)
                {
                    this.cbx_tipo_servicio.Items.Add(row._c_nombre);
                }

                // Seleccionamos el primer item
                this.cbx_tipo_servicio.SelectedIndex = 0;
            }

        }
        void Metodo_obtener_informacion_ingresada()
        {
            nombre_cliente = txt_nombre_cliente.Text;
            ruc_cliente = txt_ruc_cliente.Text;
            direccion_cliente = txt_direccion_cliente.Text;
            tipo_servicio = cbx_tipo_servicio.Text;
            nombre_de_Servicio = txt_nombre_Servicio.Text; ;
            /* contaremos las columnas llenas del gridview 
             * Solo aquellas que tengas los campos llenos
             * Se validara por cada campo ingresado
             */
            Metodo_Validar_ingreso_de_locales();
            cantidad_meses = Convert.ToInt16(nupd_periodo_de_servicio.Value);
        }

        void Metodo_Validar_ingreso_de_locales()
        {
            int filas_encontradas = dgv_informacion_locales.RowCount;

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
            //settear la informacion ingrsada
            Metodo_obtener_informacion_ingresada();
            frm_02 FORM_ = new frm_02(tipo_servicio);
            FORM_.Show();
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Este eventio valida lo que se ingresa en cada celda
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
        #endregion

        private void txt_nombre_cliente_TextChanged(object sender, EventArgs e)
        {

            lista_string_ejemplo.Add("clienteq"); 
            lista_string_ejemplo.Add("manzana"); 
            lista_string_ejemplo.Add("rojo"); 
            lista_string_ejemplo.Add("mueble"); 
            lista_string_ejemplo.Add("triton"); 
            lista_string_ejemplo.Add("automovil");
            lista_string_ejemplo.Add("batimovin");
            lista_string_ejemplo.Add("baño");
            lista_string_ejemplo.Add("mazmorra");
            lista_string_ejemplo.Add("automovil");
            lista_string_ejemplo.Add("automovil");
            lista_string_ejemplo.Add("automovil");

            foreach (string value in lista_string_ejemplo.ToList())
            {
                collection.Add(value);

            }

        }
    }
}
