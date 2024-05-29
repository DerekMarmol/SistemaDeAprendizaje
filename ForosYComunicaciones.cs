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
    public partial class ForosYComunicaciones : Form
    {
        public ForosYComunicaciones()
        {
            InitializeComponent();
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string opinion = txtOpinion.Text;

            // Validar que no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(opinion))
            {
                MessageBox.Show("Por favor, ingrese su nombre y opinión.");
                return;
            }

            // Formatear la opinión para mostrar en el ListBox
            string mensaje = $"{nombre}: {opinion}";

            // Agregar la opinión al ListBox
            lstOpiniones.Items.Add(mensaje);

            // Limpiar los TextBox
            txtNombre.Clear();
            txtOpinion.Clear();
        }
    }
}
