using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Asegúrate de agregar esta referencia

namespace SistemaDeAprendizaje
{
    public partial class FormAgregarCurso : Form
    {
        // Cadena de conexión a tu base de datos MySQL
        string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

        public FormAgregarCurso()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtNombreCurso.Clear();
            txtDescripcion.Clear();
            txtDuracion.Clear();
            txtInstructor.Clear();
            dateFechaInicio.Value = DateTime.Now;
            dateFechaFin.Value = DateTime.Now;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombreCurso = txtNombreCurso.Text;
            string descripcion = txtDescripcion.Text;
            string duracion = txtDuracion.Text;
            string instructor = txtInstructor.Text;
            DateTime fechaInicio = dateFechaInicio.Value;
            DateTime fechaFin = dateFechaFin.Value;

            // Insertar los datos en la tabla "Cursos"
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Cursos (NombreCurso, Descripcion, Duracion, Instructor, FechaInicio, FechaFin) " +
                               "VALUES (@NombreCurso, @Descripcion, @Duracion, @Instructor, @FechaInicio, @FechaFin)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@Duracion", duracion);
                command.Parameters.AddWithValue("@Instructor", instructor);
                command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@FechaFin", fechaFin);
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Curso agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpia los campos después de agregar el curso
            LimpiarCampos();
        }

        private void FormAgregarCurso_Load(object sender, EventArgs e)
        {

        }

    }
}
