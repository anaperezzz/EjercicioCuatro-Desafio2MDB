using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioCuatro
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnMantenimientoAlumnos_Click(object sender, EventArgs e)
        {
            FrmPrincipal formAlumnos = new FrmPrincipal();
            formAlumnos.ShowDialog(); // Abre la ventana de alumnos de forma modal
        }

        private void btnMantenimientoMaterias_Click(object sender, EventArgs e)
        {
            FrmMaterias formMaterias = new FrmMaterias();
            formMaterias.ShowDialog();
        }

        private void btnSalirApp_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Deseas salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
