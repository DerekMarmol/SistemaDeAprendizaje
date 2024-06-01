using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class CalifYRetro : Form
    {
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

        public CalifYRetro()
        {
            InitializeComponent();
            CargarEstudiantes();
            ConfigurarDataGridView();

            dtgCalificaciones.CellValueChanged += dtgCalificaciones_CellValueChanged;
            // buttonG.Click += buttonG_Click_1;
            // buttonAdd.Click += buttonAdd_Click;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarEstudiantes();

            if (ComboBox1.SelectedItem != null)
            {
                int idEstudiante = ObtenerIdSeleccionado(ComboBox1.SelectedItem.ToString());
                CargarCalificacionesEstudiante(idEstudiante);
            }
            else
            {
                MessageBox.Show("No hay ningún estudiante seleccionado.");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedItem != null)
            {
                int idEstudiante = ObtenerIdSeleccionado(ComboBox1.SelectedItem.ToString());
                CargarCalificacionesEstudiante(idEstudiante);
            }
        }

        private void CargarCalificacionesEstudiante(int idEstudiante)
        {
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
                                column.ReadOnly = true;
                            }

                            dtgCalificaciones.Columns["Calificacion"].ReadOnly = false;
                            dtgCalificaciones.Columns["Retroalimentacion"].ReadOnly = false;
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
            dtgCalificaciones.Columns["CalificacionID"].ReadOnly = true;
            dtgCalificaciones.Columns["CursoID"].ReadOnly = true;
        }

        private void CargarEstudiantes()
        {
            List<string> estudiantes = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, Nombre FROM Usuarios";
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
                        MessageBox.Show($"Se encontraron {estudiantes.Count} estudiantes.");
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
        }

        private int ObtenerIdSeleccionado(string seleccionado)
        {
            int idSelected = int.Parse(seleccionado.Split('-')[0].Trim());
            return idSelected;
        }

        private void ConfigurarDataGridView()
        {
            dtgCalificaciones.AllowUserToAddRows = true;
            dtgCalificaciones.AllowUserToDeleteRows = true;
            dtgCalificaciones.EditMode = DataGridViewEditMode.EditOnEnter;
            dtgCalificaciones.CellValueChanged += dtgCalificaciones_CellValueChanged;
        }

        private List<int> filasEditadas = new List<int>();
        private List<int> filasNuevas = new List<int>();

        private void dtgCalificaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dtgCalificaciones.Rows[e.RowIndex].IsNewRow)
            {
                int? calificacionID = dtgCalificaciones.Rows[e.RowIndex].Cells["CalificacionID"].Value as int?;
                if (calificacionID.HasValue)
                {
                    if (!filasEditadas.Contains(calificacionID.Value))
                    {
                        filasEditadas.Add(calificacionID.Value);
                    }
                }
                else
                {
                    if (!filasNuevas.Contains(e.RowIndex))
                    {
                        filasNuevas.Add(e.RowIndex);
                    }
                }
            }
        }

        private void buttonG_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Guardando...");
            if (ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (int calificacionID in filasEditadas)
                    {
                        // Si la lista de filas editadas contiene el ID de la calificación, entonces es una edición
                        string calificacion = ObtenerValorCelda(dtgCalificaciones, calificacionID, "Calificacion");
                        string retroalimentacion = ObtenerValorCelda(dtgCalificaciones, calificacionID, "Retroalimentacion");

                        ActualizarCalificacion(connection, calificacionID, calificacion, retroalimentacion);
                    }

                    foreach (int rowIndex in filasNuevas)
                    {
                        // Si la lista de filas nuevas contiene el índice de la fila, entonces es una nueva calificación
                        string calificacion = ObtenerValorCelda(dtgCalificaciones, rowIndex, "Calificacion");
                        string retroalimentacion = ObtenerValorCelda(dtgCalificaciones, rowIndex, "Retroalimentacion");
                        int idEstudiante = ObtenerIdSeleccionado(ComboBox1.SelectedItem.ToString());
                        int idCurso = Convert.ToInt32(ObtenerValorCelda(dtgCalificaciones, rowIndex, "CursoID"));

                        InsertarNuevaCalificacion(connection, idEstudiante, idCurso, calificacion, retroalimentacion);
                    }

                    MessageBox.Show("Se han actualizado correctamente.");
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

            // Limpiar las listas después de guardar
            filasEditadas.Clear();
            filasNuevas.Clear();
        }

        private string ObtenerValorCelda(DataGridView dataGridView, int rowIndex, string columnName)
        {
            DataGridViewRow row = dataGridView.Rows[rowIndex];
            return row.Cells[columnName].Value?.ToString() ?? string.Empty;
        }

        private void ActualizarCalificacion(MySqlConnection connection, int calificacionID, string calificacion, string retroalimentacion)
        {
            string updateQuery = "UPDATE Calificaciones SET Calificacion = @Calificacion, Retroalimentacion = @Retroalimentacion WHERE CalificacionID = @CalificacionID";
            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@Calificacion", calificacion);
                updateCommand.Parameters.AddWithValue("@Retroalimentacion", retroalimentacion);
                updateCommand.Parameters.AddWithValue("@CalificacionID", calificacionID);

                int updateResult = updateCommand.ExecuteNonQuery();
                if (updateResult <= 0)
                {
                    MessageBox.Show($"Error al actualizar la calificación y retroalimentación para CalificacionID: {calificacionID}.");
                }
            }
        }

        private void InsertarNuevaCalificacion(MySqlConnection connection, int idEstudiante, int idCurso, string calificacion, string retroalimentacion)
        {
            string insertQuery = "INSERT INTO Calificaciones (EstudianteID, CursoID, Calificacion, Retroalimentacion) VALUES (@EstudianteID, @CursoID, @Calificacion, @Retroalimentacion)";
            using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@EstudianteID", idEstudiante);
                insertCommand.Parameters.AddWithValue("@CursoID", idCurso);
                insertCommand.Parameters.AddWithValue("@Calificacion", calificacion);
                insertCommand.Parameters.AddWithValue("@Retroalimentacion", retroalimentacion);

                int insertResult = insertCommand.ExecuteNonQuery();
                if (insertResult <= 0)
                {
                    MessageBox.Show($"Error al guardar la calificación y retroalimentación para el estudiante {idEstudiante} y el curso {idCurso}.");
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estudiante antes de agregar una calificación.");
                return;
            }

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
                        return;
                    }
                }
            }

            // Crear el formulario dinámicamente
            Form selectCursoForm = new Form
            {
                Width = 300,
                Height = 150,
                Text = "Seleccionar Curso"
            };

            ComboBox comboBoxCursos = new ComboBox
            {
                DataSource = cursos,
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            selectCursoForm.Controls.Add(comboBoxCursos);

            Button buttonAceptar = new Button
            {
                Text = "Aceptar",
                Dock = DockStyle.Bottom
            };
            buttonAceptar.Click += (s, args) => selectCursoForm.DialogResult = DialogResult.OK;
            selectCursoForm.Controls.Add(buttonAceptar);

            if (selectCursoForm.ShowDialog() == DialogResult.OK)
            {
                string cursoSeleccionado = comboBoxCursos.SelectedItem.ToString();
                int idCurso = int.Parse(cursoSeleccionado.Split('-')[0].Trim());

                DataTable dt = dtgCalificaciones.DataSource as DataTable;
                if (dt != null)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["CursoID"] = idCurso;
                    dt.Rows.Add(newRow);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún curso. No se agregará una nueva calificación.");
            }
        }
    }
}
