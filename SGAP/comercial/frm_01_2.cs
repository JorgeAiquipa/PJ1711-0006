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
using System.Reflection;

using Win28etug;
using Win28ntug;

namespace SGAP.comercial
{
    public partial class frm_01_2 : Form
    {
        #region Variables e Instancias
        ET_entidad _ET_ENTIDAD = new ET_entidad();
        NT_helper _NT_Helper = new NT_helper();
        NT_tareas Tarea = new NT_tareas();
        ET_M41 _ET_M41 = new ET_M41();
        NT_M38 _NT_M38 = new NT_M38();
        NT_M41 _NT_M41 = new NT_M41();
        NT_R28 _NT_R28 = new NT_R28();
        NT_R27 _NT_R27 = new NT_R27();
        NT_M31 _NT_M31 = new NT_M31();
        NT_R29 _NT_R29 = new NT_R29();
        ET_M31 _ET_M31 = new ET_M31();
        NT_M40 _NT_M40 = new NT_M40();
        NT_R31 _NT_R31 = new NT_R31();

        List<ET_M31> _LISTA_M31 = new List<ET_M31>();
        List<ET_M41> _LISTA_M41 = new List<ET_M41>();
        List<ET_R29> _LISTA_ET_R29 = new List<ET_R29>();
        List<ET_M40> _LISTA_ET_M40 = new List<ET_M40>();
        List<ET_R28> _LISTA_ET_R28 = new List<ET_R28>();
        List<ET_R31> _LISTA_ET_R31 = new List<ET_R31>();
     
        ImageList iconos_treeView = new ImageList();

        ContextMenuStrip MenuStrip_AgregarServicio = new ContextMenuStrip();
        ContextMenuStrip MenuStrip_BorrarServicio = new ContextMenuStrip();
        ContextMenuStrip MenuStrip_VerPropiedades = new ContextMenuStrip();
        ContextMenuStrip MenuStrip_DatosGenerales = new ContextMenuStrip();

        public string nom = "";
        public string cod = "";
        public string marc = "";
        public string undad = "";
        public double precio = 0;
        public string tipo = "";

        bool Editar_cotizacion = false;

        public int Id_servicio_hijo;
        int Id_Servicio_Padre;
        int Periodo_servicio;
        int Id_CotizacionServicio;

        string nodos;
        string Id_Cotizacion;
        #region Mano de obra
        bool Mano_de_obra_modo_vista_reporte = true;
            bool Mano_de_obra_se_edito_al_menos_un_registro = false;
            bool Mano_de_obra_modo_en_edicion = false;
            bool Mano_de_obra_Cambios_guardados = false;
            int hs_mano_obra_max_value = 100;
            int hs_mano_obra_min_value = 0;
            int hs_mano_obra_large_change = 100;
            int hs_mano_obra_value_ = 0;
        #endregion

        #endregion

        #region Metodos
        public frm_01_2(ET_entidad _entity, bool editar = false)
        {
            InitializeComponent();
            Agregar_menu_contextual_servicios();         
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
            iconos_treeView.Images.Add(Properties.Resources.ojo);

            BringToFront();

            _ET_ENTIDAD = _entity;

            // Obtenemos los servicios de la cotización y alamacenamos el id del servicio padre.            
            Id_servicio_hijo = Id_Servicio_Padre;

            Conceptos_Remunerativos_metodo_Cargar();
            _NT_M40.Cargar_Listado_ += _NT_M40_Cargar_Listado_;
            Editar_cotizacion = editar;

            //Obtenemos los locales que posee la cotización seleccionada
            _ET_ENTIDAD._entity_r27._TR27_TM39_ID = _ET_ENTIDAD._entity_m39._TM39_ID;
            _ET_ENTIDAD._entity_r27._TR27_TM19_ID = _ET_ENTIDAD._entity_m39._entity_et_m19._TM19_ID;
            Locales_metodo_Cargar();
            _NT_R27.Cargar_Listado_ += _NT_R27_Cargar_Listado_;

            tabControl1.Visible = false;

            foreach (TabPage page in tabControl1.TabPages)
            {
                Panel panel = page.Controls[0] as Panel;
                Panels.Add(panel);

                panel.Parent = tabControl1.Parent;
                panel.Location = tabControl1.Location;
                panel.Visible = false;
            }

            Mostrar_pagina_cotizador(10100);

            _NT_M31.Mensaje_Alerta += Mensaje_Informacion;


            dgv_mano_de_obra.Scroll += new ScrollEventHandler(dgv_mano_de_obra_right_Scroll);
            dgv_mano_de_obra_right.Scroll += new ScrollEventHandler(dgv_mano_de_obra_Scroll);

            _NT_Helper.Set_Style_to_DatagridView(dgv_entrada_datos_mq_eq);

            _NT_R28.Cargar_explorador_De_Servicios_ += CargarExplorados_de_servicios;
            _NT_R28.Eliminar_Servicio_Explorador_ += _nt_r28_Eliminar_Servicio_Explorador_;
            _NT_R29.Cargar_Listado_ += _nt_r29_Cargar_Listado_;
            _NT_R29.Porcentaje_De_Carga += _nt_r29_Porcentaje_De_Carga;

            Obtener_Servicios_de_cotizacion();

            #region mano_de_obra
            _NT_R31.Mensaje_Info += _nt_r31_Mensaje_Info;
            _NT_R31.Mensaje_Alerta += _nt_r31_Mensaje_Alerta;
            _NT_R31.Porcentaje_De_Craga += _nt_r31_Mano_De_obra_Porcentaje_De_Craga;
            btn_guardar_mano_de_obra.Enabled = false;
            Mano_de_obra_se_edito_al_menos_un_registro = false;
            Mano_de_obra_modo_en_edicion = false;
            Mano_de_obra_Cambios_guardados = true;

            //ToolTip BTN_GUARDAR_TOOLTIP = new ToolTip();
            ////BTN_GUARDAR_TOOLTIP.IsBalloon = true;
            ////BTN_GUARDAR_TOOLTIP.ToolTipIcon = ToolTipIcon.Info;
            ////BTN_GUARDAR_TOOLTIP.ToolTipTitle = "Mensaje del sistema";
            //BTN_GUARDAR_TOOLTIP.SetToolTip(btn_guardar_mano_de_obra, "Para guardar");

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.btn_guardar_mano_de_obra, "   Guardar mano de obra (Ctrl+G)   ");
            #endregion

            #region maquinaria_y_equipo

            #endregion

            #region page_3

            #endregion
        }

        void PreLoad(bool enable)
        {
            if (enable)
            {
                Cursor = Cursors.WaitCursor;
                splitContainer1.Panel2.Cursor = Cursors.WaitCursor;
                tabControl1.Cursor = Cursors.WaitCursor;
            }
            else
            {
                Cursor = Cursors.Arrow;
                splitContainer1.Panel2.Cursor = Cursors.Arrow;
                tabControl1.Cursor = Cursors.Arrow;
            }
        }

        #region Eventos de la region
         
        public void Mensaje_Informacion(object sender, ET_entidad e)
        {
            MessageBox.Show
            (
                e._contenido_mensaje, e._titulo_mensaje,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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
            Definir_valores_scroll_de_mano_De_obra();
        }
        
        private void panel_colapse_2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            panel_colapse_2.Enabled = false;
            panel_colapse_2.Visible = false;
            Definir_valores_scroll_de_mano_De_obra();
        }

        private void frm_01_2_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.panel_colapse, "   Ocultar estructura   ");
            toolTip1.SetToolTip(this.panel_colapse_2, "   Mostrar estructura   ");

            int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
            panel_colapse_2.Location = new Point(coll + 6, 2);

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Habilitar_Buffer_doble_form(this,true);
            Habilitar_Buffer_doble_control_SplitContainer(splitContainer1,true);
            Habilitar_Buffer_doble_control_SplitterPanel(splitContainer1.Panel1,true);
            Habilitar_Buffer_doble_control_SplitterPanel(splitContainer1.Panel2,true);
            Habilitar_Buffer_doble_control_TabControl(tabControl1, true);
            Habilitar_Buffer_doble_control_Panel(panel1,true);
            Habilitar_Buffer_doble_control_Panel(panPages,true);
            Habilitar_Buffer_doble_control_Panel(panel_mano_de_obra,true);
            Habilitar_Buffer_doble_control_TabPage(tabPage1,true);
            Habilitar_Buffer_doble_control_TabPage(tabPage2,true);
            Habilitar_Buffer_doble_control_TabPage(tabPage3,true);
            Habilitar_Buffer_doble_control_gridview(dgv_mano_de_obra,true);
            Habilitar_Buffer_doble_control_gridview(dgv_mano_de_obra_right,true);

        }

        private void Habilitar_Buffer_doble_form(Form control, bool v)
        {
            typeof(Form).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            control, new object[] { true });
        }
        private void Habilitar_Buffer_doble_control_gridview(DataGridView gridview, bool v)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            gridview, new object[] { true });
        }
        private void Habilitar_Buffer_doble_control_TabControl(TabControl control, bool v)
        {
            typeof(TabControl).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            control, new object[] { true });
        }
        private void Habilitar_Buffer_doble_control_Panel(Panel control, bool v)
        {
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            control, new object[] { true });
        }

        private void Habilitar_Buffer_doble_control_TabPage(TabPage control, bool v)
        {
            typeof(TabPage).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            control, new object[] { true });
        }
        private void Habilitar_Buffer_doble_control_SplitContainer(SplitContainer control, bool v)
        {
            typeof(SplitContainer).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            control, new object[] { true });
        }
        private void Habilitar_Buffer_doble_control_SplitterPanel(SplitterPanel control, bool v)
        {
            typeof(SplitterPanel).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            control, new object[] { true });
        }
        private void frm_01_2_Resize(object sender, EventArgs e)
        {
            panel_colapse_2.Location = new Point(4, 2);
            Definir_valores_scroll_de_mano_De_obra();
        }
        #endregion

        #endregion

        #region Eventos

        List<Panel> Panels = new List<Panel>();
        Panel VisiblePanel = null;
        private void tree_view_servicios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = int.Parse(e.Node.Tag.ToString());
            Mostrar_pagina_cotizador(index);
        }
        private void Mostrar_pagina_cotizador(int index)
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
        private void tree_view_servicios_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            TreeNode node = tree_view_servicios.GetNodeAt(p);
            if (e.Button == MouseButtons.Right)
            {
                if (node != null)
                {
                    tree_view_servicios.SelectedNode = node;
                    switch (Convert.ToString(node.Tag))
                    {
                        case "10100": // ver menu nuevo servicio
                            MenuStrip_AgregarServicio.Show(tree_view_servicios, p);
                            nodos = Convert.ToString(tree_view_servicios.SelectedNode.FirstNode.Name);
                            break;
                        case "0": // ver menu para mano de obra
                            Id_servicio_hijo = Convert.ToInt32(node.Parent.Name.ToString());
                            if(btn_editar_mano_de_obra.Enabled == false)
                                Metodo_cargar_informacion_mano_de_obra();
                            MenuStrip_VerPropiedades.Show(tree_view_servicios, p);                            
                            break;
                        case "1000": // ver menu para mano de obra
                            Id_CotizacionServicio = Convert.ToInt32(tree_view_servicios.SelectedNode.Name);
                            MenuStrip_BorrarServicio.Show(tree_view_servicios, p);
                            break;
                    }
                }
            }
            if (e.Button == MouseButtons.Left)
            {

                if (node != null)
                {
                    tree_view_servicios.SelectedNode = node;

                    switch (Convert.ToString(node.Tag))
                    {
                        case "0": // ver menu para mano de obra
                            Id_servicio_hijo = Convert.ToInt32(node.Parent.Name.ToString());
                            if(!Mano_de_obra_se_edito_al_menos_un_registro)
                                Metodo_cargar_informacion_mano_de_obra();
                            break;
                    }
                }
            }
        }
        private void Item_Add_Service_click(object sender, EventArgs e)
        {
            string tm39_id;
            if (string.IsNullOrEmpty(_ET_ENTIDAD._entity_r27._TR27_TM39_ID))
                tm39_id = _ET_ENTIDAD._entity_m39._TM39_ID;
            else
                tm39_id = _ET_ENTIDAD._entity_r27._TR27_TM39_ID;

            frm_01_2_02 form_2_2 = new frm_01_2_02(Id_servicio_hijo, Id_Servicio_Padre, Periodo_servicio, tm39_id, nodos);
            form_2_2.ShowDialog();

            if (form_2_2.DialogResult == DialogResult.OK)
            {
                ET_R29 _et = new ET_R29();
                _et._TR29_TR28_ID = Id_servicio_hijo;
                Obtener_Servicios_de_cotizacion();
            }
        }

        private void Item_Datos_Generales_click(object sender, EventArgs e)
        {
            frm_01_1 form_1_1 = new frm_01_1(Id_Cotizacion);
            form_1_1.ShowDialog();            
        }

        private void Item_Del_Service_click(object sender, EventArgs e)
        {
            if (Id_CotizacionServicio == Id_Servicio_Padre)
            {
                DialogResult decision2_msg = MessageBox.Show("No puede eliminar el servicio principal.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult decision_msg = MessageBox.Show("Esta seguro de eliminar este servicio. \nSe eliminarán los registros asociados.", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (decision_msg == DialogResult.OK)
                {
                    _ET_ENTIDAD._entity_r28._TR28_ID = Id_CotizacionServicio;
                    _ET_ENTIDAD._entity_r28._TR28_TM39_ID = Id_Cotizacion;
                    _NT_R28.Et_r28(_ET_ENTIDAD._entity_r28);
                    _NT_R28.Iniciar(Tarea.ELIMINAR);
                }
            }
        }
        private void Item_mano_de_obra_click(object sender, EventArgs e)
        {
            frm_01_2_01 form_2_1 = new frm_01_2_01(Id_servicio_hijo, _LISTA_ET_M40);
            form_2_1.ShowDialog();
            if (form_2_1.DialogResult == DialogResult.OK)
            {
                btn_editar_mano_de_obra.Enabled = true;
                if (btn_editar_mano_de_obra.Enabled)
                {
                    Editar_cotizacion = true;
                    Mano_de_obra_modo_vista_reporte = true;
                }
                else
                {
                    Mano_de_obra_modo_vista_reporte = false;
                }
                _cargo_data_mano_obra = false;
                Metodo_cargar_informacion_mano_de_obra();
            }
            else
            {
                btn_editar_mano_de_obra.Enabled = false;
                if (!Mano_de_obra_modo_en_edicion)
                    btn_editar_mano_de_obra.Enabled = true;
            }
        }
        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            int coll = Convert.ToInt32(splitContainer1.SplitterDistance);
            //btn_colapse.Location = new Point(coll, 0);
            panel_colapse_2.Location = new Point(coll + 6, 2);
            Definir_valores_scroll_de_mano_De_obra();
        }

        #endregion


        #region Servicios
        public void CargarExplorados_de_servicios(object sender, ET_entidad e)
        {
            Id_Servicio_Padre = _ET_ENTIDAD._entity_r28._TR28_PADRE;
            Periodo_servicio = _ET_ENTIDAD._entity_r28._TR28_PERIODO;

            tree_view_servicios.Nodes.Clear();

            tree_view_servicios.ImageList = iconos_treeView;
            tree_view_servicios.ImageIndex = 0;

            if (!e._hubo_error && _LISTA_ET_R28 != null)
            {
                string name_nodo = string.Format("{0} - {1}", _ET_ENTIDAD._entity_m39._TM39_ID, _ET_ENTIDAD._entity_m39._entity_et_m19._TM19_DESCRIP2);
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
                        mano_obra.SelectedImageIndex = 4;

                        TreeNode maquinaria = new TreeNode("Maquinaria y equipo");
                        maquinaria.Tag = 1;
                        maquinaria.ImageIndex = 3;
                        maquinaria.SelectedImageIndex = 4;

                        TreeNode materiales = new TreeNode("Materiales e insumos");
                        materiales.Tag = 2;
                        materiales.ImageIndex = 3;
                        materiales.SelectedImageIndex = 4;

                        TreeNode implementos = new TreeNode("Implementos de limpieza");
                        implementos.Tag = 3;
                        implementos.ImageIndex = 3;
                        implementos.SelectedImageIndex = 4;

                        TreeNode suministros = new TreeNode("Suministros");
                        suministros.Tag = 4;
                        suministros.ImageIndex = 3;
                        suministros.SelectedImageIndex = 4;

                        TreeNode indumentaria = new TreeNode("Indumentaria");
                        indumentaria.Tag = 5;
                        indumentaria.ImageIndex = 3;
                        indumentaria.SelectedImageIndex = 4;

                        TreeNode Epp = new TreeNode("Epp");
                        Epp.Tag = 6;
                        Epp.ImageIndex = 3;
                        Epp.SelectedImageIndex = 4;


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
            Obtener_Servicios_de_cotizacion();
        }
        public void Obtener_Servicios_de_cotizacion()
        {
            _ET_ENTIDAD._entity_r28._TR28_TM39_ID = _ET_ENTIDAD._entity_m39._TM39_ID;
            _NT_R28.Et_r28(_ET_ENTIDAD._entity_r28);
            _NT_R28.Iniciar(Tarea.LISTAR);
        }
        private void Agregar_menu_contextual_servicios()
        {
            MenuStrip_VerPropiedades.Text = "Propiedades";
            MenuStrip_VerPropiedades.Name = "MenuStrip_ViewProperties_";
            MenuStrip_VerPropiedades.Size = new System.Drawing.Size(153, 48);

            ToolStripMenuItem View_Properties = new ToolStripMenuItem();

            View_Properties.Name = "View_Properties";
            View_Properties.Size = new System.Drawing.Size(132, 22);
            View_Properties.Text = "Configuración de cargos";
            View_Properties.Image = Properties.Resources.configuracion_dos;

            MenuStrip_VerPropiedades.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        View_Properties
                    });

            View_Properties.Click += new System.EventHandler(this.Item_mano_de_obra_click);


            //Agregar Servicio -- Datos_Generales
            MenuStrip_AgregarServicio.Text = "Servicios";
            MenuStrip_AgregarServicio.Name = "Menu_strip_for_TreeView";
            MenuStrip_AgregarServicio.Size = new System.Drawing.Size(153, 48);


            ToolStripMenuItem Add_service = new ToolStripMenuItem();

            Add_service.Name = "Add_service";
            Add_service.Size = new System.Drawing.Size(132, 22);
            Add_service.Text = "Agregar servicio...";
            Add_service.Image = Properties.Resources.agregar_reporte_dos;

            ToolStripMenuItem Datos_Generales = new ToolStripMenuItem();

            Datos_Generales.Name = "Datos_Generales";
            Datos_Generales.Size = new System.Drawing.Size(132, 22);
            Datos_Generales.Text = "Datos Generales";
            Datos_Generales.Image = Properties.Resources.agregar_reporte_dorado;

            MenuStrip_AgregarServicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        Datos_Generales, Add_service
                    });

            Add_service.Click += new System.EventHandler(this.Item_Add_Service_click);
            Datos_Generales.Click += new System.EventHandler(this.Item_Datos_Generales_click);

            MenuStrip_AgregarServicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                Datos_Generales, Add_service
            });
            
            //Eliminar Servicio
            MenuStrip_BorrarServicio.Text = "Servicios";
            MenuStrip_BorrarServicio.Name = "Menu_strip_for_TreeView";
            MenuStrip_BorrarServicio.Size = new System.Drawing.Size(153, 48);

            ToolStripMenuItem Del_service = new ToolStripMenuItem();

            Del_service.Name = "Del_service";
            Del_service.Size = new System.Drawing.Size(132, 22);
            Del_service.Text = "Eliminar servicio";
            Del_service.Image = Properties.Resources.reporte_borrar_dos;

            MenuStrip_BorrarServicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        Del_service
                    });

            Del_service.Click += new System.EventHandler(this.Item_Del_Service_click);

            MenuStrip_BorrarServicio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                Del_service
            });
        }

        #endregion

        #region Conceptos remunerativos
        private void Conceptos_Remunerativos_metodo_Cargar()
        {
            _NT_M40.Iniciar(Tarea.LISTAR);
        }
        private void _NT_M40_Cargar_Listado_(object sender, ET_entidad e)
        {
            if(!e._hubo_error)
                _LISTA_ET_M40 = e._lista_et_m40;
        }
        #endregion

        #region Locales

        private void Locales_metodo_Cargar()
        {
            _NT_R27.Agregar_ET_R27(_ET_ENTIDAD._entity_r27);
            _NT_R27.Iniciar(Tarea.LISTAR);
            //var result = _NT_R27.get_001(_ET_ENTIDAD);

        }
        private void _NT_R27_Cargar_Listado_(object sender, ET_entidad e)
        {
            if (!e._hubo_error)
            {
                _ET_ENTIDAD._lista_et_m27 = e._lista_et_m27;
                _ET_ENTIDAD._lista_et_r27 = e._lista_et_r27;


                Construir_DataGrid_Mano_Obra(dgv_mano_de_obra,dgv_mano_de_obra_right);
                CreateColumn();

            }
        }

        #endregion

        #region cargos
        private void _nt_r29_Cargar_Listado_(object sender, ET_entidad e)
        {
            _LISTA_ET_R29 = e._lista_et_r29;

            if (_LISTA_ET_R29 != null)
            {
                Desplegar_informacion_de_mano_de_obra(true);
       
                if (_LISTA_ET_R29.Count() == 0)
                    Item_mano_de_obra_click(null, null);
            }
        }
        private void _nt_r29_Porcentaje_De_Carga(object sender, int e)
        {
            if (e == 0)
                PreLoad(true);
            else
                PreLoad(false);
        }

        #endregion


        #region MANO DE OBRA
        #region MANO DE OBRA - EVENTOS
        private void _nt_r31_Mensaje_Info(object sender, ET_entidad e)
        {
            Metodo_cargar_informacion_mano_de_obra();
            MessageBox.Show(e._contenido_mensaje, e._titulo_mensaje,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void _nt_r31_Mensaje_Alerta(object sender, ET_entidad e)
        {
            MessageBox.Show(e._contenido_mensaje, e._titulo_mensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void _nt_r31_Mano_De_obra_Porcentaje_De_Craga(object sender, int e)
        {
            if (e == 0)
                PreLoad(true);
            else
                PreLoad(false);
        }
        #endregion
        bool _cargo_data_mano_obra = false;
        private void Metodo_cargar_informacion_mano_de_obra()
        {
            if (Mano_de_obra_se_edito_al_menos_un_registro)
            {
                DialogResult decision_msg = MessageBox.Show(" Tiene cambios sin guardar \n ¿Desea guardar los cambios?", "Cotización mano de obra dice:", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (decision_msg == DialogResult.OK)
                    Guardar_Cambios_mano_De_obra();
            }
            else
            {
                if (!_cargo_data_mano_obra)
                {
                    ET_R29 _et = new ET_R29();
                    _LISTA_ET_R29 = new List<ET_R29>();
                    _LISTA_ET_R29.Clear();
                    _et._TR29_TR28_ID = Id_servicio_hijo; // captura el node
                    _et._lista_et_m40 = _LISTA_ET_M40;

                    if (Editar_cotizacion)
                        _LISTA_ET_R31 = _NT_R31.get_001(Id_servicio_hijo);

                    _NT_R29.Agregar_ETR29(_et);
                    _NT_R29.Iniciar(Tarea.LISTAR);
                }
                else
                {
                    Desplegar_informacion_de_mano_de_obra(true);
                }
            }
        }
        private void dgv_mano_de_obra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int suma_total = 0;

            for (int a = 1; a < dgv_mano_de_obra.ColumnCount; a++)
            {
                int value = 0;
                if (dgv_mano_de_obra.Rows[e.RowIndex].Cells[a].Value != null)
                {
                    if (!string.IsNullOrEmpty(dgv_mano_de_obra.Rows[e.RowIndex].Cells[a].Value.ToString()))
                        suma_total = suma_total + Convert.ToInt32(dgv_mano_de_obra.Rows[e.RowIndex].Cells[a].Value);
                }

                else
                    suma_total = suma_total + value;
            }

            dgv_mano_de_obra_right.Rows[e.RowIndex].Cells[0].Value = suma_total;
            decimal producto = suma_total * (Convert.ToDecimal(dgv_mano_de_obra_right.Rows[e.RowIndex].Cells[2].Value));

            dgv_mano_de_obra_right.Rows[e.RowIndex].Cells[4].Value = string.Format("{0:#,#.00}", producto);

        }

        private void dgv_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_mano_de_obra.CurrentCell.ColumnIndex != 0)
            {
                TextBox TEX_BOX_NUMBER = e.Control as TextBox;
                TEX_BOX_NUMBER.MaxLength = 5;
                TEX_BOX_NUMBER.KeyPress += new KeyPressEventHandler(_NT_Helper.dataGridViewTextBox_Number_KeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(_NT_Helper.dataGridViewTextBox_Number_KeyPress); 
            }
        }

        private void dgv_mano_de_obra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_mano_de_obra_right.RowCount > 0)
                dgv_mano_de_obra_right.Rows[e.RowIndex].Selected = true;
        }

        private void dgv_mano_de_obra_right_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
                if(dgv_mano_de_obra.RowCount > 0)
                    dgv_mano_de_obra.Rows[e.RowIndex].Selected = true;
            //}
            //catch (Exception ex) { }
        }

        private void btn_guardar_mano_de_obra_Click(object sender, EventArgs e)
        {
            Mano_de_obra_modo_en_edicion = false;
            if (!Mano_de_obra_Cambios_guardados)
            {
                Guardar_Cambios_mano_De_obra();
                // recargar
                Metodo_cargar_informacion_mano_de_obra();
            }
            else
            {

                btn_guardar_mano_de_obra.Enabled = false;
                btn_editar_mano_de_obra.Enabled = true;
                Mano_de_obra_modo_vista_reporte = true;
                //Metodo_mostrar_calculos_de_costos_mano_de_obra();
                dgv_mano_de_obra.Refresh();
                dgv_mano_de_obra.Update();
                dgv_mano_de_obra_right.ReadOnly = true;
                dgv_mano_de_obra.ReadOnly = true;
            }
        }

        private void Guardar_Cambios_mano_De_obra()
        {
            if (Mano_de_obra_se_edito_al_menos_un_registro)
            {
                if (_LISTA_ET_R31 != null)
                {
                    _cargo_data_mano_obra = false;
                    Metodo_preparar_informacion_para_actualizar_mano_de_obra();
                    if (!Mano_de_obra_modo_en_edicion)
                    {
                        btn_guardar_mano_de_obra.Enabled = false;
                        btn_editar_mano_de_obra.Enabled = true;
                        Mano_de_obra_modo_vista_reporte = true;
                        //Metodo_mostrar_calculos_de_costos_mano_de_obra();
                        dgv_mano_de_obra.Refresh();
                        dgv_mano_de_obra.Update();
                        dgv_mano_de_obra_right.ReadOnly = true;
                        dgv_mano_de_obra.ReadOnly = true;
                    }
                }
            }
            else
            {
                _cargo_data_mano_obra = true;
                Mano_de_obra_modo_vista_reporte = true;
                btn_editar_mano_de_obra.Enabled = true;
                btn_guardar_mano_de_obra.Enabled = false;
                //Metodo_mostrar_calculos_de_costos_mano_de_obra();
                dgv_mano_de_obra.Refresh();
                dgv_mano_de_obra.Update();
                dgv_mano_de_obra_right.ReadOnly = true;
                dgv_mano_de_obra.ReadOnly = true;
            }
            Mano_de_obra_se_edito_al_menos_un_registro = false;
        }

        private void Metodo_preparar_informacion_para_actualizar_mano_de_obra()
        {
            var tmp = _LISTA_ET_R29;

            NT_R31 ins = new NT_R31();
            //ins.set_002(_lista_et_r29, _entidad._lista_et_r27);

            _NT_R31.Argregar_ET_R29_CARGOS(_LISTA_ET_R29);
            _NT_R31.Agregar_ET_R27_LOCALES(_ET_ENTIDAD._lista_et_r27);
            _NT_R31.Iniciar(Tarea.ACTUALIZAR);

            Mano_de_obra_Cambios_guardados = true;
        }

        private void btn_editar_mano_de_obra_Click(object sender, EventArgs e)
        {
            dgv_mano_de_obra_right.GridColor = Color.Gray;
            dgv_mano_de_obra.GridColor = Color.Gray;

            dgv_mano_de_obra.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_mano_de_obra.BackgroundColor = Color.White;
            dgv_mano_de_obra_right.DefaultCellStyle.BackColor = Color.FromArgb(238,238,238);
            dgv_mano_de_obra.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(238,238,238);

            dgv_mano_de_obra_right.Rows.Clear();
            dgv_mano_de_obra.Rows.Clear();


            var _Lista_et_r29_trabajadores_8_horas = _LISTA_ET_R29.Where(o => o._HOURS_DAY >= 4);
            var _Lista_et_r29_trabajadores_4_horas = _LISTA_ET_R29.Where(o => o._HOURS_DAY < 4);

            //preparar vista de mano de obra para editar
            btn_guardar_mano_de_obra.Enabled = true;
            Mano_de_obra_modo_vista_reporte = false;
            Mano_de_obra_Cambios_guardados = false;
            Editar_cotizacion = true;
            Mano_de_obra_preparar_modo_en_edicion(_Lista_et_r29_trabajadores_8_horas.ToList());
            Mano_de_obra_preparar_modo_en_edicion(_Lista_et_r29_trabajadores_4_horas.ToList());
            // devolver la propiedad readonly al conjunto de grilas mano de obra
            dgv_mano_de_obra_right.ReadOnly = false;
            dgv_mano_de_obra.ReadOnly = false;
            dgv_mano_de_obra.Columns[0].ReadOnly = true;
            btn_editar_mano_de_obra.Enabled = false;
        }

        private void Mano_de_obra_preparar_modo_en_edicion( List<ET_R29> object_list_etr29)
        {
            #region porblar grids mano de obra
            object_list_etr29.ForEach(fila_ => {
                string Texto_descripcion_mano_del_cargo = Obtener_descripcion_mano_obra(
                    fila_._TR29_DESCRIP,
                    fila_._TR29_DIAS_SEMANA,
                    fila_._TR29_HORA_ENTRADA,
                    fila_._TR29_HORA_SALIDA,
                    fila_._lista_et_r30
                );
                var res = _LISTA_ET_R31.Where(fila => fila._TR31_TR29_ID == fila_._TR29_ID).ToList();
                object[] informacion_r31 = new object[res.Count];

                int total_personal = 0;
                int indice_locales = 0;

                string[] fila_dgv_mano_obra = new string[(1 + res.Count)];
                fila_dgv_mano_obra[0] = Texto_descripcion_mano_del_cargo;

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
                object[] rellenos = new object[_ET_ENTIDAD._lista_et_m27.Count];
                int indice = 0;
                _ET_ENTIDAD._lista_et_m27.ForEach(c => {
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

                decimal SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS = 0.00M;
                decimal SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS = 0.00M;
                fila_._lista_et_r30.ForEach(X =>
                {

                    if (X._TR30_AFECTO)
                    {
                        if (X._TR30_IMPORTE != 0.00M) // TABAJA CON IMPORTE 
                            SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS += X._TR30_IMPORTE;
                        if (X._TR30_PORCENTAJE != 0.0M) // TRABAJA CON PORCENTAJE
                        {
                            if (fila_._TR29_REMUNERACION < 850.00M) // // OBTENEMOS EL PORCENTAJE DEL CONCEPTO EN BASE A LA REMUNERACION MINIMA VITAL
                                SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS +=(850.00M * X._TR30_PORCENTAJE);
                            else
                                SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS += (X._TR30_IMPORTE * X._TR30_PORCENTAJE)*1.00M;
                        }
                    }
                    else
                    {
                        if (X._TR30_IMPORTE != 0.00M) // TABAJA CON IMPORTE 
                            SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS += X._TR30_IMPORTE;
                        if (X._TR30_PORCENTAJE != 0.0M) // TRABAJA CON PORCENTAJE
                        {
                            if (fila_._TR29_REMUNERACION < 850.00M) // // OBTENEMOS EL PORCENTAJE DEL CONCEPTO EN BASE A LA REMUNERACION MINIMA VITAL
                                SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS += (850.00M * X._TR30_PORCENTAJE);
                            else
                                SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS += (X._TR30_IMPORTE * X._TR30_PORCENTAJE) * 1.00M;
                        }
                    }
                });

                decimal SUMA_DE_AFECTOS_Y_NO_AFECTOS = SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS + SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS;
                dgv_mano_de_obra_right.Rows.Add(
                    total_personal,
                    string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION),
                    string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS),
                    string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS),
                    string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION * 1.00M + SUMA_DE_AFECTOS_Y_NO_AFECTOS * 1.00M).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION * 1.00M + SUMA_DE_AFECTOS_Y_NO_AFECTOS * 1.00M),
                    string.Format("{0:#,#.00}", ((fila_._TR29_REMUNERACION + SUMA_DE_AFECTOS_Y_NO_AFECTOS) * total_personal) * 1.00M).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", ((fila_._TR29_REMUNERACION + SUMA_DE_AFECTOS_Y_NO_AFECTOS) * total_personal) * 1.00M)
                 );
                dgv_mano_de_obra.Rows.Add(fila_dgv_mano_obra);
            });
            #endregion
        }

        private void dgv_mano_de_obra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // validar que vista edicion este en false
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                Mano_de_obra_se_edito_al_menos_un_registro = true;
                Mano_de_obra_modo_en_edicion = true;

                ET_R29 _et_r29_editable = new ET_R29();
                _et_r29_editable = _LISTA_ET_R29.FirstOrDefault(x => x._Fila == e.RowIndex);
                object[] respaldo = _et_r29_editable._Locales_por_cargo_cantidad_personal;
                object[] nuevos_valores = new object[respaldo.Count()];
                int indice_res = 0;
                foreach (int[] r in respaldo)
                {
                    int[] value = new int[2];

                    value[0] = r[0];
                    value[1] = r[1];
                    if (indice_res == (e.ColumnIndex - 1))
                    {
                        if (dgv_mano_de_obra.CurrentRow.Cells[e.ColumnIndex].Value != null)
                        {
                            if (!string.IsNullOrEmpty(dgv_mano_de_obra.CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                                value[0] = Convert.ToInt32(dgv_mano_de_obra.CurrentRow.Cells[e.ColumnIndex].Value);
                            else
                                value[0] = 0;
                        }
                        else
                        {
                            value[0] = 0;
                        }
                    }
                    nuevos_valores[indice_res] = value;
                    indice_res++;
                }

                _et_r29_editable._Locales_por_cargo_cantidad_personal = nuevos_valores;// Convert.ToInt32(dgv_mano_de_obra.CurrentRow.Cells[e.ColumnIndex].Value);
            }
        }
        private void Construir_DataGrid_Mano_Obra(DataGridView _left, DataGridView _right)
        {
            bool ajustar = false;
            if (_ET_ENTIDAD._lista_et_r27.Count < 5)
                ajustar = true;

            _left.AllowUserToAddRows = false;
            _left.ScrollBars = ScrollBars.Horizontal;
            _right.ScrollBars = ScrollBars.Vertical;

            _NT_Helper.Set_Style_to_DatagridView(_left);
            _NT_Helper.Set_Style_to_DatagridView(_right);

            _left.AutoGenerateColumns = false;

            if (ajustar)
                _left.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewColumn MANO_OBRA_COL_DESCRIPCION = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_DESCRIPCION.DataPropertyName = "MANO_OBRA_COL_DESCRIPCION";
            MANO_OBRA_COL_DESCRIPCION.HeaderText = "Cargo";
            MANO_OBRA_COL_DESCRIPCION.Name = "MANO_OBRA_COL_DESCRIPCION";
            MANO_OBRA_COL_DESCRIPCION.ReadOnly = true;
            MANO_OBRA_COL_DESCRIPCION.Width = 240;
            MANO_OBRA_COL_DESCRIPCION.FillWeight = 240;

            _left.Columns.AddRange(new DataGridViewColumn[] {
                MANO_OBRA_COL_DESCRIPCION,
            });

            MANO_OBRA_COL_DESCRIPCION.Frozen = true;

            //// CARGAR COLUMNAS DE MANERA DINAMICA -> LOCALES
            if (_ET_ENTIDAD._lista_et_r27 != null)
            {
                int cantidad_final_de_indices = (_left.ColumnCount + _ET_ENTIDAD._lista_et_r27.Count);
                _left.ColumnCount = cantidad_final_de_indices;
                int indice_de_inicio = cantidad_final_de_indices - _ET_ENTIDAD._lista_et_r27.Count;
                int indice_nn = 1;
                _ET_ENTIDAD._lista_et_r27.ForEach(x =>
                {
                    _left.Columns[indice_de_inicio].Visible = true;
                    _left.Columns[indice_de_inicio].DefaultCellStyle.NullValue = "0";
                    _left.Columns[indice_de_inicio].Width = 200;
                    _left.Columns[indice_de_inicio].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    _left.Columns[indice_de_inicio].Name = x._TR27_DESCRIP;
                    _left.Columns[indice_de_inicio].HeaderText = string.IsNullOrEmpty(x._TR27_DESCRIP) ? string.Format("Local {0}", indice_nn) : x._TR27_DESCRIP.Length > 26 ? string.Format("{0}...", x._TR27_DESCRIP.Substring(0, 26)) : x._TR27_DESCRIP;
                    _left.Columns[indice_de_inicio].ToolTipText = x._TR27_DESCRIP;
                    indice_de_inicio++;
                    indice_nn++;
                });
            }
            for (int i = 0; i < _left.Columns.Count; i++)
                _left.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            _right.AllowUserToAddRows = false;
            _right.AutoGenerateColumns = false;
            _right.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            _right.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _right.ReadOnly = true;

            DataGridViewColumn MANO_OBRA_COL_SUELDO_BASICO = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUELDO_BASICO.DataPropertyName = "MANO_OBRA_COL_SUELDO_BASICO";
            MANO_OBRA_COL_SUELDO_BASICO.HeaderText = "Sueldo básico";
            MANO_OBRA_COL_SUELDO_BASICO.Name = "MANO_OBRA_COL_SUELDO_BASICO";
            MANO_OBRA_COL_SUELDO_BASICO.Width = 85;
            MANO_OBRA_COL_SUELDO_BASICO.ReadOnly = true;
            MANO_OBRA_COL_SUELDO_BASICO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MANO_OBRA_COL_SUELDO_BASICO.ToolTipText = MANO_OBRA_COL_SUELDO_BASICO.HeaderText;

            DataGridViewColumn MANO_OBRA_COL_TOTAL_PERSONAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_TOTAL_PERSONAL.DataPropertyName = "MANO_OBRA_COL_TOTAL_PERSONAL";
            MANO_OBRA_COL_TOTAL_PERSONAL.HeaderText = "Tot.personal";
            MANO_OBRA_COL_TOTAL_PERSONAL.Name = "MANO_OBRA_COL_TOTAL_PERSONAL";
            MANO_OBRA_COL_TOTAL_PERSONAL.Width = 80;
            MANO_OBRA_COL_TOTAL_PERSONAL.ReadOnly = true;
            MANO_OBRA_COL_TOTAL_PERSONAL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MANO_OBRA_COL_TOTAL_PERSONAL.ToolTipText = MANO_OBRA_COL_TOTAL_PERSONAL.HeaderText;

            DataGridViewColumn MANO_OBRA_COL_SUELDO_MENSUAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUELDO_MENSUAL.DataPropertyName = "MANO_OBRA_COL_SUELDO_MENSUAL";
            MANO_OBRA_COL_SUELDO_MENSUAL.HeaderText = "Sueldo mensual";
            MANO_OBRA_COL_SUELDO_MENSUAL.Name = "MANO_OBRA_COL_SUELDO_MENSUAL";
            MANO_OBRA_COL_SUELDO_MENSUAL.Width = 90;
            MANO_OBRA_COL_SUELDO_MENSUAL.ReadOnly = true;
            MANO_OBRA_COL_SUELDO_MENSUAL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MANO_OBRA_COL_SUELDO_MENSUAL.ToolTipText = MANO_OBRA_COL_SUELDO_MENSUAL.HeaderText;

            DataGridViewColumn MANO_OBRA_COL_TOTAL = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_TOTAL.DataPropertyName = "MANO_OBRA_COL_TOTAL";
            MANO_OBRA_COL_TOTAL.HeaderText = "Total";
            MANO_OBRA_COL_TOTAL.Name = "MANO_OBRA_COL_TOTAL";
            MANO_OBRA_COL_TOTAL.Width = 85;
            MANO_OBRA_COL_TOTAL.ReadOnly = true;
            MANO_OBRA_COL_TOTAL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MANO_OBRA_COL_TOTAL.ToolTipText = MANO_OBRA_COL_TOTAL.HeaderText;

            DataGridViewColumn MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.DataPropertyName = "MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.HeaderText = "No afectos";
            MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.Name = "MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.Width = 90;
            MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.ReadOnly = false;
            MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.ToolTipText = MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS.HeaderText;

            DataGridViewColumn MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS = new DataGridViewTextBoxColumn();
            MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.DataPropertyName = "MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.HeaderText = "Afectos";
            MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.Name = "MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS";
            MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.Width = 90;
            MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.ReadOnly = false;
            MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.ToolTipText = MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS.HeaderText;



            _right.Columns.AddRange(new DataGridViewColumn[] {
                MANO_OBRA_COL_TOTAL_PERSONAL,
                MANO_OBRA_COL_SUELDO_BASICO,
                MANO_OBRA_COL_SUM_CONCEPTOS_AFECTOS,
                MANO_OBRA_COL_SUM_CONCEPTOS_NO_AFECTOS,
                MANO_OBRA_COL_SUELDO_MENSUAL,
                MANO_OBRA_COL_TOTAL
            });
            for (int i = 0; i < _right.Columns.Count; i++)
                _right.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            Definir_valores_scroll_de_mano_De_obra();
        }

        private void Definir_valores_scroll_de_mano_De_obra()
        {
            foreach (Control control_ in dgv_mano_de_obra.Controls)
            {
                if (control_.AccessibilityObject.Role == AccessibleRole.ScrollBar)
                {
                    AccessibleObject objeto_de_acceso = new AccessibleObject();
                    objeto_de_acceso = control_.AccessibilityObject;
                    var datagridview_scroll = control_.Controls.Owner;
                    datagridview_scroll.IsAccessible = true;
                    hs_mano_obra_max_value = ((ScrollBar)datagridview_scroll).Maximum;
                    hs_mano_obra_min_value = ((ScrollBar)datagridview_scroll).Minimum;
                    hs_mano_obra_large_change = ((ScrollBar)datagridview_scroll).LargeChange;
                    hs_mano_obra_value_ = ((ScrollBar)datagridview_scroll).Value;
                }
                break;
            }

            h_scroll_mano_de_obra.Maximum = hs_mano_obra_max_value;
            h_scroll_mano_de_obra.Minimum = hs_mano_obra_min_value;
            h_scroll_mano_de_obra.LargeChange = hs_mano_obra_large_change;
            h_scroll_mano_de_obra.Value = hs_mano_obra_value_;
        }

        private void Desplegar_informacion_de_mano_de_obra(bool es_vista_reporte = false)
        {
            dgv_mano_de_obra.Rows.Clear();
            dgv_mano_de_obra_right.Rows.Clear();
            if (_LISTA_ET_R29 != null && _LISTA_ET_R29.Count > 0)
            {
                #region metodo
                var _Lista_et_r29_trabajadores_8_horas = _LISTA_ET_R29.Where(o => o._HOURS_DAY >= 4);
                var _Lista_et_r29_trabajadores_4_horas = _LISTA_ET_R29.Where(o => o._HOURS_DAY < 4);

                if (es_vista_reporte)
                {
                    dgv_mano_de_obra_right.GridColor = Color.White;
                    dgv_mano_de_obra.GridColor = Color.White;

                    dgv_mano_de_obra.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    dgv_mano_de_obra.BackgroundColor = Color.White;
                    dgv_mano_de_obra_right.BackgroundColor = Color.White;
                    dgv_mano_de_obra.DefaultCellStyle.BackColor = Color.White;
                    dgv_mano_de_obra_right.DefaultCellStyle.BackColor = Color.White;
                    dgv_mano_de_obra_right.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
                    dgv_mano_de_obra.Columns[0].DefaultCellStyle.BackColor = Color.White;
                    dgv_mano_de_obra.Columns[0].DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;

                    decimal[] MANO_DE_OBRA_COSTO_MENSUAL_LEFT = new decimal[dgv_mano_de_obra.ColumnCount];
                    decimal[] MANO_DE_OBRA_COSTO_MENSUAL_RIGHT = new decimal[dgv_mano_de_obra_right.ColumnCount];
                    MANO_DE_OBRA_COSTO_MENSUAL[0] = MANO_DE_OBRA_COSTO_MENSUAL_LEFT;
                    MANO_DE_OBRA_COSTO_MENSUAL[1] = MANO_DE_OBRA_COSTO_MENSUAL_RIGHT;

                }
                if (es_vista_reporte)
                    Ingresar_filas_vacias_dentro_de_grids(Color.Blue, dgv_mano_de_obra, dgv_mano_de_obra_right, 0, "MANO DE OBRA (MAYOR A 4 HORAS DIARIAS)");

                var obj = Desplegar_informacion_de_mano_de_obra_por_horas_de_jornada(_Lista_et_r29_trabajadores_8_horas.ToList());

                if (es_vista_reporte)
                {
                    //Ingresar_filas_vacias_dentro_de_grids(Color.Blue ,dgv_mano_de_obra, dgv_mano_de_obra_right);
                    Metodo_mostrar_calculos_de_costos_mano_de_obra(obj);
                }
                if (_Lista_et_r29_trabajadores_4_horas.ToList().Count() != 0)
                {
                    //MANO DE OBRA (MENOR A 4 HORAS DIARIAS)
                    Ingresar_filas_vacias_dentro_de_grids(Color.Blue, dgv_mano_de_obra, dgv_mano_de_obra_right, 2, "MANO DE OBRA (MENOR A 4 HORAS DIARIAS)");

                    var obj_ = Desplegar_informacion_de_mano_de_obra_por_horas_de_jornada(_Lista_et_r29_trabajadores_4_horas.ToList(), true);
                    if (es_vista_reporte)
                    {
                        //Ingresar_filas_vacias_dentro_de_grids(Color.Blue, dgv_mano_de_obra, dgv_mano_de_obra_right);
                        Metodo_mostrar_calculos_de_costos_mano_de_obra(obj_);
                    }
                }
                if (es_vista_reporte)
                {
                    Metodo_mostrar_costo_mensual_mano_de_obra();
                    dgv_mano_de_obra_right.ReadOnly = true;
                    dgv_mano_de_obra.ReadOnly = true;
                    btn_editar_mano_de_obra.Enabled = true;
                    Mano_de_obra_modo_vista_reporte = true;
                }
                Ingresar_filas_vacias_dentro_de_grids(Color.Blue, dgv_mano_de_obra, dgv_mano_de_obra_right, 2);
                #endregion
            }
        }

        private object[] Desplegar_informacion_de_mano_de_obra_por_horas_de_jornada(List<ET_R29> object_list_etr29, bool MENOR_CUATRO_HORAS = false)
        {
            object[] respuesta = new object[4];

            #region Primer_subtotal
            object[] MANO_DE_OBRA_FIRST_SUBTOTAL = new object[2];
            string[] MANO_DE_OBRA_SUBTOTALES_UNO = new string[dgv_mano_de_obra.ColumnCount];
            string[] MANO_DE_OBRA_SUBTOTALES_DOS = new string[dgv_mano_de_obra_right.ColumnCount];

            decimal[] MANO_DE_OBRA_TOTAL_POR_LOCAL = new decimal[dgv_mano_de_obra.ColumnCount - 1];

            long MANO_OBRA_TOTAL_PERSONAL = 0;
            decimal MANO_OBRA_TOTAL = 0 * 1M;

            int INDICE_MANO_DE_OBRA_SUELDO_MENSUAL_POR_CARGO = 0;
            decimal[] MANO_DE_OBRA_SUELDO_MENSUAL_POR_CARGO = new decimal[object_list_etr29.Count];

            #endregion

            #region Beneficios_sociales
            object[] MANO_DE_OBRA_BENEFICIOS_SOCIALES = new object[4];

                object[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES = new object[2];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT = new string[dgv_mano_de_obra.ColumnCount];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];

                object[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS = new object[2];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_LEFT = new string[dgv_mano_de_obra.ColumnCount];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];

                object[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES = new object[2];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT = new string[dgv_mano_de_obra.ColumnCount];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];

                object[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL = new object[2];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_LEFT = new string[dgv_mano_de_obra.ColumnCount];
                    string[] MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];
            #endregion

            #region Leyes Sociales
            object[] MANO_DE_OBRA_LEYES_SOCIALES = new object[4];
            object[] MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD = new object[2];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_LEFT = new string[dgv_mano_de_obra.ColumnCount];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];

            object[] MANO_DE_OBRA_LEYES_SOCIALES_SCTR = new object[2];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_SCTR_LEFT = new string[dgv_mano_de_obra.ColumnCount];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_SCTR_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];

            object[] MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY = new object[2];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_LEFT = new string[dgv_mano_de_obra.ColumnCount];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];

            object[] MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL = new object[2];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_LEFT = new string[dgv_mano_de_obra.ColumnCount];
            string[] MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];
            #endregion

            #region Subtotal

            object[] MANO_DE_OBRA_SUB_TOTAL = new object[2];
            string[] MANO_DE_OBRA_SUB_TOTAL_LEFT = new string[dgv_mano_de_obra.ColumnCount];
            string[] MANO_DE_OBRA_SUB_TOTAL_RIGHT = new string[dgv_mano_de_obra_right.ColumnCount];
            #endregion

            #region Poblar grids

            object_list_etr29.ForEach(fila_ => {
                string Texto_descripcion_mano_del_cargo = Obtener_descripcion_mano_obra(
                    fila_._TR29_DESCRIP,
                    fila_._TR29_DIAS_SEMANA,
                    fila_._TR29_HORA_ENTRADA,
                    fila_._TR29_HORA_SALIDA,
                    fila_._lista_et_r30
                );
                var res = _LISTA_ET_R31.Where(fila => fila._TR31_TR29_ID == fila_._TR29_ID).ToList();
                object[] informacion_r31 = new object[res.Count];

                int total_personal = 0;
                int indice_locales = 0;

                string[] fila_dgv_mano_obra = new string[(1 + res.Count)];
                fila_dgv_mano_obra[0] = Texto_descripcion_mano_del_cargo;

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
                object[] rellenos = new object[_ET_ENTIDAD._lista_et_m27.Count];
                int indice = 0;
                _ET_ENTIDAD._lista_et_m27.ForEach(c => {
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


                decimal SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS = 0.00M;
                decimal SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS = 0.00M;
                fila_._lista_et_r30.ForEach(X =>
                {

                    if (X._TR30_AFECTO)
                    {
                        if (X._TR30_IMPORTE != 0.00M) // TABAJA CON IMPORTE 
                        {
                            SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS += X._TR30_IMPORTE;
                        }
                        if (X._TR30_PORCENTAJE != 0.0M) // TRABAJA CON PORCENTAJE
                        {
                            if (fila_._TR29_REMUNERACION >= 850.00M) // // OBTENEMOS EL PORCENTAJE DEL CONCEPTO EN BASE A LA REMUNERACION MINIMA VITAL
                                SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS += ((fila_._TR29_REMUNERACION * X._TR30_PORCENTAJE) * 1.00M);
                            else
                                SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS += (850.00M * X._TR30_PORCENTAJE);

                        }
                    }
                    else
                    {
                        if (X._TR30_IMPORTE != 0.00M) // TABAJA CON IMPORTE 
                        {
                            SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS += X._TR30_IMPORTE;
                        }
                        if (X._TR30_PORCENTAJE != 0.0M) // TRABAJA CON PORCENTAJE
                        {
                            if (fila_._TR29_REMUNERACION >= 850.00M) // // OBTENEMOS EL PORCENTAJE DEL CONCEPTO EN BASE A LA REMUNERACION MINIMA VITAL
                                SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS += ((fila_._TR29_REMUNERACION * X._TR30_PORCENTAJE) * 1.00M);
                            else
                                SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS += (850.00M * X._TR30_PORCENTAJE);
                        }
                    }
                });

                decimal SUMA_DE_AFECTOS_Y_NO_AFECTOS = SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS + SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS;
                dgv_mano_de_obra_right.Rows.Add(
                    total_personal,
                    string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION),
                    string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_AFECTOS),
                    string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", SUMA_CONCEPTOS_REMUNERATIVOS_NO_AFECTOS),
                    string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION * 1.00M + SUMA_DE_AFECTOS_Y_NO_AFECTOS * 1.00M).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", fila_._TR29_REMUNERACION * 1.00M + SUMA_DE_AFECTOS_Y_NO_AFECTOS * 1.00M),
                    string.Format("{0:#,#.00}", ((fila_._TR29_REMUNERACION + SUMA_DE_AFECTOS_Y_NO_AFECTOS) * total_personal) * 1.00M).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", ((fila_._TR29_REMUNERACION + SUMA_DE_AFECTOS_Y_NO_AFECTOS) * total_personal) * 1.00M)
                 );
                MANO_DE_OBRA_SUELDO_MENSUAL_POR_CARGO[INDICE_MANO_DE_OBRA_SUELDO_MENSUAL_POR_CARGO] = fila_._TR29_REMUNERACION * 1.00M + SUMA_DE_AFECTOS_Y_NO_AFECTOS * 1.00M;
                INDICE_MANO_DE_OBRA_SUELDO_MENSUAL_POR_CARGO++;

                MANO_OBRA_TOTAL = MANO_OBRA_TOTAL + (((fila_._TR29_REMUNERACION + SUMA_DE_AFECTOS_Y_NO_AFECTOS) * total_personal) * 1.00M);
                MANO_OBRA_TOTAL_PERSONAL = MANO_OBRA_TOTAL_PERSONAL + total_personal;

                dgv_mano_de_obra.Rows.Add(fila_dgv_mano_obra);
            });
            #endregion

            #region Primer_subtotal
            for (int a = 0; a < (MANO_DE_OBRA_SUBTOTALES_UNO.Count()); a++)
            {
                if (a == 0)
                {
                    MANO_DE_OBRA_SUBTOTALES_UNO[a] = "Sub Total ";
                }
                else
                {
                    decimal MANO_DE_OBRA_TOTAL_POR_LOCAL_ = 0 * 1M;
                    object_list_etr29.ForEach(fila_ =>
                    {
                        var res = _LISTA_ET_R31.Where(fila => fila._TR31_TR29_ID == fila_._TR29_ID).ToList();
                        for (int N = 0; N < res.Count(); N++)
                        {
                            if (N == (a -1))
                            {
                                var total_personal = res.ElementAt(N);
                                decimal SUELDO_MENSUAL_POR_CARGO = 0 * 1M;
                                decimal SUMA_CONCEPTOS_REMUNERATIVOS = 0M;
                                fila_._lista_et_r30.ForEach(X =>
                                {
                                    SUMA_CONCEPTOS_REMUNERATIVOS = SUMA_CONCEPTOS_REMUNERATIVOS * 1M + X._TR30_IMPORTE * 1M;
                                });
                                SUELDO_MENSUAL_POR_CARGO = fila_._TR29_REMUNERACION * 1M + SUMA_CONCEPTOS_REMUNERATIVOS * 1M;
                                MANO_DE_OBRA_TOTAL_POR_LOCAL_ = MANO_DE_OBRA_TOTAL_POR_LOCAL_ + (SUELDO_MENSUAL_POR_CARGO * total_personal._TR31_CANT_PERSONAS);
                                break;
                            }
                        }
                    });
                    string VALOR_POR_LOCAL_SUBTOTAL = string.Format("{0:#,#.00}", MANO_DE_OBRA_TOTAL_POR_LOCAL_).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", MANO_DE_OBRA_TOTAL_POR_LOCAL_);
                    MANO_DE_OBRA_SUBTOTALES_UNO[a] = VALOR_POR_LOCAL_SUBTOTAL;
                }
            }

            for (int a = 0; a <= dgv_mano_de_obra_right.ColumnCount - 1; a++)
            {
                if(a== 0)
                    MANO_DE_OBRA_SUBTOTALES_DOS[0] = MANO_OBRA_TOTAL_PERSONAL.ToString();
                MANO_DE_OBRA_SUBTOTALES_DOS[a] = string.Empty;
                if(a == dgv_mano_de_obra_right.ColumnCount - 2)
                    MANO_DE_OBRA_SUBTOTALES_DOS[a] = "S/";
                if (a == dgv_mano_de_obra_right.ColumnCount - 1)
                    MANO_DE_OBRA_SUBTOTALES_DOS[a] = string.Format("{0:#,#.00}", MANO_OBRA_TOTAL).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", MANO_OBRA_TOTAL);

            }

            MANO_DE_OBRA_FIRST_SUBTOTAL[0] = MANO_DE_OBRA_SUBTOTALES_UNO;
            MANO_DE_OBRA_FIRST_SUBTOTAL[1] = MANO_DE_OBRA_SUBTOTALES_DOS;

            #endregion

            #region Beneficios_sociales
            decimal suma_De_beneficios_sociales_vacaciones = 0*1M;
            decimal suma_De_beneficios_sociales_cts = 0*1M;
            decimal suma_De_beneficios_sociales_gratificaciones = 0*1M;

            decimal valor_vacaciones = 0.0833333333333333M;
            decimal valor_cts = (0.0833333333333333M) + (0.166666666666667M) * (0.0833333333333333M);
            decimal valor_gratificaciones = 16.6666666666667M;
            for (int a = 0; a < MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT.Count(); a++)
            {
                if (a == 0)
                {
                    if (!MENOR_CUATRO_HORAS)
                    {
                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a] = "Vacaciones 8.33%";
                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_LEFT[a] = "CTS 9.72%";
                    }
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a] = "Gratificaciones 16.67%";
                }
                else
                {
                    if (!MENOR_CUATRO_HORAS)
                    {
                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a] = string.Format("{0:#,#.00}", (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_vacaciones * 1M)).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_vacaciones * 1M));
                        suma_De_beneficios_sociales_vacaciones = suma_De_beneficios_sociales_vacaciones + (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_vacaciones * 1M);

                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_LEFT[a] = string.Format("{0:#,#.00}", (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_cts * 1M)).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_cts * 1M));
                        suma_De_beneficios_sociales_cts = suma_De_beneficios_sociales_cts + (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_cts * 1M);
                    }
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a] = string.Format("{0:#,#.00}", (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_gratificaciones * 1M)).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_gratificaciones * 1M));
                    suma_De_beneficios_sociales_gratificaciones = suma_De_beneficios_sociales_gratificaciones + (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) * valor_gratificaciones * 1M);

                }
            }
            for (int A = 0; A < MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT.Count(); A++)
            {
                if (A == MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT.Count() - 1)
                {
                    if (!MENOR_CUATRO_HORAS)
                    {
                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT[A] = string.Format("{0:#,#.00}", suma_De_beneficios_sociales_vacaciones).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", suma_De_beneficios_sociales_vacaciones);
                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_RIGHT[A] = string.Format("{0:#,#.00}", suma_De_beneficios_sociales_cts).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", suma_De_beneficios_sociales_cts);
                    }
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_RIGHT[A] = string.Format("{0:#,#.00}", suma_De_beneficios_sociales_gratificaciones).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", suma_De_beneficios_sociales_gratificaciones);
                }
                else
                {
                    if (!MENOR_CUATRO_HORAS)
                    {
                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT[A] = "";
                        MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_RIGHT[A] = "";
                    }
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_RIGHT[A] = "";
                }
            }

            for (int a = 0; a < MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_LEFT.Count(); a++)
            {
                if (a == 0)
                {
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_LEFT[a] = "";
                }
                else
                {
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_LEFT[a] = 
                        string.Format("{0:#,#.00}",
                        (
                        (MENOR_CUATRO_HORAS == true ? (0) : (

                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_LEFT[a])

                        )) + 
                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a])
                        )).Equals(".00") ?
                        "0.00" 
                        :
                        string.Format("{0:#,#.00}",
                        (
                        (MENOR_CUATRO_HORAS == true ? (0):(

                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_LEFT[a])

                        )) +
                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a])
                        ));
                }
            }
            for (int a = 0; a < MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT.Count(); a++)
            {
                MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT[a] = "";
                if (a == MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT.Count() - 1)
                {
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT[a] =
                    string.Format("{0:#,#.00}",
                        (
                        (MENOR_CUATRO_HORAS == true ? (0) : (
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_RIGHT[a])
                        )) +
                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_RIGHT[a])
                        )).Equals(".00") ?
                        "0.00"
                        :
                        string.Format("{0:#,#.00}",
                        (
                        (MENOR_CUATRO_HORAS == true ? (0) : (
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_RIGHT[a])
                        )) +
                        Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_RIGHT[a])
                        ));
                }
                if (a == (MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT.Count() - 2))
                    MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT[a] = "S/";
            }

            MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES[0] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT;
            MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES[1] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_RIGHT;

            MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS[0] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_LEFT;
            MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS[1] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS_RIGHT;

            MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES[0] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT;
            MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES[1] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_RIGHT;

            MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL[0] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_LEFT;
            MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL[1] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT;

            MANO_DE_OBRA_BENEFICIOS_SOCIALES[0] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES;
            MANO_DE_OBRA_BENEFICIOS_SOCIALES[1] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_CTS;
            if (MENOR_CUATRO_HORAS)
            {
                MANO_DE_OBRA_BENEFICIOS_SOCIALES[0] = null;
                MANO_DE_OBRA_BENEFICIOS_SOCIALES[1] = null;
            }
            MANO_DE_OBRA_BENEFICIOS_SOCIALES[2] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES;
            MANO_DE_OBRA_BENEFICIOS_SOCIALES[3] = MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL;
            #endregion

            #region Leyes Sociales

            decimal suma_De_leyes_sociales_essalud = 0 * 1M;
            decimal suma_de_leyes_sociales_sctr = 0 * 1M;
            decimal suma_de_leyes_seguro_ley_vida = 0 * 1M;

            decimal valor_essalud = 0.09M;
            decimal valor_sctr = 0.0113M;
            decimal valor_seguro_ley_veida = 0.0071M;

            for (int a = 0; a < MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_LEFT.Count(); a++)
            {
                if (a == 0)
                {
                    MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_LEFT[a] = "EsSalud 9.00%";
                    MANO_DE_OBRA_LEYES_SOCIALES_SCTR_LEFT[a] = "S.C.T.R 1.13%";
                    if(MENOR_CUATRO_HORAS)
                        MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_LEFT[a] = "Seguro ley vida 0.71%";
                }
                else
                {
                    MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_LEFT[a] = 
                        string.Format("{0:#,#.00}", 
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) +  
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a]) + 
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a])) * valor_essalud * 1M
                        )).Equals(".00") ? 
                        "0.00" : 
                        string.Format("{0:#,#.00}", 
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a]))) * valor_essalud * 1M
                        );
                    suma_De_leyes_sociales_essalud = suma_De_leyes_sociales_essalud + 
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a])) * valor_essalud * 1M
                        );
                    // *********************************
                    MANO_DE_OBRA_LEYES_SOCIALES_SCTR_LEFT[a] =
                        string.Format("{0:#,#.00}",
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a])) * valor_sctr * 1M
                        )).Equals(".00") ?
                        "0.00" :
                        string.Format("{0:#,#.00}",
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a]))) * valor_sctr * 1M
                        );
                    suma_de_leyes_sociales_sctr = suma_de_leyes_sociales_sctr +
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_GRATIFICACIONES_LEFT[a]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_VACACIONES_LEFT[a])) * valor_sctr * 1M
                        );
                    // *********************************

                    if (MENOR_CUATRO_HORAS)
                    {
                        MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_LEFT[a] =
                            string.Format("{0:#,#.00}",
                            (
                                (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a])) * valor_seguro_ley_veida * 1M
                            )).Equals(".00") ?
                            "0.00" :
                            string.Format("{0:#,#.00}",
                            (
                                (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a]))) * valor_seguro_ley_veida * 1M
                            );
                        suma_de_leyes_seguro_ley_vida = suma_de_leyes_seguro_ley_vida +
                            (
                                (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[a])) * valor_seguro_ley_veida * 1M
                            );
                    }

                    // *********************************

                }
            }

            for (int A = 0; A < MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT.Count(); A++)
            {
                if (A == MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT.Count() - 1)
                {
                    MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT[A] = string.Format("{0:#,#.00}", suma_De_leyes_sociales_essalud).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", suma_De_leyes_sociales_essalud);
                    MANO_DE_OBRA_LEYES_SOCIALES_SCTR_RIGHT[A] = string.Format("{0:#,#.00}", suma_de_leyes_sociales_sctr).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", suma_de_leyes_sociales_sctr);
                    MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_RIGHT[A] = string.Format("{0:#,#.00}", suma_de_leyes_seguro_ley_vida).Equals(".00") ? "0.00" : string.Format("{0:#,#.00}", suma_de_leyes_seguro_ley_vida);
                }
                else
                {
                    MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT[A] = "";
                    MANO_DE_OBRA_LEYES_SOCIALES_SCTR_RIGHT[A] = "";
                    MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_RIGHT[A] = "";
                }
            }

            for (int a = 0; a < MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_LEFT.Count(); a++)
            {
                if (a == 0)
                {
                    MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_LEFT[a] = "";
                }
                else
                {
                    MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_LEFT[a] =
                        string.Format("{0:#,#.00}",
                        (
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_LEFT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SCTR_LEFT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_LEFT[a])
                        )).Equals(".00") ?
                        "0.00"
                        :
                        string.Format("{0:#,#.00}",
                        (
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_LEFT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SCTR_LEFT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_LEFT[a])
                        ));
                }
            }
            for (int a = 0; a < MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT.Count(); a++)
            {
                MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT[a] = "";
                if (a == MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT.Count() - 1)
                {
                    MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT[a] =
                    string.Format("{0:#,#.00}",
                        (
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SCTR_RIGHT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_RIGHT[a])
                        )).Equals(".00") ?
                        "0.00"
                        :
                        string.Format("{0:#,#.00}",
                        (
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SCTR_RIGHT[a]) +
                        Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_RIGHT[a])
                        ));
                }
                if (a == (MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT.Count() - 2))
                    MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT[a] = "S/";
            }

            MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD[0] = MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_LEFT;
            MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD[1] = MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD_RIGHT;

            MANO_DE_OBRA_LEYES_SOCIALES_SCTR[0] = MANO_DE_OBRA_LEYES_SOCIALES_SCTR_LEFT;
            MANO_DE_OBRA_LEYES_SOCIALES_SCTR[1] = MANO_DE_OBRA_LEYES_SOCIALES_SCTR_RIGHT;

            MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY[0] = MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_LEFT;
            MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY[1] = MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY_RIGHT;

            MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL[0] = MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_LEFT;
            MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL[1] = MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT;

            MANO_DE_OBRA_LEYES_SOCIALES[0] = MANO_DE_OBRA_LEYES_SOCIALES_ESSALUD;
            MANO_DE_OBRA_LEYES_SOCIALES[1] = MANO_DE_OBRA_LEYES_SOCIALES_SCTR;
            if(!MENOR_CUATRO_HORAS)
                MANO_DE_OBRA_LEYES_SOCIALES[2] = null;
            else
                MANO_DE_OBRA_LEYES_SOCIALES[2] = MANO_DE_OBRA_LEYES_SOCIALES_SEGURO_VIDA_LEY;

            MANO_DE_OBRA_LEYES_SOCIALES[3] = MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL;


            #endregion

            #region Subtotal
            for (int A = 0; A < MANO_DE_OBRA_SUB_TOTAL_LEFT.Count(); A++)
            {
                if (A == 0)
                    MANO_DE_OBRA_SUB_TOTAL_LEFT[A] = "Sub Total";
                else
                {
                    MANO_DE_OBRA_SUB_TOTAL_LEFT[A] =string.Format("{0:#,#.00}",
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[A]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_LEFT[A]) +
                            Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_LEFT[A])) * 1M
                        )).Equals(".00") ?
                        "0.00" :
                        string.Format("{0:#,#.00}",
                        (
                            (Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_UNO[A]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_LEFT[A]) +
                            Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_LEFT[A])) * 1M
                        ));
                }
            }
            decimal subtotal  = 0 * 1M;
            for (int A = 0; A < MANO_DE_OBRA_SUB_TOTAL_RIGHT.Count(); A++)
            {
                if (A == (MANO_DE_OBRA_SUB_TOTAL_RIGHT.Count() - 2))
                    MANO_DE_OBRA_SUB_TOTAL_RIGHT[A] = "S/";
                else if ((A == (MANO_DE_OBRA_SUB_TOTAL_RIGHT.Count() - 1)))
                {
                    subtotal = subtotal + ((Convert.ToDecimal(MANO_DE_OBRA_SUBTOTALES_DOS[A]) +
                            Convert.ToDecimal(MANO_DE_OBRA_BENEFICIOS_SOCIALES_SUTOTAL_RIGHT[A]) +
                            Convert.ToDecimal(MANO_DE_OBRA_LEYES_SOCIALES_SUB_TOTAL_RIGHT[A])) * 1M);
                }
                else
                {
                    MANO_DE_OBRA_SUB_TOTAL_RIGHT[A] = "";
                }
            }
            MANO_DE_OBRA_SUB_TOTAL_RIGHT[MANO_DE_OBRA_SUB_TOTAL_RIGHT.Count() - 1] = string.Format("{0:#,#.00}",(subtotal)).Equals(".00") ?"0.00" :string.Format("{0:#,#.00}",(subtotal));

            MANO_DE_OBRA_SUB_TOTAL[0] = MANO_DE_OBRA_SUB_TOTAL_LEFT;
            MANO_DE_OBRA_SUB_TOTAL[1] = MANO_DE_OBRA_SUB_TOTAL_RIGHT;
            #endregion

            respuesta[0] = MANO_DE_OBRA_FIRST_SUBTOTAL; //PRIMER SUBTOTAL
            respuesta[1] = MANO_DE_OBRA_BENEFICIOS_SOCIALES; //OBJETOS CON INFORMACION DE BENEFICIOS SOCIALES
            respuesta[2] = MANO_DE_OBRA_LEYES_SOCIALES; // OBJETOS CON INFORMACION DE LEYES SOCIALES  
            respuesta[3] = MANO_DE_OBRA_SUB_TOTAL; // SEGUNDO SUBTOTAL

            Metodo_Calcular_costo_mensual_mano_De_obra(MANO_DE_OBRA_SUB_TOTAL);
            return respuesta;
        }

        private object[] MANO_DE_OBRA_COSTO_MENSUAL = new object[2];

        private void Metodo_Calcular_costo_mensual_mano_De_obra(object[] mANO_DE_OBRA_SUB_TOTAL)
        {
            if (MANO_DE_OBRA_COSTO_MENSUAL[0] != null && MANO_DE_OBRA_COSTO_MENSUAL[1] != null)
            {
                decimal[] costo_mensual_por_local = (decimal[])MANO_DE_OBRA_COSTO_MENSUAL[0];
                decimal[] costo_mensual_subtotal = (decimal[])MANO_DE_OBRA_COSTO_MENSUAL[1];
                string[] sub_total_mensual_por_local = (string[])mANO_DE_OBRA_SUB_TOTAL[0];
                string[] sub_total_mensual = (string[])mANO_DE_OBRA_SUB_TOTAL[1];
                for (int A = 1; A < costo_mensual_por_local.Count(); A++)
                {
                    costo_mensual_por_local[A] = costo_mensual_por_local[A] + Convert.ToDecimal(sub_total_mensual_por_local[A]);
                }
                for (int B = costo_mensual_subtotal.Count() - 1; B < costo_mensual_subtotal.Count(); B++)
                {
                    costo_mensual_subtotal[B] = costo_mensual_subtotal[B] + Convert.ToDecimal(sub_total_mensual[B]);
                }
                MANO_DE_OBRA_COSTO_MENSUAL[0] = costo_mensual_por_local;
                MANO_DE_OBRA_COSTO_MENSUAL[1] = costo_mensual_subtotal;
            }
        }

        private string Obtener_descripcion_mano_obra(string descripcion, int dias_por_Semana, DateTime hora_entrada, DateTime hora_salida, List<ET_R30> conceptos_)
        {
            int horas = 0;
            string horario = "";
            switch (dias_por_Semana)
            {
                case 1:
                    horario = "1 día:";
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
                conceptos_short = conceptos_short + (string.IsNullOrEmpty(row._TR30_ABREV) ? string.Empty : row._TR30_ABREV) + "/";
            });
            conceptos_short = conceptos_short.Substring(0, conceptos_short.Length - 1);
            horario = horario + hora_entrada.ToString("H:mm") + " - " + hora_salida.ToString("H:mm");
            return descripcion + " " + horas.ToString() + " h " + horario + conceptos_short;
        }

        private void dgv_mano_de_obra_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if(dgv_mano_de_obra.FirstDisplayedScrollingRowIndex >= 0)
                    dgv_mano_de_obra_right.FirstDisplayedScrollingRowIndex = dgv_mano_de_obra.FirstDisplayedScrollingRowIndex;
            }
            catch (Exception ex)
            { }
        }

        private void dgv_mano_de_obra_right_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if(dgv_mano_de_obra_right.FirstDisplayedScrollingRowIndex >= 0)
                    dgv_mano_de_obra.FirstDisplayedScrollingRowIndex = dgv_mano_de_obra_right.FirstDisplayedScrollingRowIndex;
            }
            catch (Exception ex)
            { }
        }

        private void dgv_mano_de_obra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                btn_guardar_mano_de_obra_Click(null,null);
            }

        }

        // 1054 ok
        // 1058 ok
        private void Metodo_mostrar_calculos_de_costos_mano_de_obra(object Subtotal_line)
        {
            Font Font_ = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            if (Subtotal_line != null)
            {
                //MOSTRAMOS LOS SUBTOTALES
                object[] s_one = (object[])Subtotal_line;

                object[] FILA_UNO = (object[])s_one[0];

                string[] s_right = (string[])FILA_UNO[1];
                string[] s_left = (string[])FILA_UNO[0];
                dgv_mano_de_obra_right.Rows.Add(s_right);
                dgv_mano_de_obra.Rows.Add(s_left);
                //agregamos estilos a  las celdas ingresadas
                Resaltar_filas_ingresadas(dgv_mano_de_obra_right, (dgv_mano_de_obra.Rows.Count - 1), Color.Black, Font_);
                Resaltar_filas_ingresadas(dgv_mano_de_obra, (dgv_mano_de_obra.Rows.Count - 1), Color.Black, Font_);

                #region SUBTOTALES
                for (int A = 1; A < s_one.Count(); A++)
                {
                    if (A == 1)
                        Ingresar_filas_vacias_dentro_de_grids(Color.Blue,dgv_mano_de_obra, dgv_mano_de_obra_right, Titulo: "Beneficios Sociales");
                    if (A == 2)
                        Ingresar_filas_vacias_dentro_de_grids(Color.Blue, dgv_mano_de_obra, dgv_mano_de_obra_right, Titulo: "Leyes Sociales");
                    object[] NEXT_ROW = (object[])s_one[A];

                    for (int B = 0; B < NEXT_ROW.Count(); B++)
                    {
                        object[] ROW__ = (object[])NEXT_ROW[B];

                        if (A < (s_one.Count() - 1))
                        {
                            if (ROW__ != null)
                            {
                                string[] row_left = (string[])ROW__[0];
                                string[] row_right = (string[])ROW__[1];
                                dgv_mano_de_obra_right.Rows.Add(row_right);
                                dgv_mano_de_obra.Rows.Add(row_left);

                                if (B == (NEXT_ROW.Count() - 1))
                                {
                                    //agregamos estilos a  las celdas ingresadas
                                    Resaltar_filas_ingresadas(dgv_mano_de_obra_right, (dgv_mano_de_obra_right.Rows.Count - 1), Color.Blue, Font_);
                                    Resaltar_filas_ingresadas(dgv_mano_de_obra, (dgv_mano_de_obra.Rows.Count - 1), Color.Blue, Font_);
                                    //fin estilos
                                }
                            }
                        }
                    }
                    if (A == (s_one.Count() - 1))
                    {
                        //Ingresar_filas_vacias_dentro_de_grids(Color.Blue, dgv_mano_de_obra, dgv_mano_de_obra_right, Titulo: "Leyes Sociales");
                        object[] FILA_ST = (object[])s_one[A];
                        //SUBTOTAL ONE
                        string[] sT_right = (string[])FILA_ST[1];
                        string[] sT_left = (string[])FILA_ST[0];
                        dgv_mano_de_obra_right.Rows.Add(sT_right);
                        dgv_mano_de_obra.Rows.Add(sT_left);
                        //agregamos estilos a  las celdas ingresadas
                        Resaltar_filas_ingresadas(dgv_mano_de_obra_right, (dgv_mano_de_obra.Rows.Count - 1), Color.DarkBlue, Font_);
                        Resaltar_filas_ingresadas(dgv_mano_de_obra, (dgv_mano_de_obra.Rows.Count - 1), Color.DarkBlue, Font_);
                    }
                }
                #endregion
            }
        }

        private void Metodo_mostrar_costo_mensual_mano_de_obra()
        {
            Font Font_ = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            #region COSTO_MENSUAL

            //ingresar dos filas vacias de margen
            string[] COSTO_MENSUAL_PO_LOCAL__ = new string[dgv_mano_de_obra.ColumnCount];
            string[] COSTO_MENSUAL_SUMA_SUBTOTALES = new string[dgv_mano_de_obra_right.ColumnCount];
            //--> llenamos los valores para las filas como vacio en funcion a la cantidad de columnas 
            for (int a = 0; a < dgv_mano_de_obra.ColumnCount; a++)
                COSTO_MENSUAL_PO_LOCAL__[a] = "";
            for (int a = 0; a < dgv_mano_de_obra_right.ColumnCount; a++)
                COSTO_MENSUAL_SUMA_SUBTOTALES[a] = "";

            decimal[] costo_mensual_por_local = (decimal[])MANO_DE_OBRA_COSTO_MENSUAL[0];
            decimal[] costo_mensual_subtotal = (decimal[])MANO_DE_OBRA_COSTO_MENSUAL[1];
            COSTO_MENSUAL_PO_LOCAL__[0] = "COSTO MENSUAL DE M.O.";
            for (int A = 1; A < costo_mensual_por_local.Count(); A++)
            {
                COSTO_MENSUAL_PO_LOCAL__[A] = string.Format("{0:#,#.00}",
                        (
                            costo_mensual_por_local[A]
                        )).Equals(".00") ?
                        "0.00" :
                        string.Format("{0:#,#.00}",
                        (
                            costo_mensual_por_local[A]
                        ));
            }
            for (int B = costo_mensual_subtotal.Count() - 2; B < costo_mensual_subtotal.Count(); B++)
            {
                if (B == costo_mensual_subtotal.Count() - 2)
                    COSTO_MENSUAL_SUMA_SUBTOTALES[B] = "S/";
                if (B == costo_mensual_subtotal.Count() - 1)
                    COSTO_MENSUAL_SUMA_SUBTOTALES[B] =
                        string.Format("{0:#,#.00}",
                        (
                            costo_mensual_subtotal[B]
                        )).Equals(".00") ?
                        "0.00" :
                        string.Format("{0:#,#.00}",
                        (
                            costo_mensual_subtotal[B]
                        ));
                ;
            }

            dgv_mano_de_obra_right.Rows.Add(COSTO_MENSUAL_SUMA_SUBTOTALES);
            dgv_mano_de_obra.Rows.Add(COSTO_MENSUAL_PO_LOCAL__);
            //agregamos estilos a  las celdas ingresadas
            Resaltar_filas_ingresadas(dgv_mano_de_obra_right, (dgv_mano_de_obra.Rows.Count - 1), Color.DarkBlue, Font_);
            Resaltar_filas_ingresadas(dgv_mano_de_obra, (dgv_mano_de_obra.Rows.Count - 1), Color.DarkBlue, Font_);

            #endregion
        }

        private void Ingresar_filas_vacias_dentro_de_grids(Color textcolor ,DataGridView grid_left, DataGridView grid_right, int filas = 1,string Titulo = null)
        {
            //ingresar dos filas vacias de margen
            string[] fila_vacia_mano_de_obra_left = new string[grid_left.ColumnCount];
            string[] fila_vacia_mano_de_obra_right = new string[grid_right.ColumnCount];
            //--> llenamos los valores para las filas como vacio en funcion a la cantidad de columnas 
            for (int a = 0; a < grid_left.ColumnCount; a++)
            {
                fila_vacia_mano_de_obra_left[a] = "";
            }
            for (int a = 0; a < grid_right.ColumnCount; a++)
                fila_vacia_mano_de_obra_right[a] = "";

            for (int a = 0; a < filas; a++) // -> cantidad de filas vacias
            {
                grid_right.Rows.Add(fila_vacia_mano_de_obra_right);
                grid_left.Rows.Add(fila_vacia_mano_de_obra_left);
            }

            if (!string.IsNullOrEmpty(Titulo))
            {
                grid_right.Rows.Add(fila_vacia_mano_de_obra_right);

                string[] fila_titulo = new string[grid_left.ColumnCount];
                fila_titulo[0] = Titulo;
                for (int a = 1; a < grid_left.ColumnCount; a++)
                {
                    fila_titulo[a] = "";
                }
                grid_left.Rows.Add(fila_titulo);
                Font Font_ = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                Resaltar_filas_ingresadas(dgv_mano_de_obra, (dgv_mano_de_obra.Rows.Count - 1), textcolor, Font_);
                Resaltar_filas_ingresadas(dgv_mano_de_obra_right, (dgv_mano_de_obra_right.Rows.Count - 1), textcolor, Font_);
            }
        }

        private void Resaltar_filas_ingresadas(DataGridView visor, int fila, Color c, Font f = null)
        {
            for (int a = 0; a < visor.ColumnCount; a++)
            {
                visor.Rows[fila].Cells[a].Style.ForeColor = c;
                if (Font != null)
                    visor.Rows[fila].Cells[a].Style.Font = f;
            }
        }

        private void h_scroll_mano_de_obra_Scroll(object sender, ScrollEventArgs e)
        {
            dgv_mano_de_obra.HorizontalScrollingOffset = h_scroll_mano_de_obra.Value;
        }

        private void dgv_mano_de_obra_Resize(object sender, EventArgs e)
        {
            Definir_valores_scroll_de_mano_De_obra();
        }

        private void dgv_mano_de_obra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_mano_de_obra.NewRowIndex != e.RowIndex)
            {
                if (e.ColumnIndex == 1 && dgv_mano_de_obra.Rows[e.RowIndex].Cells[0].Value.ToString() == "Sub Total")
                {
                    foreach (DataGridViewCell item in dgv_mano_de_obra_right.Rows[e.RowIndex].Cells)
                        item.Style.BackColor = Color.FromArgb(255, 224, 178);
                    foreach (DataGridViewCell item in dgv_mano_de_obra.Rows[e.RowIndex].Cells)
                        item.Style.BackColor = Color.FromArgb(255, 224, 178);
                }
                // COSTO MENSUAL DE M.O.
                if (e.ColumnIndex == 1 && dgv_mano_de_obra.Rows[e.RowIndex].Cells[0].Value.ToString() == "COSTO MENSUAL DE M.O.")
                {
                    foreach (DataGridViewCell item in dgv_mano_de_obra_right.Rows[e.RowIndex].Cells)
                        item.Style.BackColor = Color.FromArgb(255, 204, 128);
                    foreach (DataGridViewCell item in dgv_mano_de_obra.Rows[e.RowIndex].Cells)
                        item.Style.BackColor = Color.FromArgb(255, 204, 128);
                }
            }
        }

        private void dgv_mano_de_obra_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Definir_valores_scroll_de_mano_De_obra();
        }

        #endregion


        #region Maquinaria y equipo
        //diego
        private void CreateColumn()
        {
            int index = 1;
            foreach (ET_M27 fila in _ET_ENTIDAD._lista_et_m27)
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
            int cont = _ET_ENTIDAD._lista_et_m27.Count;
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

                    _entidades_ = _NT_M31.gridTextBoxAutocomplete(auto_text);
                    _LISTA_M31 = _entidades_._lista_et_m31;
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
                bool existe = _LISTA_M31.Any(item => (item._TM31_DESCRIP + " " + item._TM31_TM33_ID + " " + item._TM31_TM72_ID) == e.FormattedValue.ToString());
                //bool existe = _lista_m31.Any(item => item._TM31_DESCRIP == e.FormattedValue.ToString());
                if (existe)
                {
                    ET_M31 fila = _LISTA_M31.FirstOrDefault(item => (item._TM31_DESCRIP + " " + item._TM31_TM33_ID + " " + item._TM31_TM72_ID) == e.FormattedValue.ToString());
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
            int cont = _ET_ENTIDAD._lista_et_m27.Count;
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
                int cont = _ET_ENTIDAD._lista_et_m27.Count;
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

    }
}
