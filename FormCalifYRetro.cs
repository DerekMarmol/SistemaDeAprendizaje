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
            //MessageBox.Show("Constructor FormCalifYRetro llamado.");
            CargarEstudiantes();

            ConfigurarDataGridView();
            dtgCalificaciones.CellValueChanged += dtgCalificaciones_CellValueChanged;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Form2_Load llamado.");
            CargarEstudiantes();

            if (ComboBox1.SelectedItem != null)
            {
                int idEstudiante = ObtenerIdSeleccionado(ComboBox1.SelectedItem.ToString());
                //MessageBox.Show("seleccionado " + idEstudiante);
                CargarCalificacionesEstudiante(idEstudiante);
            }
            else
            {
                MessageBox.Show("no hay seleccionado ");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("comboBox1_SelectedIndexChanged llamado.");
            if (ComboBox1.SelectedItem != null)
            {
                int idEstudiante = ObtenerIdSeleccionado(ComboBox1.SelectedItem.ToString());
                CargarCalificacionesEstudiante(idEstudiante);
            }
        }

        private void CargarCalificacionesEstudiante(int idEstudiante)
        {
            //MessageBox.Show($"CargarCalificacionesEstudiante llamado con idEstudiante: {idEstudiante}");
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

                            // Habilitar la edición en las columnas específicas
                            foreach (DataGridViewColumn column in dtgCalificaciones.Columns)
                            {
                                column.ReadOnly = true; // Deshabilitar edición para todas las columnas
                            }

                            dtgCalificaciones.Columns["Calificacion"].ReadOnly = false; // Habilitar edición para "Calificacion"
                            dtgCalificaciones.Columns["Retroalimentacion"].ReadOnly = false; // Habilitar edición para "Retroalimentacion"
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
            dtgCalificaciones.DataSource = dtCalificaciones;
            dtgCalificaciones.Columns["CalificacionID"].ReadOnly = true;
            dtgCalificaciones.Columns["CursoID"].ReadOnly = true;
        }


        private void CargarEstudiantes()
        {
            //MessageBox.Show("CargarEstudiantes llamado.");
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

            // Mensaje de depuración para verificar que se está llenando el ComboBox
            // MessageBox.Show($"ComboBox contiene {ComboBox1.Items.Count} ítems.");
        }

        private int ObtenerIdSeleccionado(string seleccionado)
        {
            //MessageBox.Show($"ObtenerIdSeleccionado llamado con seleccionado: {seleccionado}");
            int idSelected = int.Parse(seleccionado.Split('-')[0].Trim());
            return idSelected;
        }

        private void ConfigurarDataGridView()
        {
            dtgCalificaciones.AllowUserToAddRows = false;
            dtgCalificaciones.AllowUserToDeleteRows = false;
            dtgCalificaciones.EditMode = DataGridViewEditMode.EditOnEnter;
            dtgCalificaciones.CellValueChanged += dtgCalificaciones_CellValueChanged;
        }

        private List<int> filasEditadas = new List<int>();

        private void dtgCalificaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show($"CellValueChanged llamado en fila {e.RowIndex}, columna {e.ColumnIndex}");
            if (e.RowIndex >= 0 && !dtgCalificaciones.Rows[e.RowIndex].IsNewRow)
            {
                int calificacionID = Convert.ToInt32(dtgCalificaciones.Rows[e.RowIndex].Cells["CalificacionID"].Value);
                if (!filasEditadas.Contains(calificacionID))
                {
                    filasEditadas.Add(calificacionID);
                    MessageBox.Show($"Fila con CalificacionID {calificacionID} añadida a filas editadas.");
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
                        DataGridViewRow row = null;
                        foreach (DataGridViewRow r in dtgCalificaciones.Rows)
                        {
                            if (Convert.ToInt32(r.Cells["CalificacionID"].Value) == calificacionID)
                            {
                                row = r;
                                break;
                            }
                        }

                        if (row != null)
                        {
                            string calificacion = row.Cells["Calificacion"].Value.ToString();
                            string retroalimentacion = row.Cells["Retroalimentacion"].Value.ToString();
                            //MessageBox.Show($"Actualizando CalificacionID {calificacionID} con Calificacion {calificacion} y Retroalimentacion {retroalimentacion}.");

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

            // Limpia la lista de filas editadas después de guardar
            filasEditadas.Clear();
        }
    }
}
