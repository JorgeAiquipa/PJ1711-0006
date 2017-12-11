namespace SGAP.FORLDER_FRMS
{
    partial class frm_02
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
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_tree_view = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStreep_Agregar_servicio_complementario = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_tree_view.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(275, 366);
            this.treeView1.TabIndex = 0;
            // 
            // contextMenuStrip_tree_view
            // 
            this.contextMenuStrip_tree_view.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStreep_Agregar_servicio_complementario,
            this.quitarServicioToolStripMenuItem});
            this.contextMenuStrip_tree_view.Name = "contextMenuStrip_tree_view";
            this.contextMenuStrip_tree_view.Size = new System.Drawing.Size(254, 70);
            // 
            // toolStreep_Agregar_servicio_complementario
            // 
            this.toolStreep_Agregar_servicio_complementario.Name = "toolStreep_Agregar_servicio_complementario";
            this.toolStreep_Agregar_servicio_complementario.Size = new System.Drawing.Size(253, 22);
            this.toolStreep_Agregar_servicio_complementario.Text = "Agregar Servicio Complementario";
            this.toolStreep_Agregar_servicio_complementario.Click += new System.EventHandler(this.toolStreep_Agregar_servicio_complementario_Click);
            // 
            // quitarServicioToolStripMenuItem
            // 
            this.quitarServicioToolStripMenuItem.Name = "quitarServicioToolStripMenuItem";
            this.quitarServicioToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.quitarServicioToolStripMenuItem.Text = "Quitar Servicio";
            // 
            // FRM_Cotizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 366);
            this.Controls.Add(this.treeView1);
            this.Name = "FRM_Cotizador";
            this.Text = "FRM_Cotizador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip_tree_view.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_tree_view;
        private System.Windows.Forms.ToolStripMenuItem toolStreep_Agregar_servicio_complementario;
        private System.Windows.Forms.ToolStripMenuItem quitarServicioToolStripMenuItem;
    }
}