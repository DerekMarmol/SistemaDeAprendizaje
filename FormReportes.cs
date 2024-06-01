using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class FormReportes : Form
    {
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;Uid=uh4dunztmvwgo47z;Pwd=uyjiJZkG5JqLtaELmvku;";

        public FormReportes()
        {
            InitializeComponent();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            // Obtener los datos de la tabla de calificaciones
            DataTable dtCalificaciones = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT CursoID, AVG(Calificacion) AS Promedio FROM Calificaciones GROUP BY CursoID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dtCalificaciones);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos de calificaciones: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

            // Configurar el Chart
            chartReporte.Series.Clear();
            chartReporte.Series.Add("Promedio de Calificaciones");
            chartReporte.Series["Promedio de Calificaciones"].ChartType = SeriesChartType.Column;

            // Agregar datos al Chart
            foreach (DataRow row in dtCalificaciones.Rows)
            {
                string cursoID = row["CursoID"].ToString(); // Suponiendo que el ID del curso es una cadena
                double promedio = Convert.ToDouble(row["Promedio"]);
                chartReporte.Series["Promedio de Calificaciones"].Points.AddXY(cursoID, promedio);
            }
        }
    }
}
