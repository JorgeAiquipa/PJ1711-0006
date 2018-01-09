using SGAP.UserControls;
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

namespace SGAP.comercial
{
    public partial class lienzo_de_prueba : Form
    {
        private DataGridView dataGridView1 = new DataGridView();

        // Declare an ArrayList to serve as the data store. 
        private System.Collections.ArrayList customers =
            new System.Collections.ArrayList();

        // Declare a Customer object to store data for a row being edited.
        private ET_M19 customerInEdit;

        // Declare a variable to store the index of a row being edited. 
        // A value of -1 indicates that there is no row currently in edit. 
        private int rowInEdit = -1;

        // Declare a variable to indicate the commit scope. 
        // Set this value to false to use cell-level commit scope. 
        private bool rowScopeCommit = true;

        public lienzo_de_prueba()
        {
            // Initialize the form.
            //this.dataGridView1.Dock = DockStyle.Fill;
            this.Controls.Add(this.dataGridView1);
            this.Load += new EventHandler(lienzo_de_prueba_Load);
            this.Text = "DataGridView virtual-mode demo (row-level commit scope)";

        }

        private void lienzo_de_prueba_Load(object sender, EventArgs e)
        {
            // Enable virtual mode.
            this.dataGridView1.VirtualMode = true;

            // Connect the virtual-mode events to event handlers. 
            this.dataGridView1.CellValueNeeded += new
                DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            this.dataGridView1.CellValuePushed += new
                DataGridViewCellValueEventHandler(dataGridView1_CellValuePushed);
            this.dataGridView1.NewRowNeeded += new
                DataGridViewRowEventHandler(dataGridView1_NewRowNeeded);
            this.dataGridView1.RowValidated += new
                DataGridViewCellEventHandler(dataGridView1_RowValidated);
            this.dataGridView1.RowDirtyStateNeeded += new
                QuestionEventHandler(dataGridView1_RowDirtyStateNeeded);
            this.dataGridView1.CancelRowEdit += new
                QuestionEventHandler(dataGridView1_CancelRowEdit);
            this.dataGridView1.UserDeletingRow += new
                DataGridViewRowCancelEventHandler(dataGridView1_UserDeletingRow);

            // Add columns to the DataGridView.
            DataGridViewTextBoxColumn companyNameColumn = new
                DataGridViewTextBoxColumn();
            companyNameColumn.HeaderText = "Company Name";
            companyNameColumn.Name = "Company Name";
            DataGridViewTextBoxColumn contactNameColumn = new
                DataGridViewTextBoxColumn();
            contactNameColumn.HeaderText = "Contact Name";
            contactNameColumn.Name = "Contact Name";
            this.dataGridView1.Columns.Add(companyNameColumn);
            this.dataGridView1.Columns.Add(contactNameColumn);
            this.dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            // Add some sample entries to the data store. 
            this.customers.Add(new ET_M19(
                "Bon app'", "Laurence Lebihan"));
            this.customers.Add(new ET_M19(
                "Bottom-Dollar Markets", "Elizabeth Lincoln"));
            this.customers.Add(new ET_M19(
                "B's Beverages", "Victoria Ashworth"));

            // Set the row count, including the row for new records.
            this.dataGridView1.RowCount = 4;

        }

        private void cbHeader_OnCheckBoxClicked(bool state)
        {
            MessageBox.Show("todo " + state.ToString());
        }

        private void dataGridView1_CellValueNeeded(object sender,
    System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            // If this is the row for new records, no values are needed.
            if (e.RowIndex == this.dataGridView1.RowCount - 1) return;

            ET_M19 customerTmp = null;

            // Store a reference to the Customer object for the row being painted.
            if (e.RowIndex == rowInEdit)
            {
                customerTmp = this.customerInEdit;
            }
            else
            {
                customerTmp = (ET_M19)this.customers[e.RowIndex];
            }

            // Set the cell value to paint using the Customer object retrieved.
            switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Company Name":
                    e.Value = customerTmp._TM19_DESCRIP1;
                    break;

                case "Contact Name":
                    e.Value = customerTmp._TM19_DESCRIP2;
                    break;
            }
        }

        private void dataGridView1_CellValuePushed(object sender,
    System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            ET_M19 customerTmp = null;

            // Store a reference to the Customer object for the row being edited.
            if (e.RowIndex < this.customers.Count)
            {
                // If the user is editing a new row, create a new Customer object.
                if (this.customerInEdit == null)
                {
                    this.customerInEdit = new ET_M19(
                        ((ET_M19)this.customers[e.RowIndex])._TM19_DESCRIP1,
                        ((ET_M19)this.customers[e.RowIndex])._TM19_DESCRIP2);
                }
                customerTmp = this.customerInEdit;
                this.rowInEdit = e.RowIndex;
            }
            else
            {
                customerTmp = this.customerInEdit;
            }

            // Set the appropriate Customer property to the cell value entered.
            String newValue = e.Value as String;
            switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Company Name":
                    customerTmp._TM19_DESCRIP1 = newValue;
                    break;

                case "Contact Name":
                    customerTmp._TM19_DESCRIP2 = newValue;
                    break;
            }
        }

        private void dataGridView1_NewRowNeeded(object sender,
    System.Windows.Forms.DataGridViewRowEventArgs e)
        {
            // Create a new Customer object when the user edits
            // the row for new records.
            this.customerInEdit = new ET_M19();
            this.rowInEdit = this.dataGridView1.Rows.Count - 1;
        }
        private void dataGridView1_RowValidated(object sender,
    System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            // Save row changes if any were made and release the edited 
            // Customer object if there is one.
            if (e.RowIndex >= this.customers.Count &&
                e.RowIndex != this.dataGridView1.Rows.Count - 1)
            {
                // Add the new Customer object to the data store.
                this.customers.Add(this.customerInEdit);
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            else if (this.customerInEdit != null &&
                e.RowIndex < this.customers.Count)
            {
                // Save the modified Customer object in the data store.
                this.customers[e.RowIndex] = this.customerInEdit;
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            else if (this.dataGridView1.ContainsFocus)
            {
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
        }
        private void dataGridView1_RowDirtyStateNeeded(object sender,
    System.Windows.Forms.QuestionEventArgs e)
        {
            if (!rowScopeCommit)
            {
                // In cell-level commit scope, indicate whether the value
                // of the current cell has been modified.
                e.Response = this.dataGridView1.IsCurrentCellDirty;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender,
    System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.customers.Count)
            {
                // If the user has deleted an existing row, remove the 
                // corresponding Customer object from the data store.
                this.customers.RemoveAt(e.Row.Index);
            }

            if (e.Row.Index == this.rowInEdit)
            {
                // If the user has deleted a newly created row, release
                // the corresponding Customer object. 
                this.rowInEdit = -1;
                this.customerInEdit = null;
            }
        }

        private void dataGridView1_CancelRowEdit(object sender,
    System.Windows.Forms.QuestionEventArgs e)
        {
            if (this.rowInEdit == this.dataGridView1.Rows.Count - 2 &&
                this.rowInEdit == this.customers.Count)
            {
                // If the user has canceled the edit of a newly created row, 
                // replace the corresponding Customer object with a new, empty one.
                this.customerInEdit = new ET_M19();
            }
            else
            {
                // If the user has canceled the edit of an existing row, 
                // release the corresponding Customer object.
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
        }
    }
}
