using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Comprobante : Form
    {

        DateTime hoy = DateTime.Now;
        public Comprobante()
        {
            InitializeComponent();
        }
        double granhora, grandevengado, grandeducido, granneto, granpara, granprestacion, grannomina;

        

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        

        private void Report2_Click(object sender, EventArgs e)
        {
            Report rep = new Report();

            for (int i = 0; i < gvReporte1.Rows.Count; i++)
            {
                //1. Resumen General
                datos dat = new datos();
                dat.ResCedula = Convert.ToString(this.gvReporte1.Rows[i].Cells[0].Value);
                dat.ResNivel = Convert.ToString(this.gvReporte1.Rows[i].Cells[1].Value);
                dat.ResNombre = Convert.ToString(this.gvReporte1.Rows[i].Cells[2].Value);
                dat.ResDias = Convert.ToString(this.gvReporte1.Rows[i].Cells[3].Value);
                dat.ResTotalExtra = Convert.ToString(this.gvReporte1.Rows[i].Cells[4].Value);
                dat.ResTotalDevengado = Convert.ToString(this.gvReporte1.Rows[i].Cells[5].Value);
                dat.ResTotalDeducido = Convert.ToString(this.gvReporte1.Rows[i].Cells[6].Value);
                dat.ResNeto = Convert.ToString(this.gvReporte1.Rows[i].Cells[7].Value);
                dat.ResParaFiscales = Convert.ToString(this.gvReporte1.Rows[i].Cells[8].Value);
                dat.ResPrestaciones = Convert.ToString(this.gvReporte1.Rows[i].Cells[9].Value);
                dat.ResTotalNomina = Convert.ToString(this.gvReporte1.Rows[i].Cells[10].Value);
                //2. Total General
                dat.ToTotalExtra = REtotalextras.Text;
                dat.ToTotalDevengado = REdevengado.Text;
                dat.ToTotalDeducido = REdeducido.Text;
                dat.ToTotalNeto = REneto.Text;
                dat.ToTotalParaFiscales = REparafiscales.Text;
                dat.ToTotalPrestaciones = REprestaciones.Text;
                dat.ToTotalNomina = REnomina.Text;
                dat.RPNivel = lblfecha.Text;
                rep.Datos.Add(dat);
            }
            rep.ShowDialog();
        }

        

        private void abrirResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SEP = txtsepar.Text;

                string[] lineas = File.ReadAllLines(ofd.FileName);
                string[] cabeceras = lineas[0].Split(new[] { SEP }, StringSplitOptions.None);
                gvReporte1.Columns.Clear();
                foreach (string c in cabeceras)
                    gvReporte1.Columns.Add(c, c);

                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    gvReporte1.Rows.Add(celdas);
                }
                Report2.Enabled = true;                
                
            }
            Report2.Enabled = true;
            
            foreach (DataGridViewRow fila in gvReporte1.Rows)
            {
                granhora = granhora + Convert.ToDouble(fila.Cells[4].Value);
                grandevengado = grandevengado + Convert.ToDouble(fila.Cells[5].Value);
                grandeducido = grandeducido + Convert.ToDouble(fila.Cells[6].Value);
                granneto = granneto + Convert.ToDouble(fila.Cells[7].Value);
                granpara = granpara + Convert.ToDouble(fila.Cells[8].Value);
                granprestacion = granprestacion + Convert.ToDouble(fila.Cells[9].Value);
                grannomina = grannomina + Convert.ToDouble(fila.Cells[10].Value);
                Report2.Enabled = true;
                
            }
            REtotalextras.Text = Convert.ToString(granhora);
            REdevengado.Text = Convert.ToString(grandevengado);
            REdeducido.Text = Convert.ToString(grandeducido);
            REneto.Text = Convert.ToString(granneto);
            REparafiscales.Text = Convert.ToString(granpara);
            REprestaciones.Text = Convert.ToString(granprestacion);
            REnomina.Text = Convert.ToString(grannomina);
        }

        private static int o = -1;
        

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Recuerde que al regresar el menú no se le guardarán los datos\n ¿Desea volver al Menú?", "Nomina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                Menu f3 = new Menu();
                f3.Show();
                this.Hide();
            }
        }

        private void VolverNomina_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Comprobante_Load(object sender, EventArgs e)
        {
            lblfecha.Text = Convert.ToString(hoy);
            foreach (DataGridViewRow fila in gvReporte1.Rows)
            {
                granhora = granhora + Convert.ToDouble(fila.Cells[4].Value);
                grandevengado = grandevengado + Convert.ToDouble(fila.Cells[5].Value);
                grandeducido = grandeducido + Convert.ToDouble(fila.Cells[6].Value);
                granneto = granneto + Convert.ToDouble(fila.Cells[7].Value);
                granpara = granpara + Convert.ToDouble(fila.Cells[8].Value);
                granprestacion = granprestacion + Convert.ToDouble(fila.Cells[9].Value);
                grannomina = grannomina + Convert.ToDouble(fila.Cells[10].Value);
                Report2.Enabled = true;
            }
            REtotalextras.Text = Convert.ToString(granhora);
            REdevengado.Text = Convert.ToString(grandevengado);
            REdeducido.Text = Convert.ToString(grandeducido);
            REneto.Text = Convert.ToString(granneto);
            REparafiscales.Text = Convert.ToString(granpara);
            REprestaciones.Text = Convert.ToString(granprestacion);
            REnomina.Text = Convert.ToString(grannomina);            
        }
    }
}
