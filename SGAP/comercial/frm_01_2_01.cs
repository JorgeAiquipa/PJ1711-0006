﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Win28ntug;
using Win28etug;
using System.Reflection;

namespace SGAP.comercial
{
    /*
     •	Si un trabajador tiene un turno de menos de 4 horas, no se le considerará Asignación Familiar.
   
    */

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
            BackColor = Color.FromArgb(221, 221, 221);
            label10.BackColor = Color.FromArgb(0, 137, 123);
            label10.ForeColor = Color.White;
            label10.Text = Text;
            panel_cargos.BackColor = Color.White;
            panel_conceptos_remuneratios.BackColor = Color.White;
            //end style
            _lista_et_m40_sin_Dependencia = conceptos_remunerativos;
            id_Servicio_hijo = __id_Servicio_hijo;
            Construir_GridView_ManoDeObra();
            Construir_GridView_ConceptoRemunerativo();
            dgv_entrada_datos_mano_de_obra.Focus();
            dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[0, 0];
            btn_continuar.Enabled = false;
        }

        void Construir_GridView_ManoDeObra()
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
            _COL_DIAS_POR_SEMANA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
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

            TextBox bas_ = new TextBox();
            bas_.Text = string.Empty;
            _lista_Cargos = _nt_m38.TexBox_Cargo(bas_);

            ET_R29 _et = new ET_R29();
            _et._TR29_TR28_ID = id_Servicio_hijo; 
            _et._lista_et_m40 = _lista_et_m40_sin_Dependencia;
            _lista_et_r29 = _nt_r29.get_001(_et)._lista_et_r29;
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

            for (int i = 0; i < dgv_entrada_datos_mano_de_obra.Columns.Count; i++)
                dgv_entrada_datos_mano_de_obra.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
        void Construir_GridView_ConceptoRemunerativo()
        {
            dgv_conceptos_remunerativos.DataSource = null;
            dgv_conceptos_remunerativos.Update();
            dgv_conceptos_remunerativos.Refresh();

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
            _COL_CONCEPTO_SELECCIONADO.FillWeight = 50;
            //_COL_CONCEPTO_SELECCIONADO.DefaultCellStyle.SelectionBackColor = Color.White;

            DataGridViewColumn _COL_ID_CONCEPTO_REMUNERATIVO = new DataGridViewTextBoxColumn();
            _COL_ID_CONCEPTO_REMUNERATIVO.DataPropertyName = "_TM40_ID";
            _COL_ID_CONCEPTO_REMUNERATIVO.HeaderText = "Id";
            _COL_ID_CONCEPTO_REMUNERATIVO.Name = "_COL_ID_CONCEPTO_REMUNERATIVO";
            _COL_ID_CONCEPTO_REMUNERATIVO.Visible = false;

            DataGridViewColumn _COL_CONCEPTO_REMUNERATIVO = new DataGridViewTextBoxColumn();
            _COL_CONCEPTO_REMUNERATIVO.DataPropertyName = "_TM40_DESCRIP";
            _COL_CONCEPTO_REMUNERATIVO.HeaderText = "Concepto remunerativo";
            _COL_CONCEPTO_REMUNERATIVO.Name = "_COL_CONCEPTO_REMUNERATIVO";
            //_COL_CONCEPTO_REMUNERATIVO.DefaultCellStyle.SelectionBackColor = Color.White;
            _COL_CONCEPTO_REMUNERATIVO.ReadOnly = true;
            _COL_CONCEPTO_REMUNERATIVO.Width = 400;
            _COL_CONCEPTO_REMUNERATIVO.MinimumWidth = 400;
            _COL_CONCEPTO_REMUNERATIVO.FillWeight = 400;

            DataGridViewColumn _COL_AFECTO = new DataGridViewCheckBoxColumn();
            _COL_AFECTO.DataPropertyName = "_TR40_AFECTO";
            _COL_AFECTO.HeaderText = "Es Afecto";
            _COL_AFECTO.Name = "_COL_AFECTO";
            _COL_AFECTO.Width = 90;
            _COL_AFECTO.MinimumWidth = 90;
            _COL_AFECTO.FillWeight = 90;

            DataGridViewColumn _COL_IMPORTE = new DataGridViewTextBoxColumn();
            _COL_IMPORTE.DataPropertyName = "_TM40_IMPORTE";
            _COL_IMPORTE.HeaderText = "Importe";
            _COL_IMPORTE.Name = "_COL_IMPORTE";
            _COL_IMPORTE.Width = 100;
            _COL_IMPORTE.MinimumWidth = 100;
            _COL_IMPORTE.FillWeight = 100;

            DataGridViewColumn _COL_PORCENTAJE = new DataGridViewTextBoxColumn();
            _COL_PORCENTAJE.DataPropertyName = "_TM40_PORCENTAJE";
            _COL_PORCENTAJE.HeaderText = "Porcentaje %";
            _COL_PORCENTAJE.Name = "_COL_VALOR_NO_AFECTO";
            _COL_PORCENTAJE.Width = 100;
            _COL_PORCENTAJE.MinimumWidth = 100;
            _COL_PORCENTAJE.FillWeight = 100;

            dgv_conceptos_remunerativos.Columns.AddRange(new DataGridViewColumn[] {
                   _COL_CONCEPTO_SELECCIONADO,
                   _COL_ID_CONCEPTO_REMUNERATIVO,
                   _COL_CONCEPTO_REMUNERATIVO,
                   _COL_AFECTO,
                   _COL_IMPORTE,
                   _COL_PORCENTAJE
            });
        }

        //Definimos que mostrará cada celda de dgv_entrada_datos_mano_de_obra
        private void dgv_entrada_datos_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_entrada_datos_mano_de_obra.CurrentCell.ColumnIndex == dgv_entrada_datos_mano_de_obra.Columns["_COL_CARGO"].Index)
            {
                TextBox auto_text_cargo =  e.Control as TextBox;

                auto_text_cargo.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_textKeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_textKeyPress);
                if (string.IsNullOrEmpty(auto_text_cargo.Text))
                    auto_text_cargo.Text = string.Empty;
                    auto_text_cargo.Width = 300;
                    auto_text_cargo.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto_text_cargo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    _nt_m38.TexBox_Cargo(auto_text_cargo);
            }

            if (dgv_entrada_datos_mano_de_obra.CurrentCell.ColumnIndex == dgv_entrada_datos_mano_de_obra.Columns["_COL_DIAS_POR_SEMANA"].Index)
            {
                NumericUpDown numeric = e.Control as NumericUpDown;
                if (numeric != null)
                {
                    numeric.Value = Convert.ToDecimal(e.Control.Text);
                    numeric.Maximum = 7;
                    numeric.Minimum = 1;
                    numeric.TextAlign = HorizontalAlignment.Center;
                }
            }
            if (dgv_entrada_datos_mano_de_obra.CurrentCell.ColumnIndex == dgv_entrada_datos_mano_de_obra.Columns["_COL_REMUNERACION"].Index)
            {
                TextBox text_box_Decimal =  e.Control as TextBox;
                text_box_Decimal.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_Decimal_KeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(_helper.dataGridViewTextBox_Decimal_KeyPress);
            }

            if (_lista_et_r29.Count > 1)
            {
                Analizar_registros_repetido();
            }
        }
        private void btn_continuar_Click(object sender, EventArgs e)
        {
            if (_continuar)
            {
                if (InputBox() == DialogResult.OK)
                {
                    _nt_r29.set_001(_lista_et_r29, _lista_et_r29_los_eliminados);
                    DialogResult = DialogResult.OK;
                }
                //DialogResult decision_msg = MessageBox.Show("Los cambios realizados pueden afectar al calculo del costo de mano de obra. \n¿Esta seguro de guardar los cambios?", "Cotizador", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //if (decision_msg == DialogResult.OK)
                //{
                //    _nt_r29.set_001(_lista_et_r29, _lista_et_r29_los_eliminados);
                //    DialogResult = DialogResult.OK;
                //}
            }
        }

        public static DialogResult InputBox()
        {
            Form form = new Form();
            Label label = new Label();

            Panel gris = new Panel();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = "Cotizador";
            label.Text = "Los cambios realizados pueden afectar al calculo del costo de mano de obra. \n¿Esta seguro de guardar los cambios?";

            buttonOk.Text = "Guardar";
            buttonCancel.Text = "Cancelar";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(19, 20, 372, 13);
            gris.SetBounds(0, 65, 372, 50);
            buttonOk.SetBounds(200, 10, 75, 23);
            buttonCancel.SetBounds(285, 10, 75, 23);

            label.AutoSize = true;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(335, 107);
            form.Controls.AddRange(new Control[] { label, gris });
            gris.Controls.AddRange(new Control[] { buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(250, label.Right + 10), form.ClientSize.Height);
            gris.ClientSize = new Size(Math.Max(250, label.Right + 10), gris.ClientSize.Height);
            buttonOk.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            buttonCancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.BackColor = Color.White;
            gris.BackColor = Color.FromArgb(245, 245, 245);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        int Indice_fila_grid_entrada_datos_mano_obra = 0;
        int Indice_columna_grid_entrada_datos_mano_obra = 0;
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
                string nombre_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name;
                string cabecra_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].HeaderText;
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
                                //if(e.FormattedValue.ToString().Contains('.'))
                                //    in_et_r29._TR29_REMUNERACION = Convert.ToDecimal(e.FormattedValue.ToString());
                                //else
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

            DataGridView grid_view = (DataGridView)sender;

            if (!string.IsNullOrEmpty(grid_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                if (e.ColumnIndex == 4)// remuneracion basica
                {
                    if (!grid_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains('.'))
                        dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].Cells[e.ColumnIndex].Value= string.Format("{0}.00", grid_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);       
                }

                //PARA CALCULAR LA REMUNERACION BASICA CUANDO SEA MENOR A 8 HORAS 
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    DateTime HORA_ENTRADA  = new DateTime(1900, 1, 1, hour:
                        Convert.ToDateTime(grid_view.Rows[e.RowIndex].Cells[1].Value.ToString()).Hour
                        , minute:
                        Convert.ToDateTime(grid_view.Rows[e.RowIndex].Cells[1].Value.ToString()).Minute, second:
                        Convert.ToDateTime(grid_view.Rows[e.RowIndex].Cells[1].Value.ToString()).Second
                        );
                    DateTime HORA_SALIDA = new DateTime(1900, 1, 1, hour:
                        Convert.ToDateTime(grid_view.Rows[e.RowIndex].Cells[2].Value.ToString()).Hour
                        , minute:
                        Convert.ToDateTime(grid_view.Rows[e.RowIndex].Cells[2].Value.ToString()).Minute, second:
                        Convert.ToDateTime(grid_view.Rows[e.RowIndex].Cells[2].Value.ToString()).Second
                        );

                    int HORAS = (HORA_SALIDA - HORA_ENTRADA).Hours;
                    if (HORAS <= 8)
                    {
                        // OBTENEMOS EL MINIMO VITAL -- 850.00
                        decimal minimo_vital = 850.00M;
                        decimal remuneracion_calculo = minimo_vital / HORAS;
                        dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].Cells[4].Value = string.Format("{0}", remuneracion_calculo);
                    }
                }

            }



            Indice_fila_grid_entrada_datos_mano_obra = e.RowIndex;
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = string.Empty;
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

            Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;

            if (!dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow && e.RowIndex > -1)
            {
                ET_R29 _et_r29_ = _lista_et_r29.FirstOrDefault(x => x._Fila == e.RowIndex);

                for (int a = 0; a < dgv_entrada_datos_mano_de_obra.Rows.Count; a++)
                {
                    if (a != e.RowIndex)
                        dgv_entrada_datos_mano_de_obra.Rows[a].DefaultCellStyle.BackColor = Color.White;
                }
                //dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;

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
            if (_lista_et_r29.Count > 1)
            {
                Analizar_registros_repetido();
                this.dgv_entrada_datos_mano_de_obra.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgv_entrada_datos_mano_de_obra_CellPainting);

            }


        }

        private void dgv_entrada_datos_mano_de_obra_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["_COL_HORA_ENTRADA"].Value = _et_r29._TR29_HORA_ENTRADA;
            e.Row.Cells["_COL_HORA_SALIDA"].Value = _et_r29._TR29_HORA_SALIDA;
            e.Row.Cells["_COL_DIAS_POR_SEMANA"].Value = _et_r29._TR29_DIAS_SEMANA;
        }
        int COLUMN_SELECTED = 0;
        private void dgv_entrada_datos_mano_de_obra_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewCell celda_activa = dgv_entrada_datos_mano_de_obra.CurrentCell;

            if ((dgv_entrada_datos_mano_de_obra.ColumnCount - 2) == celda_activa.ColumnIndex)
            {
                // pasar a la tabla de conceptos remunerativos
                if (e.KeyData == Keys.Tab || e.KeyData == Keys.Right)
                {
                    dgv_entrada_datos_mano_de_obra.Update();
                    dgv_entrada_datos_mano_de_obra.Refresh();
                    dgv_conceptos_remunerativos.Focus();
                    e.Handled = true;

                }
            }
        }

        private void dgv_conceptos_remunerativos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.Handled = true;
                dgv_entrada_datos_mano_de_obra.Focus();

                int LastRow_g1 = dgv_entrada_datos_mano_de_obra.RowCount - 1;
                dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[0, LastRow_g1];
            }
        }

        bool _continuar = false;
        int Indice_fila_repetida = 0;
        int Indice_fila_que_repite = 0;
        bool _dibujar_repetidos = false;
        bool Analizar_registros_repetido()
        {
            int[] respuesta = _nt_r29.Metodo_Analizar_filas_repetidas(_lista_et_r29);
            // 0 -> indice repetido
            // 1 -> indice que repite
            // 2 -> devielve true: si se encontro ? fasle si no se encontro
            if (Convert.ToBoolean(respuesta[2]))
            {
                try
                {
                    Indice_fila_repetida = respuesta[0];
                    Indice_fila_que_repite = respuesta[1];
                    Indice_fila_grid_entrada_datos_mano_obra = Indice_fila_que_repite;
                    _dibujar_repetidos = true;
                    this.dgv_entrada_datos_mano_de_obra.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgv_entrada_datos_mano_de_obra_CellPainting);
                    panel_cargos.BackColor = Color.DarkSalmon;
                    dgv_entrada_datos_mano_de_obra.AllowUserToAddRows = false;
                    _continuar = false;
                    btn_continuar.Enabled = false;

                    dgv_entrada_datos_mano_de_obra.Update();
                    dgv_entrada_datos_mano_de_obra.Refresh();
                }
                catch{ }
                return false;
            }
            else
            {
                this.dgv_entrada_datos_mano_de_obra.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgv_entrada_datos_mano_de_obra_CellPainting);
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
        private void dgv_entrada_datos_mano_de_obra_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            _lista_et_m40.Clear();
            dgv_conceptos_remunerativos.DataSource = null;
            dgv_conceptos_remunerativos.Update();
            dgv_conceptos_remunerativos.Refresh();

            dgv_entrada_datos_mano_de_obra.Update();
            dgv_entrada_datos_mano_de_obra.Refresh();
        }

        private void dgv_entrada_datos_mano_de_obra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool _es_nueva_fila = false;
            int _e_row_index = e.RowIndex;
            if (dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow)
            {
                Indice_fila_grid_entrada_datos_mano_obra = e.RowIndex - 1;
                _es_nueva_fila = true;
            }
            Mostrar_conceptos_Remunerativos_fila_seleccionada(_es_nueva_fila, _e_row_index);
        }

        private void Mostrar_conceptos_Remunerativos_fila_seleccionada(bool _es_nueva_fila, int RowIndex)
        {
            if (!_es_nueva_fila)
            {
                ET_R29 _et_r29_ = _lista_et_r29.FirstOrDefault(x => x._Fila == RowIndex);
                if (_lista_et_r29.Count > 0 && _et_r29_ != null)
                {
                    if (RowIndex > -1)
                    {
                        if (Analizar_registros_repetido())
                        {
     
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

        //Aqui dibujamos el boton de eliminar fila par dgv_entrada_datos_mano_de_obra.
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
            if (_dibujar_repetidos)
            {
                if((e.ColumnIndex >= 0 && this.dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name == "_COL_CARGO" && e.RowIndex >= 0))
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == 0 && (e.RowIndex == Indice_fila_repetida) && e.Value != null)
                    {
                        e.PaintBackground(e.ClipBounds, false);
                        dgv_entrada_datos_mano_de_obra[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
                        PointF p = e.CellBounds.Location;
                        p.X += 22;

                        e.Graphics.DrawImage(Properties.Resources.atencion, e.CellBounds.X + 2, e.CellBounds.Y + 2, 16, 16);
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p.X, p.Y + 5);
                        e.Handled = true;
                    }
                    if (e.RowIndex >= 0 && e.ColumnIndex == 0 && (e.RowIndex == Indice_fila_que_repite) && e.Value != null)
                    {

                        e.PaintBackground(e.ClipBounds, false);
                        dgv_entrada_datos_mano_de_obra[e.ColumnIndex, e.RowIndex].ToolTipText = e.Value.ToString();
                        PointF p = e.CellBounds.Location;
                        p.X += 22;

                        e.Graphics.DrawImage(Properties.Resources.atencion, e.CellBounds.X + 2, e.CellBounds.Y + 2, 16, 16);
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, p.X, p.Y + 5);
                        e.Handled = true;

                        if (_dibujar_repetidos)
                        {
                            //dgv_entrada_datos_mano_de_obra.Update();
                            //dgv_entrada_datos_mano_de_obra.Refresh();
                            _dibujar_repetidos = false;
                        }
                    }
                }
            }
        }

        //Eliminamos la fila en la que se presiono el boton de borrar
        private void dgv_entrada_datos_mano_de_obra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && !dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow )
            {
                Indice_fila_grid_entrada_datos_mano_obra = e.RowIndex;
                Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;
               
                if (dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name == "_COL_DELETE_ROW")
                {
                    #region eliminar cargo de la lista
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


                    panel_conceptos_remuneratios.BackColor = Color.White;

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

                    _dibujar_repetidos = false;

                    dgv_entrada_datos_mano_de_obra.Update();
                    dgv_entrada_datos_mano_de_obra.Refresh();


                    _continuar = true;
                    btn_continuar.Enabled = true;

                    dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[0, (dgv_entrada_datos_mano_de_obra.RowCount - 1)];
                    #endregion

                }
            }

       }

        private void dgv_entrada_datos_mano_de_obra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Indice_fila_grid_entrada_datos_mano_obra = e.RowIndex;
            Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;
            dgv_entrada_datos_mano_de_obra.CurrentCell = dgv_entrada_datos_mano_de_obra[Indice_columna_grid_entrada_datos_mano_obra, e.RowIndex];
            dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].Selected = true;
        }

        private void dgv_entrada_datos_mano_de_obra_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Indice_columna_grid_entrada_datos_mano_obra = e.ColumnIndex;
            COLUMN_SELECTED = e.ColumnIndex;
            Indice_fila_grid_entrada_datos_mano_obra = e.RowIndex;
        }

        // Reevaluacion de la entrada de datos de configuraion cargos. version 1.2 - mejoramiento de funcionalidad por cesar.freitas
        private void frm_01_2_01_Load(object sender, EventArgs e)
        {
            Habilitar_Buffer_doble_control_gridview(dgv_entrada_datos_mano_de_obra,true);
            Habilitar_Buffer_doble_control_gridview(dgv_conceptos_remunerativos,true);
        }
        private void Habilitar_Buffer_doble_control_gridview(DataGridView gridview, bool v)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            gridview, new object[] { true });
        }
        private void dgv_entrada_datos_mano_de_obra_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            Analizar_registros_repetido();
            dgv_entrada_datos_mano_de_obra.Update();
            dgv_entrada_datos_mano_de_obra.Refresh();
        }

        private void dgv_entrada_datos_mano_de_obra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_entrada_datos_mano_de_obra.CurrentRow.Index != (dgv_entrada_datos_mano_de_obra.RowCount - 1))
            {
            }
        }

        private void dgv_entrada_datos_mano_de_obra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 || e.KeyValue == 9)
            {
                DataGridViewCell celda_Activa = dgv_entrada_datos_mano_de_obra.CurrentCell;
            }
        }

        private void dgv_entrada_datos_mano_de_obra_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
        private void dgv_conceptos_remunerativos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_conceptos_remunerativos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selected_cell = dgv_conceptos_remunerativos.CurrentCell;
            if (e.ColumnIndex == 3)
            {
                dgv_conceptos_remunerativos.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool valor_obtenido = Convert.ToBoolean(selected_cell.Value);

                if (!Convert.ToBoolean(dgv_conceptos_remunerativos.Rows[e.RowIndex].Cells[0].Value))
                {
                    dgv_conceptos_remunerativos.Rows[e.RowIndex].Cells[0].Value = valor_obtenido;
                } 

            }
            if (e.ColumnIndex == 0)
            {
                dgv_conceptos_remunerativos.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool valor_obtenido = Convert.ToBoolean(selected_cell.Value);

                if (Convert.ToBoolean(dgv_conceptos_remunerativos.Rows[e.RowIndex].Cells[3].Value))
                {
                    if (!valor_obtenido)
                        dgv_conceptos_remunerativos.Rows[e.RowIndex].Cells[3].Value = valor_obtenido;
                }
                else
                {
                    dgv_conceptos_remunerativos.Rows[e.RowIndex].Cells[3].Value = valor_obtenido;
                }

            }
        }

        private void dgv_conceptos_remunerativos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid_view = (DataGridView)sender;

            // para importes
            if (e.ColumnIndex == 4)
            {
              
            }
            // para porcentajes

            //if (e.ColumnIndex == 5)
            //{
            //    if (!string.IsNullOrEmpty(grid_view.Rows[e.RowIndex].Cells[5].Value.ToString()))
            //    {
            //        decimal valor_porcentaje = Convert.ToDecimal(grid_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //        dgv_conceptos_remunerativos.Rows[e.RowIndex].Cells[5].Value = valor_porcentaje.ToString("P");
            //    }
            //}
        }

        private void dgv_conceptos_remunerativos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
