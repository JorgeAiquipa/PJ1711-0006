﻿namespace SGAP.FOLDER_FRMS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_continuar = new System.Windows.Forms.Button();
            this.dgv_entrada_datos_mano_de_obra = new System.Windows.Forms.DataGridView();
            this.cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_entrada = new SGAP.UserControls.GridTimeControl();
            this.hora_salida = new SGAP.UserControls.GridTimeControl();
            this.dias_x_semana = new SGAP.UserControls.NumericUpDownColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_entrada_datos_mano_de_obra)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Controls.Add(this.btn_continuar);
            this.panel2.Controls.Add(this.dgv_entrada_datos_mano_de_obra);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 374);
            this.panel2.TabIndex = 7;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancelar.Location = new System.Drawing.Point(482, 342);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_continuar
            // 
            this.btn_continuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_continuar.Location = new System.Drawing.Point(387, 342);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(75, 23);
            this.btn_continuar.TabIndex = 7;
            this.btn_continuar.Text = "Guardar";
            this.btn_continuar.UseVisualStyleBackColor = true;
            this.btn_continuar.Click += new System.EventHandler(this.btn_continuar_Click);
            // 
            // dgv_entrada_datos_mano_de_obra
            // 
            this.dgv_entrada_datos_mano_de_obra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_entrada_datos_mano_de_obra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_entrada_datos_mano_de_obra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cargo,
            this.hora_entrada,
            this.hora_salida,
            this.dias_x_semana});
            this.dgv_entrada_datos_mano_de_obra.Location = new System.Drawing.Point(0, 22);
            this.dgv_entrada_datos_mano_de_obra.Name = "dgv_entrada_datos_mano_de_obra";
            this.dgv_entrada_datos_mano_de_obra.RowHeadersWidth = 30;
            this.dgv_entrada_datos_mano_de_obra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_entrada_datos_mano_de_obra.Size = new System.Drawing.Size(569, 312);
            this.dgv_entrada_datos_mano_de_obra.TabIndex = 0;
            this.dgv_entrada_datos_mano_de_obra.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_entrada_datos_mano_de_obra_EditingControlShowing);
            // 
            // cargo
            // 
            this.cargo.HeaderText = "Tipo cargo";
            this.cargo.Name = "cargo";
            this.cargo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cargo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cargo.Width = 180;
            // 
            // hora_entrada
            // 
            this.hora_entrada.HeaderText = "Hora Entrada";
            this.hora_entrada.Name = "hora_entrada";
            this.hora_entrada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hora_entrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hora_entrada.Width = 120;
            // 
            // hora_salida
            // 
            this.hora_salida.HeaderText = "Hora Salida";
            this.hora_salida.Name = "hora_salida";
            this.hora_salida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hora_salida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hora_salida.Width = 120;
            // 
            // dias_x_semana
            // 
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            this.dias_x_semana.DefaultCellStyle = dataGridViewCellStyle2;
            this.dias_x_semana.HeaderText = "DxS";
            this.dias_x_semana.MinimumWidth = 80;
            this.dias_x_semana.Name = "dias_x_semana";
            this.dias_x_semana.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dias_x_semana.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dias_x_semana.Width = 116;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGreen;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(569, 22);
            this.label10.TabIndex = 6;
            this.label10.Text = "Ingreso de cargos y horarios.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_01_2_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 374);
            this.Controls.Add(this.panel2);
            this.Name = "frm_01_2_01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_01_2_01";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_entrada_datos_mano_de_obra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_continuar;
        private System.Windows.Forms.DataGridView dgv_entrada_datos_mano_de_obra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargo;
        private UserControls.GridTimeControl hora_entrada;
        private UserControls.GridTimeControl hora_salida;
        private UserControls.NumericUpDownColumn dias_x_semana;
        private System.Windows.Forms.Label label10;
    }
}