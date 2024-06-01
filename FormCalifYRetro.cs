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
<<<<<<< HEAD
            CargarEstudiantes();
            ConfigurarDataGridView();

            dtgCalificaciones.CellValueChanged += dtgCalificaciones_CellValueChanged;
            // buttonG.Click += buttonG_Click_1;
            // buttonAdd.Click += buttonAdd_Click;
=======
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.cursoID = cursoID;
            this.esAdmin = esAdmin;
            this.usuarioID = usuarioID;

            ConfigurarDataGridView();
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
                CargarCalificacionesEstudiante(idEstudiante);
            }
            else
            {
                MessageBox.Show("No hay ningún estudiante seleccionado.");
            }
=======
<<<<<<< HEAD
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
                CargarCalificacionesEstudiante(idEstudiante);
            }
>>>>>>> de11e688a46e8e946d86a7355981979769225927
        }


        private void cmbEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
            MessageBox.Show("Evento cmbEstudiante_SelectedIndexChanged disparado.");
            if (cmbEstudiante.SelectedItem != null)
=======
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
=======
<<<<<<< HEAD
<<<<<<< HEAD
            MessageBox.Show("CargarCalificacionesEstudiante llamada con el ID de estudiante: " + idEstudiante);
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
<<<<<<< HEAD
                                column.ReadOnly = true;
                            }

                            dtgCalificaciones.Columns["Calificacion"].ReadOnly = false;
                            dtgCalificaciones.Columns["Retroalimentacion"].ReadOnly = false;
=======
                                column.ReadOnly = !esAdmin; // Solo los administradores pueden editar
                            }
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
            dtgCalificaciones.Columns["CalificacionID"].ReadOnly = true;
            dtgCalificaciones.Columns["CursoID"].ReadOnly = true;
        }

=======
<<<<<<< HEAD
<<<<<<< HEAD

            dvgCalificaciones.DataSource = dtCalificaciones;
=======
>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
        }

=======
        }

>>>>>>> 048ae82d7766a8b38f4b7ec6792a047b16f50b2a
>>>>>>> de11e688a46e8e946d86a7355981979769225927
        private void CargarEstudiantes()
        {
            List<string> estudiantes = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
<<<<<<< HEAD
                string query = "SELECT UsuarioID, Nombre FROM Usuarios";
=======
                string query = "SELECT UsuarioID, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM Usuarios";
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
=======
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
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
            dtgCalificaciones.AllowUserToAddRows = true;
            dtgCalificaciones.AllowUserToDeleteRows = true;
=======
<<<<<<< HEAD
            if (cmbEstudiante.SelectedItem == null || cmbCursos.SelectedItem == null || string.IsNullOrEmpty(txtCalificacion.Text) || string.IsNullOrEmpty(txtRetroalimentacion.Text))
=======
            dtgCalificaciones.AllowUserToAddRows = false;
            dtgCalificaciones.AllowUserToDeleteRows = false;
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
<<<<<<< HEAD
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
=======
                    filasEditadas.Add(calificacionID);
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
<<<<<<< HEAD
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
=======
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
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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

<<<<<<< HEAD
            // Limpiar las listas después de guardar
=======
>>>>>>> de11e688a46e8e946d86a7355981979769225927
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
