﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormCatalogoCursos : Form
    {
        string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";
        private bool esAdmin;
        private int usuarioID;



        public FormCatalogoCursos(bool esAdmin, int usuarioID)
        {
            InitializeComponent();
            this.esAdmin = esAdmin;
            this.usuarioID = usuarioID;

            btnAgregarCurso.Visible = esAdmin;
            btnEditarCurso.Visible = esAdmin;
            btnEliminarCurso.Visible = esAdmin;
            btnAdministrarMateriales.Visible = esAdmin;
        }

        private void FormCatalogoCursos_Load(object sender, EventArgs e)
        {
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
            FormAgregarCurso formAgregarCurso = new FormAgregarCurso();
            if (formAgregarCurso.ShowDialog() == DialogResult.OK)
            {
                CargarCursosEnDataGridView();

                // Obtener lista de correos de los usuarios
                List<string> correos = ObtenerCorreosUsuarios();

                // Enviar correos
                foreach (var correo in correos)
                {
                    EmailHelper.EnviarCorreo(correo, "Nuevo Curso Agregado", "Se ha agregado un nuevo curso: " + formAgregarCurso.NombreCurso);
                }
            }
        }

        private List<string> ObtenerCorreosUsuarios()
        {
            List<string> correos = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Email FROM Usuarios";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            correos.Add(reader.GetString("Email"));
                        }
                    }
                }
            }

            return correos;
        }


        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            int cursoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CursoID"].Value);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Cursos WHERE CursoID = @CursoID";
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@CursoID", cursoID);
                deleteCommand.ExecuteNonQuery();
            }

            CargarCursosEnDataGridView();
        }

        private void btnEditarCurso_Click_1(object sender, EventArgs e)
        {
            int cursoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CursoID"].Value);

            FormEditarCurso formEditarCurso = new FormEditarCurso(cursoID, connectionString);
            formEditarCurso.ShowDialog();

            CargarCursosEnDataGridView();
        }

        private void btnRegistrarCurso_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cursoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CursoID"].Value);
                int usuarioID = this.usuarioID;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string checkInscripcionQuery = "SELECT COUNT(*) FROM Inscripciones WHERE UsuarioID = @UsuarioID AND CursoID = @CursoID";
                    using (MySqlCommand checkInscripcionCommand = new MySqlCommand(checkInscripcionQuery, connection))
                    {
                        checkInscripcionCommand.Parameters.AddWithValue("@UsuarioID", usuarioID);
                        checkInscripcionCommand.Parameters.AddWithValue("@CursoID", cursoID);

                        connection.Open();
                        int inscripcionExistente = Convert.ToInt32(checkInscripcionCommand.ExecuteScalar());

                        if (inscripcionExistente > 0)
                        {
                            MessageBox.Show("Ya estás inscrito en este curso.");
                            return;
                        }
                    }

                    string query = "INSERT INTO Inscripciones (UsuarioID, CursoID) VALUES (@UsuarioID, @CursoID)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                        command.Parameters.AddWithValue("@CursoID", cursoID);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Inscripción exitosa al curso.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al inscribirse al curso: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT Nombre, Apellido, Email FROM Usuarios WHERE UsuarioID = @UsuarioID";

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

        private void btnVerCursosRegistrados_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormCursosRegistrados formCursosRegistrados = new FormCursosRegistrados(usuarioID);
                formCursosRegistrados.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAdministrarMateriales_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int cursoID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CursoID"].Value);
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT Nombre, Apellido, Email FROM Usuarios WHERE UsuarioID = @UsuarioID";
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

                                FormAdministrarMateriales formAdministrarMateriales = new FormAdministrarMateriales(cursoID, esAdmin, usuarioID, nombre, apellido, correo);
                                formAdministrarMateriales.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos del usuario.");
                            }
                        }
                    }
                }
            }
        }
    }
}
