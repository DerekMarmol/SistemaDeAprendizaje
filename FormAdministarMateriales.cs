﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormAdministrarMateriales : Form
    {
        private int cursoID;
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";
        private bool esAdmin;
        private int usuarioID;
        private string nombre;
        private string apellido;
        private string correo;
        private object nombreArchivo;

        public FormAdministrarMateriales(int cursoID, bool esAdmin, int usuarioID, string nombre, string apellido, string correo)
        {
            InitializeComponent();
            this.cursoID = cursoID;
            this.esAdmin = esAdmin;
            this.usuarioID = usuarioID;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            CargarMateriales();
            LlenarComboBoxTipoArchivo();
        }

        private void LlenarComboBoxTipoArchivo()
        {
            cboTipoArchivo.Items.Add("Documento");
            cboTipoArchivo.Items.Add("Presentación");
            cboTipoArchivo.Items.Add("Video");
            cboTipoArchivo.Items.Add("Otro");

            cboTipoArchivo.SelectedIndex = 0;
        }

        private void CargarMateriales()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT MaterialID, Nombre, Descripcion, TipoArchivo, RutaArchivo FROM Materiales WHERE CursoID = @CursoID";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@CursoID", cursoID);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
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

        private string ObtenerNombreCurso(int cursoID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT NombreCurso FROM Cursos WHERE CursoID = @CursoID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CursoID", cursoID);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : null;
                }
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string tipoArchivo = cboTipoArchivo.SelectedItem.ToString();
            string rutaArchivo = lblRutaArchivo.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Materiales (CursoID, TipoArchivo, Nombre, RutaArchivo) VALUES (@CursoID, @TipoArchivo, @Nombre, @RutaArchivo)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CursoID", cursoID);
                    command.Parameters.AddWithValue("@TipoArchivo", tipoArchivo);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@RutaArchivo", rutaArchivo);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Material agregado con éxito.");

                        List<string> correos = ObtenerCorreosUsuarios();

                        foreach (var correo in correos)
                        {
                            string nombreCurso = ObtenerNombreCurso(cursoID);
                            if (!string.IsNullOrEmpty(nombreCurso))
                            {
                                string mensaje = $"Se ha agregado un nuevo material para el curso '{nombreCurso}': {nombre}";
                                EmailHelper.EnviarCorreo(correo, "Nuevo Material Agregado", mensaje);
                            }
                        }

                        CargarMateriales();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar el material: " + ex.Message);
                    }
                }
            }
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblRutaArchivo.Text = openFileDialog.FileName;
                }
            }
        }

        private void FormAdministarMateriales_Load(object sender, EventArgs e)
        {
            
        }

        private void EliminarMaterial(int materialID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Materiales WHERE MaterialID = @MaterialID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaterialID", materialID);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Material eliminado con éxito.");
                        CargarMateriales();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el material: " + ex.Message);
                    }
                }
            }
        }

        private void btnEliminarMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int materialID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaterialID"].Value);

                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este material?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EliminarMaterial(materialID);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un material para eliminar.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cboTipoArchivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}