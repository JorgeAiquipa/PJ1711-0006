namespace SGAP.comercial
{
    partial class frm_01_2_02
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_tipo = new System.Windows.Forms.ComboBox();
            this.cbx_servicio = new System.Windows.Forms.ComboBox();
            this.btn_continuar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.num_frecuencia = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_frecuencia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Servicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Frecuencia:";
            // 
            // cb_tipo
            // 
            this.cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipo.FormattingEnabled = true;
            this.cb_tipo.Location = new System.Drawing.Point(93, 42);
            this.cb_tipo.Name = "cb_tipo";
            this.cb_tipo.Size = new System.Drawing.Size(164, 21);
            this.cb_tipo.TabIndex = 0;
            this.cb_tipo.SelectedIndexChanged += new System.EventHandler(this.cb_tipo_SelectedIndexChanged);
            // 
            // cbx_servicio
            // 
            this.cbx_servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_servicio.FormattingEnabled = true;
            this.cbx_servicio.Location = new System.Drawing.Point(93, 79);
            this.cbx_servicio.Name = "cbx_servicio";
            this.cbx_servicio.Size = new System.Drawing.Size(164, 21);
            this.cbx_servicio.TabIndex = 1;
            // 
            // btn_continuar
            // 
            this.btn_continuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_continuar.Location = new System.Drawing.Point(93, 156);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(78, 23);
            this.btn_continuar.TabIndex = 3;
            this.btn_continuar.Text = "Aceptar";
            this.btn_continuar.UseVisualStyleBackColor = true;
            this.btn_continuar.Click += new System.EventHandler(this.btn_continuar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_cancelar.Location = new System.Drawing.Point(179, 156);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(78, 23);
            this.btn_cancelar.TabIndex = 4;
            this.btn_cancelar.Text = "Cancelar <esc>";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cada";
            // 
            // num_frecuencia
            // 
            this.num_frecuencia.Location = new System.Drawing.Point(128, 114);
            this.num_frecuencia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_frecuencia.Name = "num_frecuencia";
            this.num_frecuencia.Size = new System.Drawing.Size(44, 20);
            this.num_frecuencia.TabIndex = 2;
            this.num_frecuencia.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_frecuencia.ValueChanged += new System.EventHandler(this.num_frecuencia_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "meses";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGreen;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(271, 22);
            this.label10.TabIndex = 8;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_01_2_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 191);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num_frecuencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_continuar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.cbx_servicio);
            this.Controls.Add(this.cb_tipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_01_2_02";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar servicio";
            ((System.ComponentModel.ISupportInitialize)(this.num_frecuencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_tipo;
        private System.Windows.Forms.ComboBox cbx_servicio;
        private System.Windows.Forms.Button btn_continuar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_frecuencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
    }
}