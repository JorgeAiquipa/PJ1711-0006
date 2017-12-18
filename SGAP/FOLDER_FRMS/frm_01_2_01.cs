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
        NT_M38 _nt_m38 = new NT_M38();


        public frm_01_2_01()
        {
            InitializeComponent();
        }

        private void dgv_entrada_datos_mano_de_obra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void btn_continuar_Click(object sender, EventArgs e)
        {
            // guardamos los cambios
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
