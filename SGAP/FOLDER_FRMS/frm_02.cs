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
        NT_cotizador ctr_cotizador_ = new NT_cotizador();
        int __id_tm41;

        #endregion

        #region Metodos
        public frm_02(ET_entidad _entity)
        {
            InitializeComponent();

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
            servicio.Tag = _entidad._entity_m41._TM41_ID;

            TreeNode nodo_principal = new TreeNode(_entidad._entity_m19._TM19_DESCRIP2, new TreeNode[] { servicio });
            nodo_principal.Tag = _entidad._entity_m19._TM19_ID;
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


        #endregion
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
    }
}
