using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaDeAprendizaje
{
    public partial class EvaluacionYPruebas : Form
    {
        private List<Pregunta> preguntas;
        private int preguntaActual;
        private int respuestasCorrectas;
        private bool evaluacionTerminada = false;
        private string connectionString = "Server=bofn3obbnejxfyoheir1-mysql.services.clever-cloud.com;Database=bofn3obbnejxfyoheir1;User=uh4dunztmvwgo47z;Password=uyjiJZkG5JqLtaELmvku;Port=3306;SslMode=Preferred;";

        private string nombre;
        private string apellido;
        private string correo;
        private int cursoID;
        private bool esAdmin;
        private int usuarioID;

        public EvaluacionYPruebas(string nombre, string apellido, string correo, int cursoID, bool esAdmin, int usuarioID)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.cursoID = cursoID;
            this.esAdmin = esAdmin;
            this.usuarioID = usuarioID;

            if (esAdmin)
            {
                // Mostrar controles para agregar preguntas si el usuario es administrador
                pnlAdmin.Visible = true;
            }
            else
            {
                pnlAdmin.Visible = false;
            }

            if (EvaluacionCompletada())
            {
                lblEstado.Text = "Ya has completado esta evaluación.";
                lblEstado.ForeColor = System.Drawing.Color.Blue;
                lblPregunta.Visible = false;
                txtRespuesta.Visible = false;
                btnEnviar.Visible = false;
                btnSiguiente.Visible = false;
                btnTerminar.Visible = false;
            }
            else
            {
                CargarPreguntas();
                MostrarPregunta();
            }
        }

        private bool EvaluacionCompletada()
        {
            if (preguntas == null || preguntas.Count == 0)
            {
                return false;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Respuestas WHERE CursoID = @CursoID AND UsuarioID = @UsuarioID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoID", cursoID);
                command.Parameters.AddWithValue("@UsuarioID", usuarioID);

                connection.Open();
                int respuestasCount = Convert.ToInt32(command.ExecuteScalar());

                return respuestasCount >= preguntas.Count;
            }
        }

        private void CargarPreguntas()
        {
            preguntas = new List<Pregunta>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT PreguntaID, Texto, RespuestaCorrecta FROM Preguntas WHERE CursoID = @CursoID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoID", cursoID);

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        preguntas.Add(new Pregunta
                        {
                            PreguntaID = reader.GetInt32("PreguntaID"),
                            Texto = reader.GetString("Texto"),
                            RespuestaCorrecta = reader.GetString("RespuestaCorrecta")
                        });
                    }
                }
            }

            preguntaActual = 0;

            if (EvaluacionCompletada())
            {
                MostrarResultadoGuardado();
                lblEstado.Text = "Ya has completado esta evaluación.";
                lblEstado.ForeColor = System.Drawing.Color.Blue;
                lblPregunta.Visible = false;
                txtRespuesta.Visible = false;
                btnEnviar.Visible = false;
                btnSiguiente.Visible = false;
                btnTerminar.Visible = false;
            }
            else
            {
                MostrarPregunta();
            }
        }


        private void MostrarResultadoGuardado()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Porcentaje FROM Resultados WHERE CursoID = @CursoID AND UsuarioID = @UsuarioID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoID", cursoID);
                command.Parameters.AddWithValue("@UsuarioID", usuarioID);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    double porcentaje = Convert.ToDouble(result);
                    lblResultado.Text = $"Tu porcentaje de respuestas correctas es: {porcentaje:F2}%";
                    lblResultado.ForeColor = System.Drawing.Color.Black;
                }
            }
        }


        private void MostrarPregunta()
        {
            if (preguntaActual < preguntas.Count)
            {
                lblPregunta.Text = preguntas[preguntaActual].Texto;
                txtRespuesta.Clear();
                lblResultado.Text = "";
                btnEnviar.Enabled = true;
                btnSiguiente.Visible = false;
                btnTerminar.Visible = true;
                txtRespuesta.Enabled = true;
                txtRespuesta.Focus();
            }
            else
            {
                lblPregunta.Text = "¡Examen terminado!";
                txtRespuesta.Enabled = false;
                btnEnviar.Enabled = false;
                btnSiguiente.Enabled = false;
                btnTerminar.Enabled = false;
                lblResultado.Text = "";
                MostrarPorcentaje();
            }
        }

        private void MostrarPorcentaje()
        {
            double porcentaje = ((double)respuestasCorrectas / preguntas.Count) * 100;
            lblResultado.Text = $"Tu porcentaje de respuestas correctas es: {porcentaje:F2}%";
            lblResultado.ForeColor = System.Drawing.Color.Black;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string respuestaUsuario = txtRespuesta.Text.Trim();
            if (respuestaUsuario.Equals(preguntas[preguntaActual].RespuestaCorrecta, StringComparison.OrdinalIgnoreCase))
            {
                lblResultado.Text = "Correcto!";
                lblResultado.ForeColor = System.Drawing.Color.Green;
                respuestasCorrectas++;
            }
            else
            {
                lblResultado.Text = "Incorrecto!";
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }

            GuardarRespuesta(preguntas[preguntaActual].PreguntaID, respuestaUsuario);
            btnEnviar.Enabled = false;
            btnSiguiente.Visible = true;
            btnTerminar.Visible = true;
            txtRespuesta.Enabled = false;
        }

        private void GuardarRespuesta(int preguntaID, string respuestaUsuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Respuestas (CursoID, UsuarioID, PreguntaID, Respuesta) VALUES (@CursoID, @UsuarioID, @PreguntaID, @Respuesta)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoID", cursoID);
                command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                command.Parameters.AddWithValue("@PreguntaID", preguntaID);
                command.Parameters.AddWithValue("@Respuesta", respuestaUsuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            preguntaActual++;
            MostrarPregunta();
        }

        private void btnTerminar_Click_1(object sender, EventArgs e)
        {
            MostrarPorcentaje();
            GuardarResultado();
            lblPregunta.Text = "¡Examen terminado!";
            txtRespuesta.Enabled = false;
            btnEnviar.Enabled = false;
            btnSiguiente.Enabled = false;
            btnTerminar.Enabled = false;
        }

        private void btnAgregarPregunta_Click_1(object sender, EventArgs e)
        {
            string textoPregunta = txtNuevaPregunta.Text.Trim();
            string respuestaCorrecta = txtNuevaRespuesta.Text.Trim();

            if (string.IsNullOrEmpty(textoPregunta) || string.IsNullOrEmpty(respuestaCorrecta))
            {
                MessageBox.Show("Por favor, complete tanto la pregunta como la respuesta correcta.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Preguntas (CursoID, Texto, RespuestaCorrecta) VALUES (@CursoID, @Texto, @RespuestaCorrecta)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoID", cursoID);
                command.Parameters.AddWithValue("@Texto", textoPregunta);
                command.Parameters.AddWithValue("@RespuestaCorrecta", respuestaCorrecta);

                connection.Open();
                command.ExecuteNonQuery();
            }

            CargarPreguntas();
            MostrarPregunta();
            txtNuevaPregunta.Clear();
            txtNuevaRespuesta.Clear();
            MessageBox.Show("Pregunta agregada con éxito.");
        }

        private void GuardarResultado()
        {
            double porcentaje = ((double)respuestasCorrectas / preguntas.Count) * 100;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Resultados (CursoID, UsuarioID, Porcentaje, Fecha) VALUES (@CursoID, @UsuarioID, @Porcentaje, @Fecha)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CursoID", cursoID);
                command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                command.Parameters.AddWithValue("@Porcentaje", porcentaje);
                command.Parameters.AddWithValue("@Fecha", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public class Pregunta
        {
            public int PreguntaID { get; set; }
            public string Texto { get; set; }
            public string RespuestaCorrecta { get; set; }
        }

        private void txtNuevaRespuesta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
