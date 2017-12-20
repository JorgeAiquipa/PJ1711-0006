namespace SGAP.FORLDER_FRMS
{
    partial class frm_01_2
    {
        
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.tree_view_servicios = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panPages = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_entrada_datos_mq_eq = new System.Windows.Forms.DataGridView();
            this.maquinaria = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.equipos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.und = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costounitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costototal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericUpDownColumn1 = new SGAP.UserControls.NumericUpDownColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panPages.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_entrada_datos_mq_eq)).BeginInit();
            this.SuspendLayout();
            // 
            // tree_view_servicios
            // 
            this.tree_view_servicios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tree_view_servicios.Location = new System.Drawing.Point(5, 5);
            this.tree_view_servicios.Name = "tree_view_servicios";
            this.tree_view_servicios.Size = new System.Drawing.Size(260, 405);
            this.tree_view_servicios.TabIndex = 0;
            this.tree_view_servicios.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_view_servicios_AfterSelect);
            this.tree_view_servicios.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tree_view_servicios_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panPages);
            this.panel1.Location = new System.Drawing.Point(271, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 405);
            this.panel1.TabIndex = 2;
            // 
            // panPages
            // 
            this.panPages.Controls.Add(this.tabControl1);
            this.panPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPages.Location = new System.Drawing.Point(0, 0);
            this.panPages.Name = "panPages";
            this.panPages.Size = new System.Drawing.Size(801, 401);
            this.panPages.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 369);
            this.panel2.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGreen;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(787, 22);
            this.label10.TabIndex = 6;
            this.label10.Text = "Mano de Obra";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 375);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_entrada_datos_mq_eq);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(787, 369);
            this.panel3.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightGreen;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(787, 22);
            this.label11.TabIndex = 7;
            this.label11.Text = "Page 2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(793, 375);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(790, 333);
            this.panel4.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LightGreen;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(790, 22);
            this.label12.TabIndex = 7;
            this.label12.Text = "Page 3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(793, 375);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label13);
            this.panel5.Location = new System.Drawing.Point(6, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 333);
            this.panel5.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LightGreen;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(256, 22);
            this.label13.TabIndex = 7;
            this.label13.Text = "Page 4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(793, 375);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(256, 333);
            this.panel6.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Page 5";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel7);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(793, 375);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(256, 333);
            this.panel7.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGreen;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Page 6";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_entrada_datos_mq_eq
            // 
            this.dgv_entrada_datos_mq_eq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_entrada_datos_mq_eq.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_entrada_datos_mq_eq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_entrada_datos_mq_eq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.Codigo,
            this.marca,
            this.und,
            this.maquinaria,
            this.equipos,
            this.cantotal,
            this.costounitario,
            this.costototal});
            this.dgv_entrada_datos_mq_eq.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_entrada_datos_mq_eq.Location = new System.Drawing.Point(3, 25);
            this.dgv_entrada_datos_mq_eq.Name = "dgv_entrada_datos_mq_eq";
            this.dgv_entrada_datos_mq_eq.Size = new System.Drawing.Size(780, 341);
            this.dgv_entrada_datos_mq_eq.TabIndex = 10;
            this.dgv_entrada_datos_mq_eq.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_entrada_datos_mq_eq_CellBeginEdit);
            this.dgv_entrada_datos_mq_eq.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mq_eq_CellEndEdit);
            this.dgv_entrada_datos_mq_eq.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mq_eq_CellLeave);
            this.dgv_entrada_datos_mq_eq.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_entrada_datos_mq_eq_CellValidating);
            this.dgv_entrada_datos_mq_eq.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dvg_entrada_datos_mq_eq_EditingControlShowing_1);
            // 
            // maquinaria
            // 
            this.maquinaria.HeaderText = "Maquinaria";
            this.maquinaria.Name = "maquinaria";
            this.maquinaria.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.maquinaria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.maquinaria.Width = 65;
            // 
            // equipos
            // 
            this.equipos.HeaderText = "Equipos";
            this.equipos.Name = "equipos";
            this.equipos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.equipos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.equipos.Width = 55;
            // 
            // nombre
            // 
            this.nombre.Frozen = true;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.Width = 200;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 82;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.Width = 82;
            // 
            // und
            // 
            this.und.HeaderText = "Und.";
            this.und.Name = "und";
            this.und.Width = 50;
            // 
            // cantotal
            // 
            this.cantotal.HeaderText = "Cant. Total";
            this.cantotal.Name = "cantotal";
            this.cantotal.Width = 82;
            // 
            // costounitario
            // 
            this.costounitario.HeaderText = "Costo Unitario";
            this.costounitario.Name = "costounitario";
            this.costounitario.Width = 82;
            // 
            // costototal
            // 
            this.costototal.HeaderText = "Costo Total";
            this.costototal.Name = "costototal";
            this.costototal.Width = 82;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Hora Entrada";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Hora Salida";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // numericUpDownColumn1
            // 
            this.numericUpDownColumn1.HeaderText = "DxS";
            this.numericUpDownColumn1.Name = "numericUpDownColumn1";
            this.numericUpDownColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numericUpDownColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
          
           
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 82;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Marca";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 82;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Und.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Maquinaria";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 65;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Equipos";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 55;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Cant. Total";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 82;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Costo Unitario";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 82;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Costo Total";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 82;
            // 
            // frm_01_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 413);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tree_view_servicios);
            this.Name = "frm_01_2";
            this.Text = "FRM_Cotizador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panPages.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_entrada_datos_mq_eq)).EndInit();
            this.ResumeLayout(false);

            }

            #endregion
            private System.Windows.Forms.TreeView tree_view_servicios;
            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Panel panPages;
            private System.Windows.Forms.TabControl tabControl1;
            private System.Windows.Forms.TabPage tabPage1;
            private System.Windows.Forms.Panel panel2;
            private System.Windows.Forms.Label label10;
            private System.Windows.Forms.TabPage tabPage2;
            private System.Windows.Forms.Panel panel3;
            private System.Windows.Forms.Label label11;
            private System.Windows.Forms.TabPage tabPage3;
            private System.Windows.Forms.Panel panel4;
            private System.Windows.Forms.Label label12;
            private System.Windows.Forms.TabPage tabPage4;
            private System.Windows.Forms.Panel panel5;
            private System.Windows.Forms.Label label13;
            private System.Windows.Forms.TabPage tabPage5;
            private System.Windows.Forms.Panel panel6;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.TabPage tabPage6;
            private System.Windows.Forms.Panel panel7;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
            private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
            private UserControls.NumericUpDownColumn numericUpDownColumn1;
        private System.Windows.Forms.DataGridView dgv_entrada_datos_mq_eq;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn und;
        private System.Windows.Forms.DataGridViewCheckBoxColumn maquinaria;
        private System.Windows.Forms.DataGridViewCheckBoxColumn equipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costounitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn costototal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
    }
