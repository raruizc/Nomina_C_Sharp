using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea salir de la aplicación?", "Nomina", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (r == DialogResult.Yes)
            {
                Application.Exit();
                Close();
                this.Hide();
            }
        }

        private void asignaciónEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asignacion f4 = new Asignacion();

            f4.Show();
            this.Hide();
        }

        private void consultarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar f5 = new Consultar();
            f5.Show();
            this.Hide();
        }

        private void informaciónNominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculoNomina f6 = new CalculoNomina();
            f6.Show();
            this.Hide();
        }

        private void horasExtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Horas f7 = new Horas();
            f7.Show();
            this.Hide();
        }

        private void comprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comprobante f8 = new Comprobante();
            f8.Show();
            this.Hide();
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 f9 = new AboutBox1();
            f9.Show();
        }
    }
}
