﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Win28ntug;
using Win28etug;

namespace SGAP.comercial
{
    public partial class frm_01_2_01 : Form
    {
        NT_helper _helper = new NT_helper();
        ET_entidad _et_entidad = new ET_entidad();
        NT_M40 _nt_m40 = new NT_M40();
        NT_M38 _nt_m38 = new NT_M38();
        NT_R29 _nt_r29 = new NT_R29();
        ET_R31 _et_r31 = new ET_R31();

        ET_R29 _et_r29 = new ET_R29();

        List<ET_R29> _lista_et_r29 = new List<ET_R29>();
        List<ET_M40> _lista_et_m40 = new List<ET_M40>();
        List<ET_M40> _lista_et_m40_back = new List<ET_M40>();

        int id_Servicio_hijo;

        private UserControls.GridTimeControl _COL_HORA_ENTRADA;
        private UserControls.GridTimeControl _COL_HORA_SALIDA;
        private UserControls.NumericUpDownColumn _COL_DIAS_POR_SEMANA;

        //Dictionary<int, List<ET_M40>> Mi_Grupo = new Dictionary<int, List<ET_M40>>();
        //_lista_et_m40 = _nt_m40.get_001()._lista_et_m40;
        //Dictionary<List<ET_R29>, List<ET_M40>> grupo = new Dictionary<List<ET_R29>, List<ET_M40>>();

        public frm_01_2_01(int __id_Servicio_hijo)
        {
            InitializeComponent();

            // style
            this.BackColor  = Color.FromArgb(221, 221, 221);

            label10.BackColor = Color.FromArgb(0, 134, 65);
            label10.ForeColor = Color.White;

            //end style

            id_Servicio_hijo = __id_Servicio_hijo;

            Crear_GridView_ManoDeObra();
            Crear_GridView_ConceptoRemunerativo();
        }

        void Crear_GridView_ManoDeObra()
        {
            _helper.Set_Style_to_DatagridView(dgv_entrada_datos_mano_de_obra);

            dgv_entrada_datos_mano_de_obra.AutoGenerateColumns = false;
            dgv_entrada_datos_mano_de_obra.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_entrada_datos_mano_de_obra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewColumn _COL_CARGO = new DataGridViewTextBoxColumn();
            _COL_CARGO.DataPropertyName = "_CARGO";
            _COL_CARGO.HeaderText = "Cargo";
            _COL_CARGO.Name = "_COL_CARGO";
            _COL_CARGO.Width = 140;
            _COL_CARGO.MinimumWidth = 140;
            _COL_CARGO.FillWeight = 140;


            _COL_HORA_ENTRADA = new UserControls.GridTimeControl();
            _COL_HORA_ENTRADA.Name = "_COL_HORA_ENTRADA";
            _COL_HORA_ENTRADA.HeaderText = "Hora Entrada";
            _COL_HORA_ENTRADA.Width = 70;
            _COL_HORA_ENTRADA.MinimumWidth = 70;
            _COL_HORA_ENTRADA.FillWeight = 70;

            _COL_HORA_SALIDA = new UserControls.GridTimeControl();
            _COL_HORA_SALIDA.Name = "_COL_HORA_SALIDA";
            _COL_HORA_SALIDA.HeaderText = "Hora Salida";
            _COL_HORA_SALIDA.Width = 65;
            _COL_HORA_SALIDA.MinimumWidth = 65;
            _COL_HORA_SALIDA.FillWeight = 65;

            _COL_DIAS_POR_SEMANA = new UserControls.NumericUpDownColumn();
            _COL_DIAS_POR_SEMANA.HeaderText = "Dias por Sem.";
            _COL_DIAS_POR_SEMANA.Name = "_COL_DIAS_POR_SEMANA";
            _COL_DIAS_POR_SEMANA.Width = 70;
            _COL_DIAS_POR_SEMANA.MinimumWidth = 70;
            _COL_DIAS_POR_SEMANA.FillWeight = 70;

            DataGridViewColumn _COL_REMUNERACION = new DataGridViewTextBoxColumn();
            _COL_REMUNERACION.DataPropertyName = "_COL_REMUNERACION";
            _COL_REMUNERACION.HeaderText = "Remuneración Básica";
            _COL_REMUNERACION.Name = "_COL_REMUNERACION";
            _COL_REMUNERACION.DefaultCellStyle.NullValue = "850.00";

            DataGridViewButtonColumn _COL_BTN_ADD_CONCEPTO_REMUNERATIVO = new DataGridViewButtonColumn();
            _COL_BTN_ADD_CONCEPTO_REMUNERATIVO.HeaderText = "....";
            _COL_BTN_ADD_CONCEPTO_REMUNERATIVO.Name = "_COL_BTN_ADD_CONCEPTO_REMUNERATIVO";
            _COL_BTN_ADD_CONCEPTO_REMUNERATIVO.Text = "Asignar Conceptos";
            _COL_BTN_ADD_CONCEPTO_REMUNERATIVO.UseColumnTextForButtonValue = true;

            dgv_entrada_datos_mano_de_obra.Columns.AddRange(new DataGridViewColumn[] {
                   _COL_CARGO,
                   _COL_HORA_ENTRADA,
                   _COL_HORA_SALIDA,
                   _COL_DIAS_POR_SEMANA,
                   _COL_REMUNERACION,
                   _COL_BTN_ADD_CONCEPTO_REMUNERATIVO
            });

        }
        void Crear_GridView_ConceptoRemunerativo()
        {
            _helper.Set_Style_to_DatagridView(dgv_conceptos_remunerativos);
            dgv_conceptos_remunerativos.AutoGenerateColumns = false;
            dgv_conceptos_remunerativos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_conceptos_remunerativos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewColumn _COL_CONCEPTO_SELECCIONADO = new DataGridViewCheckBoxColumn();
            _COL_CONCEPTO_SELECCIONADO.DataPropertyName = "_Seleccionado";
            _COL_CONCEPTO_SELECCIONADO.HeaderText = "Select";
            _COL_CONCEPTO_SELECCIONADO.Name = "_COL_CONCEPTO_SELECCIONADO";
            _COL_CONCEPTO_SELECCIONADO.Width = 50;
            _COL_CONCEPTO_SELECCIONADO.MinimumWidth = 50;
            _COL_CONCEPTO_SELECCIONADO.FillWeight = 100;
            _COL_CONCEPTO_SELECCIONADO.DefaultCellStyle.SelectionBackColor = Color.White;

            DataGridViewColumn _COL_ID_CONCEPTO_REMUNERATIVO = new DataGridViewTextBoxColumn();
            _COL_ID_CONCEPTO_REMUNERATIVO.DataPropertyName = "_TM40_ID";
            _COL_ID_CONCEPTO_REMUNERATIVO.HeaderText = "Id";
            _COL_ID_CONCEPTO_REMUNERATIVO.Name = "_COL_ID_CONCEPTO_REMUNERATIVO";
            _COL_ID_CONCEPTO_REMUNERATIVO.Visible = false;

            DataGridViewColumn _COL_CONCEPTO_REMUNERATIVO = new DataGridViewTextBoxColumn();
            _COL_CONCEPTO_REMUNERATIVO.DataPropertyName = "_TM40_DESCRIP";
            _COL_CONCEPTO_REMUNERATIVO.HeaderText = "Concepto Remunerativo";
            _COL_CONCEPTO_REMUNERATIVO.Name = "_COL_CONCEPTO_REMUNERATIVO";
            _COL_CONCEPTO_REMUNERATIVO.DefaultCellStyle.SelectionBackColor = Color.White;
            _COL_CONCEPTO_REMUNERATIVO.ReadOnly = true;
            _COL_CONCEPTO_REMUNERATIVO.Width = 600;
            _COL_CONCEPTO_REMUNERATIVO.MinimumWidth = 600;
            _COL_CONCEPTO_REMUNERATIVO.FillWeight = 600;

            dgv_conceptos_remunerativos.Columns.AddRange(new DataGridViewColumn[] {
                   _COL_CONCEPTO_SELECCIONADO,
                   _COL_ID_CONCEPTO_REMUNERATIVO,
                   _COL_CONCEPTO_REMUNERATIVO
            });
        }

        public void Analizar_informacion_ingresada()
        {

        }

        List<ET_M38> _lista_ = new List<ET_M38>();
        private void dgv_entrada_datos_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //tiene lugar cuando se clickea el contenido de una celda

            if (this.dgv_entrada_datos_mano_de_obra.CurrentCell.ColumnIndex == this.dgv_entrada_datos_mano_de_obra.Columns["_COL_CARGO"].Index)
            {
                TextBox auto_text_cargo =  e.Control as TextBox;

                auto_text_cargo.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_textKeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_textKeyPress);

                if (auto_text_cargo != null)
                {
                    auto_text_cargo.Width = 300;
                    auto_text_cargo.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto_text_cargo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    _lista_ = _nt_m38.TexBox_Cargo(auto_text_cargo)._lista_et_m38;
                }
            }

            if (this.dgv_entrada_datos_mano_de_obra.CurrentCell.ColumnIndex == this.dgv_entrada_datos_mano_de_obra.Columns["_COL_DIAS_POR_SEMANA"].Index)
            {
                NumericUpDown numeric = e.Control as NumericUpDown;
                if (numeric != null)
                {
                    numeric.Value = Convert.ToDecimal(e.Control.Text);
                    numeric.Maximum = 7;
                    numeric.Minimum = 1;
                }
            }
            if (this.dgv_entrada_datos_mano_de_obra.CurrentCell.ColumnIndex == this.dgv_entrada_datos_mano_de_obra.Columns["_COL_REMUNERACION"].Index)
            {
                TextBox text_box_Decimal =  e.Control as TextBox;
                text_box_Decimal.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_Decimal_KeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_Decimal_KeyPress);
            }

        }

        private void btn_continuar_Click(object sender, EventArgs e)
        {
            _et_entidad = new ET_entidad();
            _et_entidad._entity_r28._TR28_ID = id_Servicio_hijo;
            _et_entidad._lista_et_r29 = _lista_et_r29;
            _nt_r29.set_001(_et_entidad);
            // guardamos los cambios
            //Analizar_informacion_ingresada();
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }


        int Indice_grid_entrada_datos_mano_obra = 0;
        // Este evento valida lo que se ingresa en cada celda
        private void dgv_entrada_datos_mano_de_obra_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow)
            {
                Indice_grid_entrada_datos_mano_obra = e.RowIndex;

                for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                {
                    if (a != e.RowIndex)
                        dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;
                }

                String nombre_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name;
                String cabecra_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].HeaderText;
                //// evitamos validad el boton
                if (nombre_columna.Equals("_COL_BTN_ADD_CONCEPTO_REMUNERATIVO")) return;

                var msg = string.Format("El campo de nombre {0} esta vacio", cabecra_columna);

                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = msg;
                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSalmon;
                    e.Cancel = true;
                }
                else
                {
                    bool existe = _lista_et_r29.Any(item => item._Fila == e.RowIndex);
                    // sis existe actualizo la lista
                    if (existe)
                    {
                        ET_R29 _fila = _lista_et_r29.FirstOrDefault(cus => cus._Fila == e.RowIndex);

                        switch (nombre_columna)
                        {
                            case "_COL_CARGO":
                                _fila._TR29_DESCRIP = e.FormattedValue.ToString();
                                ET_M38 cargo = _lista_.FirstOrDefault(x => x._TM38_DESCRIP == _fila._TR29_DESCRIP);
                                if (cargo != null)
                                {
                                    _fila._TR29_TM38_ID = cargo._TM38_ID; //id_cargo
                                }
                                else
                                {
                                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = msg;
                                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSalmon;
                                    e.Cancel = true;
                                }
                                break;
                            case "_COL_HORA_ENTRADA":
                                _fila._TR29_HORA_ENTRADA = Convert.ToDateTime(e.FormattedValue.ToString());
                                break;
                            case "_COL_HORA_SALIDA":
                                _fila._TR29_HORA_SALIDA = Convert.ToDateTime(e.FormattedValue.ToString());
                                break;
                            case "_COL_DIAS_POR_SEMANA":
                                _fila._TR29_DIAS_SEMANA = Convert.ToInt32(e.FormattedValue.ToString());
                                break;
                            case "_COL_REMUNERACION":
                                _fila._TR29_REMUNERACION = Convert.ToDecimal(e.FormattedValue.ToString());
                                break;
                        }
                        _fila._TR29_TR28_ID = id_Servicio_hijo;
                    }
                    else
                    {
                        //es nuevo ingreso 
                        ET_R29 in_et_r29 = new ET_R29();
                        in_et_r29._Fila = e.RowIndex;
                        in_et_r29._TR29_TR28_ID = id_Servicio_hijo;
                        //in_et_r29._lista_et_m40 = _nt_m40.get_001()._lista_et_m40; 
                        switch (nombre_columna)
                        {
                            case "_COL_CARGO":
                                in_et_r29._TR29_DESCRIP = e.FormattedValue.ToString();

                                ET_M38 cargo = _lista_.FirstOrDefault(x => x._TM38_DESCRIP == e.FormattedValue.ToString());
                                if (cargo != null)
                                {
                                    in_et_r29._TR29_TM38_ID = cargo._TM38_ID;
                                }
                                else
                                {
                                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = msg;
                                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSalmon;
                                    e.Cancel = true;
                                }
                                break;
                            case "_COL_HORA_ENTRADA":
                                in_et_r29._TR29_HORA_ENTRADA = Convert.ToDateTime(e.FormattedValue.ToString());
                                break;
                            case "_COL_HORA_SALIDA":
                                in_et_r29._TR29_HORA_SALIDA = Convert.ToDateTime(e.FormattedValue.ToString());
                                break;
                            case "_COL_DIAS_POR_SEMANA":
                                in_et_r29._TR29_DIAS_SEMANA = Convert.ToInt32(e.FormattedValue.ToString());
                                break;
                            case "_COL_REMUNERACION":
                                in_et_r29._TR29_REMUNERACION = Convert.ToDecimal(e.FormattedValue.ToString());
                                break;
                        }
                        _lista_et_r29.Add(in_et_r29);
                    }
                }
            }
        }

        private void dgv_entrada_datos_mano_de_obra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = string.Empty;
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        private void dgv_entrada_datos_mano_de_obra_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["_COL_HORA_ENTRADA"].Value = _et_r29._TR29_HORA_ENTRADA;
            e.Row.Cells["_COL_HORA_SALIDA"].Value = _et_r29._TR29_HORA_SALIDA;
            e.Row.Cells["_COL_DIAS_POR_SEMANA"].Value = _et_r29._TR29_DIAS_SEMANA;
        }

        private void dgv_entrada_datos_mano_de_obra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                btn_cancelar_Click(null, null);
            }
            if (e.Control && e.KeyCode == Keys.G)
            {
                btn_continuar_Click(null, null);
            }
        }
        private void dgv_conceptos_remunerativos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                btn_cancelar_Click(null, null);
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                Procesar_conceptos_por_Cargo();
            }
        }


        private void dgv_entrada_datos_mano_de_obra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //DataGridView grid = (DataGridView)sender;
            //_helper.Set_border_toCell_selecction(grid, e);
        }

        private void dgv_conceptos_remunerativos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //DataGridView grid = (DataGridView)sender;
            //_helper.Set_border_toCell_selecction(grid, e);
        }
        

        void Procesar_conceptos_por_Cargo()
        {
            //me pocisiona en la grilla
            dgv_entrada_datos_mano_de_obra.Focus();
            dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[0, (Indice_grid_entrada_datos_mano_obra+1)];

            //me devuelve el color de la fila
            for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;

            groupBox2.BackColor = DefaultBackColor;


            ET_R29 et_r29_ = _lista_et_r29.FirstOrDefault(x => x._Fila == Indice_grid_entrada_datos_mano_obra);

            _lista_et_m40_back = new List<ET_M40>();
            _lista_et_m40_back = _lista_et_m40.Where(x => x._fila >= 0).ToList();

            et_r29_._lista_et_m40 = _lista_et_m40_back;


            // analizamos lo ingresado
            int[] respuesta = _nt_r29.Metodo_Analizar_filas_repetidas(_lista_et_r29);
            // 0 -> indice repetido
            // 1 -> devielve true: si se encontro ? fasle si no se encontro
            if (Convert.ToBoolean(respuesta[1]))
            {
                //posicionanos en la fila
                dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[1, Indice_grid_entrada_datos_mano_obra];
                // resaltar las lineas repetidas
                dgv_entrada_datos_mano_de_obra.Rows[respuesta[0]].DefaultCellStyle.BackColor = Color.Salmon;
                groupBox2.BackColor = Color.Salmon;
            }
            else
            {
                //devolver el color
                groupBox2.BackColor = DefaultBackColor;

                _lista_et_m40.Clear();

                dgv_conceptos_remunerativos.DataSource = null;
                dgv_conceptos_remunerativos.Update();
                dgv_conceptos_remunerativos.Refresh();

            }

        }
        //Cuando hacemos click en el boton de agregar conceptos
        private void dgv_entrada_datos_mano_de_obra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (!dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow)
                {
                    var mi_grid = (DataGridView)sender;
                    if (mi_grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                        {
                            if (a != e.RowIndex)
                                dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;
                        }
                        dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;

                        ET_R29 _et_r29_ = _lista_et_r29.FirstOrDefault(x => x._Fila == e.RowIndex);

                        if (_et_r29_._lista_et_m40.Count != 0)
                            _lista_et_m40 = _et_r29_._lista_et_m40;
                        else
                            _lista_et_m40 = _nt_m40.get_001()._lista_et_m40;

                        groupBox2.BackColor = Color.LightSkyBlue;

                        dgv_conceptos_remunerativos.Focus();
                        dgv_conceptos_remunerativos.DataSource = null;
                        dgv_conceptos_remunerativos.Update();
                        dgv_conceptos_remunerativos.Refresh();
                        dgv_conceptos_remunerativos.DataSource = _lista_et_m40;

                    }
                }
            }

        }


        private void dgv_conceptos_remunerativos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // validaremos la entrada de datos desde aqui

        }

        private void dgv_conceptos_remunerativos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            String nombre_columna = dgv_conceptos_remunerativos.Columns[e.ColumnIndex].Name;
            String cabecra_columna = dgv_conceptos_remunerativos.Columns[e.ColumnIndex].HeaderText;
            //// evitamos validad el boton
            if (nombre_columna.Equals("_COL_CONCEPTO_REMUNERATIVO")) return;

            if (string.IsNullOrEmpty(e.ToString())) //tiene que ser solo la columna checkbox
            {

            }
        }


        private void dgv_entrada_datos_mano_de_obra_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv_conceptos_remunerativos.DataSource = null;
            dgv_conceptos_remunerativos.Update();
            dgv_conceptos_remunerativos.Refresh();
        }


        // boton de prueba
        private void button1_Click(object sender, EventArgs e)
        {
            Procesar_conceptos_por_Cargo();
        }
    }
}
