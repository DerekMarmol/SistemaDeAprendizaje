using MySql.Data.MySqlClient;
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
    public partial class FormCrearGrupo : Form
    {
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";
        private int? grupoId; // Variable para almacenar el ID del grupo que se está editando

        public FormCrearGrupo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Lógica de edición ya está manejada en el método de guardar
            // Al buscar un grupo y encontrarlo, se puede editar y luego guardar.
            if (grupoId == null)
            {
                MessageBox.Show("Primero busque un grupo para editar.");
                return;
            }
            btnGuardar.PerformClick();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            grupoId = null; // Reiniciar la variable grupoId
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command;
                if (grupoId == null)
                {
                    // Insertar nuevo registro
                    string insertQuery = "INSERT INTO Grupos (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                    command = new MySqlCommand(insertQuery, connection);
                }
                else
                {
                    // Actualizar registro existente
                    string updateQuery = "UPDATE Grupos SET Nombre = @Nombre, Descripcion = @Descripcion WHERE GrupoID = @GrupoID";
                    command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@GrupoID", grupoId);
                }

                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show(grupoId == null ? "Grupo guardado correctamente." : "Grupo actualizado correctamente.");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el grupo: " + ex.Message);
                }
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre del grupo para buscar.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT GrupoID, Nombre, Descripcion FROM Grupos WHERE Nombre = @Nombre";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            grupoId = reader.GetInt32("GrupoID");
                            txtNombre.Text = reader.GetString("Nombre");
                            txtDescripcion.Text = reader.GetString("Descripcion");
                            MessageBox.Show("Grupo encontrado. Ahora puede editar los datos.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un grupo con ese nombre.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el grupo: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAsignaGrupoProy frmAsignaGrupo = new FormAsignaGrupoProy();
            frmAsignaGrupo.Show();
        }
    }
}
