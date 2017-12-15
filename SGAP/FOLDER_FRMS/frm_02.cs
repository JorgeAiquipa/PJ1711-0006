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
    public partial class frm_02 : Form
    {


        #region Variables

        ET_entidad _entidad = new ET_entidad();
        NT_M38 _nt_m38 = new NT_M38();


        NT_cotizador ctr_cotizador_ = new NT_cotizador();
        int __id_tm41;

        #endregion

        #region Metodos
        public frm_02(ET_entidad _entity)
        {
            InitializeComponent();
            

            this.BringToFront();

            this.tree_view_servicios.ContextMenuStrip = this.contextMenuStrip_tree_view;
            _entidad = _entity;

            __id_tm41 = _entity._entity_m41._TM41_ID;
            Metodo_Obtener_conceptos_default();

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


            //Diego
            CreateColumn();
            //

        }


        void Metodo_Obtener_conceptos_default()
        {

            TreeNode mano_obra = new TreeNode("Mano de Obra");
            mano_obra.Name  = "Mano de Obra";
            mano_obra.Tag = 0;
            TreeNode maquinaria = new TreeNode("Maquinaria y Equipo");
            maquinaria.Tag = 1;
            TreeNode materiales = new TreeNode("Materiales e Insumos");
            materiales.Tag = 2;
            TreeNode implementos = new TreeNode("Implementos de Limpieza");
            implementos.Tag = 3;
            TreeNode suministros = new TreeNode("Suministros");
            suministros.Tag = 4;
            TreeNode indumentaria = new TreeNode("Indumentaria");
            indumentaria.Tag = 5;

            TreeNode servicio = new TreeNode(_entidad._entity_m41._TM41_DESCRIP, new TreeNode[] {
                mano_obra,maquinaria,materiales,implementos,suministros,indumentaria
            });
            servicio.Name = _entidad._entity_m41._TM41_DESCRIP;
            servicio.Tag = 0;//_entidad._entity_m41._TM41_ID;

            TreeNode nodo_principal = new TreeNode(_entidad._entity_m19._TM19_DESCRIP2, new TreeNode[] { servicio });
            nodo_principal.Tag = 0; //_entidad._entity_m19._TM19_ID;
            nodo_principal.Name = _entidad._entity_m19._TM19_DESCRIP1;

            nodo_principal.ExpandAll();

            //DataSet resultado = ctr_cotizador_.Lista();

            /*
            foreach (DataRow row in resultado.Tables[0].Rows)
            {
                string textbox = row[1].ToString();
                nodo_principal.Nodes.Add(textbox);
            }
            */

            tree_view_servicios.Nodes.Add(nodo_principal);
        }



        #endregion

        #region Eventos

        private void toolStreep_Agregar_servicio_complementario_Click(object sender, EventArgs e)
        {
            Metodo_Obtener_conceptos_default();
        }

        List<Panel> Panels = new List<Panel>();
        Panel VisiblePanel = null;
        //tiene lugar cuando cambia ala selección.
        private void tree_view_servicios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = int.Parse(e.Node.Tag.ToString());
            DisplayPanel(index);
        }


        // Display the appropriate Panel.
        private void DisplayPanel(int index)
        {
            if (Panels.Count < 1) return;

            // If this is the same Panel, do nothing.
            if (VisiblePanel == Panels[index]) return;

            // Hide the previously visible Panel.
            if (VisiblePanel != null) VisiblePanel.Visible = false;

            // Display the appropriate Panel.
            Panels[index].Visible = true;
            VisiblePanel = Panels[index];
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //tiene lugar cuando se clickea el contenido de una celda

            string column_name = dgv_entrada_datos_mano_de_obra.Columns[0].Name; // cargo
            if (column_name.Equals("cargo"))
            {
                TextBox auto_text = e.Control as TextBox;

                if (auto_text != null)
                {
                    auto_text.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    _nt_m38.gridTextBoxAutocomplete(auto_text);
                }
            }


        }




        #endregion

        #region Mano de obra
        //


        #endregion

        #region Maquinaria y equipo

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

        private void dgv_entrada_datos_mano_de_obra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //diego
        private void CreateColumn()
        {
            //int cantd =_entidad._lista_et_m27.Count;
            try
            {
                int index = 1;

                listView_materiales_equipos.Columns.Add("Nombre", 200, HorizontalAlignment.Left);
                listView_materiales_equipos.Columns.Add("Codigo", 100, HorizontalAlignment.Left);
                listView_materiales_equipos.Columns.Add("Marca", 60, HorizontalAlignment.Left);
                listView_materiales_equipos.Columns.Add("Und", -2, HorizontalAlignment.Left);
                listView_materiales_equipos.Columns.Add("Maquinaria", -2, HorizontalAlignment.Left);
                listView_materiales_equipos.Columns.Add("Equipos", -2, HorizontalAlignment.Left);

                foreach (ET_M27 fila in _entidad._lista_et_m27)
                {
                    listView_materiales_equipos.Columns.Add(string.Format("Local {0}", fila._TM27_NOMBRE), -2, HorizontalAlignment.Left);
                    index++;
                }
            }
            catch (Exception ex){
            }
            listView_materiales_equipos.Columns.Add("Cantidad Total", -2, HorizontalAlignment.Left);
            listView_materiales_equipos.Columns.Add("Costo Unitario", -2, HorizontalAlignment.Left);
            listView_materiales_equipos.Columns.Add("Costo Total", -2, HorizontalAlignment.Left);


            
        }

        #region Mano de obra
        //


        #endregion

        #region Maquinaria y equipo

        #endregion

        private void listView_materiales_equipos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
