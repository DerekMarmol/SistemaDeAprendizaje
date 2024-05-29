namespace SistemaDeAprendizaje
{
    partial class FormEditarCurso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarCurso));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dateFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dateFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.txtInstructor = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreCurso = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Fecha De Finalización Del Curso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Fecha De Inicio Del Curso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Instructor Del Curso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Duración Del Curso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Descripción Del Curso";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(645, 188);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 23);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar Curso";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dateFechaFin
            // 
            this.dateFechaFin.Location = new System.Drawing.Point(324, 285);
            this.dateFechaFin.Name = "dateFechaFin";
            this.dateFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dateFechaFin.TabIndex = 19;
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.Location = new System.Drawing.Point(324, 232);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(199, 20);
            this.dateFechaInicio.TabIndex = 18;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(324, 144);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(156, 20);
            this.txtDuracion.TabIndex = 17;
            // 
            // txtInstructor
            // 
            this.txtInstructor.Location = new System.Drawing.Point(324, 188);
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.Size = new System.Drawing.Size(156, 20);
            this.txtInstructor.TabIndex = 16;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(324, 102);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(156, 20);
            this.txtDescripcion.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre Del Curso";
            // 
            // txtNombreCurso
            // 
            this.txtNombreCurso.Location = new System.Drawing.Point(324, 61);
            this.txtNombreCurso.Name = "txtNombreCurso";
            this.txtNombreCurso.Size = new System.Drawing.Size(156, 20);
            this.txtNombreCurso.TabIndex = 13;
            // 
            // FormEditarCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dateFechaFin);
            this.Controls.Add(this.dateFechaInicio);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.txtInstructor);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreCurso);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditarCurso";
            this.Text = "FormEditarCurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DateTimePicker dateFechaFin;
        private System.Windows.Forms.DateTimePicker dateFechaInicio;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.TextBox txtInstructor;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreCurso;
    }
}