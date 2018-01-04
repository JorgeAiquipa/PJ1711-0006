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
        NT_tareas Tarea = new NT_tareas();
        ET_M41 _et_m41 = new ET_M41();
        NT_M38 _nt_m38 = new NT_M38();
        NT_M41 _nt_m41 = new NT_M41();
        NT_R28 _nt_r28 = new NT_R28();
        NT_R27 _nt_r27 = new NT_R27();
        NT_M31 _nt_m31 = new NT_M31();
        NT_R29 _nt_r29 = new NT_R29();
        ET_M31 _et_m31 = new ET_M31();
        NT_M40 _NT_M40 = new NT_M40();
        NT_R31 _nt_r31 = new NT_R31();

        List<ET_M31> _lista_m31 = new List<ET_M31>();
        List<ET_M41> _lista_m41 = new List<ET_M41>();
        List<ET_R29> _lista_et_r29 = new List<ET_R29>();
        List<ET_M40> _lista_et_m40 = new List<ET_M40>();
        List<ET_R28> _lista_et_r28 = new List<ET_R28>();
        List<ET_R31> _lista_et_r31 = new List<ET_R31>();
     
        public string nom = "";
        public string cod = "";
        public string marc = "";
        public string undad = "";
        public double precio = 0;
        public string tipo = "";
        //bool primer_Selected_node = false;
        ImageList iconos_treeView = new ImageList();

        ContextMenuStrip MenuStrip_AddService = new ContextMenuStrip();
        ContextMenuStrip MenuStrip_DelService = new ContextMenuStrip();
        ContextMenuStrip MenuStrip_ViewProperties_ = new ContextMenuStrip();

        int Id_Servicio_Padre;
        public int Id_servicio_hijo;
        int Periodo_servicio;
        string nodos;
        string Id_Cotizacion;
        int Id_CotizacionServicio;
        bool Editar_cotizacion = false;
        bool mostrar_resumen_De_mano_de_obra = false;


        #endregion

        #region Metodos
        public frm_01_2(ET_entidad _entity, bool editar = false)
        {         
            
            InitializeComponent();

            Agregar_menu_contextual();         

            //style

            this.BackColor = Color.FromArgb(221, 221, 221);

            label10.BackColor = Color.FromArgb(0, 137,123);
            label10.ForeColor = Color.White;
            label11.BackColor = Color.FromArgb(0, 137, 123);
            label11.ForeColor = Color.White;
            label12.BackColor = Color.FromArgb(0, 137, 123);
            label12.ForeColor = Color.White;
            label13.BackColor = Color.FromArgb(0, 137, 123);
            label13.ForeColor = Color.White;
            label6.BackColor = Color.FromArgb(0, 137, 123);
            label6.ForeColor = Color.White;
            label5.BackColor = Color.FromArgb(0, 137, 123);
            label5.ForeColor = Color.White;
            label4.BackColor = Color.FromArgb(0, 137, 123);
            label4.ForeColor = Color.White;
            label3.BackColor = Color.FromArgb(0, 137, 123);
            label3.ForeColor = Color.White;
            label2.BackColor = Color.FromArgb(0, 137, 123);
            label2.ForeColor = Color.White;
            label1.BackColor = Color.FromArgb(0, 137, 123);
            label1.ForeColor = Color.White;
            panel12.BackColor = Color.FromArgb(0, 137, 123);

            panel_colapse.BackColor = Color.FromArgb(255, 238, 88);
            panel_colapse.BackgroundImage = Properties.Resources.izquierda;
            panel_colapse.BackgroundImageLayout = ImageLayout.Stretch;

            panel_colapse_2.Enabled = false;
            panel_colapse_2.Visible = false;
            panel_colapse_2.BackColor = Color.FromArgb(255, 238, 88);
            panel_colapse_2.BackgroundImage = Properties.Resources.derecha;
            panel_colapse_2.BackgroundImageLayout = ImageLayout.Stretch;


            iconos_treeView.TransparentColor = Color.White;
            iconos_treeView.ColorDepth = ColorDepth.Depth32Bit;
            iconos_treeView.ImageSize = new Size(16, 16);

            iconos_treeView.Images.Add(Properties.Resources.reporte);
            iconos_treeView.Images.Add(Properties.Resources.reporte_3);
            iconos_treeView.Images.Add(Properties.Resources.reporte_2);
            iconos_treeView.Images.Add(Properties.Resources.nota);

            //tree_view_servicios.ImageList = iconos_treeView;

            this.BringToFront();

            //end style

            _entidad = _entity;

            // Obtenemos los servicios de la cotización y alamacenamos el id del servicio padre.            
            Id_servicio_hijo = Id_Servicio_Padre;

            _lista_et_m40 = _NT_M40.get_001()._lista_et_m40;

            Editar_cotizacion = editar;

            //Obtenemos los locales que posee la cotización seleccionada
            _entidad._entity_r27._TR27_TM39_ID = _entidad._entity_m39._TM39_ID;
            _entidad._entity_r27._TR27_TM19_ID = _entidad._entity_m39._entity_et_m19._TM19_ID;
            var result = _nt_r27.get_001(_entidad);
            _entidad._lista_et_m27 = result._lista_et_m27;
            _entidad._lista_et_r27 = result._lista_et_r27;


            tabControl1.Visible = false;

            foreach (TabPage page in tabControl1.TabPages)
            {
                Panel panel = page.Controls[0] as Panel;
                Panels.Add(panel);

                panel.Parent = tabControl1.Parent;
                panel.Location = tabControl1.Location;
                panel.Visible = false;
            }

            DisplayPanel(10100);
            Contruir_DataGrid_Mano_Obra();
            CreateColumn();

            _nt_m31.Mensaje_Alerta += Mensaje_Informacion;

            dgv_mano_de_obra.Scroll += new ScrollEventHandler(dgv_mano_de_obra_right_Scroll);
            dgv_mano_de_obra_right.Scroll += new ScrollEventHandler(dgv_mano_de_obra_Scroll);

            _helper.Set_Style_to_DatagridView(dgv_entrada_datos_mq_eq);

            _nt_r28.Cargar_explorador_De_Servicios_ += CargarExplorados_de_servicios;
            _nt_r28.Eliminar_Servicio_Explorador_ += _nt_r28_Eliminar_Servicio_Explorador_;
            _nt_r29.Cargar_Listado_ += _nt_r29_Cargar_Listado_;

            Obtener_Servicios_de_cotizacion();

            #region mano_de_obra
            
            btn_editar_mano_de_obra.Enabled = Editar_cotizacion;
            btn_guardar_mano_de_obra.Enabled = false;
            #endregion

            #region maquinaria_y_equipo

            #endregion

            #region page_3

            #endregion
        }

        private void _nt_r29_Cargar_Listado_(object sender, ET_entidad e)
        {
            _lista_et_r29 = e._lista_et_r29;
            

            if (_lista_et_r29 != null && _lista_et_r29.Count > 0)
            {
                Desplegar_informacion_de_mano_de_obra();
            }
            else
            {
                if (_entro)
                    Item_mano_de_obra_click(null, null);
            }
        }

        public void Obtener_Servicios_de_cotizacion()
        {
            _entidad._entity_r28._TR28_TM39_ID = _entidad._entity_m39._TM39_ID;
            _nt_r28.Et_r28(_entidad._entity_r28);
            _nt_r28.Iniciar(Tarea.LISTAR);
        }
        #region Eventos
         
        public void Mensaje_Informacion(object sender, ET_entidad e)
        {
            MessageBox.Show
            (
                e._contenido_mensaje, e._titulo_mensaje,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        public void CargarExplorados_de_servicios(object sender, ET_entidad e)
        {
            Id_Servicio_Padre = _entidad._entity_r28._TR28_PADRE;
            Periodo_servicio = _entidad._entity_r28._TR28_PERIODO;

            tree_view_servicios.Nodes.Clear();

            tree_view_servicios.ImageList = iconos_treeView;
            tree_view_servicios.ImageIndex = 0;

            if (!e._hubo_error && _lista_et_r28 != null)
            {
                string name_nodo = string.Format("{0} - {1}", _entidad._entity_m39._TM39_ID, _entidad._entity_m39._entity_et_m19._TM19_DESCRIP2);
                Text = string.Format("Cotización: {0}", name_nodo);
                TreeNode nodo_principal = new TreeNode();
                nodo_principal.Tag = 10100;
                nodo_principal.Name = name_nodo;
                nodo_principal.Text = name_nodo;

                var lista_resultadito = e._lista_et_r28
                    .GroupBy(u => u._TR28_TM42_ID)
                    .OrderBy(o => o.Max(a => a._TR28_ID))
                    .Select(grp => grp.ToList())
                    .ToList();

                foreach (List<ET_R28> _lista_r28 in lista_resultadito)
                {
                    int id_tipo_Servicio = 0;
                    string nombre_servicio = "";

                    TreeNode servicios = new TreeNode();                    

                    foreach (ET_R28 row_u in _lista_r28)
                    {
                        id_tipo_Servicio = row_u._TR28_TM42_ID;
                        nombre_servicio = row_u._TR28_TM42_DESCRIP;
                        Id_Servicio_Padre = row_u._TR28_PADRE;

                        Id_Cotizacion = row_u._TR28_TM39_ID;
                        //Id_CotizacionServicio = row_u._TR28_ID;

                        TreeNode mano_obra = new TreeNode("Mano de obra");
                        mano_obra.Name = "Mano de Obra";
                        mano_obra.Tag = 0;
                        mano_obra.ImageIndex = 3;
                        mano_obra.SelectedImageIndex = 3;

                        TreeNode maquinaria = new TreeNode("Maquinaria y equipo");
                        maquinaria.Tag = 1;
                        maquinaria.ImageIndex = 3;
                        maquinaria.SelectedImageIndex = 3;

                        TreeNode materiales = new TreeNode("Materiales e insumos");
                        materiales.Tag = 2;
                        materiales.ImageIndex = 3;
                        materiales.SelectedImageIndex = 3;

                        TreeNode implementos = new TreeNode("Implementos de limpieza");
                        implementos.Tag = 3;
                        implementos.ImageIndex = 3;
                        implementos.SelectedImageIndex = 3;

                        TreeNode suministros = new TreeNode("Suministros");
                        suministros.Tag = 4;
                        suministros.ImageIndex = 3;
                        suministros.SelectedImageIndex = 3;

                        TreeNode indumentaria = new TreeNode("Indumentaria");
                        indumentaria.Tag = 5;
                        indumentaria.ImageIndex = 3;
                        indumentaria.SelectedImageIndex = 3;

                        TreeNode Epp = new TreeNode("Epp");
                        Epp.Tag = 6;
                        Epp.ImageIndex = 3;
                        Epp.SelectedImageIndex = 3;


                        TreeNode node_hijo = new TreeNode(row_u._TR28_DESCRIP, new TreeNode[] {
                                mano_obra,maquinaria,materiales,implementos,suministros,indumentaria,Epp
                                        });
                        node_hijo.Text = row_u._TR28_DESCRIP;
                        node_hijo.Tag = 1000;
                        node_hijo.Name = row_u._TR28_ID.ToString();
                        node_hijo.ImageIndex = 2;
                        node_hijo.SelectedImageIndex = 2;

                        servicios.Nodes.Add(node_hijo);
                        servicios.Text = row_u._TR28_TM42_DESCRIP;
                        servicios.Name = Convert.ToString(id_tipo_Servicio);
                        servicios.Tag = 2000;
                        servicios.ImageIndex = 1;
                        servicios.SelectedImageIndex = 1;
                    }
                    servicios.NodeFont = new Font(this.tree_view_servicios.Font, FontStyle.Bold);
                    nodo_principal.Nodes.Add(servicios);

                }
                //agregar nuevos nodos 7 y 8
                TreeNode financieros = new TreeNode("Gastos financieros");
                financieros.Tag = 7;
                financieros.ImageIndex = 1;
                financieros.SelectedImageIndex = 1;
                financieros.NodeFont = new Font(this.tree_view_servicios.Font, FontStyle.Bold);

                TreeNode indirectos = new TreeNode("Otros gastos indirectos");
                indirectos.Tag = 8;
                indirectos.ImageIndex = 1;
                indirectos.SelectedImageIndex = 1;
                indirectos.NodeFont = new Font(this.tree_view_servicios.Font, FontStyle.Bold);

                nodo_principal.Nodes.Add(financieros);
                nodo_principal.Nodes.Add(indirectos);

                nodo_principal.ExpandAll();
                tree_view_servicios.Nodes.Add(nodo_principal);

                tree_view_servicios.SelectedNode = tree_view_servicios.Nodes[0];
                //if (!primer_Selected_node)
                //{
                //    primer_Selected_node = true;
                //    tree_view_servicios.SelectedNode = tree_view_servicios.Nodes[0].Nodes[0].Nodes[0].Nodes[0];
                //    Metodo_cargar_informacion_mano_de_obra();
                //}
            }
        }
        private void _nt_r28_Eliminar_Servicio_Explorador_(object sender, ET_entidad e)
        {
            //throw new NotImplementedException();
            Obtener_Servicios_de_cotizacion();

        }
        private void panel_colapse_MouseHover(object sender, EventArgs e)
        {
            panel_colapse.BackColor = Color.White;
            panel_colapse.Cursor = Cursors.Hand;
        }

        private void panel_colapse_MouseLeave(object sender, EventArgs e)
        {
            panel_colapse.BackColor = Color.FromArgb(255, 238, 88);
        }

        private void panel_colapse_2_MouseHover(object sender, EventArgs e)
        {
            panel_colapse_2.BackColor = Color.White;
            panel_colapse_2.Cursor = Cursors.Hand;
        }

        private void panel_colapse_2_MouseLeave(object sender, EventArgs e)
        {
            panel_colapse_2.BackColor = Color.FromArgb(255, 238, 88);
        }

        private void panel_colapse_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
            panel_colapse_2.Enabled = true;
            panel_colapse_2.Visible = true;
            panel_colapse_2.Location = new Point(4, 2);
        }

        private void panel_colapse_2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            panel_colapse_2.Enabled = false;
            panel_colapse_2.Visible = false;
        }

        private void frm_01_2_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.panel_colapse, "Ocultar estructura");
            toolTip1.SetToolTip(this.panel_colapse_2, "Ver estructura");

            int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
            panel_colapse_2.Location = new Point(coll + 6, 2);

        }

        private void frm_01_2_Resize(object sender, EventArgs e)
        {
            panel_colapse_2.Location = new Point(4, 2);
        }
        #endregion

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
            Add_service.Text = "Agregar servicio...";

            MenuStrip_AddService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        Add_service
                    });

            Add_service.Click += new System.EventHandler(this.Item_Add_Service_click);

            MenuStrip_AddService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                Add_service
            });

            

            //Eliminar Servicio
            MenuStrip_DelService.Text = "Servicios";
            MenuStrip_DelService.Name = "Menu_strip_for_TreeView";
            MenuStrip_DelService.Size = new System.Drawing.Size(153, 48);

            ToolStripMenuItem Del_service = new ToolStripMenuItem();

            Del_service.Name = "Del_service";
            Del_service.Size = new System.Drawing.Size(132, 22);
            Del_service.Text = "Eliminar servicio";

            MenuStrip_DelService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        Del_service
                    });

            Del_service.Click += new System.EventHandler(this.Item_Del_Service_click);

            MenuStrip_DelService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                Del_service
            });
        }

        #endregion

        #region Eventos

        List<Panel> Panels = new List<Panel>();
        Panel VisiblePanel = null;
        //tiene lugar cuando cambia la selección.
        private void tree_view_servicios_AfterSelect(object sender, TreeViewEventArgs e)
        {

            int index = int.Parse(e.Node.Tag.ToString());
            DisplayPanel(index);
        }

        private void DisplayPanel(int index)
        {
            if (index <= 8)
            {
                if (Panels.Count < 1) return;

                if (VisiblePanel == Panels[index]) return;

                if (VisiblePanel != null) VisiblePanel.Visible = false;

                Panels[index].Visible = true;
                VisiblePanel = Panels[index];
            }
            else if (index == 10100)
            {
                if (Panels.Count < 1) return;

                if (VisiblePanel == Panels[9]) return;

                if (VisiblePanel != null) VisiblePanel.Visible = false;

                Panels[9].Visible = true;
                VisiblePanel = Panels[9];
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
                        case "1000": // ver menu para mano de obra

                            Id_CotizacionServicio = Convert.ToInt32(tree_view_servicios.SelectedNode.Name);
                            MenuStrip_DelService.Show(tree_view_servicios, p);
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
                Obtener_Servicios_de_cotizacion();
                //Cargar_servicios();
            }

        }

        private void Item_Del_Service_click(object sender, EventArgs e)
        {
            if (Id_CotizacionServicio == Id_Servicio_Padre)
            {
                DialogResult decision2_msg = MessageBox.Show("No puede eliminar el servicio principal.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (decision2_msg == DialogResult.OK) { }
            }
            else
            {
                DialogResult decision_msg = MessageBox.Show("Esta seguro de que desea eliminar este servicio.", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (decision_msg == DialogResult.OK)
            {
                _entidad._entity_r28._TR28_ID = Id_CotizacionServicio;
                _entidad._entity_r28._TR28_TM39_ID = Id_Cotizacion;


                    _nt_r28.Et_r28(_entidad._entity_r28);
                    _nt_r28.Iniciar(Tarea.ELIMINAR);
            }

        }            
            
        }

        void Metodo_cargar_informacion_servicio()//diego
        {
            ET_R29 _et = new ET_R29();
            _et._TR29_TR28_ID = Id_servicio_hijo; // captura el node
        }

        private void Item_mano_de_obra_click(object sender, EventArgs e)
        {
            _entro = false;
            frm_01_2_01 form_2_1 = new frm_01_2_01(Id_servicio_hijo, _lista_et_m40);
            form_2_1.ShowDialog();
            if (form_2_1.DialogResult == DialogResult.OK)
            {
                Editar_cotizacion = true;
                btn_editar_mano_de_obra.Enabled = true;
                Metodo_cargar_informacion_mano_de_obra();
                mostrar_resumen_De_mano_de_obra = true;

            }
        }
        #endregion

        #region Mano de obra
        bool _entro = true;
        void Metodo_cargar_informacion_mano_de_obra()
        {
            ET_R29 _et = new ET_R29();
            _lista_et_r29 = new List<ET_R29>();
            _lista_et_r29.Clear();
            _et._TR29_TR28_ID = Id_servicio_hijo; // captura el node
            _et._lista_et_m40 = _lista_et_m40;


            if (Editar_cotizacion)
                _lista_et_r31 = _nt_r31.get_001(Id_servicio_hijo);
            _nt_r29.Agregar_ETR29(_et);
            _nt_r29.Iniciar(Tarea.LISTAR);

        }
        private void dgv_mano_de_obra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int suma_total = 0;

            for (int a = 1; a < dgv_mano_de_obra.ColumnCount; a++)
            {
                suma_total = suma_total + Convert.ToInt32(dgv_mano_de_obra.Rows[e.RowIndex].Cells[a].Value);
            }

            dgv_mano_de_obra_right.Rows[e.RowIndex].Cells[0].Value = suma_total;
            dgv_mano_de_obra_right.Rows[e.RowIndex].Cells[4].Value = suma_total * (Convert.ToDecimal(dgv_mano_de_obra_right.Rows[e.RowIndex].Cells[3].Value));


        }

        private void dgv_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dgv_mano_de_obra.CurrentCell.ColumnIndex != 0)
            {
                TextBox TEX_BOX_NUMBER = e.Control as TextBox;
                TEX_BOX_NUMBER.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_Number_KeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_Number_KeyPress);
            }
        }

        private void dgv_mano_de_obra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgv_mano_de_obra_right.Rows[e.RowIndex].Selected = true;
        }

        private void dgv_mano_de_obra_right_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv_mano_de_obra.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception) { }
        }

        private void btn_guardar_mano_de_obra_Click(object sender, EventArgs e)
        {
            // call metodo guardar
            // mostrar seguidamente la vista general de mano de obra
            if (_lista_et_r31.Count > 0)
            //actualizar
            {
                Metodo_preparar_informacion_para_actualizar_mano_de_obra();
            }
            else
            {
                Metodo_preparar_informacion_para_registrar_mano_de_obra();
            }
        }

        private void Metodo_preparar_informacion_para_actualizar_mano_de_obra()
        {
            var tmp = _lista_et_r29;

            NT_R31 ins = new NT_R31();
            ins.set_002(_lista_et_r29, _entidad._lista_et_r27);
        }

        private void Metodo_preparar_informacion_para_registrar_mano_de_obra()
        {
            var tmp = _lista_et_r29;

            NT_R31 ins = new NT_R31();
            ins.set_001(_lista_et_r29, _entidad._lista_et_r27);
        }

        private void btn_editar_mano_de_obra_Click(object sender, EventArgs e)
        {
            //preparar vista de mano de obra para editar
            btn_guardar_mano_de_obra.Enabled = true;
            mostrar_resumen_De_mano_de_obra = false;
            // ocultar el detalle de subtotales
            //
        }

        private void dgv_mano_de_obra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                ET_R29 _et_r29_editable = new ET_R29();
                _et_r29_editable = _lista_et_r29.FirstOrDefault(x => x._Fila == e.RowIndex);
                object[] respaldo = _et_r29_editable._Locales_por_cargo_cantidad_personal;
                object[] nuevos_valores = new object[respaldo.Count()];
                int indice_res = 0;
                foreach (int[] r in respaldo)
                {
                    int[] value = new int[2];

                    value[0] = r[0];
                    value[1] = r[1];
                    if(indice_res == (e.ColumnIndex - 1))
                        value[0] = Convert.ToInt32(dgv_mano_de_obra.CurrentRow.Cells[e.ColumnIndex].Value);

                    nuevos_valores[indice_res] = value;
                    indice_res++;
                }

                _et_r29_editable._Locales_por_cargo_cantidad_personal = nuevos_valores;// Convert.ToInt32(dgv_mano_de_obra.CurrentRow.Cells[e.ColumnIndex].Value);
            }
        }
        private void Contruir_DataGrid_Mano_Obra()
        {
            dgv_mano_de_obra.AllowUserToAddRows = false;
            dgv_mano_de_obra.ScrollBars = ScrollBars.Horizontal;

            _helper.Set_Style_to_DatagridView(dgv_mano_de_obra);
            _helper.Set_Style_to_DatagridView(dgv_mano_de_obra_right);

            dgv_mano_de_obra.AutoGenerateColumns = false;
            dgv_mano_de_obra.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
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

            if (_entidad._lista_et_r27 != null)
            {

                int cantidad_final_de_indices = (dgv_mano_de_obra.ColumnCount + _entidad._lista_et_r27.Count);
                dgv_mano_de_obra.ColumnCount = cantidad_final_de_indices;

                int indice_de_inicio = cantidad_final_de_indices - _entidad._lista_et_r27.Count;

                int indice_nn = 1;
                _entidad._lista_et_r27.ForEach(x =>
                {
                    dgv_mano_de_obra.Columns[indice_de_inicio].Visible = true;
                    dgv_mano_de_obra.Columns[indice_de_inicio].DefaultCellStyle.NullValue = "0";
                    dgv_mano_de_obra.Columns[indice_de_inicio].Width = 200;
                    dgv_mano_de_obra.Columns[indice_de_inicio].Name = x._TR27_DESCRIP;
                    dgv_mano_de_obra.Columns[indice_de_inicio].HeaderText = string.IsNullOrEmpty(x._TR27_DESCRIP) ? string.Format("Local {0}", indice_nn) : x._TR27_DESCRIP.Length > 26 ? string.Format("{0}...", x._TR27_DESCRIP.Substring(0, 26)) : x._TR27_DESCRIP;
                    indice_de_inicio++;
                    indice_nn++;
                });

            }
            //dgv_mano_de_obra.

            // for datgrid mano de obra right
            dgv_mano_de_obra_right.AllowUserToAddRows = false;
            dgv_mano_de_obra_right.AutoGenerateColumns = false;
            dgv_mano_de_obra_right.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //dgv_mano_de_obra_right.ReadOnly = true;

            // columnas de remuneraciones 

            // remuneraciones de acuerdo a la lista de remuneraciones que se obtiene al consultar la mano de obra
            //
            DataGridViewColumn MANO_OBRA_COL_SUELDO_BASICO = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUELDO_BASICO.DataPropertyName = "MANO_OBRA_COL_SUELDO_BASICO";
            MANO_OBRA_COL_SUELDO_BASICO.HeaderText = "Sueldo básico";
            MANO_OBRA_COL_SUELDO_BASICO.Name = "MANO_OBRA_COL_SUELDO_BASICO";
            MANO_OBRA_COL_SUELDO_BASICO.Width = 85;
            //MANO_OBRA_COL_SUELDO_BASICO.ReadOnly = true;
            MANO_OBRA_COL_SUELDO_BASICO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewColumn MANO_OBRA_COL_TOTAL_PERSONAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_TOTAL_PERSONAL.DataPropertyName = "MANO_OBRA_COL_TOTAL_PERSONAL";
            MANO_OBRA_COL_TOTAL_PERSONAL.HeaderText = "Tot.personal";
            MANO_OBRA_COL_TOTAL_PERSONAL.Name = "MANO_OBRA_COL_TOTAL_PERSONAL";
            MANO_OBRA_COL_TOTAL_PERSONAL.Width = 80;
            //MANO_OBRA_COL_TOTAL_PERSONAL.ReadOnly = true;
            MANO_OBRA_COL_TOTAL_PERSONAL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewColumn MANO_OBRA_COL_SUELDO_MENSUAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUELDO_MENSUAL.DataPropertyName = "MANO_OBRA_COL_SUELDO_MENSUAL";
            MANO_OBRA_COL_SUELDO_MENSUAL.HeaderText = "Sueldo mensual";
            MANO_OBRA_COL_SUELDO_MENSUAL.Name = "MANO_OBRA_COL_SUELDO_MENSUAL";
            MANO_OBRA_COL_SUELDO_MENSUAL.Width = 60;
            //MANO_OBRA_COL_SUELDO_MENSUAL.ReadOnly = true;
            MANO_OBRA_COL_SUELDO_MENSUAL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewColumn MANO_OBRA_COL_TOTAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_TOTAL.DataPropertyName = "MANO_OBRA_COL_TOTAL";
            MANO_OBRA_COL_TOTAL.HeaderText = "Total";
            MANO_OBRA_COL_TOTAL.Name = "MANO_OBRA_COL_TOTAL";
            MANO_OBRA_COL_TOTAL.Width = 85;
            //MANO_OBRA_COL_TOTAL.ReadOnly = true;
            MANO_OBRA_COL_TOTAL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewColumn MANO_OBRA_COL_SUM_CONCEPTOS = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUM_CONCEPTOS.DataPropertyName = "MANO_OBRA_COL_SUM_CONCEPTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS.HeaderText = "Total conceptos";
            MANO_OBRA_COL_SUM_CONCEPTOS.Name = "MANO_OBRA_COL_SUM_CONCEPTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS.Width = 70;
            //MANO_OBRA_COL_SUM_CONCEPTOS.ReadOnly = false;
            MANO_OBRA_COL_SUM_CONCEPTOS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


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

        private void Desplegar_informacion_de_mano_de_obra()
        {

            dgv_mano_de_obra.Rows.Clear();
            //dgv_mano_de_obra.DataSource = null;
            //dgv_mano_de_obra.Refresh();
            //dgv_mano_de_obra.Update();
            dgv_mano_de_obra_right.Rows.Clear();

            _lista_et_r29.ForEach(fila_ => {

                string cargo_horario_conceptos = Obtener_descripcion_mano_obra(fila_._TR29_DESCRIP, fila_._TR29_DIAS_SEMANA, fila_._TR29_HORA_ENTRADA, fila_._TR29_HORA_SALIDA, fila_._lista_et_r30);

                //_lista_et_r31
                var res = _lista_et_r31.Where(fila => fila._TR31_TR29_ID == fila_._TR29_ID).ToList();

                object[] informacion_r31 = new object[res.Count];


                int total_personal = 0;
                int indice_locales = 0;

                string[] fila_dgv_mano_obra = new string[(1 + res.Count)];
                fila_dgv_mano_obra[0] = cargo_horario_conceptos;

                int indice_dgv_mano_obra = 1;
                res.ForEach(r => {

                    int[] cantidades = new int[2];
                    cantidades[0] = r._TR31_CANT_PERSONAS;
                    cantidades[1] = r._TR31_ID;
                    informacion_r31[indice_locales] = cantidades;

                    total_personal = total_personal + r._TR31_CANT_PERSONAS;
                    fila_dgv_mano_obra[indice_dgv_mano_obra] = r._TR31_CANT_PERSONAS.ToString();
                    indice_locales++;
                    indice_dgv_mano_obra++;
                });

                int[] relleno = new int[] { 0, 0 };
                object[] rellenos = new object[_entidad._lista_et_m27.Count];
                int indice = 0;
                _entidad._lista_et_m27.ForEach(c => {
                    rellenos[indice] = relleno;
                    indice++;
                });

                if (Editar_cotizacion)
                    if (res.Count() == 0)
                        fila_._Locales_por_cargo_cantidad_personal = rellenos;//new int[_entidad._lista_et_m27.Count];
                    else
                        fila_._Locales_por_cargo_cantidad_personal = informacion_r31;
                else
                    fila_._Locales_por_cargo_cantidad_personal = rellenos;//new int[_entidad._lista_et_m27.Count];

                var list = fila_._lista_et_r30;
                decimal SUMA_CONCEPTOS_REMUNERATIVOS = 0M;
                fila_._lista_et_r30.ForEach(X =>
                {
                    SUMA_CONCEPTOS_REMUNERATIVOS = SUMA_CONCEPTOS_REMUNERATIVOS * 1M + X._TR30_IMPORTE * 1M;
                });

                dgv_mano_de_obra_right.Rows.Add(
                    total_personal, // total personal
                    fila_._TR29_REMUNERACION, // sueldo basico
                    SUMA_CONCEPTOS_REMUNERATIVOS,
                    fila_._TR29_REMUNERACION * 1M + SUMA_CONCEPTOS_REMUNERATIVOS * 1M,
                    ((fila_._TR29_REMUNERACION + SUMA_CONCEPTOS_REMUNERATIVOS) * total_personal)*1M
                 );

                dgv_mano_de_obra.Rows.Add(fila_dgv_mano_obra);
            });

            //if(mostrar_resumen_De_mano_de_obra)
                //mostrar sub totales
        }

        private string Obtener_descripcion_mano_obra(string descripcion, int dias_por_Semana, DateTime hora_entrada, DateTime hora_salida, List<ET_R30> conceptos_)
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

            string conceptos_short = " ";
            conceptos_.ForEach(row => {
                conceptos_short = conceptos_short + (string.IsNullOrEmpty(row._TR30_DESCRIP) ? string.Empty : row._TR30_DESCRIP.Substring(0, 3)) + "/";
            });
            conceptos_short = conceptos_short.Substring(0, conceptos_short.Length - 1);

            horario = horario + hora_entrada.ToString("H:mm") + " - " + hora_salida.ToString("H:mm");

            return descripcion + " " + horas.ToString() + " h " + horario + conceptos_short;

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

        private void dgv_mano_de_obra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {

                // manipular lo ingresado par poder registrarlo
                //_lista_et_r29 = _lista_et_r29;
            }
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
        #endregion


        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
            //btn_colapse.Location = new Point(coll, 0);
            panel_colapse_2.Location = new Point(coll + 6, 2);

        }

        //probar calculo de mano de obra
        // añadir la filas de calculos de mano de obra
        private void button1_Click(object sender, EventArgs e)
        {
            Metodo_mostrar_calculos_de_costos_mano_de_obra();
        }

        private void Metodo_mostrar_calculos_de_costos_mano_de_obra()
        {
            //ingresar dos filas vacias de margen

            string[] fila_vacia_mano_de_obra_left = new string[dgv_mano_de_obra.ColumnCount];
            string[] fila_vacia_mano_de_obra_right = new string[dgv_mano_de_obra_right.ColumnCount];

            //--> llenamos los valores para las filas como vacio en funcion a la cantidad de columnas 
            for (int a = 0; a < dgv_mano_de_obra.ColumnCount; a++)
                fila_vacia_mano_de_obra_left[a] = "";
            for (int a = 0; a < dgv_mano_de_obra_right.ColumnCount; a++)
                fila_vacia_mano_de_obra_right[a] = "";

            for (int a = 0; a < 2; a++) // -> cantidad de filas vacias por defecto 2
            {
                dgv_mano_de_obra_right.Rows.Add(fila_vacia_mano_de_obra_right);
                dgv_mano_de_obra.Rows.Add(fila_vacia_mano_de_obra_left);
            }

            int sub_total_personal = 0;
            _lista_et_r29.ForEach(fila_ => {

                // total de personal // suma de todo
                ////_lista_et_r31
                //var res = _lista_et_r31.Where(fila => fila._TR31_TR29_ID == fila_._TR29_ID).ToList();

                //object[] informacion_r31 = new object[res.Count];


                //int total_personal = 0;

                //int indice_dgv_mano_obra = 1;
                //res.ForEach(r =>
                //{

                //    int[] cantidades = new int[2];
                //    cantidades[0] = r._TR31_CANT_PERSONAS;
                //    cantidades[1] = r._TR31_ID;
                //    informacion_r31[indice_locales] = cantidades;

                //    total_personal = total_personal + r._TR31_CANT_PERSONAS;
                //    indice_locales++;
                //    indice_dgv_mano_obra++;
                //});
            });
            //_lista_et_r29.ForEach(fila_ => {

            //    string cargo_horario_conceptos = Obtener_descripcion_mano_obra(fila_._TR29_DESCRIP, fila_._TR29_DIAS_SEMANA, fila_._TR29_HORA_ENTRADA, fila_._TR29_HORA_SALIDA, fila_._lista_et_r30);

            //    //_lista_et_r31
            //    var res = _lista_et_r31.Where(fila => fila._TR31_TR29_ID == fila_._TR29_ID).ToList();

            //    object[] informacion_r31 = new object[res.Count];


            //    int total_personal = 0;
            //    int indice_locales = 0;

            //    string[] fila_dgv_mano_obra = new string[(1 + res.Count)];
            //    fila_dgv_mano_obra[0] = cargo_horario_conceptos;

            //    int indice_dgv_mano_obra = 1;
            //    res.ForEach(r => {

            //        int[] cantidades = new int[2];
            //        cantidades[0] = r._TR31_CANT_PERSONAS;
            //        cantidades[1] = r._TR31_ID;
            //        informacion_r31[indice_locales] = cantidades;

            //        total_personal = total_personal + r._TR31_CANT_PERSONAS;
            //        fila_dgv_mano_obra[indice_dgv_mano_obra] = r._TR31_CANT_PERSONAS.ToString();
            //        indice_locales++;
            //        indice_dgv_mano_obra++;
            //    });

            //    int[] relleno = new int[] { 0, 0 };
            //    object[] rellenos = new object[_entidad._lista_et_m27.Count];
            //    int indice = 0;
            //    _entidad._lista_et_m27.ForEach(c => {
            //        rellenos[indice] = relleno;
            //        indice++;
            //    });

            //    if (Editar_cotizacion)
            //        if (res.Count() == 0)
            //            fila_._Locales_por_cargo_cantidad_personal = rellenos;//new int[_entidad._lista_et_m27.Count];
            //        else
            //            fila_._Locales_por_cargo_cantidad_personal = informacion_r31;
            //    else
            //        fila_._Locales_por_cargo_cantidad_personal = rellenos;//new int[_entidad._lista_et_m27.Count];

            //    var list = fila_._lista_et_r30;
            //    decimal SUMA_CONCEPTOS_REMUNERATIVOS = 0M;
            //    fila_._lista_et_r30.ForEach(X =>
            //    {
            //        SUMA_CONCEPTOS_REMUNERATIVOS = SUMA_CONCEPTOS_REMUNERATIVOS * 1M + X._TR30_IMPORTE * 1M;
            //    });

            //    dgv_mano_de_obra_right.Rows.Add(
            //        total_personal, // total personal
            //        fila_._TR29_REMUNERACION, // sueldo basico
            //        SUMA_CONCEPTOS_REMUNERATIVOS,
            //        fila_._TR29_REMUNERACION * 1M + SUMA_CONCEPTOS_REMUNERATIVOS * 1M,
            //        ((fila_._TR29_REMUNERACION + SUMA_CONCEPTOS_REMUNERATIVOS) * total_personal) * 1M
            //     );

            //    dgv_mano_de_obra.Rows.Add(fila_dgv_mano_obra);
            //});
        }
    }
}
