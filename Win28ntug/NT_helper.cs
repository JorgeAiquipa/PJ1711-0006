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
            //dgv_entrada_datos_mano_de_obra.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            //dgv_entrada_datos_mano_de_obra.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            //dgv_entrada_datos_mano_de_obra.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridView.MultiSelect = false;
            DataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DataGridView.ColumnHeadersHeight = 25;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataGridView.AllowUserToResizeColumns = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.BorderStyle = BorderStyle.None;
            DataGridView.GridColor = Color.White;
            DataGridView.BackgroundColor = Color.White;
            DataGridView.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            DataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            //DataGridView.EnableHeadersVisualStyles = false;
            DataGridView.RowHeadersVisible = false;
        }

        public void Set_border_toCell_selecction(DataGridView dataGridView1, DataGridViewCellPaintingEventArgs e)
        {
            //Draw only grid content cells not ColumnHeader cells nor RowHeader cells
            if (e.ColumnIndex > -1 & e.RowIndex > -1)
            {
                //Pen for left and top borders
                using (var backGroundPen = new Pen(e.CellStyle.BackColor, 1))
                //Pen for bottom and right borders
                using (var gridlinePen = new Pen(dataGridView1.GridColor, 1))
                //Pen for selected cell borders
                using (var selectedPen = new Pen(Color.FromArgb(0, 134, 65), 1))
                {
                    var topLeftPoint = new Point(e.CellBounds.Left, e.CellBounds.Top);
                    var topRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Top);
                    var bottomRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    var bottomleftPoint = new Point(e.CellBounds.Left, e.CellBounds.Bottom - 1);

                    //Draw selected cells here
                    if (dataGridView1[e.ColumnIndex, e.RowIndex].Selected)
                    {
                        //Paint all parts except borders.
                        e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                        //Draw selected cells border here
                        e.Graphics.DrawRectangle(selectedPen, new Rectangle(e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width - 1, e.CellBounds.Height - 1));

                        //Handled painting for this cell, Stop default rendering.
                        e.Handled = true;
                    }
                    //Draw non-selected cells here
                    else
                    {
                        //Paint all parts except borders.
                        e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                        //Top border of first row cells should be in background color
                        if (e.RowIndex == 0)
                            e.Graphics.DrawLine(backGroundPen, topLeftPoint, topRightPoint);

                        //Left border of first column cells should be in background color
                        if (e.ColumnIndex == 0)
                            e.Graphics.DrawLine(backGroundPen, topLeftPoint, bottomleftPoint);

                        //Bottom border of last row cells should be in gridLine color
                        if (e.RowIndex == dataGridView1.RowCount - 1)
                            e.Graphics.DrawLine(gridlinePen, bottomRightPoint, bottomleftPoint);
                        else  //Bottom border of non-last row cells should be in background color
                            e.Graphics.DrawLine(backGroundPen, bottomRightPoint, bottomleftPoint);

                        //Right border of last column cells should be in gridLine color
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                            e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint);
                        else //Right border of non-last column cells should be in background color
                            e.Graphics.DrawLine(backGroundPen, bottomRightPoint, topRightPoint);

                        //Top border of non-first row cells should be in gridLine color, and they should be drawn here after right border
                        if (e.RowIndex > 0)
                            e.Graphics.DrawLine(gridlinePen, topLeftPoint, topRightPoint);

                        //Left border of non-first column cells should be in gridLine color, and they should be drawn here after bottom border
                        if (e.ColumnIndex > 0)
                            e.Graphics.DrawLine(gridlinePen, topLeftPoint, bottomleftPoint);

                        //We handled painting for this cell, Stop default rendering.
                        e.Handled = true;
                    }
                }
            }
        }



    }

}
