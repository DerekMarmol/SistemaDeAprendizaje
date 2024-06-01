using System;
using System.Data;
using MySql.Data.MySqlClient;
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
            txtContraseña.PasswordChar = '*';

            lblNombre.BackColor = Color.Transparent;
            lblNombre.Parent = pictureBoxFondo;

            lblApellido.BackColor = Color.Transparent;
            lblApellido.Parent = pictureBoxFondo;

            lblEmail.BackColor = Color.Transparent;
            lblEmail.Parent = pictureBoxFondo;

            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Parent = pictureBoxFondo;
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!EsEmailValido(email))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.");
                return;
            }

            string contraseñaHash = BCrypt.Net.BCrypt.HashPassword(contraseña);

            string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string checkEmailQuery = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
                using (MySqlCommand checkEmailCommand = new MySqlCommand(checkEmailQuery, connection))
                {
                    checkEmailCommand.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    int count = Convert.ToInt32(checkEmailCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Este correo electrónico ya está registrado.");
                        return;
                    }
                }

                string query = "INSERT INTO Usuarios (Nombre, Apellido, Email, Contraseña, isAdmin) VALUES (@Nombre, @Apellido, @Email, @Contraseña, @IsAdmin)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseñaHash);
                    command.Parameters.AddWithValue("@IsAdmin", false);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario registrado con éxito");

                        if (connection.State == ConnectionState.Open)
                            connection.Close();

                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);

                        if (connection.State == ConnectionState.Open)
                            connection.Close();

                        return;
                    }
                }
            }
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string contraseñaIngresada = txtContraseña.Text;

            string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, Nombre, Apellido, Email, Contraseña, isAdmin FROM Usuarios WHERE Email = @Email";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string contraseñaHash = reader.GetString("Contraseña");
                                bool isAdmin = reader.GetBoolean("isAdmin");
                                int usuarioID = reader.GetInt32("UsuarioID");
                                string nombre = reader.GetString("Nombre");
                                string apellido = reader.GetString("Apellido");
                                string correo = reader.GetString("Email");

                                if (BCrypt.Net.BCrypt.Verify(contraseñaIngresada, contraseñaHash))
                                {
                                    MessageBox.Show("Inicio de sesión exitoso");
                                    this.Hide();

                                    FormInicio formInicio = new FormInicio(isAdmin, usuarioID, nombre, apellido, correo);
                                    formInicio.Show();
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

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxFondo_Click(object sender, EventArgs e)
        {

        }
    }
}
