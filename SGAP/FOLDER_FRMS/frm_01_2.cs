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

        #endregion

        #region Metodos
        public frm_01_2(ET_entidad _entity, bool editar = false)
        {
            InitializeComponent();
            this.BringToFront();
            this.tree_view_servicios.ContextMenuStrip = this.contextMenuStrip_tree_view;
            _entidad = _entity;

            // obtener los servicios 
            _nt_r28.get_001(_entity, tree_view_servicios);

            if (editar)
            {


                
                //obtener los locales que posee la cotizacion seleccionada
                //_entidad
                _entidad._entity_r27._TR27_TM39_ID = _entidad._entity_m39._TM39_ID;
                _entidad._entity_r27._TR27_TM19_ID = _entidad._entity_m39._entity_et_m19._TM19_ID;
                var result = _nt_r27.get_001(_entidad);
                _entidad._lista_et_m27 = result._lista_et_m27;
            }


            //__id_tm41 = _entity._entity_m41._TM41_ID;
            //Metodo_Obtener_conceptos_default();

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

        #endregion

        #region Eventos

        private void toolStreep_Agregar_servicio_complementario_Click(object sender, EventArgs e)
        {
            //Metodo_Obtener_conceptos_default();

            _nt_r28.set_002(_entidad);
        }

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

            string column_name = dgv_entrada_datos_mq_eq.Columns[0].Name; // nombre
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

            //dvg_entrada_datos_mq_eq.Rows.Add(_lista_m31._TM31_DESCRIP, _et_m31._TM31_ID);

            //string codigo = string.Format(_et_m31._TM31_ID);
            //string nombre = _et_m31._TM31_DESCRIP;
            //dgv_entrada_datos_mq_eq.Rows.Add("TV", "PRO03");  

            //int cont = _entidad._lista_et_m27.count;

            //DataGridViewRow fila = new DataGridViewRow();
            //fila.CreateCells(dgv_entrada_datos_mq_eq);
            //fila.Cells[0].Value = nom;
            //fila.Cells[1].Value = codigo;

            //dgv_entrada_datos_mq_eq.Rows.Add(fila);
        }


        private void dgv_entrada_datos_mq_eq_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string nombre = dgv_entrada_datos_mq_eq.Columns[e.ColumnIndex].Name;
            if (nombre=="nombre")
            {
                bool existe = _lista_m31.Any(item => item._TM31_DESCRIP == e.FormattedValue.ToString());
                if (existe)
                {
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

            string column_name = dgv_entrada_datos_mq_eq.Columns[0].Name; // nombre
            if (column_name.Equals("nombre"))
            {
                int cont =  _entidad._lista_et_m27.Count;
                int i;
                i = dgv_entrada_datos_mq_eq.CurrentRow.Index;
                dgv_entrada_datos_mq_eq.Rows[i].Cells[0].Value = nom;
                dgv_entrada_datos_mq_eq.Rows[i].Cells[1].Value = cod;
                dgv_entrada_datos_mq_eq.Rows[i].Cells[2].Value = marc;
                dgv_entrada_datos_mq_eq.Rows[i].Cells[3].Value = undad;
                dgv_entrada_datos_mq_eq.Rows[i].Cells[7+cont].Value = precio;

                if (tipo == "MQ")
                {
                    dgv_entrada_datos_mq_eq.Rows[i].Cells[4].Value = 1;

                }else if (tipo == "EQ")
                {
                    dgv_entrada_datos_mq_eq.Rows[i].Cells[5].Value = 1;
                }

            }
            //DataGridViewRow fila = new DataGridViewRow();
            //fila.CreateCells(dgv_entrada_datos_mq_eq);
            ////fila.Cells[0].Value = nom;
            //fila.Cells[1].Value = cod;
            //fila.Cells[2].Value = marc;
            //fila.Cells[3].Value = undad;

            //dgv_entrada_datos_mq_eq.Rows.Add(fila);
        }
    }
    }
