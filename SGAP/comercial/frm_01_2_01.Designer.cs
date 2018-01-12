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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_01_2_01));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_conceptos_remuneratios = new System.Windows.Forms.Panel();
            this.dgv_conceptos_remunerativos = new System.Windows.Forms.DataGridView();
            this.panel_cargos = new System.Windows.Forms.Panel();
            this.dgv_entrada_datos_mano_de_obra = new System.Windows.Forms.DataGridView();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_continuar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTimeControl1 = new SGAP.UserControls.GridTimeControl();
            this.gridTimeControl2 = new SGAP.UserControls.GridTimeControl();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel_conceptos_remuneratios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_conceptos_remunerativos)).BeginInit();
            this.panel_cargos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_entrada_datos_mano_de_obra)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel_conceptos_remuneratios);
            this.panel2.Controls.Add(this.panel_cargos);
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Controls.Add(this.btn_continuar);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 585);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Conceptos remunerativos:";
            // 
            // panel_conceptos_remuneratios
            // 
            this.panel_conceptos_remuneratios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_conceptos_remuneratios.Controls.Add(this.dgv_conceptos_remunerativos);
            this.panel_conceptos_remuneratios.Location = new System.Drawing.Point(0, 330);
            this.panel_conceptos_remuneratios.Name = "panel_conceptos_remuneratios";
            this.panel_conceptos_remuneratios.Padding = new System.Windows.Forms.Padding(7);
            this.panel_conceptos_remuneratios.Size = new System.Drawing.Size(754, 217);
            this.panel_conceptos_remuneratios.TabIndex = 1;
            // 
            // dgv_conceptos_remunerativos
            // 
            this.dgv_conceptos_remunerativos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_conceptos_remunerativos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_conceptos_remunerativos.Location = new System.Drawing.Point(7, 7);
            this.dgv_conceptos_remunerativos.Name = "dgv_conceptos_remunerativos";
            this.dgv_conceptos_remunerativos.RowHeadersWidth = 30;
            this.dgv_conceptos_remunerativos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_conceptos_remunerativos.Size = new System.Drawing.Size(740, 203);
            this.dgv_conceptos_remunerativos.TabIndex = 0;
            this.dgv_conceptos_remunerativos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_conceptos_remunerativos_CellClick);
            this.dgv_conceptos_remunerativos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_conceptos_remunerativos_CellContentClick);
            this.dgv_conceptos_remunerativos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_conceptos_remunerativos_CellEndEdit);
            this.dgv_conceptos_remunerativos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_conceptos_remunerativos_CellFormatting);
            this.dgv_conceptos_remunerativos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_conceptos_remunerativos_KeyDown);
            // 
            // panel_cargos
            // 
            this.panel_cargos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_cargos.Controls.Add(this.dgv_entrada_datos_mano_de_obra);
            this.panel_cargos.Location = new System.Drawing.Point(0, 21);
            this.panel_cargos.Name = "panel_cargos";
            this.panel_cargos.Padding = new System.Windows.Forms.Padding(7);
            this.panel_cargos.Size = new System.Drawing.Size(754, 273);
            this.panel_cargos.TabIndex = 0;
            // 
            // dgv_entrada_datos_mano_de_obra
            // 
            this.dgv_entrada_datos_mano_de_obra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_entrada_datos_mano_de_obra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_entrada_datos_mano_de_obra.Location = new System.Drawing.Point(7, 7);
            this.dgv_entrada_datos_mano_de_obra.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_entrada_datos_mano_de_obra.Name = "dgv_entrada_datos_mano_de_obra";
            this.dgv_entrada_datos_mano_de_obra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_entrada_datos_mano_de_obra.Size = new System.Drawing.Size(740, 259);
            this.dgv_entrada_datos_mano_de_obra.TabIndex = 0;
            this.dgv_entrada_datos_mano_de_obra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_CellClick);
            this.dgv_entrada_datos_mano_de_obra.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_CellEndEdit);
            this.dgv_entrada_datos_mano_de_obra.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_CellEnter);
            this.dgv_entrada_datos_mano_de_obra.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_CellLeave);
            this.dgv_entrada_datos_mano_de_obra.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_entrada_datos_mano_de_obra_CellPainting);
            this.dgv_entrada_datos_mano_de_obra.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_entrada_datos_mano_de_obra_CellValidating);
            this.dgv_entrada_datos_mano_de_obra.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_entrada_datos_mano_de_obra_DefaultValuesNeeded);
            this.dgv_entrada_datos_mano_de_obra.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_entrada_datos_mano_de_obra_EditingControlShowing);
            this.dgv_entrada_datos_mano_de_obra.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_entrada_datos_mano_de_obra_RowEnter);
            this.dgv_entrada_datos_mano_de_obra.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_entrada_datos_mano_de_obra_RowsAdded);
            this.dgv_entrada_datos_mano_de_obra.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_entrada_datos_mano_de_obra_UserDeletedRow);
            this.dgv_entrada_datos_mano_de_obra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_entrada_datos_mano_de_obra_KeyDown);
            this.dgv_entrada_datos_mano_de_obra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_entrada_datos_mano_de_obra_KeyPress);
            this.dgv_entrada_datos_mano_de_obra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_entrada_datos_mano_de_obra_KeyUp);
            this.dgv_entrada_datos_mano_de_obra.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgv_entrada_datos_mano_de_obra_PreviewKeyDown);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancelar.Location = new System.Drawing.Point(644, 553);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(100, 23);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_continuar
            // 
            this.btn_continuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_continuar.Location = new System.Drawing.Point(534, 553);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(100, 23);
            this.btn_continuar.TabIndex = 2;
            this.btn_continuar.Text = "Aceptar";
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
            this.label10.Size = new System.Drawing.Size(754, 22);
            this.label10.TabIndex = 6;
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
            this.ClientSize = new System.Drawing.Size(754, 585);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(733, 620);
            this.Name = "frm_01_2_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración de cargos";
            this.Load += new System.EventHandler(this.frm_01_2_01_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_conceptos_remuneratios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_conceptos_remunerativos)).EndInit();
            this.panel_cargos.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dgv_conceptos_remunerativos;
        private System.Windows.Forms.DataGridView dgv_entrada_datos_mano_de_obra;
        private System.Windows.Forms.Panel panel_conceptos_remuneratios;
        private System.Windows.Forms.Panel panel_cargos;
        private System.Windows.Forms.Label label1;
    }
}