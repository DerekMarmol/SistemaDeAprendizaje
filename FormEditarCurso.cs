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
    public partial class FormEditarCurso : Form
    {
        private int cursoID;
        private string connectionString;

        public FormEditarCurso(int cursoID, string connectionString)
        {
            InitializeComponent();
            this.cursoID = cursoID;
            this.connectionString = connectionString;
            CargarDetallesCurso();
        }

        private void CargarDetallesCurso()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT NombreCurso, Descripcion, Duracion, Instructor, FechaInicio, FechaFin FROM Cursos WHERE CursoID = @CursoID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoID", cursoID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombreCurso.Text = reader["NombreCurso"].ToString();
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                        txtDuracion.Text = reader["Duracion"].ToString();
                        txtInstructor.Text = reader["Instructor"].ToString();
                        dateFechaInicio.Value = Convert.ToDateTime(reader["FechaInicio"]);
                        dateFechaFin.Value = Convert.ToDateTime(reader["FechaFin"]);
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string nuevoNombreCurso = txtNombreCurso.Text;
            string nuevaDescripcion = txtDescripcion.Text;
            DateTime nuevaFechaInicio = dateFechaInicio.Value;
            DateTime nuevaFechaFin = dateFechaFin.Value;

            ActualizarCursoEnBaseDeDatos(cursoID, nuevoNombreCurso, nuevaDescripcion, nuevaFechaInicio, nuevaFechaFin);

            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarCursoEnBaseDeDatos(int cursoID, string nuevoNombre, string nuevaDescripcion, DateTime nuevaFechaInicio, DateTime nuevaFechaFin)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Cursos SET NombreCurso = @Nombre, Descripcion = @Descripcion, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE CursoID = @CursoID";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@CursoID", cursoID);
                updateCommand.Parameters.AddWithValue("@Nombre", nuevoNombre);
                updateCommand.Parameters.AddWithValue("@Descripcion", nuevaDescripcion);
                updateCommand.Parameters.AddWithValue("@FechaInicio", nuevaFechaInicio);
                updateCommand.Parameters.AddWithValue("@FechaFin", nuevaFechaFin);
                updateCommand.ExecuteNonQuery();
            }
        }


    }
}
