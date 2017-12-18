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
namespace SGAP.FOLDER_FRMS
{
    public partial class frm_01_2_01 : Form
    {
        ET_entidad _et_entidad = new ET_entidad();
        NT_M38 _nt_m38 = new NT_M38();
        NT_R29 _nt_r29 = new NT_R29();
        ET_R31 _et_r31 = new ET_R31();

        ET_R29 _et_r29 = new ET_R29();

        List<ET_R29> _lista_et_r29 = new List<ET_R29>();

        public frm_01_2_01()
        {
            InitializeComponent();
        }
        public void Analizar_informacion_ingresada()
        {

            // llenamos una lista de tipo 

            // recorrecmos lo ingresado y creamo una lista del tipo et_r31;

            // mostramos la información en el form padre page mano de obra.

            //_lista_et_r29
            _et_entidad = new ET_entidad();
            _et_entidad._lista_et_r29 = _lista_et_r29;
            _nt_r29.set_001(_et_entidad);
        }

        private void dgv_entrada_datos_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //tiene lugar cuando se clickea el contenido de una celda
            string column_name = dgv_entrada_datos_mano_de_obra.Columns[0].Name; // cargo
            string colum_dias_x_Semana = dgv_entrada_datos_mano_de_obra.Columns[3].Name; // cargo
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
            if (colum_dias_x_Semana.Equals("dias_x_semana"))
            {
                NumericUpDown numeric = e.Control as NumericUpDown;
                if (numeric != null)
                {
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

                    switch (nombre_columna)
                    {
                        case "cargo":
                            _et_r29._TR29_DESCRIP = e.FormattedValue.ToString();
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

        //private void dgv_entrada_datos_mano_de_obra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dgv_entrada_datos_mano_de_obra.Columns[e.ColumnIndex].Name == "hora_entrada")
        //    {
        //        e.Value = DateTime.Now.ToString("T");
        //        e.FormattingApplied = true;
        //    }
        //}
    }
}
