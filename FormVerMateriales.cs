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
    public partial class FormVerMateriales : Form
    {
        private int cursoID;
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

        public FormVerMateriales(int cursoID)
        {
            InitializeComponent();
            this.cursoID = cursoID;
            CargarMateriales();
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

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string rutaArchivo = dataGridView1.SelectedRows[0].Cells["RutaArchivo"].Value.ToString();
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = System.IO.Path.GetFileName(rutaArchivo);
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.Copy(rutaArchivo, saveFileDialog.FileName);
                        MessageBox.Show("Archivo descargado con éxito.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un material para descargar.");
            }
        }
    }

}
