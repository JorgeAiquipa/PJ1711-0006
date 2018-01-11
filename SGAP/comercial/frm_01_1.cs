using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Win28etug;
using Win28ntug;

namespace SGAP.comercial
{
    public partial class frm_01_1 : Form
    {

        #region Instancias
        public ET_entidad _entity = new ET_entidad();
        ET_globales Globales = new ET_globales();
        NT_helper _helper = new NT_helper();
        NT_tareas Tarea = new NT_tareas();
        ET_M19 _et_m19 = new ET_M19();
        ET_M41 _et_m41 = new ET_M41();
        ET_M39 _et_m39 = new ET_M39();
        ET_R28 _et_r28 = new ET_R28();

        NT_M19 _nt_m19 = new NT_M19();
        NT_M27 _nt_m27 = new NT_M27();
        NT_M41 _nt_m41 = new NT_M41();
        NT_M39 _nt_m39 = new NT_M39();
        NT_R28 _nt_r28 = new NT_R28();

        List<ET_M19> _lista_m19 = new List<ET_M19>();
        List<ET_M27> _lista_m27 = new List<ET_M27>();
        List<ET_M41> _lista_m41 = new List<ET_M41>();
        List<ET_R19> _lista_R19 = new List<ET_R19>();
        #endregion

        #region Variables
        string ID_TM19;
        int ID_TM41;
        string NOMBRE_DEL_CLIENTE;
        string RUC_DEL_CLIENTE;
        string NOMBRE_TIPO_DE_SERVICIO;
        string nombre_de_Servicio;
        int ID_TIPO_SERVICIO=1;

        int PERIODO_ = 1;
        string CBX_PRIMER_ITEM = "[Seleccione un servicio]";
        string[] Array_clientes_autocomplete;

        DataGridViewCellStyle Estilo_de_columna_nombre_local = new DataGridViewCellStyle();
        ImageList validation_image = new ImageList();
        #endregion

        #region Métodos
        public frm_01_1()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(221, 221, 221);

            autoCompleteTextBox_t_m19.MaxLength = 500;            

            _nt_m19.Mensaje_Alerta += Mensaje_alerta;
            _nt_m19.Cargar_busqueda_ += Cargar_Busqueda_T_M19;
            _nt_m19.Porcentaje_De_Craga += Porcentaje_De_Craga;

            _nt_m27.Cargar_busqueda_ += Cargar_Busqueda_T_M27;
            _nt_m41.Cargar_busqueda_ += Cargar_Busqueda_T_M41;
            panel4.BackColor = Color.White;
            lbl_locales_info.Text = string.Empty;

            validation_image.TransparentColor = Color.White;
            validation_image.ColorDepth = ColorDepth.Depth32Bit;
            validation_image.ImageSize = new Size(16, 16);
            validation_image.Images.Add(Properties.Resources.atencion);
            validation_image.Images.Add(Properties.Resources.ok);

            panel1.BackgroundImage = validation_image.Images[0];
            panel2.BackgroundImage = validation_image.Images[0];
            panel2.Visible = false;
            label10.BackColor = Color.FromArgb(0, 137, 123);
            label10.ForeColor = Color.White;
            panel3.BackColor = Color.White;

            Crear_Grid_Locales();

            Metodo_obtener_tipo_servicio();
            //ToolTip Tooltip_locales = new ToolTip();
            //Tooltip_locales.IsBalloon = true;
            //Tooltip_locales.ToolTipIcon = ToolTipIcon.Info;
            //Tooltip_locales.ToolTipTitle = "Mensaje del sistema";
            //Tooltip_locales.SetToolTip(dgv_informacion_locales, "Se requiere seleccionar por lo menos un local.");
        }
        void Crear_Grid_Locales()
        {
            _helper.Set_Style_to_DatagridView(dgv_informacion_locales);
            dgv_informacion_locales.Columns[0].Selected = true;
            dgv_informacion_locales.Columns[0].ToolTipText = "Seleccionar todos los locales";
            dgv_informacion_locales.AllowUserToAddRows = false;
            dgv_informacion_locales.AutoGenerateColumns = false;
            dgv_informacion_locales.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_informacion_locales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void Metodo_obtener_tipo_servicio()
        {
            cbx_tipo_servicio.Items.Clear();
            ET_M41 _et_41 = new ET_M41();
            _et_41._TM41_TM42_ID = ID_TIPO_SERVICIO;
            _nt_m41.Agregar_Et_m41(_et_41);
            _nt_m41.Iniciar(Tarea.BUSCAR);
        }
        void Metodo_obtener_informacion_ingresada()
        {
            NOMBRE_DEL_CLIENTE = autoCompleteTextBox_t_m19.Text;
            RUC_DEL_CLIENTE = txt_ruc_cliente.Text;
            NOMBRE_TIPO_DE_SERVICIO = cbx_tipo_servicio.Text;
            PERIODO_ = Convert.ToInt16(nupd_periodo_de_servicio.Value);
        }

        #endregion

        #region Eventos
        void Porcentaje_De_Craga(object sender, int e)
        {
            if (e < 100)
            {
                Cursor.Current = Cursors.WaitCursor;
                autoCompleteTextBox_t_m19.Values = Array_clientes_autocomplete;
            }
            else
            {
                autoCompleteTextBox_t_m19.Values = null;
            }
        }
        private void Cargar_Busqueda_T_M19(object sender, ET_entidad e)
        {
            if (!e._hubo_error && e._lista_et_m19.Count > 0)
            {
                _lista_m19 = e._lista_et_m19;
                int count = e._lista_et_m19.Count;
                Array_clientes_autocomplete = new string[count];

                int A = 0;
                e._lista_et_m19.ForEach(X=> {
                    Array_clientes_autocomplete[A] = X._TM19_DESCRIP2;
                    A++;
                });
                autoCompleteTextBox_t_m19.Values = Array_clientes_autocomplete;
            }
        }
        private void Cargar_Busqueda_T_M27(object sender, ET_entidad e)
        {
            if (!e._hubo_error && e._lista_et_m27.Count > 0)
            {
                _lista_m27 = new List<ET_M27>();
                _lista_m27 = e._lista_et_m27;
                dgv_informacion_locales.DataSource = _lista_m27;
                panel1.Visible = false;
                rb_tipo1.Focus();
            }
            Metodo_mostrar_info_de_locales();
        }
        private void Cargar_Busqueda_T_M41(object sender, ET_entidad e)
        {
            if (!e._hubo_error  && e._lista_et_r19 != null)
            {
                _lista_R19 = e._lista_et_r19.ToList();

                cbx_tipo_servicio.Items.Add(CBX_PRIMER_ITEM);
                foreach (ET_R19 row in e._lista_et_r19)
                {
                    cbx_tipo_servicio.Items.Add(row._TR19_TM41_DESCRIP);
                }
                cbx_tipo_servicio.SelectedIndex = 0;
            }
        }
        private void Mensaje_alerta(object sender, ET_entidad e)
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
            Cursor.Current = Cursors.WaitCursor;
            Metodo_obtener_informacion_ingresada();

            _entity._lista_et_m27 = _lista_m27.Where(local => local._seleccionado == true).ToList();

            int cantidad = _entity._lista_et_m27.Count;
            int cant_tabla = _lista_m27.Count;

            if (txt_ruc_cliente.Text != "") //Cliente valido
            {
                if (cant_tabla != 0) //Hay locales
                {
                    if (cbx_tipo_servicio.Text != "" && cbx_tipo_servicio.Text != CBX_PRIMER_ITEM) //Servicio
                    {
                        if (cantidad > 0) //Local Marcado
                        {
                            //seteamos informacion del cliente
                            _et_m19._TM19_DESCRIP1 = RUC_DEL_CLIENTE;
                            _et_m19._TM19_DESCRIP2 = NOMBRE_DEL_CLIENTE;
                            _et_m19._TM19_ID = ID_TM19;
                            _entity._entity_m19 = _et_m19;

                            //seteamos info del servicio seleccionado
                            _et_m41._TM41_TM42_ID = ID_TIPO_SERVICIO;//diego
                            _et_m41._TM41_DESCRIP = nombre_de_Servicio;
                            _et_m41._TM41_ID = ID_TM41;
                            _entity._entity_m41 = _et_m41;

                            //informacion de la cotizacion a registrar
                            _et_m39._TM39_DESCRIP = string.Format("{0} Para {1}", nombre_de_Servicio, NOMBRE_DEL_CLIENTE);//nombre de la cotizacion
                            _et_m39._TM39_TM19_ID = ID_TM19;

                            _entity._entity_m39 = _et_m39;
                            _entity._entity_r28._TR28_PERIODO = Convert.ToInt32(nupd_periodo_de_servicio.Value);

                            var result = _nt_m39.set_001(_entity);

                            _entity._entity_r28._TR28_PADRE = result._entity_r28._TR28_PADRE;
                            _entity._entity_m39._TM39_ID = result._entity_m39._TM39_ID;
                            _entity._entity_m39._entity_et_m19._TM19_ID = ID_TM19;
                            _entity._entity_m39._entity_et_m19._TM19_DESCRIP2 = NOMBRE_DEL_CLIENTE; //razon social

                            this.DialogResult = DialogResult.OK;

                            this.Dispose();
                        }
                        else
                        {
                            DialogResult decision_msg = MessageBox.Show("Se requiere seleccionar por lo menos un local.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (decision_msg == DialogResult.OK) { dgv_informacion_locales.Focus(); }

                        }
                    }
                    else
                    {
                        panel2.Visible = true;
                        rb_tipo1.Focus();
                        DialogResult decision_msg = MessageBox.Show("Seleccione un servicio.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (decision_msg == DialogResult.OK) { cbx_tipo_servicio.Focus(); }
                    }
                }
                else
                {
                    DialogResult decision_msg = MessageBox.Show("Este cliente no posee locales.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (decision_msg == DialogResult.OK) { autoCompleteTextBox_t_m19.Focus(); }
                }
            }
            else
            {
                DialogResult decision_msg = MessageBox.Show("Seleccione un cliente valido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (decision_msg == DialogResult.OK) { autoCompleteTextBox_t_m19.Focus(); }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Obtener_Informacion_t_m19()
        {
            _et_m19 = new ET_M19();
            _et_m19 = _lista_m19.FirstOrDefault(item=> item._TM19_DESCRIP2.ToUpper() == autoCompleteTextBox_t_m19.Text.ToUpper().Trim());
            if (_et_m19 != null)
            {
                ID_TM19 = _et_m19._TM19_ID;
                txt_ruc_cliente.Text = _et_m19._TM19_DESCRIP1;
                _nt_m27.Agregar_Et_m19(_et_m19);
                _nt_m27.Iniciar(Tarea.BUSCAR);
            }
            else
            {
                panel1.Visible = true;
                MessageBox.Show
                (
                    " La búsqueda de cliente no obtubo resultados. \n Intente de nuevo.", "Alerta!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                autoCompleteTextBox_t_m19.Focus();
                
            }
        }

        private void Limpiar_Informacion_ingresada()
        {
            RUC_DEL_CLIENTE = string.Empty;
            NOMBRE_DEL_CLIENTE = string.Empty;
            ID_TM19 = string.Empty;
            ID_TIPO_SERVICIO = 0;
            nombre_de_Servicio = string.Empty;
            ID_TM41 = 0;
            txt_ruc_cliente.Text = string.Empty;
            _lista_m27.Clear();
            dgv_informacion_locales.DataSource = null;
            dgv_informacion_locales.Update();
            dgv_informacion_locales.Refresh();
            dgv_informacion_locales.DataSource = _lista_m27;
            Metodo_mostrar_info_de_locales();
        }

        private void cbx_tipo_servicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_tipo_servicio.Text != "" && cbx_tipo_servicio.Text != CBX_PRIMER_ITEM)
            {
                panel2.Visible = false;
                cbx_tipo_servicio.Items.Remove(CBX_PRIMER_ITEM);
                nombre_de_Servicio = cbx_tipo_servicio.Text.ToString();
                var result = _lista_R19.FirstOrDefault(p => p._TR19_TM41_DESCRIP == nombre_de_Servicio);
                ID_TM41 = result._TR19_TM41_ID;
            }
        }
        private void autoCompleteTextBox_t_m19_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(autoCompleteTextBox_t_m19.Text))
            {
                string filtro = autoCompleteTextBox_t_m19.Text;
                _nt_m19._Filtro(filtro);
                _nt_m19.Iniciar(Tarea.BUSCAR);
                
            }
            else
            {
                Limpiar_Informacion_ingresada();
            }

            Limpiar_Informacion_ingresada();
        }
        private void autoCompleteTextBox_t_m19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                Limpiar_Informacion_ingresada();
                Obtener_Informacion_t_m19();
                autoCompleteTextBox_t_m19.Text = autoCompleteTextBox_t_m19.Text.Trim();
            }
        }
        private void autoCompleteTextBox_t_m19_Enter(object sender, EventArgs e)
        {
            //Limpiar_Informacion_ingresada();
        }

        private void rb_tipo1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tipo1.Checked == true)
            {
                ID_TIPO_SERVICIO = Globales.Servicio_general;
                Metodo_obtener_tipo_servicio();
                panel2.Visible = true;

            }
        }
        private void rb_tipo2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tipo2.Checked == true)
            {
                ID_TIPO_SERVICIO = Globales.Servicio_especial;
                Metodo_obtener_tipo_servicio();
                panel2.Visible = true;

            }
        }

        private void autoCompleteTextBox_t_m19_Leave(object sender, EventArgs e)
        {            
            //Obtener_Informacion_t_m19();
            autoCompleteTextBox_t_m19.Text = autoCompleteTextBox_t_m19.Text.Trim();
        }


        #endregion

        private void frm_01_1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.panel1, "Seleccione un cliente");
            toolTip1.SetToolTip(this.panel2, "Seleccione un servicio");
            panel1.Visible = false;
            Habilitar_Buffer_doble_control_gridview(dgv_informacion_locales,true);
        }

        private void Habilitar_Buffer_doble_control_gridview(DataGridView gridview, bool v)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            gridview, new object[] { true });
        }

        private void dgv_informacion_locales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_informacion_locales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                dgv_informacion_locales.CommitEdit(DataGridViewDataErrorContexts.Commit);
                Metodo_mostrar_info_de_locales();
            }
        }

        private void Metodo_mostrar_info_de_locales()
        {
            var result = _lista_m27.Where(local => local._seleccionado == true).ToList().Count();

            if (_lista_m27.Count < 1)
                lbl_locales_info.Text = "Sin locales";
            else if (_lista_m27.Count == 1)
                lbl_locales_info.Text = string.Format("{0} Local" + (result == 1 ? " {1} local seleccionado" : "{1} locales seleccionados"), _lista_m27.Count, result);
            else if (_lista_m27.Count > 1)
                lbl_locales_info.Text = string.Format("{0} Locales " + (result == 1 ? " {1} local seleccionado" : "{1} locales seleccionados"), _lista_m27.Count, result);

        }

        private void dgv_informacion_locales_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Metodo_mostrar_info_de_locales();
        }


    }
}
