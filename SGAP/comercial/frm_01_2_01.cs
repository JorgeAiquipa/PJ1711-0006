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
        ET_entidad _et_entidad = new ET_entidad();
        NT_M38 _nt_m38 = new NT_M38();
        NT_R29 _nt_r29 = new NT_R29();
        ET_R31 _et_r31 = new ET_R31();

        ET_R29 _et_r29 = new ET_R29();

        List<ET_R29> _lista_et_r29 = new List<ET_R29>();

        int id_Servicio_hijo;
        public frm_01_2_01(int __id_Servicio_hijo)
        {
            InitializeComponent();
            id_Servicio_hijo = __id_Servicio_hijo;

        }

        public void Analizar_informacion_ingresada()
        {
            _et_entidad = new ET_entidad();
            _et_entidad._entity_r28._TR28_ID = id_Servicio_hijo;
            _et_entidad._lista_et_r29 = _lista_et_r29;
            _nt_r29.set_001(_et_entidad);
        }

        List<ET_M38> _lista_ = new List<ET_M38>();
        private void dgv_entrada_datos_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //tiene lugar cuando se clickea el contenido de una celda
            string column_name = dgv_entrada_datos_mano_de_obra.Columns[0].Name; // cargo
            string column_hora_e = dgv_entrada_datos_mano_de_obra.Columns[1].Name; // hora entrada
            string column_hora_s = dgv_entrada_datos_mano_de_obra.Columns[2].Name; // hora salida
            string colum_dias_x_Semana = dgv_entrada_datos_mano_de_obra.Columns[3].Name; // dias_x_Semana

            //DataGridView tabla_locales = (DataGridView)sender;

            if (column_name.Equals("cargo"))
            {
                TextBox auto_text = e.Control as TextBox;

                if (auto_text != null)
                {
                    auto_text.Width = 300;
                    auto_text.AutoCompleteMode = AutoCompleteMode.Suggest;
                    auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    _lista_ = _nt_m38.gridTextBoxAutocomplete(auto_text)._lista_et_m38;
                }
            }
            if (column_hora_e.Equals("hora_entrada"))
            {
                DateTimePicker time = e.Control as DateTimePicker;

                if (time != null)
                {
                    e.CellStyle.Format = "hh:mm tt";
                    e.Control.Text = "07:00:00 am";
                }
            }
            if (column_hora_s.Equals("hora_salida"))
            {
                DateTimePicker time = e.Control as DateTimePicker;

                if (time != null)
                {
                    e.CellStyle.Format = "hh:mm tt";
                    e.Control.Text = "15:00:00 pm";
                }
            }
            if (colum_dias_x_Semana.Equals("dias_x_semana"))
            {
                NumericUpDown numeric = e.Control as NumericUpDown;
                if (numeric != null)
                {
                    numeric.Value = Convert.ToDecimal(e.Control.Text);
                    numeric.Maximum = 7;
                    numeric.Minimum = 1;
                }
            }
        }

        private void btn_continuar_Click(object sender, EventArgs e)
        {
            // guardamos los cambios
            Analizar_informacion_ingresada();
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        // Este evento valida lo que se ingresa en cada celda
        private void dgv_entrada_datos_mano_de_obra_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (!dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].IsNewRow)
            {
                String nombre_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name;
                String cabecra_columna = dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].HeaderText;
                //// evitamos validad el boton de borrar local
                //if (nombre_columna.Equals("header_btn_delete_row_dgv_Informacion_locales")) return;

                var msg = string.Format("El campo de nombre {0} esta vacio", cabecra_columna);

                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = msg;
                    dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSalmon;
                    e.Cancel = true;
                }
                else
                {
                    _et_r29 = new ET_R29();
                    _et_r29._Fila = e.RowIndex;
                    _et_r29._TR29_TR28_ID = id_Servicio_hijo;
                    switch (nombre_columna)
                    {
                        case "cargo":
                            _et_r29._TR29_DESCRIP = e.FormattedValue.ToString();

                            ET_M38 cargo = _lista_.FirstOrDefault(x => x._TM38_DESCRIP == _et_r29._TR29_DESCRIP);
                            if (cargo != null)
                            {
                                _et_r29._TR29_TM38_ID = cargo._TM38_ID;
                            }
                            else
                            {
                                dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].ErrorText = msg;
                                dgv_entrada_datos_mano_de_obra.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSalmon;
                                e.Cancel = true;
                            }
                            break;
                        case "hora_entrada":
                            _et_r29._TR29_HORA_ENTRADA = Convert.ToDateTime(e.FormattedValue.ToString());
                            break;
                        case "hora_salida":
                            _et_r29._TR29_HORA_SALIDA = Convert.ToDateTime(e.FormattedValue.ToString());
                            break;
                        case "dias_x_semana":
                            _et_r29._TR29_DIAS_SEMANA = Convert.ToInt32(e.FormattedValue.ToString());
                            break;
                    }

                    bool existe = _lista_et_r29.Any(item => item._Fila == e.RowIndex);

                    // sis existe actualizo la lista
                    if (existe)
                    {
                        ET_R29 _fila = _lista_et_r29.FirstOrDefault(cus => cus._Fila == _et_r29._Fila);

                        switch (nombre_columna)
                        {
                            case "cargo":
                                _fila._TR29_DESCRIP = _et_r29._TR29_DESCRIP;
                                ET_M38 cargo = _lista_.FirstOrDefault(x => x._TM38_DESCRIP == _et_r29._TR29_DESCRIP);
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
                            case "hora_entrada":
                                _fila._TR29_HORA_ENTRADA = _et_r29._TR29_HORA_ENTRADA;
                                break;
                            case "hora_salida":
                                _fila._TR29_HORA_SALIDA = _et_r29._TR29_HORA_SALIDA;
                                break;
                            case "dias_x_semana":
                                _fila._TR29_DIAS_SEMANA = _et_r29._TR29_DIAS_SEMANA;
                                break;
                        }
                        _fila._TR29_TR28_ID = id_Servicio_hijo;
                    }
                    else
                    {
                        _lista_et_r29.Add(_et_r29);
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
        }

        private void dgv_entrada_datos_mano_de_obra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name == "hora_entrada")
            {
                e.Value = DateTime.Now.ToString("T");
                e.CellStyle.Format = "hh:mm tt";
                //e.Value = "07:00:00 am";
                e.FormattingApplied = true;

            }
            if (dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name == "hora_salida")
            {
                e.Value = DateTime.Now.ToString("T");
                e.CellStyle.Format = "hh:mm tt";
                //e.Value = "15:00:00 pm";
                e.FormattingApplied = true;
            }
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
    }
}
