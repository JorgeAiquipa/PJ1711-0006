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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_direccion_cliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_nombre_Servicio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nupd_periodo_de_servicio = new System.Windows.Forms.NumericUpDown();
            this.dgv_informacion_locales = new System.Windows.Forms.DataGridView();
            this.c_nombre_local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.header_btn_delete_row_dgv_Informacion_locales = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbx_tipo_servicio = new System.Windows.Forms.ComboBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_continuar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupd_periodo_de_servicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_informacion_locales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(14, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Información General";
            // 
            // txt_nombre_cliente
            // 
            this.txt_nombre_cliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre_cliente.Location = new System.Drawing.Point(177, 40);
            this.txt_nombre_cliente.Name = "txt_nombre_cliente";
            this.txt_nombre_cliente.Size = new System.Drawing.Size(338, 27);
            this.txt_nombre_cliente.TabIndex = 3;
            this.txt_nombre_cliente.TextChanged += new System.EventHandler(this.txt_nombre_cliente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre de Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "RUC Cliente";
            // 
            // txt_ruc_cliente
            // 
            this.txt_ruc_cliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruc_cliente.Location = new System.Drawing.Point(177, 76);
            this.txt_ruc_cliente.Name = "txt_ruc_cliente";
            this.txt_ruc_cliente.Size = new System.Drawing.Size(338, 27);
            this.txt_ruc_cliente.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dirección Cliente";
            // 
            // txt_direccion_cliente
            // 
            this.txt_direccion_cliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_direccion_cliente.Location = new System.Drawing.Point(177, 112);
            this.txt_direccion_cliente.Name = "txt_direccion_cliente";
            this.txt_direccion_cliente.Size = new System.Drawing.Size(338, 27);
            this.txt_direccion_cliente.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo de Servicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nombre de Servicio";
            // 
            // txt_nombre_Servicio
            // 
            this.txt_nombre_Servicio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre_Servicio.Location = new System.Drawing.Point(177, 184);
            this.txt_nombre_Servicio.Name = "txt_nombre_Servicio";
            this.txt_nombre_Servicio.Size = new System.Drawing.Size(338, 27);
            this.txt_nombre_Servicio.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Periodo del Servicio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(231, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "meses.";
            // 
            // nupd_periodo_de_servicio
            // 
            this.nupd_periodo_de_servicio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupd_periodo_de_servicio.Location = new System.Drawing.Point(177, 220);
            this.nupd_periodo_de_servicio.Name = "nupd_periodo_de_servicio";
            this.nupd_periodo_de_servicio.Size = new System.Drawing.Size(48, 27);
            this.nupd_periodo_de_servicio.TabIndex = 15;
            // 
            // dgv_informacion_locales
            // 
            this.dgv_informacion_locales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_informacion_locales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_informacion_locales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_informacion_locales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_nombre_local,
            this.c_direccion,
            this.header_btn_delete_row_dgv_Informacion_locales});
            this.dgv_informacion_locales.Location = new System.Drawing.Point(19, 284);
            this.dgv_informacion_locales.Name = "dgv_informacion_locales";
            this.dgv_informacion_locales.Size = new System.Drawing.Size(647, 253);
            this.dgv_informacion_locales.TabIndex = 16;
            this.dgv_informacion_locales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_informacion_locales_CellContentClick);
            this.dgv_informacion_locales.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_informacion_locales_CellEndEdit);
            this.dgv_informacion_locales.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_informacion_locales_CellValidating);
            this.dgv_informacion_locales.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_informacion_locales_RowValidating);
            // 
            // c_nombre_local
            // 
            this.c_nombre_local.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_nombre_local.FillWeight = 152.2843F;
            this.c_nombre_local.HeaderText = "Nombre Local";
            this.c_nombre_local.Name = "c_nombre_local";
            // 
            // c_direccion
            // 
            this.c_direccion.FillWeight = 89.53451F;
            this.c_direccion.HeaderText = "Dirección";
            this.c_direccion.Name = "c_direccion";
            // 
            // header_btn_delete_row_dgv_Informacion_locales
            // 
            this.header_btn_delete_row_dgv_Informacion_locales.FillWeight = 58.18122F;
            this.header_btn_delete_row_dgv_Informacion_locales.HeaderText = ".....";
            this.header_btn_delete_row_dgv_Informacion_locales.Name = "header_btn_delete_row_dgv_Informacion_locales";
            // 
            // cbx_tipo_servicio
            // 
            this.cbx_tipo_servicio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_tipo_servicio.FormattingEnabled = true;
            this.cbx_tipo_servicio.Items.AddRange(new object[] {
            "Servicio General de Limpiza",
            "Servicio de Fumigación",
            "Servicio de Desratización"});
            this.cbx_tipo_servicio.Location = new System.Drawing.Point(177, 148);
            this.cbx_tipo_servicio.Name = "cbx_tipo_servicio";
            this.cbx_tipo_servicio.Size = new System.Drawing.Size(338, 28);
            this.cbx_tipo_servicio.TabIndex = 9;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.Location = new System.Drawing.Point(505, 546);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(161, 28);
            this.btn_cancelar.TabIndex = 17;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_continuar
            // 
            this.btn_continuar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_continuar.Location = new System.Drawing.Point(351, 546);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(148, 28);
            this.btn_continuar.TabIndex = 18;
            this.btn_continuar.Text = "Continuar";
            this.btn_continuar.UseVisualStyleBackColor = true;
            this.btn_continuar.Click += new System.EventHandler(this.btn_continuar_Click);
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
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_nombre_Servicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_direccion_cliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ruc_cliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nombre_cliente);
            this.Controls.Add(this.label1);
            this.Name = "frm_01_1";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_direccion_cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_nombre_Servicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nupd_periodo_de_servicio;
        private System.Windows.Forms.DataGridView dgv_informacion_locales;
        private System.Windows.Forms.ComboBox cbx_tipo_servicio;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_continuar;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_nombre_local;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_direccion;
        private System.Windows.Forms.DataGridViewButtonColumn header_btn_delete_row_dgv_Informacion_locales;
    }
}