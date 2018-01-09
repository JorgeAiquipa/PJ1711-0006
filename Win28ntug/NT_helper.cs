using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win28ntug
{
    public class NT_helper
    {
        public void textKeyPress(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        public void numberKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            if (char.IsLetter(e.KeyChar)) { e.Handled = true; }
        }

        public void numberDecimalKeyPress(TextBox _textbox, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if ((e.KeyChar == '.') && (!_textbox.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }

        public void dataGridViewTextBox_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox _textbox = (TextBox)sender;

            //if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            //if (char.IsLetter(e.KeyChar)) { e.Handled = true; }
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }


        public void dataGridViewTextBox_Decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox _textbox = (TextBox)sender;

            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if ((e.KeyChar == '.') && (!_textbox.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }


        public void dataGridViewTextBox_textKeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Return)
            //{
            //    // Do Something
            //}
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        public void Set_Style_to_DatagridView(DataGridView DataGridView)
        {
            DataGridView.MultiSelect = false;
            DataGridView.GridColor = Color.DarkGray;
            DataGridView.EnableHeadersVisualStyles = true;
            //DataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridView.ColumnHeadersHeight = 22;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridView.AllowUserToResizeColumns = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.BorderStyle = BorderStyle.None;
            DataGridView.BackgroundColor = Color.White;
            DataGridView.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            DataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            DataGridView.RowHeadersVisible = false;
        }

        public void Center_Preload(string message = "", object sender_parent = null, object sender_child = null)
        {

        }

    }

}
