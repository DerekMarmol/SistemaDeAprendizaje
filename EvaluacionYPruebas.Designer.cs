namespace SistemaDeAprendizaje
{
    partial class EvaluacionYPruebas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvaluacionYPruebas));
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnAgregarPregunta = new System.Windows.Forms.Button();
            this.txtNuevaRespuesta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNuevaPregunta = new System.Windows.Forms.Label();
            this.txtNuevaPregunta = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Location = new System.Drawing.Point(358, 273);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(113, 23);
            this.btnSiguiente.TabIndex = 7;
            this.btnSiguiente.Text = "Siguiente Pregunta";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblPregunta
            // 
            this.lblPregunta.Location = new System.Drawing.Point(346, 118);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(125, 24);
            this.lblPregunta.TabIndex = 10;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblResultado.Location = new System.Drawing.Point(12, 129);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(55, 13);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "Resultado";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Location = new System.Drawing.Point(358, 217);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(113, 23);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar Respuesta";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtRespuesta.Location = new System.Drawing.Point(177, 154);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(461, 20);
            this.txtRespuesta.TabIndex = 8;
            this.txtRespuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.btnTerminar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pnlAdmin);
            this.panel1.Controls.Add(this.lblPregunta);
            this.panel1.Controls.Add(this.lblResultado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 10;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(406, 299);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 15;
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Location = new System.Drawing.Point(349, 321);
            this.btnTerminar.Margin = new System.Windows.Forms.Padding(0);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(130, 23);
            this.btnTerminar.TabIndex = 14;
            this.btnTerminar.Text = "Terminar Evaluación";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click_1);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(4, 202);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 245);
            this.panel3.TabIndex = 12;
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Controls.Add(this.btnAgregarPregunta);
            this.pnlAdmin.Controls.Add(this.txtNuevaRespuesta);
            this.pnlAdmin.Controls.Add(this.label1);
            this.pnlAdmin.Controls.Add(this.lblNuevaPregunta);
            this.pnlAdmin.Controls.Add(this.txtNuevaPregunta);
            this.pnlAdmin.Location = new System.Drawing.Point(100, 12);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Size = new System.Drawing.Size(643, 103);
            this.pnlAdmin.TabIndex = 11;
            // 
            // btnAgregarPregunta
            // 
            this.btnAgregarPregunta.Location = new System.Drawing.Point(258, 77);
            this.btnAgregarPregunta.Name = "btnAgregarPregunta";
            this.btnAgregarPregunta.Size = new System.Drawing.Size(100, 23);
            this.btnAgregarPregunta.TabIndex = 4;
            this.btnAgregarPregunta.Text = "Agregar Pregunta";
            this.btnAgregarPregunta.UseVisualStyleBackColor = true;
            this.btnAgregarPregunta.Click += new System.EventHandler(this.btnAgregarPregunta_Click_1);
            // 
            // txtNuevaRespuesta
            // 
            this.txtNuevaRespuesta.Location = new System.Drawing.Point(3, 56);
            this.txtNuevaRespuesta.Name = "txtNuevaRespuesta";
            this.txtNuevaRespuesta.Size = new System.Drawing.Size(635, 20);
            this.txtNuevaRespuesta.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Respuesta Correcta";
            // 
            // lblNuevaPregunta
            // 
            this.lblNuevaPregunta.AutoSize = true;
            this.lblNuevaPregunta.Location = new System.Drawing.Point(270, 2);
            this.lblNuevaPregunta.Name = "lblNuevaPregunta";
            this.lblNuevaPregunta.Size = new System.Drawing.Size(85, 13);
            this.lblNuevaPregunta.TabIndex = 1;
            this.lblNuevaPregunta.Text = "Nueva Pregunta";
            // 
            // txtNuevaPregunta
            // 
            this.txtNuevaPregunta.Location = new System.Drawing.Point(3, 18);
            this.txtNuevaPregunta.Name = "txtNuevaPregunta";
            this.txtNuevaPregunta.Size = new System.Drawing.Size(635, 20);
            this.txtNuevaPregunta.TabIndex = 0;
            // 
            // EvaluacionYPruebas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EvaluacionYPruebas";
            this.Text = "EvaluacionYPruebas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAdmin.ResumeLayout(false);
            this.pnlAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAdmin;
        private System.Windows.Forms.TextBox txtNuevaPregunta;
        private System.Windows.Forms.Label lblNuevaPregunta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevaRespuesta;
        private System.Windows.Forms.Button btnAgregarPregunta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Label lblEstado;
    }
}