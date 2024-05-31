using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormCalifYRetro : Form
    {
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

        public FormCalifYRetro()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarEstudiantes();
            CargarCursos();
            if (cmbEstudiante.SelectedItem != null)
            {
                int idEstudiante = ObtenerIdSeleccionado(cmbEstudiante.SelectedItem.ToString());
                MessageBox.Show("seleccionado " + idEstudiante);
                CargarCalificacionesEstudiante(idEstudiante);
            }
            else
            {
                MessageBox.Show("no hay seleccionado ");
            }
        }


        private void cmbEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Evento cmbEstudiante_SelectedIndexChanged disparado.");
            if (cmbEstudiante.SelectedItem != null)
            {
                int idEstudiante = ObtenerIdSeleccionado(cmbEstudiante.SelectedItem.ToString());
                CargarCalificacionesEstudiante(idEstudiante);
            }
        }

        private void CargarCalificacionesEstudiante(int idEstudiante)
        {
            MessageBox.Show("CargarCalificacionesEstudiante llamada con el ID de estudiante: " + idEstudiante);
            DataTable dtCalificaciones = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT CalificacionID, CursoID, Calificacion, Retroalimentacion FROM Calificaciones WHERE EstudianteID = @EstudianteID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EstudianteID", idEstudiante);
                    try
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dtCalificaciones);
                            dvgCalificaciones.DataSource = dtCalificaciones;
                        }
                        MessageBox.Show("se cargó la data del grid ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar las calificaciones del estudiante: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

            dvgCalificaciones.DataSource = dtCalificaciones;
        }


        private void CargarEstudiantes()
        {
            List<string> estudiantes = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, Nombre FROM Usuarios as Estudiantes";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                estudiantes.Add($"{reader.GetInt32("UsuarioID")} - {reader.GetString("Nombre")}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los estudiantes: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

            cmbEstudiante.DataSource = estudiantes;
        }

        private void CargarCursos()
        {
            List<string> cursos = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT CursoID, NombreCurso FROM Cursos";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cursos.Add($"{reader.GetInt32("CursoID")} - {reader.GetString("NombreCurso")}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los cursos: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

            cmbCursos.DataSource = cursos;
        }

        private int ObtenerIdSeleccionado(string seleccionado)
        {
            int idSelected = int.Parse(seleccionado.Split('-')[0].Trim());
            MessageBox.Show("Evento cmbEstudiante_SelectedIndexChanged disparado. " + idSelected);
            return idSelected;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedItem == null || cmbCursos.SelectedItem == null || string.IsNullOrEmpty(txtCalificacion.Text) || string.IsNullOrEmpty(txtRetroalimentacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            int idEstudiante = ObtenerIdSeleccionado(cmbEstudiante.SelectedItem.ToString());
            MessageBox.Show("ObtenerIdSeleccionado "+ idEstudiante );
            int idCurso = ObtenerIdSeleccionado(cmbCursos.SelectedItem.ToString());
            int calificacion;

            if (!int.TryParse(txtCalificacion.Text, out calificacion))
            {
                MessageBox.Show("Por favor, ingrese una calificación válida.");
                return;
            }

            string retroalimentacion = txtRetroalimentacion.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT CalificacionID FROM Calificaciones WHERE EstudianteID = @IdEstudiante AND CursoID = @CursoID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                    command.Parameters.AddWithValue("@CursoID", idCurso);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // Existe, actualizar
                            int calificacionID = Convert.ToInt32(result);
                            string updateQuery = "UPDATE Calificaciones SET Calificacion = @Calificacion, Retroalimentacion = @Retroalimentacion WHERE CalificacionID = @CalificacionID";
                            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Calificacion", calificacion);
                                updateCommand.Parameters.AddWithValue("@Retroalimentacion", retroalimentacion);
                                updateCommand.Parameters.AddWithValue("@CalificacionID", calificacionID);

                                int updateResult = updateCommand.ExecuteNonQuery();
                                if (updateResult > 0)
                                {
                                    MessageBox.Show("La calificación y retroalimentación se han actualizado correctamente.");
                                }
                                else
                                {
                                    MessageBox.Show("Error al actualizar la calificación y retroalimentación.");
                                }
                            }
                        }
                        else
                        {
                            // No existe, insertar
                            string insertQuery = "INSERT INTO Calificaciones (EstudianteID, CursoID, Calificacion, Retroalimentacion) VALUES (@IdEstudiante, @CursoID, @Calificacion, @Retroalimentacion)";
                            using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@IdEstudiante", idEstudiante);
                                insertCommand.Parameters.AddWithValue("@CursoID", idCurso);
                                insertCommand.Parameters.AddWithValue("@Calificacion", calificacion);
                                insertCommand.Parameters.AddWithValue("@Retroalimentacion", retroalimentacion);

                                int insertResult = insertCommand.ExecuteNonQuery();
                                if (insertResult > 0)
                                {
                                    MessageBox.Show("La calificación y retroalimentación se han guardado correctamente.");
                                }
                                else
                                {
                                    MessageBox.Show("Error al guardar la calificación y retroalimentación.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la calificación y retroalimentación: " + ex.Message);
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
