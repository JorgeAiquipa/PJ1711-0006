using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Win28etug;
using Win28ntug;

namespace SGAP.comercial
{
    public partial class frm_01_2 : Form
    {
        #region Variables

        ET_entidad _entidad = new ET_entidad();
        NT_helper _helper = new NT_helper();
        ET_M41 _et_m41 = new ET_M41();
        NT_M38 _nt_m38 = new NT_M38();
        NT_M41 _nt_m41 = new NT_M41();
        NT_R28 _nt_r28 = new NT_R28();
        NT_R27 _nt_r27 = new NT_R27();
        NT_M31 _nt_m31 = new NT_M31();
        NT_R29 _nt_r29 = new NT_R29();
        ET_M31 _et_m31 = new ET_M31();
        NT_M40 _NT_M40 = new NT_M40();
        List<ET_M31> _lista_m31 = new List<ET_M31>();
        List<ET_M41> _lista_m41 = new List<ET_M41>();
        List<ET_R29> _lista_et_r29 = new List<ET_R29>();
        List<ET_M40> _lista_et_m40 = new List<ET_M40>();
        public string nom = "";
        public string cod = "";
        public string marc = "";
        public string undad = "";
        public double precio = 0;
        public string tipo = "";

        ContextMenuStrip MenuStrip_AddService = new ContextMenuStrip();
        ContextMenuStrip MenuStrip_ViewProperties_ = new ContextMenuStrip();

        int Id_Servicio_Padre;
        public int Id_servicio_hijo;
        int Periodo_servicio;
        string nodos;
        #endregion

        #region Metodos
        public frm_01_2(ET_entidad _entity, bool editar = false)
        {         
            
            InitializeComponent();

            Agregar_menu_contextual();         

            //style

            this.BackColor = Color.FromArgb(221, 221, 221);

            label10.BackColor = Color.FromArgb(0, 134, 65);
            label10.ForeColor = Color.White;
            label11.BackColor = Color.FromArgb(0, 134, 65);
            label11.ForeColor = Color.White;
            label12.BackColor = Color.FromArgb(0, 134, 65);
            label12.ForeColor = Color.White;
            label13.BackColor = Color.FromArgb(0, 134, 65);
            label13.ForeColor = Color.White;
            label3.BackColor = Color.FromArgb(0, 134, 65);
            label3.ForeColor = Color.White;
            this.BringToFront();

            //end style

            _entidad = _entity;

            // Obtenemos los servicios de la cotización y alamacenamos el id del servicio padre.
            Cargar_servicios();
            Id_servicio_hijo = Id_Servicio_Padre;

            _lista_et_m40 = _NT_M40.get_001()._lista_et_m40;

            if (editar)
            {
                //Obtenemos los locales que posee la cotización seleccionada
                _entidad._entity_r27._TR27_TM39_ID = _entidad._entity_m39._TM39_ID;
                _entidad._entity_r27._TR27_TM19_ID = _entidad._entity_m39._entity_et_m19._TM19_ID;
                var result = _nt_r27.get_001(_entidad);
                _entidad._lista_et_m27 = result._lista_et_m27;

                Metodo_cargar_informacion_mano_de_obra();
            }


            tabControl1.Visible = false;

            foreach (TabPage page in tabControl1.TabPages)
            {
                Panel panel = page.Controls[0] as Panel;
                Panels.Add(panel);

                panel.Parent = tabControl1.Parent;
                panel.Location = tabControl1.Location;
                panel.Visible = false;
            }

            DisplayPanel(0);
            CreateColumn();

            _nt_m31.Mensaje_Alerta += Mensaje_alerta;

            dgv_mano_de_obra.Scroll += new ScrollEventHandler(dgv_mano_de_obra_right_Scroll);
            dgv_mano_de_obra_right.Scroll += new ScrollEventHandler(dgv_mano_de_obra_Scroll);

        }

        static void Mensaje_alerta(object sender, ET_entidad e)
        {
            MessageBox.Show
            (
                e._contenido_mensaje, e._titulo_mensaje,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        public void Cargar_servicios()
        {
            var result_int = _nt_r28.get_001(_entidad, tree_view_servicios);
            Id_Servicio_Padre = result_int[0];//_entidad._entity_r28._TR28_PADRE;
            Periodo_servicio = result_int[1];//_entidad._entity_r28._TR28_PERIODO;

        }

        void Agregar_menu_contextual()
        {
            MenuStrip_ViewProperties_.Text = "Propiedades";
            MenuStrip_ViewProperties_.Name = "MenuStrip_ViewProperties_";
            MenuStrip_ViewProperties_.Size = new System.Drawing.Size(153, 48);

            ToolStripMenuItem View_Properties = new ToolStripMenuItem();

            View_Properties.Name = "View_Properties";
            View_Properties.Size = new System.Drawing.Size(132, 22);
            View_Properties.Text = "Configuración de cargos";

            MenuStrip_ViewProperties_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        View_Properties
                    });

            View_Properties.Click += new System.EventHandler(this.Item_mano_de_obra_click);


            //Agregar Servicio
            MenuStrip_AddService.Text = "Servicios";
            MenuStrip_AddService.Name = "Menu_strip_for_TreeView";
            MenuStrip_AddService.Size = new System.Drawing.Size(153, 48);

            ToolStripMenuItem Add_service = new ToolStripMenuItem();

            Add_service.Name = "Add_service";
            Add_service.Size = new System.Drawing.Size(132, 22);
            Add_service.Text = "Agregar Servicio...";

            //diego
            MenuStrip_AddService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        Add_service
                    });

            Add_service.Click += new System.EventHandler(this.Item_Add_Service_click);
            //diego

            MenuStrip_AddService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                Add_service
            });
        }

        #endregion

        #region Eventos

        List<Panel> Panels = new List<Panel>();
        Panel VisiblePanel = null;
        //tiene lugar cuando cambia ala selección.
        private void tree_view_servicios_AfterSelect(object sender, TreeViewEventArgs e)
        {

            int index = int.Parse(e.Node.Tag.ToString());
            DisplayPanel(index);
        }

        private void DisplayPanel(int index)
        {
            // si el indice esta furea del intervalo veremos los resumenes general

            if (index <= 6)
            {
                if (Panels.Count < 1) return;

                if (VisiblePanel == Panels[index]) return;

                if (VisiblePanel != null) VisiblePanel.Visible = false;

                Panels[index].Visible = true;
                VisiblePanel = Panels[index];
            }
        }

        // Mostramos un menu contextual por cada nodeo del treeview
        private TreeNode m_OldSelectNode;
        private void tree_view_servicios_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);

            TreeNode node = tree_view_servicios.GetNodeAt(p);

            if (e.Button == MouseButtons.Right)
            {

                if (node != null)
                {
                    m_OldSelectNode = tree_view_servicios.SelectedNode;
                    tree_view_servicios.SelectedNode = node;


                    switch (Convert.ToString(node.Tag))
                    {
                        case "10100": // ver menu nuevo servicio

                            MenuStrip_AddService.Show(tree_view_servicios, p);
                            nodos = Convert.ToString(tree_view_servicios.SelectedNode.FirstNode.Name);
                            break;
                        case "0": // ver menu para mano de obra
                            Id_servicio_hijo = Convert.ToInt32(node.Parent.Name.ToString());
                            Metodo_cargar_informacion_mano_de_obra();
                            MenuStrip_ViewProperties_.Show(tree_view_servicios, p);
                            break;
                    }

                    tree_view_servicios.SelectedNode = m_OldSelectNode;
                    m_OldSelectNode = null;
                }
            }
            if (e.Button == MouseButtons.Left)
            {

                if (node != null)
                {
                    m_OldSelectNode = tree_view_servicios.SelectedNode;
                    tree_view_servicios.SelectedNode = node;

                    switch (Convert.ToString(node.Tag))
                    {
                        case "0": // ver menu para mano de obra
                            Id_servicio_hijo = Convert.ToInt32(node.Parent.Name.ToString());
                            //cargar pagina de mano de obra para el servicio seleccionado
                            Metodo_cargar_informacion_mano_de_obra();
                            break;
                    }

                    tree_view_servicios.SelectedNode = m_OldSelectNode;
                    m_OldSelectNode = null;
                }
            }
        }


        //diego
        private void Item_Add_Service_click(object sender, EventArgs e)
        {
            string tm39_id;

            if (string.IsNullOrEmpty(_entidad._entity_r27._TR27_TM39_ID))
                tm39_id = _entidad._entity_m39._TM39_ID;
            else
                tm39_id = _entidad._entity_r27._TR27_TM39_ID;

            frm_01_2_02 form_2_2 = new frm_01_2_02(Id_servicio_hijo, Id_Servicio_Padre, Periodo_servicio, tm39_id, nodos);
            form_2_2.ShowDialog();

            if (form_2_2.DialogResult == DialogResult.OK)
            {
                //Item_servicio_click(object sender);
                Metodo_cargar_informacion_servicio();

                Cargar_servicios();
            }

        }

        void Metodo_cargar_informacion_servicio()//diego
        {
            ET_R29 _et = new ET_R29();
            _et._TR29_TR28_ID = Id_servicio_hijo; // captura el node
        }

        private void Item_mano_de_obra_click(object sender, EventArgs e)
        {

            frm_01_2_01 form_2_1 = new frm_01_2_01(Id_servicio_hijo, _lista_et_m40);
            form_2_1.ShowDialog();
            if (form_2_1.DialogResult != DialogResult.Cancel)
            {
                Metodo_cargar_informacion_mano_de_obra();
            }

        }
        #endregion

        #region Mano de obra
        void Metodo_cargar_informacion_mano_de_obra()
        {
            ET_R29 _et = new ET_R29();
            _et._TR29_TR28_ID = Id_servicio_hijo; // captura el node
            _et._lista_et_m40 = _lista_et_m40;
            _lista_et_r29 = _nt_r29.get_001(_et)._lista_et_r29;

            Contruir_DataGrid_Mano_Obra(); // Construimos la grilla

            Desplegar_informacion();
        }




        #endregion

        #region Maquinaria y equipo
        //diego
        private void CreateColumn()
        {
            int index = 1;
            foreach (ET_M27 fila in _entidad._lista_et_m27)
            {
                // Initialize the button column.
                DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn
                {
                    HeaderText = string.Format("{0}", fila._TM27_NOMBRE),
                };
                // Add the column to the control.
                dgv_entrada_datos_mq_eq.Columns.Insert(6, Column);
                index++;
            }

        }
        #endregion


        private Boolean Dia_semana(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void dgv_entrada_datos_mano_de_obra_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //validar celda

        }

        private void dvg_entrada_datos_mq_eq_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int cont = _entidad._lista_et_m27.Count;
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgv_entrada_datos_mq_eq.CurrentCell.ColumnIndex > 5 && dgv_entrada_datos_mq_eq.CurrentCell.ColumnIndex <= cont + 5) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            //tiene lugar cuando se clickea el contenido de una celda
            int i;
            i = dgv_entrada_datos_mq_eq.CurrentRow.Index;
            string column_name = dgv_entrada_datos_mq_eq.Columns[i].Name; // nombre
            if (column_name.Equals("nombre"))
            {
                TextBox auto_text = e.Control as TextBox;

                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    ET_entidad _entidades_ = new ET_entidad();

                    _entidades_ = _nt_m31.gridTextBoxAutocomplete(auto_text);
                    _lista_m31 = _entidades_._lista_et_m31;
                }
            }

        }


        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgv_entrada_datos_mq_eq_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void dgv_entrada_datos_mq_eq_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string nombre = dgv_entrada_datos_mq_eq.Columns[e.ColumnIndex].Name;
            if (nombre == "nombre")
            {
                bool existe = _lista_m31.Any(item => (item._TM31_DESCRIP + " " + item._TM31_TM33_ID + " " + item._TM31_TM72_ID) == e.FormattedValue.ToString());
                //bool existe = _lista_m31.Any(item => item._TM31_DESCRIP == e.FormattedValue.ToString());
                if (existe)
                {
                    ET_M31 fila = _lista_m31.FirstOrDefault(item => (item._TM31_DESCRIP + " " + item._TM31_TM33_ID + " " + item._TM31_TM72_ID) == e.FormattedValue.ToString());
                    //ET_M31 fila = _lista_m31.FirstOrDefault(item => item._TM31_DESCRIP == e.FormattedValue.ToString());

                    nom = fila._TM31_DESCRIP;//
                    cod = fila._TM31_ID;
                    marc = fila._TM31_TM33_ID;
                    undad = fila._TM31_TM72_ID;
                    precio = Convert.ToDouble(fila._TM31_PRECIO);
                    tipo = fila._TM31_TM34_ID;
                }

            }

        }

        private void dgv_entrada_datos_mq_eq_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cont = _entidad._lista_et_m27.Count;
            int i;
            i = dgv_entrada_datos_mq_eq.CurrentRow.Index;

            int suma = 0;
            int cel = 6;
            for (int o = 1; o <= cont; o++)
            {
                int celda = Convert.ToInt32(dgv_entrada_datos_mq_eq.Rows[i].Cells[cel].Value);
                suma = suma + celda;
                cel++;
            }

            double total = suma * precio;

            dgv_entrada_datos_mq_eq.Rows[i].Cells[6 + cont].Value = suma;
            dgv_entrada_datos_mq_eq.Rows[i].Cells[8 + cont].Value = total;

            string column_name = dgv_entrada_datos_mq_eq.Columns[e.ColumnIndex].Name; // nombre
            if (column_name.Equals("nombre"))
            {

                dgv_entrada_datos_mq_eq.Rows[i].Cells[0].Value = nom;

                string nombre = Convert.ToString(dgv_entrada_datos_mq_eq.Rows[i].Cells[0].Value);

                if (nombre != "")

                {


                    dgv_entrada_datos_mq_eq.Rows[i].Cells[1].Value = cod;
                    dgv_entrada_datos_mq_eq.Rows[i].Cells[2].Value = marc;
                    dgv_entrada_datos_mq_eq.Rows[i].Cells[3].Value = undad;
                    dgv_entrada_datos_mq_eq.Rows[i].Cells[7 + cont].Value = precio;

                    if (tipo == "MQ")
                    {
                        dgv_entrada_datos_mq_eq.Rows[i].Cells[4].Value = 1;
                        dgv_entrada_datos_mq_eq.Rows[i].Cells[5].Value = 0;

                    }
                    else if (tipo == "EQ")
                    {
                        dgv_entrada_datos_mq_eq.Rows[i].Cells[5].Value = 1;
                        dgv_entrada_datos_mq_eq.Rows[i].Cells[4].Value = 0;
                    }

                }

            }

        }

        private void dgv_entrada_datos_mq_eq_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            string column_name = dgv_entrada_datos_mq_eq.Columns[e.ColumnIndex].Name; // nombre
            if (column_name.Equals("nombre"))
            {
                int cont = _entidad._lista_et_m27.Count;
                int i;
                i = dgv_entrada_datos_mq_eq.CurrentRow.Index;
                dgv_entrada_datos_mq_eq.Rows[i].Cells[0].Value = "";
                dgv_entrada_datos_mq_eq.Rows[i].Cells[1].Value = "";
                dgv_entrada_datos_mq_eq.Rows[i].Cells[2].Value = "";
                dgv_entrada_datos_mq_eq.Rows[i].Cells[3].Value = "";
                dgv_entrada_datos_mq_eq.Rows[i].Cells[4].Value = 0;
                dgv_entrada_datos_mq_eq.Rows[i].Cells[5].Value = 0;
                int cel = 6;
                for (int o = 1; o <= cont; o++)
                {
                    int celda = Convert.ToInt32(dgv_entrada_datos_mq_eq.Rows[i].Cells[cel].Value);
                    dgv_entrada_datos_mq_eq.Rows[i].Cells[cel].Value = null;
                    cel++;
                }
                dgv_entrada_datos_mq_eq.Rows[i].Cells[6 + cont].Value = "";
                dgv_entrada_datos_mq_eq.Rows[i].Cells[7 + cont].Value = "";

            }
        }

        void Contruir_DataGrid_Mano_Obra()
        {
            dgv_mano_de_obra.AllowUserToAddRows = false;

            dgv_mano_de_obra.Rows.Clear();
            dgv_mano_de_obra.Columns.Clear();
            dgv_mano_de_obra.DataSource = null;
            dgv_mano_de_obra.Refresh();
            dgv_mano_de_obra.Update();

            dgv_mano_de_obra_right.Rows.Clear();
            dgv_mano_de_obra_right.Columns.Clear();
            dgv_mano_de_obra_right.DataSource = null;
            dgv_mano_de_obra_right.Refresh();
            dgv_mano_de_obra_right.Update();

            _helper.Set_Style_to_DatagridView(dgv_mano_de_obra);
            _helper.Set_Style_to_DatagridView(dgv_mano_de_obra_right);

            dgv_mano_de_obra.AutoGenerateColumns = false;
            dgv_mano_de_obra.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //dgv_mano_de_obra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            #region COLUMNAS
            //DataGridViewColumn _COL_FILA = new DataGridViewTextBoxColumn();
            //_COL_FILA.DataPropertyName = "_COL_FILA";
            //_COL_FILA.HeaderText = "Cargo";
            //_COL_FILA.Name = "_COL_FILA";
            //_COL_FILA.Visible = false;

            //DataGridViewColumn _COL_DESCRIPCION = new DataGridViewTextBoxColumn();
            //_COL_DESCRIPCION.DataPropertyName = "_COL_DESCRIPCION";
            //_COL_DESCRIPCION.HeaderText = "Cargo";
            //_COL_DESCRIPCION.Name = "_COL_DESCRIPCION";
            //_COL_DESCRIPCION.Width = 140;
            ////_COL_DESCRIPCION.MinimumWidth = 140;
            ////_COL_DESCRIPCION.FillWeight = 140;

            //DataGridViewColumn _COL_HORA_ENTRADA = new DataGridViewTextBoxColumn();
            //_COL_HORA_ENTRADA.Name = "_COL_HORA_ENTRADA";
            //_COL_HORA_ENTRADA.HeaderText = "Hora Entrada";
            //_COL_HORA_ENTRADA.Width = 80;
            //_COL_HORA_ENTRADA.DefaultCellStyle.Format = "T";
            ////_COL_HORA_ENTRADA.MinimumWidth = 70;
            ////_COL_HORA_ENTRADA.FillWeight = 70;

            //DataGridViewColumn _COL_HORA_SALIDA = new DataGridViewTextBoxColumn();
            //_COL_HORA_SALIDA.Name = "_COL_HORA_SALIDA";
            //_COL_HORA_SALIDA.HeaderText = "Hora Salida";
            //_COL_HORA_SALIDA.Width = 70;
            //_COL_HORA_SALIDA.DefaultCellStyle.Format = "T";
            ////_COL_HORA_SALIDA.MinimumWidth = 65;
            ////_COL_HORA_SALIDA.FillWeight = 65;

            //DataGridViewColumn _COL_DIAS_POR_SEMANA = new DataGridViewTextBoxColumn();
            //_COL_DIAS_POR_SEMANA.HeaderText = "Dias por Sem.";
            //_COL_DIAS_POR_SEMANA.Name = "_COL_DIAS_POR_SEMANA";
            //_COL_DIAS_POR_SEMANA.Width = 70;
            ////_COL_DIAS_POR_SEMANA.MinimumWidth = 70;
            ////_COL_DIAS_POR_SEMANA.FillWeight = 70;

            //DataGridViewColumn _COL_REMUNERACION = new DataGridViewTextBoxColumn();
            //_COL_REMUNERACION.DataPropertyName = "_COL_REMUNERACION";
            //_COL_REMUNERACION.HeaderText = "Remuneración Básica";
            //_COL_REMUNERACION.Name = "_COL_REMUNERACION";
            //_COL_REMUNERACION.DefaultCellStyle.Format = "C";
            //_COL_REMUNERACION.DefaultCellStyle.NullValue = "850.00";
            #endregion

            DataGridViewColumn MANO_OBRA_COL_DESCRIPCION = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_DESCRIPCION.DataPropertyName = "MANO_OBRA_COL_DESCRIPCION";
            MANO_OBRA_COL_DESCRIPCION.HeaderText = "Cargo";
            MANO_OBRA_COL_DESCRIPCION.Name = "MANO_OBRA_COL_DESCRIPCION";
            MANO_OBRA_COL_DESCRIPCION.Width = 260;
            MANO_OBRA_COL_DESCRIPCION.ReadOnly = true;

            //_COL_DESCRIPCION.MinimumWidth = 140;
            //_COL_DESCRIPCION.FillWeight = 140

            dgv_mano_de_obra.Columns.AddRange(new DataGridViewColumn[] {
                MANO_OBRA_COL_DESCRIPCION,
            });
            MANO_OBRA_COL_DESCRIPCION.Frozen = true;

            //// CARGAR COLUMNAS DE MANERA DINAMICA -> LOCALES

            if (_entidad._lista_et_m27 != null)
            {
                int cantidad_final_de_indices = (dgv_mano_de_obra.ColumnCount + _entidad._lista_et_m27.Count);
                dgv_mano_de_obra.ColumnCount = cantidad_final_de_indices;

                int indice_de_inicio = cantidad_final_de_indices - _entidad._lista_et_m27.Count;

                _entidad._lista_et_m27.ForEach(x =>
                {
                    dgv_mano_de_obra.Columns[indice_de_inicio].Visible = true;
                    dgv_mano_de_obra.Columns[indice_de_inicio].Width = 200;
                    dgv_mano_de_obra.Columns[indice_de_inicio].Name = x._TM27_NOMBRE;
                    dgv_mano_de_obra.Columns[indice_de_inicio].HeaderText = x._TM27_NOMBRE;
                    indice_de_inicio++;
                });

            }
            //dgv_mano_de_obra.

            // for datgrid mano de obra right
            dgv_mano_de_obra_right.AllowUserToAddRows = false;
            dgv_mano_de_obra_right.AutoGenerateColumns = false;
            dgv_mano_de_obra_right.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_mano_de_obra_right.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv_mano_de_obra_right.DefaultCellStyle.SelectionForeColor = Color.Black;
            //dgv_mano_de_obra_right.ReadOnly = true;

            // columnas de remuneraciones 

            // remuneraciones de acuerdo a la lista de remuneraciones que se obtiene al consultar la mano de obra
            //
            DataGridViewColumn MANO_OBRA_COL_SUELDO_BASICO = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUELDO_BASICO.DataPropertyName = "MANO_OBRA_COL_SUELDO_BASICO";
            MANO_OBRA_COL_SUELDO_BASICO.HeaderText = "SueldoBásico";
            MANO_OBRA_COL_SUELDO_BASICO.Name = "MANO_OBRA_COL_SUELDO_BASICO";
            MANO_OBRA_COL_SUELDO_BASICO.Width = 90;
            MANO_OBRA_COL_SUELDO_BASICO.ReadOnly = true;

            DataGridViewColumn MANO_OBRA_COL_TOTAL_PERSONAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_TOTAL_PERSONAL.DataPropertyName = "MANO_OBRA_COL_TOTAL_PERSONAL";
            MANO_OBRA_COL_TOTAL_PERSONAL.HeaderText = "Tot.Personal";
            MANO_OBRA_COL_TOTAL_PERSONAL.Name = "MANO_OBRA_COL_TOTAL_PERSONAL";
            MANO_OBRA_COL_TOTAL_PERSONAL.Width = 120;
            MANO_OBRA_COL_TOTAL_PERSONAL.ReadOnly = true;

            DataGridViewColumn MANO_OBRA_COL_SUELDO_MENSUAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUELDO_MENSUAL.DataPropertyName = "MANO_OBRA_COL_SUELDO_MENSUAL";
            MANO_OBRA_COL_SUELDO_MENSUAL.HeaderText = "Sueldo Mensual";
            MANO_OBRA_COL_SUELDO_MENSUAL.Name = "MANO_OBRA_COL_SUELDO_MENSUAL";
            MANO_OBRA_COL_SUELDO_MENSUAL.Width = 120;
            MANO_OBRA_COL_SUELDO_MENSUAL.ReadOnly = true;

            DataGridViewColumn MANO_OBRA_COL_TOTAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_TOTAL.DataPropertyName = "MANO_OBRA_COL_TOTAL";
            MANO_OBRA_COL_TOTAL.HeaderText = "Total";
            MANO_OBRA_COL_TOTAL.Name = "MANO_OBRA_COL_TOTAL";
            MANO_OBRA_COL_TOTAL.Width = 120;
            MANO_OBRA_COL_TOTAL.ReadOnly = true;

            DataGridViewColumn MANO_OBRA_COL_SUM_CONCEPTOS = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUM_CONCEPTOS.DataPropertyName = "MANO_OBRA_COL_SUM_CONCEPTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS.HeaderText = "Total Conceptos";
            MANO_OBRA_COL_SUM_CONCEPTOS.Name = "MANO_OBRA_COL_SUM_CONCEPTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS.Width = 120;
            MANO_OBRA_COL_SUM_CONCEPTOS.ReadOnly = false;

            dgv_mano_de_obra_right.Columns.AddRange(new DataGridViewColumn[] {
                MANO_OBRA_COL_TOTAL_PERSONAL,
                MANO_OBRA_COL_SUELDO_BASICO,
                MANO_OBRA_COL_SUM_CONCEPTOS,
                MANO_OBRA_COL_SUELDO_MENSUAL,
                MANO_OBRA_COL_TOTAL
            });
            //MANO_OBRA_COL_TOTAL_PERSONAL.DisplayIndex = 0;
            //MANO_OBRA_COL_SUELDO_BASICO.DisplayIndex = 1;

            ////// CARGAR COLUMNAS DE MANERA DINAMICA -> CONCEPTOS REMUNERATIVOS

            //if (_lista_et_m40 != null)
            //{
            //    int indice_de_inicio = dgv_mano_de_obra_right.ColumnCount;

            //    dgv_mano_de_obra_right.ColumnCount = _lista_et_m40.Count + dgv_mano_de_obra_right.ColumnCount;

            //    //_lista_et_m40.ForEach(x =>
            //    //{

            //    //    dgv_mano_de_obra_right.Columns[indice_de_inicio].Visible = true;
            //    //    dgv_mano_de_obra_right.Columns[indice_de_inicio].Width = 200;
            //    //    dgv_mano_de_obra_right.Columns[indice_de_inicio].Name = x._TM40_DESCRIP;
            //    //    dgv_mano_de_obra_right.Columns[indice_de_inicio].HeaderText = x._TM40_DESCRIP;
            //    //    indice_de_inicio++;
            //    //});

            //    //MANO_OBRA_COL_SUELDO_MENSUAL.DisplayIndex = dgv_mano_de_obra_right.ColumnCount - 1;
            //    //MANO_OBRA_COL_TOTAL.DisplayIndex = dgv_mano_de_obra_right.ColumnCount - 1;
            //}


        }

        void Desplegar_informacion()
        {

            // Ingresamos los datos evitando enlazarlo a una fuente de datos
            // _lista_et_r29

            _lista_et_r29.ForEach(fila_ => {

                string[] ceros_ = new string[dgv_mano_de_obra_right.ColumnCount];
                for (int a = 0; a < dgv_mano_de_obra_right.ColumnCount; a++)
                    ceros_[a] = "0";

                dgv_mano_de_obra.Rows.Add(
                    Obtener_descripcion_mano_obra(fila_._TR29_DESCRIP, fila_._TR29_DIAS_SEMANA, fila_._TR29_HORA_ENTRADA, fila_._TR29_HORA_SALIDA)
                    );

                dgv_mano_de_obra_right.Rows.Add(
                       0, // total personal
                       fila_._TR29_REMUNERACION, // sueldo basico
                       "suma de conceptos remunerativos"
                    );
            });


        }
        string Obtener_descripcion_mano_obra(string descripcion, int dias_por_Semana, DateTime hora_entrada, DateTime hora_salida)
        {
            //string semana_laborar = "";
            int horas = 0;
            string horario = "";

            switch (dias_por_Semana)
            {
                case 1:
                    horario = "Jornal:";
                    break;

                case 2:
                    horario = "L-Ma:";
                    break;
                case 3:
                    horario = "L-Mi:";
                    break;
                case 4:
                    horario = "L-J:";
                    break;
                case 5:
                    horario = "L-V:";
                    break;
                case 6:
                    horario = "L-S:";
                    break;
                case 7:
                    horario = "L-D:";
                    break;
            }

            horas = (hora_salida - hora_entrada).Hours;

            horario = horario + hora_entrada.ToString("H:mm") + " - " + hora_salida.ToString("H:mm");

            return descripcion + " " + horas.ToString() + " h " + horario;

        }

        private void dgv_mano_de_obra_Scroll(object sender, ScrollEventArgs e)
        {
            //dgv_mano_de_obra_right.VerticallScrollBar.Value = e.NewValue;
            try
            {
                dgv_mano_de_obra_right.FirstDisplayedScrollingRowIndex = dgv_mano_de_obra.FirstDisplayedScrollingRowIndex;
            }
            catch (Exception ex)
            { }
        }

        private void dgv_mano_de_obra_right_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dgv_mano_de_obra.FirstDisplayedScrollingRowIndex = dgv_mano_de_obra_right.FirstDisplayedScrollingRowIndex;
            }
            catch (Exception ex)
            { }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
            }
        }

        private void dgv_mano_de_obra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {

                // manipular lo ingresado par poder registrarlo
                _lista_et_r29 = _lista_et_r29;
            }
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == false)
            {
                splitContainer1.Panel1Collapsed = true;
                btn_colapse.Text = "";
                btn_colapse.BackgroundImage = Image.FromFile(@"E:\Proyectos\En_Desarrollo\SGAP\Resources\rigth_arrow.png");
                
                btn_colapse.Location = new Point(0, 0);

            }
            else if (splitContainer1.Panel1Collapsed == true)
            {              
                splitContainer1.Panel1Collapsed = false;
                btn_colapse.Text = "";
                btn_colapse.BackgroundImage = Image.FromFile(@"E:\Proyectos\En_Desarrollo\SGAP\Resources\left_arrow.png");
                int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
                btn_colapse.Location = new Point(coll, 0);
            }
        }

        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
            btn_colapse.Location = new Point(coll, 0);
        }

        private void dgv_mano_de_obra_right_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.dgv_mano_de_obra_right.CurrentCell.ColumnIndex == this.dgv_mano_de_obra_right.Columns["_COL_CARGO"].Index)
            //{
            //    TextBox auto_text_cargo = e.Control as TextBox;

            //    if (string.IsNullOrEmpty(auto_text_cargo.Text))
            //        auto_text_cargo.Text = string.Empty;
            //    //if (auto_text_cargo != null)
            //    //{
            //    auto_text_cargo.Width = 300;
            //    auto_text_cargo.AutoCompleteMode = AutoCompleteMode.Suggest;
            //    auto_text_cargo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //    _nt_m38.TexBox_Cargo(auto_text_cargo);
            //    //}
            //}
        }

        private void dgv_mano_de_obra_right_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
        UserControls.frm_tooltip tool = new UserControls.frm_tooltip();

        void tar()
        {
        }
        private void dgv_mano_de_obra_right_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tool.Show();
            }
            catch (Exception ex) { }
        }

        private void dgv_mano_de_obra_right_MouseHover(object sender, EventArgs e)
        {

        }

        private void dgv_mano_de_obra_right_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tool.Close();
            }
            catch (Exception ex) { }
        }

        private void frm_01_2_Load(object sender, EventArgs e)
        {
            int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
            btn_colapse.Location = new Point(coll, 0);
        }

    }
}
