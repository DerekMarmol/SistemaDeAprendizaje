namespace SistemaDeAprendizaje
{
    partial class CalifYRetro
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgCalificaciones = new System.Windows.Forms.DataGridView();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonG = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Estudiante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 37);
            this.label1.TabIndex = 8;
            this.label1.Text = "Calificaciones y Retroalimentación";
            // 
            // dtgCalificaciones
            // 
            this.dtgCalificaciones.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dtgCalificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCalificaciones.GridColor = System.Drawing.Color.Thistle;
            this.dtgCalificaciones.Location = new System.Drawing.Point(126, 128);
            this.dtgCalificaciones.Name = "dtgCalificaciones";
            this.dtgCalificaciones.Size = new System.Drawing.Size(503, 150);
            this.dtgCalificaciones.TabIndex = 20;
            this.dtgCalificaciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCalificaciones_CellValueChanged);
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(222, 67);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(249, 21);
            this.ComboBox1.TabIndex = 21;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // buttonG
            // 
            this.buttonG.Location = new System.Drawing.Point(126, 345);
            this.buttonG.Name = "buttonG";
            this.buttonG.Size = new System.Drawing.Size(75, 23);
            this.buttonG.TabIndex = 22;
            this.buttonG.Text = "Guardar";
            this.buttonG.UseVisualStyleBackColor = true;
            this.buttonG.Click += new System.EventHandler(this.buttonG_Click_1);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(240, 345);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 23;
            this.buttonAdd.Text = "Agregar";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // CalifYRetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonG);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.dtgCalificaciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "CalifYRetro";
            this.Text = "FormCalifYRetro";
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgCalificaciones;
        private System.Windows.Forms.ComboBox ComboBox1;
        private System.Windows.Forms.Button buttonG;
        private System.Windows.Forms.Button buttonAdd;
    }
}