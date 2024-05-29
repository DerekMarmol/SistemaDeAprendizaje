namespace SistemaDeAprendizaje
{
    partial class FormCatalogoCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCatalogoCursos));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVerCursosRegistrados = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAgregarCurso = new System.Windows.Forms.Button();
            this.btnEditarCurso = new System.Windows.Forms.Button();
            this.btnEliminarCurso = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRegistrarCurso = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Catálogo De Cursos";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnVerCursosRegistrados);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(4, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 426);
            this.panel1.TabIndex = 2;
            // 
            // btnVerCursosRegistrados
            // 
            this.btnVerCursosRegistrados.Location = new System.Drawing.Point(6, 400);
            this.btnVerCursosRegistrados.Name = "btnVerCursosRegistrados";
            this.btnVerCursosRegistrados.Size = new System.Drawing.Size(135, 23);
            this.btnVerCursosRegistrados.TabIndex = 12;
            this.btnVerCursosRegistrados.Text = "Ver Cursos Registrados";
            this.btnVerCursosRegistrados.UseVisualStyleBackColor = true;
            this.btnVerCursosRegistrados.Click += new System.EventHandler(this.btnVerCursosRegistrados_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Perfil De Usuario";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAgregarCurso
            // 
            this.btnAgregarCurso.Location = new System.Drawing.Point(685, 94);
            this.btnAgregarCurso.Name = "btnAgregarCurso";
            this.btnAgregarCurso.Size = new System.Drawing.Size(103, 23);
            this.btnAgregarCurso.TabIndex = 3;
            this.btnAgregarCurso.Text = "Agregar Curso";
            this.btnAgregarCurso.UseVisualStyleBackColor = true;
            this.btnAgregarCurso.Click += new System.EventHandler(this.btnAgregarCurso_Click);
            // 
            // btnEditarCurso
            // 
            this.btnEditarCurso.Location = new System.Drawing.Point(685, 134);
            this.btnEditarCurso.Name = "btnEditarCurso";
            this.btnEditarCurso.Size = new System.Drawing.Size(103, 23);
            this.btnEditarCurso.TabIndex = 4;
            this.btnEditarCurso.Text = "Editar Curso";
            this.btnEditarCurso.UseVisualStyleBackColor = true;
            this.btnEditarCurso.Click += new System.EventHandler(this.btnEditarCurso_Click_1);
            // 
            // btnEliminarCurso
            // 
            this.btnEliminarCurso.Location = new System.Drawing.Point(685, 175);
            this.btnEliminarCurso.Name = "btnEliminarCurso";
            this.btnEliminarCurso.Size = new System.Drawing.Size(103, 23);
            this.btnEliminarCurso.TabIndex = 5;
            this.btnEliminarCurso.Text = "Eliminar Curso";
            this.btnEliminarCurso.UseVisualStyleBackColor = true;
            this.btnEliminarCurso.Click += new System.EventHandler(this.btnEliminarCurso_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(199, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(442, 327);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnRegistrarCurso
            // 
            this.btnRegistrarCurso.Location = new System.Drawing.Point(685, 217);
            this.btnRegistrarCurso.Name = "btnRegistrarCurso";
            this.btnRegistrarCurso.Size = new System.Drawing.Size(103, 23);
            this.btnRegistrarCurso.TabIndex = 7;
            this.btnRegistrarCurso.Text = "Registrarse";
            this.btnRegistrarCurso.UseVisualStyleBackColor = true;
            this.btnRegistrarCurso.Click += new System.EventHandler(this.btnRegistrarCurso_Click);
            // 
            // FormCatalogoCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistrarCurso);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnEliminarCurso);
            this.Controls.Add(this.btnEditarCurso);
            this.Controls.Add(this.btnAgregarCurso);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCatalogoCursos";
            this.Text = "FormCatalogoCursos";
            this.Load += new System.EventHandler(this.FormCatalogoCursos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregarCurso;
        private System.Windows.Forms.Button btnEditarCurso;
        private System.Windows.Forms.Button btnEliminarCurso;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegistrarCurso;
        private System.Windows.Forms.Button btnVerCursosRegistrados;
    }
}