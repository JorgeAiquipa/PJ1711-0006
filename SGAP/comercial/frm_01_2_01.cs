using System;
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

        List<ET_M40> _lista_et_m40 = new List<ET_M40>();
        List<ET_R29> _lista_et_r29 = new List<ET_R29>();
        List<ET_R29> _lista_et_r29_los_eliminados = new List<ET_R29>();
        List<ET_M40> _lista_et_m40_back = new List<ET_M40>();
        List<ET_M40> _lista_et_m40_sin_Dependencia = new List<ET_M40>();
        List<ET_M38> _lista_Cargos = new List<ET_M38>();
        int id_Servicio_hijo;

        private UserControls.GridTimeControl _COL_HORA_ENTRADA;
        private UserControls.GridTimeControl _COL_HORA_SALIDA;
        private UserControls.NumericUpDownColumn _COL_DIAS_POR_SEMANA;

        public frm_01_2_01(int __id_Servicio_hijo, List<ET_M40> conceptos_remunerativos)
        {
            InitializeComponent();

            // style
            this.BackColor = Color.FromArgb(221, 221, 221);

            label10.BackColor = Color.FromArgb(0, 137, 123);
            label10.ForeColor = Color.White;
            label10.Text = this.Text;

            panel_cargos.BackColor = Color.White;
            panel_conceptos_remuneratios.BackColor = Color.White;
            //end style

            _lista_et_m40_sin_Dependencia = conceptos_remunerativos;

            id_Servicio_hijo = __id_Servicio_hijo;

            Crear_GridView_ManoDeObra();
            Crear_GridView_ConceptoRemunerativo();

            dgv_entrada_datos_mano_de_obra.Focus();
            dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[0, 0];
            btn_continuar.Enabled = false;
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
            _COL_CARGO.Width = 200;
            _COL_CARGO.MinimumWidth = 200;
            _COL_CARGO.FillWeight = 200;


            _COL_HORA_ENTRADA = new UserControls.GridTimeControl();
            _COL_HORA_ENTRADA.Name = "_COL_HORA_ENTRADA";
            _COL_HORA_ENTRADA.HeaderText = "Hora entrada";
            _COL_HORA_ENTRADA.Width = 75;
            _COL_HORA_ENTRADA.MinimumWidth = 75;
            _COL_HORA_ENTRADA.FillWeight = 75;

            _COL_HORA_SALIDA = new UserControls.GridTimeControl();
            _COL_HORA_SALIDA.Name = "_COL_HORA_SALIDA";
            _COL_HORA_SALIDA.HeaderText = "Hora salida";
            _COL_HORA_SALIDA.Width = 80;
            _COL_HORA_SALIDA.MinimumWidth = 80;
            _COL_HORA_SALIDA.FillWeight = 80;

            _COL_DIAS_POR_SEMANA = new UserControls.NumericUpDownColumn();
            _COL_DIAS_POR_SEMANA.HeaderText = "Dias por sem.";
            _COL_DIAS_POR_SEMANA.Name = "_COL_DIAS_POR_SEMANA";
            _COL_DIAS_POR_SEMANA.Width = 80;
            _COL_DIAS_POR_SEMANA.MinimumWidth = 80;
            _COL_DIAS_POR_SEMANA.FillWeight = 80;

            DataGridViewColumn _COL_REMUNERACION = new DataGridViewTextBoxColumn();
            _COL_REMUNERACION.DataPropertyName = "_COL_REMUNERACION";
            _COL_REMUNERACION.HeaderText = "Remuneración básica";
            _COL_REMUNERACION.Name = "_COL_REMUNERACION";
            _COL_REMUNERACION.DefaultCellStyle.NullValue = "850.00";

            DataGridViewButtonColumn _COL_DELETE_ROW = new DataGridViewButtonColumn();
            _COL_DELETE_ROW.HeaderText = string.Empty;
            _COL_DELETE_ROW.Name = "_COL_DELETE_ROW";

            dgv_entrada_datos_mano_de_obra.Columns.AddRange(new DataGridViewColumn[] {
                   _COL_CARGO,
                   _COL_HORA_ENTRADA,
                   _COL_HORA_SALIDA,
                   _COL_DIAS_POR_SEMANA,
                   _COL_REMUNERACION,
                   _COL_DELETE_ROW
            });

            // desplegamos la informacion
            TextBox bas_ = new TextBox();
            bas_.Text = string.Empty;
            _lista_Cargos = _nt_m38.TexBox_Cargo(bas_);

            ET_R29 _et = new ET_R29();
            _et._TR29_TR28_ID = id_Servicio_hijo; // captura el node
            _et._lista_et_m40 = _lista_et_m40_sin_Dependencia;
            _lista_et_r29 = _nt_r29.get_001(_et)._lista_et_r29;
            //_lista_et_r29_back = _lista_et_r29;
            if (_lista_et_r29.Count > 0)
            {

                _lista_et_r29.ForEach(fila_ => {

                    dgv_entrada_datos_mano_de_obra.Rows.Add(
                        fila_._TR29_DESCRIP,
                        fila_._TR29_HORA_ENTRADA,
                        fila_._TR29_HORA_SALIDA,
                        fila_._TR29_DIAS_SEMANA,
                        fila_._TR29_REMUNERACION
                        );
                });
            }

        }
        void Crear_GridView_ConceptoRemunerativo()
        {
            dgv_conceptos_remunerativos.AllowUserToAddRows = false;
            _helper.Set_Style_to_DatagridView(dgv_conceptos_remunerativos);
            dgv_conceptos_remunerativos.AutoGenerateColumns = false;
            dgv_conceptos_remunerativos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_conceptos_remunerativos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewColumn _COL_CONCEPTO_SELECCIONADO = new DataGridViewCheckBoxColumn();
            _COL_CONCEPTO_SELECCIONADO.DataPropertyName = "_Seleccionado";
            _COL_CONCEPTO_SELECCIONADO.HeaderText = "";
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
            _COL_CONCEPTO_REMUNERATIVO.HeaderText = "Concepto remunerativo";
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

        
        private void dgv_entrada_datos_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //tiene lugar cuando se clickea el contenido de una celda

            if (this.dgv_entrada_datos_mano_de_obra.CurrentCell.ColumnIndex == this.dgv_entrada_datos_mano_de_obra.Columns["_COL_CARGO"].Index)
            {
                TextBox auto_text_cargo =  e.Control as TextBox;

                auto_text_cargo.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_textKeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_textKeyPress);
                if (string.IsNullOrEmpty(auto_text_cargo.Text))
                    auto_text_cargo.Text = string.Empty;
                //if (auto_text_cargo != null)
                //{
                    auto_text_cargo.Width = 300;
                    auto_text_cargo.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto_text_cargo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    _nt_m38.TexBox_Cargo(auto_text_cargo);
                //}
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

            if(_lista_et_r29.Count > 1)
                Analizar_registros_repetido();

        }

        private void btn_continuar_Click(object sender, EventArgs e)
        {
            if (_continuar)
            {
                //_et_entidad = new ET_entidad();
                //_et_entidad._entity_r28._TR28_ID = id_Servicio_hijo;
                //_et_entidad._lista_et_r29 = _lista_et_r29;

                _nt_r29.set_001(_lista_et_r29, _lista_et_r29_los_eliminados);
                // guardamos los cambios
                //Analizar_informacion_ingresada();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }


        int Indice_fila_grid_entrada_datos_mano_obra = 0;
        int Indice_columna_grid_entrada_datos_mano_obra = 0;
        // Este evento valida lo que se ingresa en cada celda
        private void dgv_entrada_datos_mano_de_obra_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            #region entrada_datos
            if (!dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow)
            {
              
                for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                {
                    if (a != e.RowIndex)
                        dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;
                }

                String nombre_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name;
                String cabecra_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].HeaderText;
                //// evitamos validad el boton
                if (nombre_columna.Equals("_COL_DELETE_ROW")) return;

                var msg = string.Format("El campo de nombre {0} esta vacio", cabecra_columna);

                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = msg;
                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSalmon;
                    e.Cancel = true;
                }
                else
                {
                    Indice_fila_grid_entrada_datos_mano_obra = e.RowIndex;

                    bool existe = _lista_et_r29.Any(item => item._Fila == e.RowIndex);
                    // sis existe actualizo la lista
                    if (existe)
                    {
                        ET_R29 _fila = _lista_et_r29.FirstOrDefault(cus => cus._Fila == e.RowIndex);

                        switch (nombre_columna)
                        {
                            case "_COL_CARGO":
                                _fila._TR29_DESCRIP = e.FormattedValue.ToString();
                                ET_M38 cargo = _lista_Cargos.FirstOrDefault(x => x._TM38_DESCRIP == _fila._TR29_DESCRIP);
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
                                 DateTime hora_e_no_Fecha = new DateTime(1900, 1, 1, Convert.ToDateTime(e.FormattedValue.ToString()).Hour, Convert.ToDateTime(e.FormattedValue.ToString()).Minute, Convert.ToDateTime(e.FormattedValue.ToString()).Second);
                                _fila._TR29_HORA_ENTRADA = hora_e_no_Fecha;// Convert.ToDateTime(e.FormattedValue.ToString());
                                break;
                            case "_COL_HORA_SALIDA":
                                 DateTime hora_s_no_Fecha = new DateTime(1900, 1, 1, Convert.ToDateTime(e.FormattedValue.ToString()).Hour, Convert.ToDateTime(e.FormattedValue.ToString()).Minute, Convert.ToDateTime(e.FormattedValue.ToString()).Second);
                                _fila._TR29_HORA_SALIDA = hora_s_no_Fecha;// Convert.ToDateTime(e.FormattedValue.ToString());
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
                        in_et_r29._TR29_ST = 0;
                        in_et_r29._TR29_FLG_ELIMINADO = 0;
                        in_et_r29._TR29_TR28_ID = id_Servicio_hijo;
                        //in_et_r29._lista_et_m40 = _nt_m40.get_001()._lista_et_m40; 
                        switch (nombre_columna)
                        {
                            case "_COL_CARGO":
                                in_et_r29._TR29_DESCRIP = e.FormattedValue.ToString();

                                ET_M38 cargo = _lista_Cargos.FirstOrDefault(x => x._TM38_DESCRIP == e.FormattedValue.ToString());
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
                                DateTime hora_e_no_Fecha = new DateTime(1900, 1, 1, Convert.ToDateTime(e.FormattedValue.ToString()).Hour, Convert.ToDateTime(e.FormattedValue.ToString()).Minute, Convert.ToDateTime(e.FormattedValue.ToString()).Second);
                                in_et_r29._TR29_HORA_ENTRADA = hora_e_no_Fecha;// Convert.ToDateTime(e.FormattedValue.ToString());
                                break;
                            case "_COL_HORA_SALIDA":
                                DateTime hora_s_no_Fecha = new DateTime(1900, 1, 1, Convert.ToDateTime(e.FormattedValue.ToString()).Hour, Convert.ToDateTime(e.FormattedValue.ToString()).Minute, Convert.ToDateTime(e.FormattedValue.ToString()).Second);
                                in_et_r29._TR29_HORA_SALIDA = hora_s_no_Fecha;// Convert.ToDateTime(e.FormattedValue.ToString());
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
            #endregion
        }

        private void dgv_entrada_datos_mano_de_obra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = string.Empty;
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

            SendKeys.Send("{TAB}");
            Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;

            //_lista_et_r29 -> asignar beneficios sin seleccion false
            if (!dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow && e.RowIndex > -1)
            {
                ET_R29 _et_r29_ = _lista_et_r29.FirstOrDefault(x => x._Fila == e.RowIndex);

                for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                {
                    if (a != e.RowIndex)
                        dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;
                }
                dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;

                if (_et_r29_._lista_et_m40.Count != 0)
                    _lista_et_m40 = _et_r29_._lista_et_m40;
                else
                    _lista_et_m40 = _nt_m40.get_001()._lista_et_m40;

                _lista_et_m40_back = new List<ET_M40>();
                _lista_et_m40_back = _lista_et_m40.Where(x => x._fila >= 0).ToList();

                _et_r29_._lista_et_m40 = _lista_et_m40_back;


                panel_conceptos_remuneratios.BackColor = Color.LightSkyBlue;

                //dgv_conceptos_remunerativos.Focus();
                dgv_conceptos_remunerativos.DataSource = null;
                dgv_conceptos_remunerativos.Update();
                dgv_conceptos_remunerativos.Refresh();
                dgv_conceptos_remunerativos.DataSource = _lista_et_m40;
            }
            if (_lista_et_r29.Count > 1)
                Analizar_registros_repetido();

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
                btn_cancelar_Click(null, null);

            if (e.Control && e.KeyCode == Keys.G)
                btn_continuar_Click(null, null);

            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                int A = Indice_fila_grid_entrada_datos_mano_obra;
                dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[Indice_columna_grid_entrada_datos_mano_obra, A];
                //SendKeys.Send("{RIGHT}");
            }

            if (e.KeyData == Keys.Tab)
            {
                e.Handled = true;
                //int A = Indice_fila_grid_entrada_datos_mano_obra;
                //dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[Indice_columna_grid_entrada_datos_mano_obra, A];
                //dgv_entrada_datos_mano_de_obra.Rows[A].Selected = true;
                SendKeys.Send("{ENTER}");
            }
            if (e.KeyData == Keys.Right)
            {
                //cuando llegue a la ultima columna
                int LastColumn = 5;
                if (Indice_columna_grid_entrada_datos_mano_obra == LastColumn)
                {
                    //focus al grid conceptos
                    dgv_conceptos_remunerativos.Focus();
                    e.Handled = true;
                }
            }
        }

        private void dgv_conceptos_remunerativos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                btn_cancelar_Click(null, null);
            }
            if (e.KeyData == Keys.Tab)
            {
                //int LastRow = dgv_conceptos_remunerativos.RowCount;
                //// si estamos en la ultima fila y ultima columna 
                ////pasamos al grid 1 focus en nueva row
                //if ((dgv_conceptos_remunerativos.CurrentRow.Index == (LastRow - 1)))
                //{
                e.Handled = true;
                dgv_entrada_datos_mano_de_obra.Focus();

                int LastRow_g1 = dgv_entrada_datos_mano_de_obra.RowCount - 1;
                dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[0, LastRow_g1];
                //}
            }
        }



        bool _continuar = false;
        bool Analizar_registros_repetido()
        {
            // analizamos lo ingresado
            int[] respuesta = _nt_r29.Metodo_Analizar_filas_repetidas(_lista_et_r29);
            // 0 -> indice repetido
            // 1 -> devielve true: si se encontro ? fasle si no se encontro
            if (Convert.ToBoolean(respuesta[1]))
            {
                try
                {
                    for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                    {
                        dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                    dgv_entrada_datos_mano_de_obra.Rows[respuesta[0]].DefaultCellStyle.BackColor = Color.Khaki;
                    dgv_entrada_datos_mano_de_obra.Rows[Indice_fila_grid_entrada_datos_mano_obra].DefaultCellStyle.BackColor = Color.DarkSalmon;

                    panel_cargos.BackColor = Color.DarkSalmon;
                    dgv_entrada_datos_mano_de_obra.AllowUserToAddRows = false;
                    _continuar = false;
                    btn_continuar.Enabled = false;
                }
                catch (Exception ex) { }
                return false;
            }
            else
            {
                panel_cargos.BackColor = Color.White;
                try
                {
                    dgv_entrada_datos_mano_de_obra.AllowUserToAddRows = true;
                }
                catch { }
                _lista_et_m40.Clear();
                dgv_conceptos_remunerativos.DataSource = null;
                dgv_conceptos_remunerativos.Update();
                dgv_conceptos_remunerativos.Refresh();

                _continuar = true;
                btn_continuar.Enabled = true;

                return true;

            }
        }
        private void dgv_entrada_datos_mano_de_obra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_entrada_datos_mano_de_obra_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _lista_et_m40.Clear();
            dgv_conceptos_remunerativos.DataSource = null;
            dgv_conceptos_remunerativos.Update();
            dgv_conceptos_remunerativos.Refresh();
        }

        private void dgv_entrada_datos_mano_de_obra_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_entrada_datos_mano_de_obra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //mostrar los conceptos remunerativo de la fila que es la nueva posocion
            if (!dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow)
            {
                ET_R29 _et_r29_ = _lista_et_r29.FirstOrDefault(x => x._Fila == e.RowIndex);
                if (_lista_et_r29.Count > 0 && _et_r29_ != null)
                {
                    if (e.RowIndex > -1)
                    {

                        if (Analizar_registros_repetido())
                        {
                            for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                            {
                                if (a != e.RowIndex)
                                    dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;
                            }
                            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;

                            if (_et_r29_._lista_et_m40.Count != 0)
                                _lista_et_m40 = _et_r29_._lista_et_m40;
                            else
                                _lista_et_m40 = _nt_m40.get_001()._lista_et_m40;

                            _lista_et_m40_back = new List<ET_M40>();
                            _lista_et_m40_back = _lista_et_m40.Where(x => x._fila >= 0).ToList();

                            _et_r29_._lista_et_m40 = _lista_et_m40_back;


                            panel_conceptos_remuneratios.BackColor = Color.LightSkyBlue;

                            dgv_conceptos_remunerativos.DataSource = null;
                            dgv_conceptos_remunerativos.Update();
                            dgv_conceptos_remunerativos.Refresh();
                            dgv_conceptos_remunerativos.DataSource = _lista_et_m40;
                        }
                    }
                    else
                    {
                        panel_conceptos_remuneratios.BackColor = Color.White;

                        _lista_et_m40.Clear();

                        dgv_conceptos_remunerativos.DataSource = null;
                        dgv_conceptos_remunerativos.Update();
                        dgv_conceptos_remunerativos.Refresh();

                    }
                }
            }
            else
            {

                for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                {
                    dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;
                }

                panel_conceptos_remuneratios.BackColor = Color.White;

                _lista_et_m40.Clear();

                dgv_conceptos_remunerativos.DataSource = null;
                dgv_conceptos_remunerativos.Update();
                dgv_conceptos_remunerativos.Refresh();

            }

        }

        private void dgv_entrada_datos_mano_de_obra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name == "_COL_DELETE_ROW" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].Cells["_COL_DELETE_ROW"] as DataGridViewButtonCell;
                Image delete_image = Properties.Resources.borrar;

                e.Graphics.DrawImage(delete_image, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].Height = delete_image.Height + 7;
                dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Width = delete_image.Width + 7;

                e.Handled = true;
            }
        }

        private void dgv_entrada_datos_mano_de_obra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // eliminamos la fila actual de la vista y del databinding
            if (e.RowIndex > -1 && !dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow )
            {
                Indice_fila_grid_entrada_datos_mano_obra = e.RowIndex;
                Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;

                if (dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name == "_COL_DELETE_ROW")
                {

                    ET_R29 edit_entity = _lista_et_r29.FirstOrDefault(row => row._Fila == e.RowIndex);
                    edit_entity._TR29_FLG_ELIMINADO = 1;
                    _lista_et_r29_los_eliminados.Add(edit_entity);

                    dgv_entrada_datos_mano_de_obra.Rows.RemoveAt(dgv_entrada_datos_mano_de_obra.CurrentRow.Index);

                    List<ET_R29> _clon = new List<ET_R29>();

                    int fila = 0;
                    foreach (ET_R29 row in _lista_et_r29)
                    {
                        if (row._TR29_FLG_ELIMINADO != 1)
                        {
                            ET_R29 e_ = new ET_R29();
                            e_._Fila = fila;
                            e_._TR29_ID = row._TR29_ID;
                            e_._TR29_TR28_ID = row._TR29_TR28_ID;
                            e_._TR29_TM38_ID = row._TR29_TM38_ID;
                            e_._TR29_HORA_ENTRADA = row._TR29_HORA_ENTRADA;
                            e_._TR29_HORA_SALIDA = row._TR29_HORA_SALIDA;
                            e_._TR29_DIAS_SEMANA = row._TR29_DIAS_SEMANA;
                            e_._TR29_DESCRIP = row._TR29_DESCRIP;
                            e_._TR29_ST = row._TR29_ST;
                            e_._TR29_FLG_ELIMINADO = row._TR29_FLG_ELIMINADO;
                            e_._TR29_UCREA = row._TR29_UCREA;
                            e_._TR29_FCREA = row._TR29_FCREA;
                            e_._TR29_UACTUALIZA = row._TR29_UACTUALIZA;
                            e_._TR29_FACTUALIZA = row._TR29_FACTUALIZA;
                            e_._TR29_REMUNERACION = row._TR29_REMUNERACION;
                            e_._TR29_TM2_ID = row._TR29_TM2_ID;
                            e_._lista_et_m40 = row._lista_et_m40;
                            e_._lista_et_r30 = row._lista_et_r30;

                            _clon.Add(e_);
                            fila++;
                        }
                    }
                    _lista_et_r29.Clear();
                    _lista_et_r29 = _clon;

                    dgv_entrada_datos_mano_de_obra.Update();


                    panel_conceptos_remuneratios.BackColor = Color.White;

                    _lista_et_m40.Clear();

                    dgv_conceptos_remunerativos.DataSource = null;
                    dgv_conceptos_remunerativos.Update();
                    dgv_conceptos_remunerativos.Refresh();

                    try
                    {
                        dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[0, e.RowIndex];
                        dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].Selected = true;
                    }
                    catch (Exception) { }
                }
            }

        }

        private void dgv_entrada_datos_mano_de_obra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;
            dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[Indice_columna_grid_entrada_datos_mano_obra, e.RowIndex];
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].Selected = true;
        }

        private void dgv_entrada_datos_mano_de_obra_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;
        }
    }
}
