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
    public partial class EvaluacionYPruebas : Form

    {
        private List<Pregunta> preguntas;
        private int preguntaActual;
        private int respuestasCorrectas;
        public EvaluacionYPruebas()

        {
            InitializeComponent();
            CargarPreguntas();
            MostrarPregunta();

        }
        private void CargarPreguntas()
        {
            preguntas = new List<Pregunta>
            {
                new Pregunta { Texto = "¿Cuál es la capital de Guatemala?", RespuestaCorrecta = "Ciudad de Guatemala" },
                new Pregunta { Texto = "¿Cuánto es 2 + 2?", RespuestaCorrecta = "4" },
                new Pregunta { Texto = "¿Cuál es el color del cielo?", RespuestaCorrecta = "Azul" }
            };
            preguntaActual = 0;
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
                txtRespuesta.Enabled = true;
                txtRespuesta.Focus();
            }
            else
            {
                lblPregunta.Text = "¡Examen terminado!";
                txtRespuesta.Enabled = false;
                btnEnviar.Enabled = false;
                btnSiguiente.Enabled = false;
                lblResultado.Text = "";
                MostrarPorcentaje();
            }
        }
        private void MostrarPorcentaje()
        {
            double porcentaje = ((double)respuestasCorrectas / preguntas.Count) * 100;
            lblResultado.Text = $"Tu porcentaje de respuestas correctas es: {porcentaje}%";
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
            btnEnviar.Enabled = false;
            btnSiguiente.Visible = true;
            txtRespuesta.Enabled = false;

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            preguntaActual++;
            MostrarPregunta();
        }
        public class Pregunta
        {
            public string Texto { get; set; }
            public string RespuestaCorrecta { get; set; }
        }

    }
}
