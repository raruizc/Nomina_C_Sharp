namespace Nomina
{
    partial class Consultar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnfiltrar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtsep = new System.Windows.Forms.TextBox();
            this.dgvfiltrado = new System.Windows.Forms.DataGridView();
            this.dgvconsultar = new System.Windows.Forms.DataGridView();
            this.btndevolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcedula = new System.Windows.Forms.TextBox();
            this.btnconsultar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnivel = new System.Windows.Forms.TextBox();
            this.btnconsultarnivel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfiltrado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvconsultar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Teal;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.volverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.abrirToolStripMenuItem.Text = "Abrir Archivo";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // volverToolStripMenuItem
            // 
            this.volverToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            this.volverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.volverToolStripMenuItem.Text = "Volver";
            this.volverToolStripMenuItem.Click += new System.EventHandler(this.volverToolStripMenuItem_Click);
            // 
            // btnfiltrar
            // 
            this.btnfiltrar.Location = new System.Drawing.Point(304, 214);
            this.btnfiltrar.Name = "btnfiltrar";
            this.btnfiltrar.Size = new System.Drawing.Size(161, 23);
            this.btnfiltrar.TabIndex = 4;
            this.btnfiltrar.Text = "&Seleccionar Empleado";
            this.btnfiltrar.UseVisualStyleBackColor = true;
            this.btnfiltrar.Click += new System.EventHandler(this.btnfiltrar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(634, 214);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(125, 23);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "&Enviar para Calcular";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtsep
            // 
            this.txtsep.Location = new System.Drawing.Point(12, 319);
            this.txtsep.Name = "txtsep";
            this.txtsep.Size = new System.Drawing.Size(35, 20);
            this.txtsep.TabIndex = 7;
            this.txtsep.Text = ",";
            this.txtsep.Visible = false;
            // 
            // dgvfiltrado
            // 
            this.dgvfiltrado.AllowUserToAddRows = false;
            this.dgvfiltrado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvfiltrado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvfiltrado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvfiltrado.BackgroundColor = System.Drawing.Color.White;
            this.dgvfiltrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfiltrado.Location = new System.Drawing.Point(66, 259);
            this.dgvfiltrado.Name = "dgvfiltrado";
            this.dgvfiltrado.ReadOnly = true;
            this.dgvfiltrado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfiltrado.Size = new System.Drawing.Size(653, 54);
            this.dgvfiltrado.TabIndex = 14;
            // 
            // dgvconsultar
            // 
            this.dgvconsultar.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.dgvconsultar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvconsultar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvconsultar.BackgroundColor = System.Drawing.Color.White;
            this.dgvconsultar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvconsultar.Location = new System.Drawing.Point(66, 37);
            this.dgvconsultar.Name = "dgvconsultar";
            this.dgvconsultar.ReadOnly = true;
            this.dgvconsultar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvconsultar.Size = new System.Drawing.Size(653, 150);
            this.dgvconsultar.TabIndex = 15;
            // 
            // btndevolver
            // 
            this.btndevolver.Location = new System.Drawing.Point(481, 214);
            this.btndevolver.Name = "btndevolver";
            this.btndevolver.Size = new System.Drawing.Size(116, 23);
            this.btndevolver.TabIndex = 16;
            this.btndevolver.Text = "&Devolver Empleado";
            this.btndevolver.UseVisualStyleBackColor = true;
            this.btndevolver.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cedula";
            // 
            // txtcedula
            // 
            this.txtcedula.Location = new System.Drawing.Point(77, 197);
            this.txtcedula.Name = "txtcedula";
            this.txtcedula.Size = new System.Drawing.Size(100, 20);
            this.txtcedula.TabIndex = 18;
            // 
            // btnconsultar
            // 
            this.btnconsultar.Location = new System.Drawing.Point(194, 195);
            this.btnconsultar.Name = "btnconsultar";
            this.btnconsultar.Size = new System.Drawing.Size(75, 23);
            this.btnconsultar.TabIndex = 19;
            this.btnconsultar.Text = "&Consultar";
            this.btnconsultar.UseVisualStyleBackColor = true;
            this.btnconsultar.Click += new System.EventHandler(this.btnconsultar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nivel";
            // 
            // txtnivel
            // 
            this.txtnivel.Location = new System.Drawing.Point(77, 230);
            this.txtnivel.Name = "txtnivel";
            this.txtnivel.Size = new System.Drawing.Size(100, 20);
            this.txtnivel.TabIndex = 21;
            // 
            // btnconsultarnivel
            // 
            this.btnconsultarnivel.Location = new System.Drawing.Point(194, 228);
            this.btnconsultarnivel.Name = "btnconsultarnivel";
            this.btnconsultarnivel.Size = new System.Drawing.Size(75, 23);
            this.btnconsultarnivel.TabIndex = 22;
            this.btnconsultarnivel.Text = "&Consultar";
            this.btnconsultarnivel.UseVisualStyleBackColor = true;
            this.btnconsultarnivel.Click += new System.EventHandler(this.btnconsultarnivel_Click);
            // 
            // Consultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 342);
            this.Controls.Add(this.btnconsultarnivel);
            this.Controls.Add(this.txtnivel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnconsultar);
            this.Controls.Add(this.txtcedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndevolver);
            this.Controls.Add(this.dgvconsultar);
            this.Controls.Add(this.dgvfiltrado);
            this.Controls.Add(this.txtsep);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnfiltrar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Consultar";
            this.Text = ".::    Consultar Empleados    ::.";
            this.Load += new System.EventHandler(this.Consultar_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfiltrado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvconsultar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volverToolStripMenuItem;
        private System.Windows.Forms.Button btnfiltrar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtsep;
        private System.Windows.Forms.DataGridView dgvfiltrado;
        private System.Windows.Forms.DataGridView dgvconsultar;
        private System.Windows.Forms.Button btndevolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcedula;
        private System.Windows.Forms.Button btnconsultar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnivel;
        private System.Windows.Forms.Button btnconsultarnivel;
    }
}