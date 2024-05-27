using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaDeAprendizaje
{
    public partial class FormCatalogoCursos : Form
    {
        // Cadena de conexión a tu base de datos MySQL
        string connectionString = "Server=your_server;Database=your_database;Uid=your_username;Pwd=your_password;";

        public FormCatalogoCursos()
        {
            InitializeComponent();
        }

        private void FormCatalogoCursos_Load(object sender, EventArgs e)
        {
            // Cargar los datos de la tabla de cursos en el DataGridView al cargar el formulario
            CargarCursosEnDataGridView();
        }

        private void CargarCursosEnDataGridView()
        {
            // Consulta SQL para seleccionar todos los cursos
            string query = "SELECT * FROM Cursos";

            // Crear un DataTable para almacenar los datos de la consulta
            DataTable dataTable = new DataTable();

            // Crear una conexión y un adaptador de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                try
                {
                    // Abrir la conexión y llenar el DataTable con los datos de la consulta
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error que ocurra durante la consulta
                    MessageBox.Show("Error al cargar los cursos: " + ex.Message);
                }
            }

            // Enlazar el DataTable al DataGridView
            dataGridViewCursos.DataSource = dataTable;
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            // Abrir el formulario para agregar un nuevo curso
            FormAgregarEditarCurso formAgregarCurso = new FormAgregarEditarCurso();
            if (formAgregarCurso.ShowDialog() == DialogResult.OK)
            {
                // Recargar los datos en el DataGridView después de agregar el curso
                CargarCursosEnDataGridView();
            }
        }

        private void btnEditarCurso_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un curso en el DataGridView
            if (dataGridViewCursos.SelectedRows.Count > 0)
            {
                // Obtener el ID del curso seleccionado
                int cursoID = Convert.ToInt32(dataGridViewCursos.SelectedRows[0].Cells["CursoID"].Value);

                // Abrir el formulario para editar el curso seleccionado
                FormAgregarEditarCurso formEditarCurso = new FormAgregarEditarCurso(cursoID);
                if (formEditarCurso.ShowDialog() == DialogResult.OK)
                {
                    // Recargar los datos en el DataGridView después de editar el curso
                    CargarCursosEnDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un curso para editar.");
            }
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado un curso en el DataGridView
            if (dataGridViewCursos.SelectedRows.Count > 0)
            {
                // Obtener el ID del curso seleccionado
                int cursoID = Convert.ToInt32(dataGridViewCursos.SelectedRows[0].Cells["CursoID"].Value);

                // Confirmar la eliminación con un mensaje al usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este curso?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Ejecutar la consulta para eliminar el curso de la base de datos
                    string query = "DELETE FROM Cursos WHERE CursoID = @CursoID";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CursoID", cursoID);
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Curso eliminado correctamente.");
                            // Recargar los datos en el DataGridView después de eliminar el curso
                            CargarCursosEnDataGridView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al eliminar el curso: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un curso para eliminar.");
            }
        }

        private void dataGridViewCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Puedes manejar eventos en el DataGridView si es necesario
        }
    }
}
