using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaDeAprendizaje
{
    public partial class FormCalifYRetro : Form
    {
        string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

        private string nombre;
        private string apellido;
        private string correo;
        private int cursoID;
        private bool esAdmin;
        private int usuarioID;

        public CalifYRetro(string nombre, string apellido, string correo, int cursoID, bool esAdmin, int usuarioID)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.cursoID = cursoID;
            this.esAdmin = esAdmin;
            this.usuarioID = usuarioID;

            ConfigurarDataGridView();
        }

        private void FormCalifYRetro_Load(object sender, EventArgs e)
        {
            CargarEstudiantes();
            CargarCursos();
            if (cmbEstudiante.SelectedItem != null)
            {
<<<<<<< HEAD
                int idEstudiante = ObtenerIdSeleccionado(cmbEstudiante.SelectedItem.ToString());
                MessageBox.Show("seleccionado " + idEstudiante);
=======
                int idEstudiante = ObtenerIdSeleccionado(ComboBox1.SelectedItem.ToString());
<<<<<<< HEAD
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
                CargarCalificacionesEstudiante(idEstudiante);
            }
        }


        private void cmbEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            MessageBox.Show("Evento cmbEstudiante_SelectedIndexChanged disparado.");
            if (cmbEstudiante.SelectedItem != null)
=======
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
            if (ComboBox1.SelectedItem != null)
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
            {
                int idEstudiante = ObtenerIdSeleccionado(cmbEstudiante.SelectedItem.ToString());
                CargarCalificacionesEstudiante(idEstudiante);
            }
        }

        private void CargarCalificacionesEstudiante(int idEstudiante)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            MessageBox.Show("CargarCalificacionesEstudiante llamada con el ID de estudiante: " + idEstudiante);
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
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
                            dtgCalificaciones.DataSource = dtCalificaciones;

                            foreach (DataGridViewColumn column in dtgCalificaciones.Columns)
                            {
                                column.ReadOnly = !esAdmin; // Solo los administradores pueden editar
                            }
                        }
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
<<<<<<< HEAD
<<<<<<< HEAD

            dvgCalificaciones.DataSource = dtCalificaciones;
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
        }

=======
        }

>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
        private void CargarEstudiantes()
        {
            List<string> estudiantes = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM Usuarios";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                estudiantes.Add($"{reader.GetInt32("UsuarioID")} - {reader.GetString("NombreCompleto")}");
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

            ComboBox1.DataSource = estudiantes;
<<<<<<< HEAD
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
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
        }

        private int ObtenerIdSeleccionado(string seleccionado)
        {
            int idSelected = int.Parse(seleccionado.Split('-')[0].Trim());
            MessageBox.Show("Evento cmbEstudiante_SelectedIndexChanged disparado. " + idSelected);
            return idSelected;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (cmbEstudiante.SelectedItem == null || cmbCursos.SelectedItem == null || string.IsNullOrEmpty(txtCalificacion.Text) || string.IsNullOrEmpty(txtRetroalimentacion.Text))
=======
            dtgCalificaciones.AllowUserToAddRows = false;
            dtgCalificaciones.AllowUserToDeleteRows = false;
            dtgCalificaciones.EditMode = DataGridViewEditMode.EditOnEnter;
            dtgCalificaciones.CellValueChanged += dtgCalificaciones_CellValueChanged;
        }

        private List<int> filasEditadas = new List<int>();

        private void dtgCalificaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dtgCalificaciones.Rows[e.RowIndex].IsNewRow)
            {
                int calificacionID = Convert.ToInt32(dtgCalificaciones.Rows[e.RowIndex].Cells["CalificacionID"].Value);
                if (!filasEditadas.Contains(calificacionID))
                {
                    filasEditadas.Add(calificacionID);
                }
            }
        }

        private void buttonG_Click_1(object sender, EventArgs e)
        {
            if (!esAdmin)
<<<<<<< HEAD
            {
                MessageBox.Show("No tienes permisos para guardar las calificaciones.");
=======
            {
                MessageBox.Show("No tienes permisos para guardar las calificaciones.");
                return;
            }

            if (ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estudiante.");
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
                return;
            }

            if (ComboBox1.SelectedItem == null)
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
            {
                MessageBox.Show("Por favor, seleccione un estudiante.");
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
<<<<<<< HEAD
                            // Existe, actualizar
                            int calificacionID = Convert.ToInt32(result);
=======
                            string calificacion = row.Cells["Calificacion"].Value.ToString();
                            string retroalimentacion = row.Cells["Retroalimentacion"].Value.ToString();

>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
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
                            }
                        }
                    }
                    MessageBox.Show("Las calificaciones y retroalimentaciones se han actualizado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar las calificaciones y retroalimentaciones: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            filasEditadas.Clear();
        }
    }
}
