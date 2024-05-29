using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormCursosRegistrados : Form
    {
        string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";
        private int usuarioID;

        public bool esAdmin { get; private set; }

        public FormCursosRegistrados(int usuarioID)
        {
            InitializeComponent();
            this.usuarioID = usuarioID;
        }


        public FormCursosRegistrados()
        {
        }

        private void FormCursosRegistrados_Load(object sender, EventArgs e)
        {
            CargarCursosRegistradosEnDataGridView();
        }

        private void CargarCursosRegistradosEnDataGridView()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT c.CursoID, c.NombreCurso, c.Descripcion FROM Cursos c " + "INNER JOIN Inscripciones i ON c.CursoID = i.CursoID " + "WHERE i.UsuarioID = @UsuarioID";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@UsuarioID", usuarioID);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT Nombre, Apellido, Email, isAdmin FROM Usuarios WHERE UsuarioID = @UsuarioID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);

                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombre = reader.GetString("Nombre");
                                string apellido = reader.GetString("Apellido");
                                string correo = reader.GetString("Email");
                                bool esAdmin = reader.GetBoolean("isAdmin");

                                this.Hide();
                                FormInicio formInicio = new FormInicio(esAdmin, usuarioID, nombre, apellido, correo);
                                formInicio.Show();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos del usuario.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void EliminarCursoInscrito(int cursoID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Inscripciones WHERE UsuarioID = @UsuarioID AND CursoID = @CursoID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    command.Parameters.AddWithValue("@CursoID", cursoID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Curso eliminado de la lista de inscripciones.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el curso de la lista de inscripciones: " + ex.Message);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int cursoID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CursoID"].Value);

                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este curso de tu lista de inscripciones?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EliminarCursoInscrito(cursoID);
                    CargarCursosRegistradosEnDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un curso para eliminar.");
            }
        }

    }
}
