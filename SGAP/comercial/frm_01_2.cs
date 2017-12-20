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
    public partial class frm_01_2 : Form
    {
        #region Variables

        ET_entidad _entidad = new ET_entidad();
        NT_M38 _nt_m38 = new NT_M38();
        NT_M41 _nt_m41 = new NT_M41();
        NT_R28 _nt_r28 = new NT_R28();
        NT_R27 _nt_r27 = new NT_R27();
        NT_M31 _nt_m31 = new NT_M31();
        ET_M31 _et_m31 = new ET_M31();
        List<ET_M31> _lista_m31 = new List<ET_M31>();
        
        public string nom;
        public string cod;
        public string marc;
        public string undad;
        public string precio;
        public string tipo;

        ContextMenuStrip MenuStrip_AddService = new ContextMenuStrip();
        ContextMenuStrip MenuStrip_ViewProperties_ = new ContextMenuStrip();

        int Id_Servicio_Padre;
        public int Id_servicio_hijo;
        int Periodo_servicio;
        #endregion

        #region Metodos
        public frm_01_2(ET_entidad _entity, bool editar = false)
        {
            InitializeComponent();
            Agregar_menu_contextual();
            this.BringToFront();

            _entidad = _entity;

            // Obtenemos los servicios de la cotización y alamacenamos el id del servicio padre.
            Cargar_servicios();

            Id_servicio_hijo = Id_Servicio_Padre;
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

        }

        void Cargar_servicios()
        {
            var result_array_int = _nt_r28.get_001(_entidad, tree_view_servicios);
            Id_Servicio_Padre = result_array_int[0];
            Periodo_servicio = result_array_int[1];
        }
        void Agregar_menu_contextual()
        {
            MenuStrip_ViewProperties_.Text = "Propiedades";
            MenuStrip_ViewProperties_.Name = "MenuStrip_ViewProperties_";
            MenuStrip_ViewProperties_.Size = new System.Drawing.Size(153, 48);

            ToolStripMenuItem View_Properties = new ToolStripMenuItem();

            View_Properties.Name = "View_Properties";
            View_Properties.Size = new System.Drawing.Size(132, 22);
            View_Properties.Text = "Ver Propiedades";

            MenuStrip_ViewProperties_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        View_Properties
                    });

            View_Properties.Click += new System.EventHandler(this.Item_mano_de_obra_click);


            MenuStrip_AddService.Text = "Servicios";
            MenuStrip_AddService.Name = "Menu_strip_for_TreeView";
            MenuStrip_AddService.Size = new System.Drawing.Size(153, 48);

            ToolStripMenuItem Add_service = new ToolStripMenuItem();

            Add_service.Name = "Add_service";
            Add_service.Size = new System.Drawing.Size(132, 22);
            Add_service.Text = "Agregar Servicio ->";

            var result = _nt_m41.get_001();

            if (!result._hubo_error)
            {
                result._lista_et_m41.ForEach(x =>
                {
                    ToolStripMenuItem item_ = new ToolStripMenuItem();
                    item_.Name = x._TM41_ID.ToString();
                    item_.Size = new System.Drawing.Size(152, 22);
                    item_.Text = x._TM41_DESCRIP;

                    Add_service.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        item_
                    });

                    item_.Click += new System.EventHandler(this.Item_servicio_click);
                });
            }
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

            if (index <= 5)
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

        private void Item_servicio_click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            int id_Servicio_seleccionado = Convert.ToInt32(item.Name.ToString());
            string Nombre_Servicio_seleccionado = item.Text;

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


            Cargar_servicios();
        }

        private void Item_mano_de_obra_click(object sender, EventArgs e)
        {
            frm_01_2_01 form_2_1 = new frm_01_2_01(Id_servicio_hijo);
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
            dgv_mano_de_obra.DataSource = _nt_r29.get_001(_et)._lista_et_r29;
            Contruir_DataGrid_Mano_Obra();
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

                    _entidades_= _nt_m31.gridTextBoxAutocomplete(auto_text);
                    _lista_m31 = _entidades_._lista_et_m31;                
                }
            }

        }

        private void dgv_entrada_datos_mq_eq_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void dgv_entrada_datos_mq_eq_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string nombre = dgv_entrada_datos_mq_eq.Columns[e.ColumnIndex].Name;
            if (nombre=="nombre")
            {
                //bool existe = _lista_m31.Any(item => item._TM31_DESCRIP + item._TM31_TM33_ID + item._TM31_TM72_ID == e.FormattedValue.ToString());
                bool existe = _lista_m31.Any(item => item._TM31_DESCRIP == e.FormattedValue.ToString());
                if (existe)
                {
                    //ET_M31 fila = _lista_m31.FirstOrDefault(item => item._TM31_DESCRIP + item._TM31_TM33_ID + item._TM31_TM72_ID == e.FormattedValue.ToString());
                    ET_M31 fila = _lista_m31.FirstOrDefault(item => item._TM31_DESCRIP == e.FormattedValue.ToString());

                    nom = fila._TM31_DESCRIP;//
                    cod = fila._TM31_ID;
                    marc = fila._TM31_TM33_ID;
                    undad = fila._TM31_TM72_ID;
                    precio = fila._TM31_PRECIO;
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

            double total = suma * Convert.ToDouble(precio);

            dgv_entrada_datos_mq_eq.Rows[i].Cells[6 + cont].Value = suma;
            dgv_entrada_datos_mq_eq.Rows[i].Cells[8 + cont].Value = total;

            string column_name = dgv_entrada_datos_mq_eq.Columns[e.ColumnIndex].Name; // nombre
            if (column_name.Equals("nombre"))
            {

                string nombre = Convert.ToString(dgv_entrada_datos_mq_eq.Rows[i].Cells[0].Value);

                if (nombre != "")

                {    
                              
                    
                    //dgv_entrada_datos_mq_eq.Rows[i].Cells[0].Value = nom;
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
                dgv_entrada_datos_mq_eq.Rows[i].Cells[7 + cont].Value = "";
                dgv_entrada_datos_mq_eq.Rows[i].Cells[6 + cont].Value = "";

            }
        }

    void Contruir_DataGrid_Mano_Obra()
    {

        dgv_mano_de_obra.Columns["_Fila"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_ID"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_TR28_ID"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_TM38_ID"].Visible = false;

        dgv_mano_de_obra.Columns["_TR29_DESCRIP"].Visible = true;
        dgv_mano_de_obra.Columns["_TR29_DESCRIP"].HeaderText = "Cargo";
        dgv_mano_de_obra.Columns["_TR29_DESCRIP"].DisplayIndex = 0;
        dgv_mano_de_obra.Columns["_TR29_DESCRIP"].Width = 200;


        dgv_mano_de_obra.Columns["_TR29_HORA_ENTRADA"].Visible = true;
        dgv_mano_de_obra.Columns["_TR29_HORA_ENTRADA"].HeaderText = "Hora Entrada";
        dgv_mano_de_obra.Columns["_TR29_HORA_ENTRADA"].DefaultCellStyle.Format = "hh:mm tt";
        dgv_mano_de_obra.Columns["_TR29_HORA_ENTRADA"].DisplayIndex = 1;

        dgv_mano_de_obra.Columns["_TR29_HORA_SALIDA"].Visible = true;
        dgv_mano_de_obra.Columns["_TR29_HORA_SALIDA"].HeaderText = "Hora Salida";
        dgv_mano_de_obra.Columns["_TR29_HORA_SALIDA"].DefaultCellStyle.Format = "hh:mm tt";
        dgv_mano_de_obra.Columns["_TR29_HORA_SALIDA"].DisplayIndex = 2;

        dgv_mano_de_obra.Columns["_TR29_DIAS_SEMANA"].Visible = true;
        dgv_mano_de_obra.Columns["_TR29_DIAS_SEMANA"].HeaderText = "Dias por semana";
        dgv_mano_de_obra.Columns["_TR29_DIAS_SEMANA"].DisplayIndex = 3;


        dgv_mano_de_obra.Columns["_TR29_ST"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_FLG_ELIMINADO"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_UCREA"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_FCREA"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_UACTUALIZA"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_FACTUALIZA"].Visible = false;
        dgv_mano_de_obra.Columns["_TR29_REMUNERACION"].Visible = true;
        dgv_mano_de_obra.Columns["_TR29_TM2_ID"].Visible = false;

    }

    #endregion

    #region Maquinaria y equipo

    #endregion
}
}
