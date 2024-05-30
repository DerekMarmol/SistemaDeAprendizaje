using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormAdministrarMateriales : Form
    {
        private int cursoID;
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

        public FormAdministrarMateriales(int cursoID)
        {
            InitializeComponent();
            this.cursoID = cursoID;
            CargarMateriales();
            LlenarComboBoxTipoArchivo();
        }

        private void LlenarComboBoxTipoArchivo()
        {
            // Ejemplo de tipos de archivo, puedes ajustar estos valores según tus necesidades
            cboTipoArchivo.Items.Add("Documento");
            cboTipoArchivo.Items.Add("Presentación");
            cboTipoArchivo.Items.Add("Video");
            cboTipoArchivo.Items.Add("Otro");
            // Selecciona el primer ítem por defecto
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string tipoArchivo = cboTipoArchivo.SelectedItem.ToString();
            string rutaArchivo = lblRutaArchivo.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Materiales (CursoID, Nombre, Descripcion, TipoArchivo, RutaArchivo) VALUES (@CursoID, @Nombre, @Descripcion, @TipoArchivo, @RutaArchivo)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CursoID", cursoID);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Descripcion", descripcion);
                    command.Parameters.AddWithValue("@TipoArchivo", tipoArchivo);
                    command.Parameters.AddWithValue("@RutaArchivo", rutaArchivo);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Material agregado con éxito.");
                    CargarMateriales();
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
    }
}