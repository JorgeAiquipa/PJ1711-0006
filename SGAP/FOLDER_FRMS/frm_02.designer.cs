﻿namespace SGAP.FORLDER_FRMS
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
            this.contextMenuStrip_tree_view = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStreep_Agregar_servicio_complementario = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.split_mano_obra = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_tree_view.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.split_mano_obra)).BeginInit();
            this.split_mano_obra.Panel1.SuspendLayout();
            this.split_mano_obra.Panel2.SuspendLayout();
            this.split_mano_obra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip_tree_view
            // 
            this.contextMenuStrip_tree_view.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStreep_Agregar_servicio_complementario,
            this.quitarServicioToolStripMenuItem});
            this.contextMenuStrip_tree_view.Name = "contextMenuStrip_tree_view";
            this.contextMenuStrip_tree_view.Size = new System.Drawing.Size(254, 48);
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
            // tree_view_servicios
            // 
            this.tree_view_servicios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tree_view_servicios.Location = new System.Drawing.Point(5, 5);
            this.tree_view_servicios.Name = "tree_view_servicios";
            this.tree_view_servicios.Size = new System.Drawing.Size(260, 427);
            this.tree_view_servicios.TabIndex = 0;
            this.tree_view_servicios.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_view_servicios_AfterSelect);
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
            this.panel1.Size = new System.Drawing.Size(591, 427);
            this.panel1.TabIndex = 2;
            // 
            // panPages
            // 
            this.panPages.Controls.Add(this.tabControl1);
            this.panPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPages.Location = new System.Drawing.Point(0, 0);
            this.panPages.Name = "panPages";
            this.panPages.Size = new System.Drawing.Size(587, 423);
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
            this.tabControl1.Size = new System.Drawing.Size(587, 423);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.split_mano_obra);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 391);
            this.panel2.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGreen;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(573, 22);
            this.label10.TabIndex = 6;
            this.label10.Text = "Page 1";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(579, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 391);
            this.panel3.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightGreen;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(573, 22);
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
            this.tabPage3.Size = new System.Drawing.Size(500, 360);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 333);
            this.panel4.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LightGreen;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(256, 22);
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
            this.tabPage4.Size = new System.Drawing.Size(500, 360);
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
            this.tabPage5.Size = new System.Drawing.Size(500, 360);
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
            this.tabPage6.Size = new System.Drawing.Size(500, 360);
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
            // split_mano_obra
            // 
            this.split_mano_obra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_mano_obra.Location = new System.Drawing.Point(0, 22);
            this.split_mano_obra.Name = "split_mano_obra";
            this.split_mano_obra.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_mano_obra.Panel1
            // 
            this.split_mano_obra.Panel1.Controls.Add(this.dataGridView1);
            // 
            // split_mano_obra.Panel2
            // 
            this.split_mano_obra.Panel2.Controls.Add(this.dataGridView2);
            this.split_mano_obra.Size = new System.Drawing.Size(573, 369);
            this.split_mano_obra.SplitterDistance = 182;
            this.split_mano_obra.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(573, 182);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(573, 183);
            this.dataGridView2.TabIndex = 0;
            // 
            // frm_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 435);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tree_view_servicios);
            this.Name = "frm_02";
            this.Text = "FRM_Cotizador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip_tree_view.ResumeLayout(false);
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
            this.split_mano_obra.Panel1.ResumeLayout(false);
            this.split_mano_obra.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_mano_obra)).EndInit();
            this.split_mano_obra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_tree_view;
        private System.Windows.Forms.ToolStripMenuItem toolStreep_Agregar_servicio_complementario;
        private System.Windows.Forms.ToolStripMenuItem quitarServicioToolStripMenuItem;
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
        private System.Windows.Forms.SplitContainer split_mano_obra;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}