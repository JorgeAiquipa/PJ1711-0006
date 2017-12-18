﻿using System;
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

        #region Mano de obra


        #endregion

            }


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
                dataGridView1.Columns.Insert(6, Column);
                index++;
            }



            ////int cantd =_entidad._lista_et_m27.Count;
            //try
            //{
            //        //int index = 1;

            //        listView_materiales_equipos.Columns.Add("Nombre", 200, HorizontalAlignment.Left);
            //        listView_materiales_equipos.Columns.Add("Codigo", 100, HorizontalAlignment.Left);
            //        listView_materiales_equipos.Columns.Add("Marca", 60, HorizontalAlignment.Left);
            //        listView_materiales_equipos.Columns.Add("Und", -2, HorizontalAlignment.Left);
            //        listView_materiales_equipos.Columns.Add("Maquinaria", -2, HorizontalAlignment.Left);
            //        listView_materiales_equipos.Columns.Add("Equipos", -2, HorizontalAlignment.Left);

            //        foreach (ET_M27 fila in _entidad._lista_et_m27)
            //        {
            //            listView_materiales_equipos.Columns.Add(string.Format("{0}", fila._TM27_NOMBRE), -2, HorizontalAlignment.Left);
            //            index++;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //    listView_materiales_equipos.Columns.Add("Cantidad Total", -2, HorizontalAlignment.Left);
            //    listView_materiales_equipos.Columns.Add("Costo Unitario", -2, HorizontalAlignment.Left);
            //    listView_materiales_equipos.Columns.Add("Costo Total", -2, HorizontalAlignment.Left);



        }
        #endregion

        }
    }
