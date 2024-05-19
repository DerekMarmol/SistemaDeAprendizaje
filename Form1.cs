using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using BCrypt.Net;


namespace SistemaDeAprendizaje
{
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string contraseña = BCrypt.Net.BCrypt.HashPassword(txtContraseña.Text);

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Verificar si el correo electrónico ya está registrado
                string checkEmailQuery = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
                using (SqlCommand checkEmailCommand = new SqlCommand(checkEmailQuery, connection))
                {
                    checkEmailCommand.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    int count = (int)checkEmailCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Este correo electrónico ya está registrado.");
                        return;
                    }
                }

                // Si no está registrado, proceder a registrar al nuevo usuario
                string query = "INSERT INTO Usuarios (Nombre, Apellido, Email, Contraseña) VALUES (@Nombre, @Apellido, @Email, @Contraseña)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario registrado con éxito");

                        // Cerrar conexión si es necesario
                        if (connection.State == ConnectionState.Open)
                            connection.Close();

                        return;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);

                        // Cerrar conexión si es necesario
                        if (connection.State == ConnectionState.Open)
                            connection.Close();

                        return;
                    }
                }
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string contraseñaIngresada = txtContraseña.Text;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Contraseña FROM Usuarios WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string contraseñaHash = reader.GetString(0);
                                if (BCrypt.Net.BCrypt.Verify(contraseñaIngresada, contraseñaHash))
                                {
                                    MessageBox.Show("Inicio de sesión exitoso");
                                }
                                else
                                {
                                    MessageBox.Show("Contraseña incorrecta. Por favor, inténtalo de nuevo.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No existe una cuenta con ese correo electrónico.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

    }
}
