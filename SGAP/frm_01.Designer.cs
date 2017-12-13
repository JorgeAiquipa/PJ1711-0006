namespace SGAP
{
    partial class frm_01
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_cotizaciones = new System.Windows.Forms.DataGridView();
            this.c_numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_direccion_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_locales_Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_fecha_creacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_left = new System.Windows.Forms.Panel();
            this.pnl_filter_wraper = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_cd_close = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNuevoCotizacion = new System.Windows.Forms.Button();
            this.txt_cliente_or_ruc = new System.Windows.Forms.TextBox();
            this.chkb_estado_pendiente = new System.Windows.Forms.CheckBox();
            this.chkb_estado_cerrado = new System.Windows.Forms.CheckBox();
            this.chkb_estado_aprobado = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.dtp_fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_filtrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cotizaciones)).BeginInit();
            this.pnl_left.SuspendLayout();
            this.pnl_filter_wraper.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_cotizaciones
            // 
            this.dgv_cotizaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_cotizaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_cotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cotizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_numero,
            this.c_cliente,
            this.c_ruc,
            this.c_direccion_cliente,
            this.c_servicio,
            this.c_locales_Cant,
            this.c_fecha_creacion,
            this.c_estado,
            this.c_version});
            this.dgv_cotizaciones.Location = new System.Drawing.Point(262, 50);
            this.dgv_cotizaciones.Name = "dgv_cotizaciones";
            this.dgv_cotizaciones.Size = new System.Drawing.Size(681, 590);
            this.dgv_cotizaciones.TabIndex = 13;
            // 
            // c_numero
            // 
            this.c_numero.FillWeight = 126.5823F;
            this.c_numero.HeaderText = "#";
            this.c_numero.Name = "c_numero";
            this.c_numero.Width = 30;
            // 
            // c_cliente
            // 
            this.c_cliente.FillWeight = 265.9851F;
            this.c_cliente.HeaderText = "Cliente";
            this.c_cliente.Name = "c_cliente";
            this.c_cliente.Width = 300;
            // 
            // c_ruc
            // 
            this.c_ruc.FillWeight = 146.0292F;
            this.c_ruc.HeaderText = "RUC";
            this.c_ruc.Name = "c_ruc";
            this.c_ruc.Width = 120;
            // 
            // c_direccion_cliente
            // 
            this.c_direccion_cliente.FillWeight = 108.3648F;
            this.c_direccion_cliente.HeaderText = "Dirección Cliente";
            this.c_direccion_cliente.Name = "c_direccion_cliente";
            this.c_direccion_cliente.Width = 300;
            // 
            // c_servicio
            // 
            this.c_servicio.HeaderText = "Nombre de Servicio";
            this.c_servicio.Name = "c_servicio";
            this.c_servicio.Width = 300;
            // 
            // c_locales_Cant
            // 
            this.c_locales_Cant.FillWeight = 41.30978F;
            this.c_locales_Cant.HeaderText = "Cant Loc";
            this.c_locales_Cant.Name = "c_locales_Cant";
            // 
            // c_fecha_creacion
            // 
            this.c_fecha_creacion.FillWeight = 39.04712F;
            this.c_fecha_creacion.HeaderText = "Fec Crea";
            this.c_fecha_creacion.Name = "c_fecha_creacion";
            // 
            // c_estado
            // 
            this.c_estado.FillWeight = 37.14248F;
            this.c_estado.HeaderText = "Estado";
            this.c_estado.Name = "c_estado";
            this.c_estado.Width = 60;
            // 
            // c_version
            // 
            this.c_version.FillWeight = 35.53922F;
            this.c_version.HeaderText = "Version";
            this.c_version.Name = "c_version";
            this.c_version.Width = 120;
            // 
            // pnl_left
            // 
            this.pnl_left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_left.BackColor = System.Drawing.Color.White;
            this.pnl_left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_left.Controls.Add(this.btn_filtrar);
            this.pnl_left.Controls.Add(this.pnl_filter_wraper);
            this.pnl_left.Controls.Add(this.label2);
            this.pnl_left.Controls.Add(this.label7);
            this.pnl_left.Controls.Add(this.label6);
            this.pnl_left.Controls.Add(this.txt_cliente_or_ruc);
            this.pnl_left.Controls.Add(this.chkb_estado_pendiente);
            this.pnl_left.Controls.Add(this.chkb_estado_cerrado);
            this.pnl_left.Controls.Add(this.chkb_estado_aprobado);
            this.pnl_left.Controls.Add(this.label5);
            this.pnl_left.Controls.Add(this.dtp_fecha_fin);
            this.pnl_left.Controls.Add(this.dtp_fecha_inicio);
            this.pnl_left.Controls.Add(this.label3);
            this.pnl_left.Location = new System.Drawing.Point(0, 0);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(261, 640);
            this.pnl_left.TabIndex = 2;
            // 
            // pnl_filter_wraper
            // 
            this.pnl_filter_wraper.BackColor = System.Drawing.Color.Silver;
            this.pnl_filter_wraper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnl_filter_wraper.Controls.Add(this.label4);
            this.pnl_filter_wraper.Controls.Add(this.panel1);
            this.pnl_filter_wraper.Controls.Add(this.pnl_cd_close);
            this.pnl_filter_wraper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_filter_wraper.Location = new System.Drawing.Point(0, 0);
            this.pnl_filter_wraper.Name = "pnl_filter_wraper";
            this.pnl_filter_wraper.Size = new System.Drawing.Size(259, 50);
            this.pnl_filter_wraper.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.GhostWhite;
            this.label4.Location = new System.Drawing.Point(52, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "FILTROS";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SGAP.Properties.Resources.cd_icon_filter;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(30, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 14;
            // 
            // pnl_cd_close
            // 
            this.pnl_cd_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_cd_close.Location = new System.Drawing.Point(199, 0);
            this.pnl_cd_close.Name = "pnl_cd_close";
            this.pnl_cd_close.Size = new System.Drawing.Size(60, 50);
            this.pnl_cd_close.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(21, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filtro por Estado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(23, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha fin:";
            // 
            // btnNuevoCotizacion
            // 
            this.btnNuevoCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNuevoCotizacion.Location = new System.Drawing.Point(13, 12);
            this.btnNuevoCotizacion.Name = "btnNuevoCotizacion";
            this.btnNuevoCotizacion.Size = new System.Drawing.Size(149, 26);
            this.btnNuevoCotizacion.TabIndex = 1;
            this.btnNuevoCotizacion.Text = "Nueva Cotización";
            this.btnNuevoCotizacion.UseVisualStyleBackColor = true;
            this.btnNuevoCotizacion.Click += new System.EventHandler(this.btnNuevoCotizacion_Click);
            // 
            // txt_cliente_or_ruc
            // 
            this.txt_cliente_or_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txt_cliente_or_ruc.Location = new System.Drawing.Point(22, 90);
            this.txt_cliente_or_ruc.Name = "txt_cliente_or_ruc";
            this.txt_cliente_or_ruc.Size = new System.Drawing.Size(219, 20);
            this.txt_cliente_or_ruc.TabIndex = 4;
            this.txt_cliente_or_ruc.TextChanged += new System.EventHandler(this.txt_cliente_or_ruc_TextChanged);
            // 
            // chkb_estado_pendiente
            // 
            this.chkb_estado_pendiente.AutoSize = true;
            this.chkb_estado_pendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkb_estado_pendiente.ForeColor = System.Drawing.Color.Black;
            this.chkb_estado_pendiente.Location = new System.Drawing.Point(28, 316);
            this.chkb_estado_pendiente.Name = "chkb_estado_pendiente";
            this.chkb_estado_pendiente.Size = new System.Drawing.Size(79, 17);
            this.chkb_estado_pendiente.TabIndex = 11;
            this.chkb_estado_pendiente.Text = "Pendientes";
            this.chkb_estado_pendiente.UseVisualStyleBackColor = true;
            this.chkb_estado_pendiente.CheckedChanged += new System.EventHandler(this.chkb_estado_pendiente_CheckedChanged);
            // 
            // chkb_estado_cerrado
            // 
            this.chkb_estado_cerrado.AutoSize = true;
            this.chkb_estado_cerrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkb_estado_cerrado.ForeColor = System.Drawing.Color.Black;
            this.chkb_estado_cerrado.Location = new System.Drawing.Point(28, 293);
            this.chkb_estado_cerrado.Name = "chkb_estado_cerrado";
            this.chkb_estado_cerrado.Size = new System.Drawing.Size(68, 17);
            this.chkb_estado_cerrado.TabIndex = 10;
            this.chkb_estado_cerrado.Text = "Cerrados";
            this.chkb_estado_cerrado.UseVisualStyleBackColor = true;
            this.chkb_estado_cerrado.CheckedChanged += new System.EventHandler(this.chkb_estado_cerrado_CheckedChanged);
            // 
            // chkb_estado_aprobado
            // 
            this.chkb_estado_aprobado.AutoSize = true;
            this.chkb_estado_aprobado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkb_estado_aprobado.ForeColor = System.Drawing.Color.Black;
            this.chkb_estado_aprobado.Location = new System.Drawing.Point(28, 270);
            this.chkb_estado_aprobado.Name = "chkb_estado_aprobado";
            this.chkb_estado_aprobado.Size = new System.Drawing.Size(77, 17);
            this.chkb_estado_aprobado.TabIndex = 9;
            this.chkb_estado_aprobado.Text = "Aprobados";
            this.chkb_estado_aprobado.UseVisualStyleBackColor = true;
            this.chkb_estado_aprobado.CheckedChanged += new System.EventHandler(this.chkb_estado_aprobado_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha inicio:";
            // 
            // dtp_fecha_fin
            // 
            this.dtp_fecha_fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_fin.Location = new System.Drawing.Point(110, 188);
            this.dtp_fecha_fin.Name = "dtp_fecha_fin";
            this.dtp_fecha_fin.Size = new System.Drawing.Size(131, 20);
            this.dtp_fecha_fin.TabIndex = 7;
            // 
            // dtp_fecha_inicio
            // 
            this.dtp_fecha_inicio.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtp_fecha_inicio.CalendarTitleForeColor = System.Drawing.Color.DarkRed;
            this.dtp_fecha_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_inicio.Location = new System.Drawing.Point(110, 160);
            this.dtp_fecha_inicio.Name = "dtp_fecha_inicio";
            this.dtp_fecha_inicio.Size = new System.Drawing.Size(131, 20);
            this.dtp_fecha_inicio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(21, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filtro por Fecha";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNuevoCotizacion);
            this.panel2.Location = new System.Drawing.Point(261, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 50);
            this.panel2.TabIndex = 14;
            // 
            // btn_filtrar
            // 
            this.btn_filtrar.Location = new System.Drawing.Point(26, 366);
            this.btn_filtrar.Name = "btn_filtrar";
            this.btn_filtrar.Size = new System.Drawing.Size(75, 23);
            this.btn_filtrar.TabIndex = 18;
            this.btn_filtrar.Text = "Filtrar";
            this.btn_filtrar.UseVisualStyleBackColor = true;
            // 
            // frm_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 640);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_cotizaciones);
            this.Controls.Add(this.pnl_left);
            this.MinimumSize = new System.Drawing.Size(960, 600);
            this.Name = "frm_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cotizaciones)).EndInit();
            this.pnl_left.ResumeLayout(false);
            this.pnl_left.PerformLayout();
            this.pnl_filter_wraper.ResumeLayout(false);
            this.pnl_filter_wraper.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_cotizaciones;
        private System.Windows.Forms.Panel pnl_left;
        private System.Windows.Forms.TextBox txt_cliente_or_ruc;
        private System.Windows.Forms.CheckBox chkb_estado_pendiente;
        private System.Windows.Forms.CheckBox chkb_estado_cerrado;
        private System.Windows.Forms.CheckBox chkb_estado_aprobado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
        private System.Windows.Forms.DateTimePicker dtp_fecha_inicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNuevoCotizacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_filter_wraper;
        private System.Windows.Forms.Panel pnl_cd_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_ruc;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_direccion_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_locales_Cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_fecha_creacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_version;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_filtrar;
    }
}

