using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormCursosRegistrados : Form
    {
        string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";
        private int usuarioID;

        public FormCursosRegistrados(int usuarioID)
        {
            InitializeComponent();
            this.usuarioID = usuarioID;
        }


        public FormCursosRegistrados()
        {
        }

        private void FormCursosRegistrados_Load(object sender, EventArgs e)
        {
            CargarCursosRegistradosEnDataGridView();
        }

        private void CargarCursosRegistradosEnDataGridView()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT c.CursoID, c.NombreCurso, c.Descripcion FROM Cursos c " + "INNER JOIN Inscripciones i ON c.CursoID = i.CursoID " + "WHERE i.UsuarioID = @UsuarioID";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@UsuarioID", usuarioID);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

    }
}
