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
    public partial class FormEditarCurso : Form
    {
        private int cursoID;

        public FormEditarCurso()
        {
            InitializeComponent();
        }

        public FormEditarCurso(int cursoID)
        {
            this.cursoID = cursoID;
        }
    }
}
