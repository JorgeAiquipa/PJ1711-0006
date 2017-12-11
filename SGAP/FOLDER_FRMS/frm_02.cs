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

        //ctrConectar ctr_conectar = new ctrConectar();
        NT_cotizador ctr_cotizador_ = new NT_cotizador();

        #endregion

        #region Metodos
        public frm_02(string tipo_servicio = null)
        {
            InitializeComponent();

            //carga de estilos
            this.treeView1.ContextMenuStrip = this.contextMenuStrip_tree_view;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //carga de metodos 
            //ctr_conectar.Metodo_Conectar();
            Metodo_Obtener_conceptos_default(tipo_servicio);

        }


        void Metodo_Obtener_conceptos_default(String Tipo_Servicio)
        {
            if (Tipo_Servicio != string.Empty)
            {
                TreeNode nodo_principal = new TreeNode();
                nodo_principal.Name = Tipo_Servicio+"+1";
                nodo_principal.Text = Tipo_Servicio;
                nodo_principal.Expand();

                DataSet resultado = ctr_cotizador_.Lista();

                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    string textbox = row[1].ToString();
                    nodo_principal.Nodes.Add(textbox);
                }
                this.treeView1.Nodes.Add(nodo_principal);
            }
        }
        #endregion

        #region Eventos

        private void toolStreep_Agregar_servicio_complementario_Click(object sender, EventArgs e)
        {
            string tipo_Servicio = "";
            Metodo_Obtener_conceptos_default(tipo_Servicio);
        }

        #endregion


    }
}
