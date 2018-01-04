namespace SGAP.comercial
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
            this.pnl_left = new System.Windows.Forms.Panel();
            this.btn_limpiar_filtro = new System.Windows.Forms.Button();
            this.btn_filtrar = new System.Windows.Forms.Button();
            this.pnl_filter_wraper = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_cd_close = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkb_estado_pendiente = new System.Windows.Forms.CheckBox();
            this.chkb_estado_cerrado = new System.Windows.Forms.CheckBox();
            this.chkb_estado_aprobado = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.dtp_fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNuevoCotizacion = new System.Windows.Forms.Button();
            this.listView_Cotizaciones = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_first_detail = new System.Windows.Forms.Panel();
            this.lbl_status = new System.Windows.Forms.Label();
            this.txt_cliente = new SGAP.UserControls.ControlTextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTimeControl1 = new SGAP.UserControls.GridTimeControl();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_left.SuspendLayout();
            this.pnl_filter_wraper.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_first_detail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_left
            // 
            this.pnl_left.BackColor = System.Drawing.Color.White;
            this.pnl_left.Controls.Add(this.txt_cliente);
            this.pnl_left.Controls.Add(this.btn_limpiar_filtro);
            this.pnl_left.Controls.Add(this.btn_filtrar);
            this.pnl_left.Controls.Add(this.pnl_filter_wraper);
            this.pnl_left.Controls.Add(this.label2);
            this.pnl_left.Controls.Add(this.label7);
            this.pnl_left.Controls.Add(this.label6);
            this.pnl_left.Controls.Add(this.chkb_estado_pendiente);
            this.pnl_left.Controls.Add(this.chkb_estado_cerrado);
            this.pnl_left.Controls.Add(this.chkb_estado_aprobado);
            this.pnl_left.Controls.Add(this.label5);
            this.pnl_left.Controls.Add(this.dtp_fecha_fin);
            this.pnl_left.Controls.Add(this.dtp_fecha_inicio);
            this.pnl_left.Controls.Add(this.label3);
            this.pnl_left.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnl_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_left.Location = new System.Drawing.Point(0, 0);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(254, 638);
            this.pnl_left.TabIndex = 2;
            // 
            // btn_limpiar_filtro
            // 
            this.btn_limpiar_filtro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_limpiar_filtro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_limpiar_filtro.Location = new System.Drawing.Point(137, 599);
            this.btn_limpiar_filtro.Name = "btn_limpiar_filtro";
            this.btn_limpiar_filtro.Size = new System.Drawing.Size(100, 26);
            this.btn_limpiar_filtro.TabIndex = 4;
            this.btn_limpiar_filtro.Text = "Quitar filtro";
            this.btn_limpiar_filtro.UseVisualStyleBackColor = true;
            this.btn_limpiar_filtro.Click += new System.EventHandler(this.btn_limpiar_filtro_Click);
            // 
            // btn_filtrar
            // 
            this.btn_filtrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_filtrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_filtrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_filtrar.Location = new System.Drawing.Point(18, 599);
            this.btn_filtrar.Name = "btn_filtrar";
            this.btn_filtrar.Size = new System.Drawing.Size(100, 26);
            this.btn_filtrar.TabIndex = 3;
            this.btn_filtrar.Text = " Filtrar";
            this.btn_filtrar.UseVisualStyleBackColor = true;
            this.btn_filtrar.Click += new System.EventHandler(this.btn_filtrar_Click);
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
            this.pnl_filter_wraper.Size = new System.Drawing.Size(254, 50);
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
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "FILTROS";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SGAP.Properties.Resources.filtro;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(30, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 14;
            // 
            // pnl_cd_close
            // 
            this.pnl_cd_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_cd_close.Location = new System.Drawing.Point(194, 0);
            this.pnl_cd_close.Name = "pnl_cd_close";
            this.pnl_cd_close.Size = new System.Drawing.Size(60, 50);
            this.pnl_cd_close.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(21, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filtro por estado";
            this.label2.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(23, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cliente - R.U.C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(40, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha fin:";
            // 
            // chkb_estado_pendiente
            // 
            this.chkb_estado_pendiente.AutoSize = true;
            this.chkb_estado_pendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkb_estado_pendiente.ForeColor = System.Drawing.Color.Black;
            this.chkb_estado_pendiente.Location = new System.Drawing.Point(28, 343);
            this.chkb_estado_pendiente.Name = "chkb_estado_pendiente";
            this.chkb_estado_pendiente.Size = new System.Drawing.Size(79, 17);
            this.chkb_estado_pendiente.TabIndex = 11;
            this.chkb_estado_pendiente.Text = "Pendientes";
            this.chkb_estado_pendiente.UseVisualStyleBackColor = true;
            this.chkb_estado_pendiente.Visible = false;
            // 
            // chkb_estado_cerrado
            // 
            this.chkb_estado_cerrado.AutoSize = true;
            this.chkb_estado_cerrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkb_estado_cerrado.ForeColor = System.Drawing.Color.Black;
            this.chkb_estado_cerrado.Location = new System.Drawing.Point(28, 320);
            this.chkb_estado_cerrado.Name = "chkb_estado_cerrado";
            this.chkb_estado_cerrado.Size = new System.Drawing.Size(68, 17);
            this.chkb_estado_cerrado.TabIndex = 10;
            this.chkb_estado_cerrado.Text = "Cerrados";
            this.chkb_estado_cerrado.UseVisualStyleBackColor = true;
            this.chkb_estado_cerrado.Visible = false;
            // 
            // chkb_estado_aprobado
            // 
            this.chkb_estado_aprobado.AutoSize = true;
            this.chkb_estado_aprobado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkb_estado_aprobado.ForeColor = System.Drawing.Color.Black;
            this.chkb_estado_aprobado.Location = new System.Drawing.Point(28, 297);
            this.chkb_estado_aprobado.Name = "chkb_estado_aprobado";
            this.chkb_estado_aprobado.Size = new System.Drawing.Size(77, 17);
            this.chkb_estado_aprobado.TabIndex = 9;
            this.chkb_estado_aprobado.Text = "Aprobados";
            this.chkb_estado_aprobado.UseVisualStyleBackColor = true;
            this.chkb_estado_aprobado.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(40, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
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
            this.dtp_fecha_fin.TabIndex = 2;
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
            this.dtp_fecha_inicio.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(23, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filtro por fecha de creación";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnNuevoCotizacion);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 50);
            this.panel2.TabIndex = 0;
            // 
            // btnNuevoCotizacion
            // 
            this.btnNuevoCotizacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNuevoCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoCotizacion.Location = new System.Drawing.Point(13, 12);
            this.btnNuevoCotizacion.Name = "btnNuevoCotizacion";
            this.btnNuevoCotizacion.Size = new System.Drawing.Size(141, 26);
            this.btnNuevoCotizacion.TabIndex = 0;
            this.btnNuevoCotizacion.Text = "Nueva cotización";
            this.btnNuevoCotizacion.UseVisualStyleBackColor = true;
            this.btnNuevoCotizacion.Click += new System.EventHandler(this.btnNuevoCotizacion_Click);
            // 
            // listView_Cotizaciones
            // 
            this.listView_Cotizaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Cotizaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_Cotizaciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_Cotizaciones.FullRowSelect = true;
            this.listView_Cotizaciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Cotizaciones.Location = new System.Drawing.Point(0, 53);
            this.listView_Cotizaciones.Margin = new System.Windows.Forms.Padding(0);
            this.listView_Cotizaciones.Name = "listView_Cotizaciones";
            this.listView_Cotizaciones.Size = new System.Drawing.Size(682, 558);
            this.listView_Cotizaciones.TabIndex = 0;
            this.listView_Cotizaciones.UseCompatibleStateImageBehavior = false;
            this.listView_Cotizaciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_Cotizaciones_KeyDown);
            this.listView_Cotizaciones.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Cotizaciones_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_left);
            this.splitContainer1.Panel1MinSize = 256;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.panel_first_detail);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.listView_Cotizaciones);
            this.splitContainer1.Panel2MinSize = 20;
            this.splitContainer1.Size = new System.Drawing.Size(944, 640);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // panel_first_detail
            // 
            this.panel_first_detail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_first_detail.BackColor = System.Drawing.Color.White;
            this.panel_first_detail.Controls.Add(this.lbl_status);
            this.panel_first_detail.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_first_detail.Location = new System.Drawing.Point(0, 611);
            this.panel_first_detail.Margin = new System.Windows.Forms.Padding(0);
            this.panel_first_detail.Name = "panel_first_detail";
            this.panel_first_detail.Size = new System.Drawing.Size(682, 27);
            this.panel_first_detail.TabIndex = 1;
            // 
            // lbl_status
            // 
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_status.Location = new System.Drawing.Point(483, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lbl_status.Size = new System.Drawing.Size(199, 27);
            this.lbl_status.TabIndex = 0;
            this.lbl_status.Text = "PreLoad";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_cliente
            // 
            this.txt_cliente.Location = new System.Drawing.Point(24, 97);
            this.txt_cliente.MaxLength = 500;
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.txt_cliente.PlaceHolderIcon = global::SGAP.Properties.Resources.cliente;
            this.txt_cliente.PlaceHolderIconAlignment = SGAP.UserControls.ContAlignment.Left;
            this.txt_cliente.PlaceHolderText = "Ingrese nombre de cliente  o R.U.C";
            this.txt_cliente.Size = new System.Drawing.Size(217, 20);
            this.txt_cliente.TabIndex = 0;
            this.txt_cliente.TextChanged += new System.EventHandler(this.txt_cliente_TextChanged);
            this.txt_cliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cliente_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TM39_ID";
            this.dataGridViewTextBoxColumn1.FillWeight = 126.5823F;
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TM19_DESCRIP2";
            this.dataGridViewTextBoxColumn2.FillWeight = 265.9851F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TM19_DESCRIP1";
            this.dataGridViewTextBoxColumn3.FillWeight = 146.0292F;
            this.dataGridViewTextBoxColumn3.HeaderText = "RUC";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TM39_DESCRIP";
            this.dataGridViewTextBoxColumn4.FillWeight = 108.3648F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Dirección Cliente";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 41.30978F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre de Servicio";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 300;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TM39_UCREA";
            this.dataGridViewTextBoxColumn6.FillWeight = 41.30978F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Cant Loc";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // gridTimeControl1
            // 
            this.gridTimeControl1.DataPropertyName = "TM39_FCREA";
            this.gridTimeControl1.FillWeight = 39.04712F;
            this.gridTimeControl1.HeaderText = "Fec Crea";
            this.gridTimeControl1.Name = "gridTimeControl1";
            this.gridTimeControl1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTimeControl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TM39_ST";
            this.dataGridViewTextBoxColumn7.FillWeight = 39.04712F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Fec Crea";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 37.14248F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 60;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 35.53922F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Version";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // frm_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 640);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(960, 600);
            this.Name = "frm_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de cotizaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_left.ResumeLayout(false);
            this.pnl_left.PerformLayout();
            this.pnl_filter_wraper.ResumeLayout(false);
            this.pnl_filter_wraper.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_first_detail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_left;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_filtrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private UserControls.GridTimeControl gridTimeControl1;
        private System.Windows.Forms.ListView listView_Cotizaciones;
        private System.Windows.Forms.Button btn_limpiar_filtro;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel_first_detail;
        private UserControls.ControlTextBox txt_cliente;
        private System.Windows.Forms.Label lbl_status;
    }
}

