using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Asegúrate de agregar esta referencia

namespace SistemaDeAprendizaje
{
    public partial class FormCatalogoCursos : Form
    {
        // Cadena de conexión a tu base de datos MySQL
        string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

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
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT CursoID, NombreCurso, Descripcion, Duracion, Instructor, FechaInicio, FechaFin FROM Cursos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            // Abre el formulario para agregar un nuevo curso
            FormAgregarCurso formAgregarCurso = new FormAgregarCurso();
            formAgregarCurso.ShowDialog();

            // Actualiza los datos en el DataGridView después de agregar un curso
            CargarCursosEnDataGridView();
        }

        private void btnEditarCurso_Click(object sender, EventArgs e)
        {
            // Obtén el ID del curso seleccionado en el DataGridView
            int cursoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CursoID"].Value);

            // Abre el formulario para editar el curso con el ID correspondiente
            FormEditarCurso formEditarCurso = new FormEditarCurso(cursoID);
            formEditarCurso.ShowDialog();

            // Actualiza los datos en el DataGridView después de editar el curso
            CargarCursosEnDataGridView();
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            // Obtén el ID del curso seleccionado en el DataGridView
            int cursoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CursoID"].Value);

            // Elimina el curso con el ID correspondiente de la base de datos
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Cursos WHERE CursoID = @CursoID";
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@CursoID", cursoID);
                deleteCommand.ExecuteNonQuery();
            }

            // Actualiza los datos en el DataGridView después de eliminar el curso
            CargarCursosEnDataGridView();
        }
    }
}