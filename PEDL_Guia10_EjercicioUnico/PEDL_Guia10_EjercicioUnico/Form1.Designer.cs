namespace PEDL_Guia10_EjercicioUnico
{
    partial class Simulador
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoVerticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBArco = new System.Windows.Forms.ComboBox();
            this.CBVertice = new System.Windows.Forms.ComboBox();
            this.btnelimarco = new System.Windows.Forms.Button();
            this.btneliminarvertice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CBNodoPartida = new System.Windows.Forms.ComboBox();
            this.btnprofundidad = new System.Windows.Forms.Button();
            this.btnanchura = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtbuscarvert = new System.Windows.Forms.TextBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btndistancia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMSCrearVertice.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(463, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simulador de Grafos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pizarra
            // 
            this.Pizarra.BackColor = System.Drawing.SystemColors.Info;
            this.Pizarra.Location = new System.Drawing.Point(242, 66);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(819, 384);
            this.Pizarra.TabIndex = 1;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVerticeToolStripMenuItem});
            this.CMSCrearVertice.Name = "CMSCrearVertice";
            this.CMSCrearVertice.Size = new System.Drawing.Size(148, 26);
            this.CMSCrearVertice.Opening += new System.ComponentModel.CancelEventHandler(this.CMSCrearVertice_Opening);
            this.CMSCrearVertice.Click += new System.EventHandler(this.CMSCrearVertice_Click);
            // 
            // nuevoVerticeToolStripMenuItem
            // 
            this.nuevoVerticeToolStripMenuItem.Name = "nuevoVerticeToolStripMenuItem";
            this.nuevoVerticeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.nuevoVerticeToolStripMenuItem.Text = "Nuevo Vertice";
            this.nuevoVerticeToolStripMenuItem.Click += new System.EventHandler(this.nuevoVerticeToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBArco);
            this.groupBox2.Controls.Add(this.CBVertice);
            this.groupBox2.Controls.Add(this.btnelimarco);
            this.groupBox2.Controls.Add(this.btneliminarvertice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 118);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Función eliminar";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // CBArco
            // 
            this.CBArco.FormattingEnabled = true;
            this.CBArco.Location = new System.Drawing.Point(65, 73);
            this.CBArco.Name = "CBArco";
            this.CBArco.Size = new System.Drawing.Size(59, 21);
            this.CBArco.TabIndex = 7;
            // 
            // CBVertice
            // 
            this.CBVertice.FormattingEnabled = true;
            this.CBVertice.Location = new System.Drawing.Point(65, 39);
            this.CBVertice.Name = "CBVertice";
            this.CBVertice.Size = new System.Drawing.Size(59, 21);
            this.CBVertice.TabIndex = 6;
            // 
            // btnelimarco
            // 
            this.btnelimarco.Location = new System.Drawing.Point(132, 71);
            this.btnelimarco.Name = "btnelimarco";
            this.btnelimarco.Size = new System.Drawing.Size(75, 23);
            this.btnelimarco.TabIndex = 5;
            this.btnelimarco.Text = "Eliminar";
            this.btnelimarco.UseVisualStyleBackColor = true;
            this.btnelimarco.Click += new System.EventHandler(this.btnelimarco_Click);
            // 
            // btneliminarvertice
            // 
            this.btneliminarvertice.Location = new System.Drawing.Point(132, 37);
            this.btneliminarvertice.Name = "btneliminarvertice";
            this.btneliminarvertice.Size = new System.Drawing.Size(75, 23);
            this.btneliminarvertice.TabIndex = 4;
            this.btneliminarvertice.Text = "Eliminar";
            this.btneliminarvertice.UseVisualStyleBackColor = true;
            this.btneliminarvertice.Click += new System.EventHandler(this.btneliminarvertice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Arco:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Vertice:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CBNodoPartida);
            this.groupBox3.Controls.Add(this.btnprofundidad);
            this.groupBox3.Controls.Add(this.btnanchura);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 118);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recorridos";
            // 
            // CBNodoPartida
            // 
            this.CBNodoPartida.FormattingEnabled = true;
            this.CBNodoPartida.Location = new System.Drawing.Point(108, 39);
            this.CBNodoPartida.Name = "CBNodoPartida";
            this.CBNodoPartida.Size = new System.Drawing.Size(99, 21);
            this.CBNodoPartida.TabIndex = 8;
            // 
            // btnprofundidad
            // 
            this.btnprofundidad.Location = new System.Drawing.Point(19, 79);
            this.btnprofundidad.Name = "btnprofundidad";
            this.btnprofundidad.Size = new System.Drawing.Size(75, 23);
            this.btnprofundidad.TabIndex = 5;
            this.btnprofundidad.Text = "Profundidad";
            this.btnprofundidad.UseVisualStyleBackColor = true;
            this.btnprofundidad.Click += new System.EventHandler(this.btnprofundidad_Click);
            // 
            // btnanchura
            // 
            this.btnanchura.Location = new System.Drawing.Point(132, 79);
            this.btnanchura.Name = "btnanchura";
            this.btnanchura.Size = new System.Drawing.Size(75, 23);
            this.btnanchura.TabIndex = 4;
            this.btnanchura.Text = "Anchura";
            this.btnanchura.UseVisualStyleBackColor = true;
            this.btnanchura.Click += new System.EventHandler(this.btnanchura_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nodo de partida:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtbuscarvert);
            this.groupBox4.Controls.Add(this.btnbuscar);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(12, 323);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 91);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buscador";
            // 
            // txtbuscarvert
            // 
            this.txtbuscarvert.Location = new System.Drawing.Point(65, 39);
            this.txtbuscarvert.Name = "txtbuscarvert";
            this.txtbuscarvert.Size = new System.Drawing.Size(59, 20);
            this.txtbuscarvert.TabIndex = 10;
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(132, 37);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(75, 23);
            this.btnbuscar.TabIndex = 4;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Vertice:";
            // 
            // btndistancia
            // 
            this.btndistancia.Location = new System.Drawing.Point(77, 420);
            this.btndistancia.Name = "btndistancia";
            this.btndistancia.Size = new System.Drawing.Size(93, 30);
            this.btndistancia.TabIndex = 5;
            this.btndistancia.Text = "Distancia";
            this.btndistancia.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Click derecho para crear un Nodo";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 507);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btndistancia);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Pizarra);
            this.Controls.Add(this.label1);
            this.Name = "Simulador";
            this.Text = "Simulador de Grafos";
            this.Load += new System.EventHandler(this.Simulador_Load);
            this.CMSCrearVertice.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pizarra;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem nuevoVerticeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBArco;
        private System.Windows.Forms.ComboBox CBVertice;
        private System.Windows.Forms.Button btnelimarco;
        private System.Windows.Forms.Button btneliminarvertice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CBNodoPartida;
        private System.Windows.Forms.Button btnprofundidad;
        private System.Windows.Forms.Button btnanchura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtbuscarvert;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btndistancia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

