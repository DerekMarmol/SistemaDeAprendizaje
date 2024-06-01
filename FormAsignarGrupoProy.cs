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
    public partial class FormAsignaGrupoProy : Form
    {
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";
        public FormAsignaGrupoProy()
        {
            InitializeComponent();
        }

        private void FormCreacionProyectos_Load(object sender, EventArgs e)
        {
            CargarGrupos();
            CargarAlumnos();
            CargarAsignaciones();
        }

        private void CargarGrupos()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT GrupoID, Nombre FROM Grupos";
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dtGrupos = new DataTable();
                        dtGrupos.Load(reader);
                        comboBox1.DisplayMember = "Nombre";
                        comboBox1.ValueMember = "GrupoID";
                        comboBox1.DataSource = dtGrupos;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los grupos: " + ex.Message);
                }
            }
        }

        private void CargarAlumnos()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT UsuarioID, Nombre FROM Usuarios";
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dtAlumnos = new DataTable();
                        dtAlumnos.Load(reader);
                        comboBox2.DisplayMember = "Nombre";
                        comboBox2.ValueMember = "UsuarioID";
                        comboBox2.DataSource = dtAlumnos;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los alumnos: " + ex.Message);
                }
            }
        }


        private void CargarAsignaciones()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ag.AsignacionID, g.Nombre AS Grupo, u.Nombre AS Alumno FROM AsignacionGrupos ag " +
                               "JOIN Grupos g ON ag.GrupoID = g.GrupoID " +
                               "JOIN Usuarios u ON ag.EstudianteID = u.UsuarioID";
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dtAsignaciones = new DataTable();
                    adapter.Fill(dtAsignaciones);
                    dataGridView1.DataSource = dtAsignaciones;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las asignaciones: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un grupo y un alumno.");
                return;
            }

            int grupoId = Convert.ToInt32(comboBox1.SelectedValue);
            int alumnoId = Convert.ToInt32(comboBox2.SelectedValue);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO AsignacionGrupos (GrupoID, EstudianteID) VALUES (@GrupoID, @EstudianteID)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@GrupoID", grupoId);
                command.Parameters.AddWithValue("@EstudianteID", alumnoId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Alumno asignado al grupo correctamente.");
                    CargarAsignaciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asignar alumno al grupo: " + ex.Message);
                }
            }
        }


    }
}
