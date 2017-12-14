namespace SGAP.FORLDER_FRMS
{
    partial class frm_01_1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ruc_cliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nupd_periodo_de_servicio = new System.Windows.Forms.NumericUpDown();
            this.dgv_informacion_locales = new System.Windows.Forms.DataGridView();
            this._seleccionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._TM27_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_DIRECCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_TM19_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_TM2_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_TM9_DIST_CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_TM28_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_ST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_FLG_ELIMINADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_CODGREEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_UCREA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_FCREA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_UACTUALIZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TM27_FACTUALIZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.header_btn_delete_row_dgv_Informacion_locales = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbx_tipo_servicio = new System.Windows.Forms.ComboBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_continuar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nupd_periodo_de_servicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_informacion_locales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Información General";
            // 
            // txt_nombre_cliente
            // 
            this.txt_nombre_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_nombre_cliente.Location = new System.Drawing.Point(136, 36);
            this.txt_nombre_cliente.Name = "txt_nombre_cliente";
            this.txt_nombre_cliente.Size = new System.Drawing.Size(338, 20);
            this.txt_nombre_cliente.TabIndex = 3;
            this.txt_nombre_cliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_nombre_cliente_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre de Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(21, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "RUC Cliente";
            // 
            // txt_ruc_cliente
            // 
            this.txt_ruc_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_ruc_cliente.Location = new System.Drawing.Point(136, 72);
            this.txt_ruc_cliente.Name = "txt_ruc_cliente";
            this.txt_ruc_cliente.ReadOnly = true;
            this.txt_ruc_cliente.Size = new System.Drawing.Size(338, 20);
            this.txt_ruc_cliente.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(21, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo de Servicio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(21, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Periodo del Servicio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(190, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "meses.";
            // 
            // nupd_periodo_de_servicio
            // 
            this.nupd_periodo_de_servicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nupd_periodo_de_servicio.Location = new System.Drawing.Point(136, 150);
            this.nupd_periodo_de_servicio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupd_periodo_de_servicio.Name = "nupd_periodo_de_servicio";
            this.nupd_periodo_de_servicio.Size = new System.Drawing.Size(48, 20);
            this.nupd_periodo_de_servicio.TabIndex = 15;
            this.nupd_periodo_de_servicio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgv_informacion_locales
            // 
            this.dgv_informacion_locales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_informacion_locales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_informacion_locales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_informacion_locales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._seleccionado,
            this._TM27_NOMBRE,
            this._TM27_DIRECCION,
            this._TM27_ID,
            this._TM27_TM19_ID,
            this._TM27_TM2_ID,
            this._TM27_TM9_DIST_CODIGO,
            this._TM27_TM28_ID,
            this._TM27_ST,
            this._TM27_FLG_ELIMINADO,
            this._TM27_CODGREEM,
            this._TM27_UCREA,
            this._TM27_FCREA,
            this._TM27_UACTUALIZA,
            this._TM27_FACTUALIZA,
            this.header_btn_delete_row_dgv_Informacion_locales});
            this.dgv_informacion_locales.Location = new System.Drawing.Point(12, 185);
            this.dgv_informacion_locales.Name = "dgv_informacion_locales";
            this.dgv_informacion_locales.Size = new System.Drawing.Size(654, 355);
            this.dgv_informacion_locales.TabIndex = 16;
            this.dgv_informacion_locales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_informacion_locales_CellContentClick);
            this.dgv_informacion_locales.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_informacion_locales_CellEndEdit);
            this.dgv_informacion_locales.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_informacion_locales_CellValidating);
            this.dgv_informacion_locales.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_informacion_locales_RowValidating);
            // 
            // _seleccionado
            // 
            this._seleccionado.DataPropertyName = "_seleccionado";
            this._seleccionado.FillWeight = 60.91371F;
            this._seleccionado.HeaderText = "....";
            this._seleccionado.Name = "_seleccionado";
            this._seleccionado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._seleccionado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _TM27_NOMBRE
            // 
            this._TM27_NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._TM27_NOMBRE.DataPropertyName = "_TM27_NOMBRE";
            this._TM27_NOMBRE.FillWeight = 172.1251F;
            this._TM27_NOMBRE.HeaderText = "Nombre Local";
            this._TM27_NOMBRE.Name = "_TM27_NOMBRE";
            // 
            // _TM27_DIRECCION
            // 
            this._TM27_DIRECCION.DataPropertyName = "_TM27_DIRECCION";
            this._TM27_DIRECCION.FillWeight = 101.1997F;
            this._TM27_DIRECCION.HeaderText = "Dirección";
            this._TM27_DIRECCION.Name = "_TM27_DIRECCION";
            // 
            // _TM27_ID
            // 
            this._TM27_ID.DataPropertyName = "_TM27_ID";
            this._TM27_ID.HeaderText = "_TM27_ID";
            this._TM27_ID.Name = "_TM27_ID";
            this._TM27_ID.Visible = false;
            // 
            // _TM27_TM19_ID
            // 
            this._TM27_TM19_ID.DataPropertyName = "_TM27_TM19_ID";
            this._TM27_TM19_ID.HeaderText = "_TM27_TM19_ID";
            this._TM27_TM19_ID.Name = "_TM27_TM19_ID";
            this._TM27_TM19_ID.Visible = false;
            // 
            // _TM27_TM2_ID
            // 
            this._TM27_TM2_ID.DataPropertyName = "_TM27_TM2_ID";
            this._TM27_TM2_ID.HeaderText = "_TM27_TM2_ID";
            this._TM27_TM2_ID.Name = "_TM27_TM2_ID";
            this._TM27_TM2_ID.Visible = false;
            // 
            // _TM27_TM9_DIST_CODIGO
            // 
            this._TM27_TM9_DIST_CODIGO.DataPropertyName = "_TM27_TM9_DIST_CODIGO";
            this._TM27_TM9_DIST_CODIGO.HeaderText = "_TM27_TM9_DIST_CODIGO";
            this._TM27_TM9_DIST_CODIGO.Name = "_TM27_TM9_DIST_CODIGO";
            this._TM27_TM9_DIST_CODIGO.Visible = false;
            // 
            // _TM27_TM28_ID
            // 
            this._TM27_TM28_ID.DataPropertyName = "_TM27_TM28_ID";
            this._TM27_TM28_ID.HeaderText = "_TM27_TM28_ID";
            this._TM27_TM28_ID.Name = "_TM27_TM28_ID";
            this._TM27_TM28_ID.Visible = false;
            // 
            // _TM27_ST
            // 
            this._TM27_ST.DataPropertyName = "_TM27_ST";
            this._TM27_ST.HeaderText = "_TM27_ST";
            this._TM27_ST.Name = "_TM27_ST";
            this._TM27_ST.Visible = false;
            // 
            // _TM27_FLG_ELIMINADO
            // 
            this._TM27_FLG_ELIMINADO.DataPropertyName = "_TM27_FLG_ELIMINADO";
            this._TM27_FLG_ELIMINADO.HeaderText = "_TM27_FLG_ELIMINADO";
            this._TM27_FLG_ELIMINADO.Name = "_TM27_FLG_ELIMINADO";
            this._TM27_FLG_ELIMINADO.Visible = false;
            // 
            // _TM27_CODGREEM
            // 
            this._TM27_CODGREEM.DataPropertyName = "_TM27_CODGREEM";
            this._TM27_CODGREEM.HeaderText = "_TM27_CODGREEM";
            this._TM27_CODGREEM.Name = "_TM27_CODGREEM";
            this._TM27_CODGREEM.Visible = false;
            // 
            // _TM27_UCREA
            // 
            this._TM27_UCREA.DataPropertyName = "_TM27_UCREA";
            this._TM27_UCREA.HeaderText = "_TM27_UCREA";
            this._TM27_UCREA.Name = "_TM27_UCREA";
            this._TM27_UCREA.Visible = false;
            // 
            // _TM27_FCREA
            // 
            this._TM27_FCREA.DataPropertyName = "_TM27_FCREA";
            this._TM27_FCREA.HeaderText = "_TM27_FCREA";
            this._TM27_FCREA.Name = "_TM27_FCREA";
            this._TM27_FCREA.Visible = false;
            // 
            // _TM27_UACTUALIZA
            // 
            this._TM27_UACTUALIZA.DataPropertyName = "_TM27_UACTUALIZA";
            this._TM27_UACTUALIZA.HeaderText = "_TM27_UACTUALIZA";
            this._TM27_UACTUALIZA.Name = "_TM27_UACTUALIZA";
            this._TM27_UACTUALIZA.Visible = false;
            // 
            // _TM27_FACTUALIZA
            // 
            this._TM27_FACTUALIZA.DataPropertyName = "_TM27_FACTUALIZA";
            this._TM27_FACTUALIZA.HeaderText = "_TM27_FACTUALIZA";
            this._TM27_FACTUALIZA.Name = "_TM27_FACTUALIZA";
            this._TM27_FACTUALIZA.Visible = false;
            // 
            // header_btn_delete_row_dgv_Informacion_locales
            // 
            this.header_btn_delete_row_dgv_Informacion_locales.FillWeight = 65.76151F;
            this.header_btn_delete_row_dgv_Informacion_locales.HeaderText = ".....";
            this.header_btn_delete_row_dgv_Informacion_locales.Name = "header_btn_delete_row_dgv_Informacion_locales";
            this.header_btn_delete_row_dgv_Informacion_locales.Visible = false;
            // 
            // cbx_tipo_servicio
            // 
            this.cbx_tipo_servicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbx_tipo_servicio.FormattingEnabled = true;
            this.cbx_tipo_servicio.Location = new System.Drawing.Point(136, 108);
            this.cbx_tipo_servicio.Name = "cbx_tipo_servicio";
            this.cbx_tipo_servicio.Size = new System.Drawing.Size(338, 21);
            this.cbx_tipo_servicio.TabIndex = 9;
            this.cbx_tipo_servicio.SelectedIndexChanged += new System.EventHandler(this.cbx_tipo_servicio_SelectedIndexChanged);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_cancelar.Location = new System.Drawing.Point(566, 546);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(100, 23);
            this.btn_cancelar.TabIndex = 17;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_continuar
            // 
            this.btn_continuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_continuar.Location = new System.Drawing.Point(460, 546);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(100, 23);
            this.btn_continuar.TabIndex = 18;
            this.btn_continuar.Text = "Continuar";
            this.btn_continuar.UseVisualStyleBackColor = true;
            this.btn_continuar.Click += new System.EventHandler(this.btn_continuar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "_TM27_NOMBRE";
            this.dataGridViewTextBoxColumn1.FillWeight = 172.1251F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre Local";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "_TM27_DIRECCION";
            this.dataGridViewTextBoxColumn2.FillWeight = 101.1997F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Dirección";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 185;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "_TM27_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "_TM27_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "_TM27_TM19_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "_TM27_TM19_ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "_TM27_TM2_ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "_TM27_TM2_ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "_TM27_TM9_DIST_CODIGO";
            this.dataGridViewTextBoxColumn6.HeaderText = "_TM27_TM9_DIST_CODIGO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "_TM27_TM28_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "_TM27_TM28_ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "_TM27_ST";
            this.dataGridViewTextBoxColumn8.HeaderText = "_TM27_ST";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "_TM27_FLG_ELIMINADO";
            this.dataGridViewTextBoxColumn9.HeaderText = "_TM27_FLG_ELIMINADO";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "_TM27_CODGREEM";
            this.dataGridViewTextBoxColumn10.HeaderText = "_TM27_CODGREEM";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "_TM27_UCREA";
            this.dataGridViewTextBoxColumn11.HeaderText = "_TM27_UCREA";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "_TM27_FCREA";
            this.dataGridViewTextBoxColumn12.HeaderText = "_TM27_FCREA";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "_TM27_UACTUALIZA";
            this.dataGridViewTextBoxColumn13.HeaderText = "_TM27_UACTUALIZA";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "_TM27_FACTUALIZA";
            this.dataGridViewTextBoxColumn14.HeaderText = "_TM27_FACTUALIZA";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // frm_01_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 584);
            this.Controls.Add(this.btn_continuar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.cbx_tipo_servicio);
            this.Controls.Add(this.dgv_informacion_locales);
            this.Controls.Add(this.nupd_periodo_de_servicio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ruc_cliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nombre_cliente);
            this.Controls.Add(this.label1);
            this.Name = "frm_01_1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_Informacion_general";
            ((System.ComponentModel.ISupportInitialize)(this.nupd_periodo_de_servicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_informacion_locales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ruc_cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nupd_periodo_de_servicio;
        private System.Windows.Forms.DataGridView dgv_informacion_locales;
        private System.Windows.Forms.ComboBox cbx_tipo_servicio;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_continuar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _seleccionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_DIRECCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_TM19_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_TM2_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_TM9_DIST_CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_TM28_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_ST;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_FLG_ELIMINADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_CODGREEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_UCREA;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_FCREA;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_UACTUALIZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TM27_FACTUALIZA;
        private System.Windows.Forms.DataGridViewButtonColumn header_btn_delete_row_dgv_Informacion_locales;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}