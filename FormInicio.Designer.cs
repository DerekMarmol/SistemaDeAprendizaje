namespace SistemaDeAprendizaje
{
    partial class FormInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVerCursosRegistrados = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCambiarImagen = new System.Windows.Forms.Button();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.lblInfoNombre = new System.Windows.Forms.Label();
            this.lblInfoApellido = new System.Windows.Forms.Label();
            this.lblInfoCorreo = new System.Windows.Forms.Label();
            this.lblPerfilNombre = new System.Windows.Forms.Label();
            this.lblPerfilApellido = new System.Windows.Forms.Label();
            this.lblPerfilCorreo = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnVerCursosRegistrados);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 426);
            this.panel1.TabIndex = 1;
            // 
            // btnVerCursosRegistrados
            // 
            this.btnVerCursosRegistrados.Location = new System.Drawing.Point(26, 391);
            this.btnVerCursosRegistrados.Name = "btnVerCursosRegistrados";
            this.btnVerCursosRegistrados.Size = new System.Drawing.Size(135, 23);
            this.btnVerCursosRegistrados.TabIndex = 11;
            this.btnVerCursosRegistrados.Text = "Ver Cursos Registrados";
            this.btnVerCursosRegistrados.UseVisualStyleBackColor = true;
            this.btnVerCursosRegistrados.Click += new System.EventHandler(this.btnVerCursosRegistrados_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Catalogo De Cursos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnCambiarImagen
            // 
            this.btnCambiarImagen.Location = new System.Drawing.Point(642, 157);
            this.btnCambiarImagen.Name = "btnCambiarImagen";
            this.btnCambiarImagen.Size = new System.Drawing.Size(122, 23);
            this.btnCambiarImagen.TabIndex = 2;
            this.btnCambiarImagen.Text = "Cambiar Imagen";
            this.btnCambiarImagen.UseVisualStyleBackColor = true;
            this.btnCambiarImagen.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInformacion
            // 
            this.lblInformacion.BackColor = System.Drawing.Color.Transparent;
            this.lblInformacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacion.Location = new System.Drawing.Point(311, 12);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(205, 43);
            this.lblInformacion.TabIndex = 3;
            this.lblInformacion.Text = "Información Personal";
            // 
            // lblInfoNombre
            // 
            this.lblInfoNombre.AutoSize = true;
            this.lblInfoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoNombre.Location = new System.Drawing.Point(222, 73);
            this.lblInfoNombre.Name = "lblInfoNombre";
            this.lblInfoNombre.Size = new System.Drawing.Size(76, 20);
            this.lblInfoNombre.TabIndex = 4;
            this.lblInfoNombre.Text = "Nombre:";
            // 
            // lblInfoApellido
            // 
            this.lblInfoApellido.AutoSize = true;
            this.lblInfoApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoApellido.Location = new System.Drawing.Point(222, 126);
            this.lblInfoApellido.Name = "lblInfoApellido";
            this.lblInfoApellido.Size = new System.Drawing.Size(78, 20);
            this.lblInfoApellido.TabIndex = 5;
            this.lblInfoApellido.Text = "Apellido:";
            // 
            // lblInfoCorreo
            // 
            this.lblInfoCorreo.AutoSize = true;
            this.lblInfoCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCorreo.Location = new System.Drawing.Point(222, 179);
            this.lblInfoCorreo.Name = "lblInfoCorreo";
            this.lblInfoCorreo.Size = new System.Drawing.Size(64, 20);
            this.lblInfoCorreo.TabIndex = 6;
            this.lblInfoCorreo.Text = "E-mail:";
            // 
            // lblPerfilNombre
            // 
            this.lblPerfilNombre.AccessibleName = "lblPerfilNombre";
            this.lblPerfilNombre.AutoSize = true;
            this.lblPerfilNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfilNombre.Location = new System.Drawing.Point(311, 73);
            this.lblPerfilNombre.Name = "lblPerfilNombre";
            this.lblPerfilNombre.Size = new System.Drawing.Size(0, 20);
            this.lblPerfilNombre.TabIndex = 7;
            this.lblPerfilNombre.Click += new System.EventHandler(this.lblPerfilNombre_Click);
            // 
            // lblPerfilApellido
            // 
            this.lblPerfilApellido.AutoSize = true;
            this.lblPerfilApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfilApellido.Location = new System.Drawing.Point(311, 131);
            this.lblPerfilApellido.Name = "lblPerfilApellido";
            this.lblPerfilApellido.Size = new System.Drawing.Size(0, 20);
            this.lblPerfilApellido.TabIndex = 8;
            // 
            // lblPerfilCorreo
            // 
            this.lblPerfilCorreo.AutoSize = true;
            this.lblPerfilCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfilCorreo.Location = new System.Drawing.Point(311, 179);
            this.lblPerfilCorreo.Name = "lblPerfilCorreo";
            this.lblPerfilCorreo.Size = new System.Drawing.Size(0, 20);
            this.lblPerfilCorreo.TabIndex = 9;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(235, 216);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(106, 23);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "Editar Información";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxImage.BackgroundImage")));
            this.pictureBoxImage.Location = new System.Drawing.Point(634, 12);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(145, 139);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblPerfilCorreo);
            this.Controls.Add(this.lblPerfilApellido);
            this.Controls.Add(this.lblPerfilNombre);
            this.Controls.Add(this.lblInfoCorreo);
            this.Controls.Add(this.lblInfoApellido);
            this.Controls.Add(this.lblInfoNombre);
            this.Controls.Add(this.lblInformacion);
            this.Controls.Add(this.btnCambiarImagen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCambiarImagen;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.Label lblInfoNombre;
        private System.Windows.Forms.Label lblInfoApellido;
        private System.Windows.Forms.Label lblInfoCorreo;
        private System.Windows.Forms.Label lblPerfilNombre;
        private System.Windows.Forms.Label lblPerfilApellido;
        private System.Windows.Forms.Label lblPerfilCorreo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVerCursosRegistrados;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}