using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeAprendizaje
{
    public partial class FormEditarPerfil : Form
    {
        public FormEditarPerfil()
        {
            InitializeComponent();
        }

        public string CorreoElectronico { get; private set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public FormEditarPerfil(string correoElectronico, string nombreActual, string apellidoActual)
        {
            InitializeComponent();
            CorreoElectronico = correoElectronico;
            txtNombre.Text = nombreActual;
            txtApellido.Text = apellidoActual;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Nombre = txtNombre.Text;
            Apellido = txtApellido.Text;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Email", CorreoElectronico);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("La información se ha actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario con ese correo electrónico.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar la información: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
