using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormInicio : Form
    {
        private bool esAdmin;
        private int usuarioID;

        public FormInicio(bool isAdmin, int usuarioID)
        {
            InitializeComponent();
            this.esAdmin = isAdmin;
            this.usuarioID = usuarioID;
        }

        public FormInicio()
        {
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
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        Image imagenOriginal = Image.FromFile(filePath);
                        Image imagenRedimensionada = RedimensionarImagen(imagenOriginal, 150, 139);

                        pictureBoxImage.Image = imagenRedimensionada;

                        string rutaGuardado = Path.Combine(Application.StartupPath, "ImagenesPerfil");
                        if (!Directory.Exists(rutaGuardado))
                        {
                            Directory.CreateDirectory(rutaGuardado);
                        }

                        string rutaImagen = Path.Combine(rutaGuardado, $"{Guid.NewGuid()}.png");
                        imagenRedimensionada.Save(rutaImagen, System.Drawing.Imaging.ImageFormat.Png);

                        ActualizarImagenPerfilEnBaseDeDatos(lblPerfilCorreo.Text, rutaImagen);

                        MessageBox.Show("Imagen guardada y actualizada con éxito.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    }
                }
            }
        }

        private void ActualizarImagenPerfilEnBaseDeDatos(string correo, string rutaImagen)
        {
            string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET FotoPerfil = @FotoPerfil WHERE Email = @Email";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FotoPerfil", rutaImagen);
                    command.Parameters.AddWithValue("@Email", correo);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private Image RedimensionarImagen(Image imagenOriginal, int ancho, int alto)
        {
            Bitmap imagenRedimensionada = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(imagenRedimensionada))
            {
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return imagenRedimensionada;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormEditarPerfil formEditar = new FormEditarPerfil(lblPerfilCorreo.Text, lblPerfilNombre.Text, lblPerfilApellido.Text);

            if (formEditar.ShowDialog() == DialogResult.OK)
            {
                lblPerfilNombre.Text = formEditar.Nombre;
                lblPerfilApellido.Text = formEditar.Apellido;
            }
        }

        private void lblPerfilNombre_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormCatalogoCursos formCatalogo = new FormCatalogoCursos(esAdmin, usuarioID);
                formCatalogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnVerCursosRegistrados_Click(object sender, EventArgs e)
        {
            try
            {
                FormCursosRegistrados formCursosRegistrados = new FormCursosRegistrados(usuarioID);
                formCursosRegistrados.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnVerCursosRegistrados_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormCursosRegistrados formCursosRegistrados = new FormCursosRegistrados(usuarioID);
                formCursosRegistrados.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        internal void SetPerfilNombre(object value)
        {
            throw new NotImplementedException();
        }

        internal void SetPerfilCorreo(object value)
        {
            throw new NotImplementedException();
        }
    }
}
