namespace SGAP.comercial
{
    partial class frm_01_2_01
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv_conceptos_remunerativos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_entrada_datos_mano_de_obra = new System.Windows.Forms.DataGridView();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_continuar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTimeControl1 = new SGAP.UserControls.GridTimeControl();
            this.gridTimeControl2 = new SGAP.UserControls.GridTimeControl();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_conceptos_remunerativos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_entrada_datos_mano_de_obra)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Controls.Add(this.btn_continuar);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 507);
            this.panel2.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.dgv_conceptos_remunerativos);
            this.groupBox2.Location = new System.Drawing.Point(15, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 207);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conceptos remunerativos para la fila seleccionada";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "<ALT + C>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_conceptos_remunerativos
            // 
            this.dgv_conceptos_remunerativos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_conceptos_remunerativos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_conceptos_remunerativos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_conceptos_remunerativos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_conceptos_remunerativos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_conceptos_remunerativos.Location = new System.Drawing.Point(3, 16);
            this.dgv_conceptos_remunerativos.Name = "dgv_conceptos_remunerativos";
            this.dgv_conceptos_remunerativos.RowHeadersWidth = 30;
            this.dgv_conceptos_remunerativos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_conceptos_remunerativos.Size = new System.Drawing.Size(644, 188);
            this.dgv_conceptos_remunerativos.TabIndex = 0;
            this.dgv_conceptos_remunerativos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_conceptos_remunerativos_CellPainting);
            this.dgv_conceptos_remunerativos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_conceptos_remunerativos_CellValidating);
            this.dgv_conceptos_remunerativos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_conceptos_remunerativos_CellValueChanged);
            this.dgv_conceptos_remunerativos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_conceptos_remunerativos_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_entrada_datos_mano_de_obra);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingreso de cargos y horarios.";
            // 
            // dgv_entrada_datos_mano_de_obra
            // 
            this.dgv_entrada_datos_mano_de_obra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_entrada_datos_mano_de_obra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_entrada_datos_mano_de_obra.Location = new System.Drawing.Point(3, 16);
            this.dgv_entrada_datos_mano_de_obra.Name = "dgv_entrada_datos_mano_de_obra";
            this.dgv_entrada_datos_mano_de_obra.Size = new System.Drawing.Size(650, 205);
            this.dgv_entrada_datos_mano_de_obra.TabIndex = 0;
            this.dgv_entrada_datos_mano_de_obra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_CellContentClick);
            this.dgv_entrada_datos_mano_de_obra.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_CellEndEdit);
            this.dgv_entrada_datos_mano_de_obra.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_CellLeave);
            this.dgv_entrada_datos_mano_de_obra.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_entrada_datos_mano_de_obra_CellValidating);
            this.dgv_entrada_datos_mano_de_obra.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_entrada_datos_mano_de_obra_DefaultValuesNeeded);
            this.dgv_entrada_datos_mano_de_obra.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_entrada_datos_mano_de_obra_EditingControlShowing);
            this.dgv_entrada_datos_mano_de_obra.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_RowLeave);
            this.dgv_entrada_datos_mano_de_obra.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_entrada_datos_mano_de_obra_RowsAdded);
            this.dgv_entrada_datos_mano_de_obra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_entrada_datos_mano_de_obra_KeyDown);
            this.dgv_entrada_datos_mano_de_obra.Leave += new System.EventHandler(this.dgv_entrada_datos_mano_de_obra_Leave);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancelar.Location = new System.Drawing.Point(538, 475);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(124, 23);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar <esc>";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_continuar
            // 
            this.btn_continuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_continuar.Location = new System.Drawing.Point(398, 475);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(134, 23);
            this.btn_continuar.TabIndex = 7;
            this.btn_continuar.Text = "Guardar <CTR+G>";
            this.btn_continuar.UseVisualStyleBackColor = true;
            this.btn_continuar.Click += new System.EventHandler(this.btn_continuar_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGreen;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(680, 22);
            this.label10.TabIndex = 6;
            this.label10.Text = "Entrada de Datos";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Cargo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 134;
            // 
            // gridTimeControl1
            // 
            this.gridTimeControl1.HeaderText = "Hora entrada";
            this.gridTimeControl1.Name = "gridTimeControl1";
            this.gridTimeControl1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTimeControl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridTimeControl1.Width = 135;
            // 
            // gridTimeControl2
            // 
            this.gridTimeControl2.HeaderText = "Hora salida";
            this.gridTimeControl2.Name = "gridTimeControl2";
            this.gridTimeControl2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTimeControl2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridTimeControl2.Width = 134;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Dias por semana";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 134;
            // 
            // frm_01_2_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 507);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(696, 546);
            this.MinimumSize = new System.Drawing.Size(696, 546);
            this.Name = "frm_01_2_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entrada de Datos";
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_conceptos_remunerativos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_entrada_datos_mano_de_obra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_continuar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private UserControls.GridTimeControl gridTimeControl1;
        private UserControls.GridTimeControl gridTimeControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_conceptos_remunerativos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_entrada_datos_mano_de_obra;
    }
}