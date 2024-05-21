using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeAprendizaje
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        public void SetPerfilNombre(string nombre)
        {
            lblPerfilNombre.Text = nombre;
        }

        public void SetPerfilApellido(string apellido)
        {
            lblPerfilApellido.Text = apellido;
        }

        public void SetPerfilCorreo(string correo)
        {
            lblPerfilCorreo.Text = correo;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtiene la ruta del archivo seleccionado
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Carga la imagen en la PictureBox
                        pictureBoxImage.Image = Image.FromFile(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    }
                }
            }
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de edición con los valores actuales
            FormEditarPerfil formEditar = new FormEditarPerfil(lblPerfilCorreo.Text, lblPerfilNombre.Text, lblPerfilApellido.Text);

            // Mostrar el formulario de edición y verificar si el usuario aceptó los cambios
            if (formEditar.ShowDialog() == DialogResult.OK)
            {
                // Actualizar las etiquetas con los nuevos valores
                lblPerfilNombre.Text = formEditar.Nombre;
                lblPerfilApellido.Text = formEditar.Apellido;

                // Aquí deberías agregar el código para actualizar la base de datos con los nuevos valores
                // ...
            }
        }
    }
}
