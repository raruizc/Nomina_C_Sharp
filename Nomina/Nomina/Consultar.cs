using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Consultar : Form
    {
        private static int o = -1;
        public Consultar()
        {
            InitializeComponent();
        }

        private void Consultar_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerde abrir el archivo creado en el formulario\n 'Asignación de Empleados'", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Information);
            o = -1;
            btnconsultar.Enabled = false;
            btnconsultarnivel.Enabled = false;
            btnEnviar.Enabled = false;
            btndevolver.Enabled = false;
            btnfiltrar.Enabled = false;

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SEP = txtsep.Text;
                CalculoNomina f6 = new CalculoNomina();
                string[] lineas = File.ReadAllLines(ofd.FileName);
                string[] cabeceras = lineas[0].Split(new[] { SEP }, StringSplitOptions.None);
                dgvconsultar.Columns.Clear();
                foreach (string c in cabeceras)
                    dgvconsultar.Columns.Add(c, c);
                dgvfiltrado.Columns.Clear();
                foreach (string co in cabeceras)
                    dgvfiltrado.Columns.Add(co, co);
                /*f6.dgvnomina.Columns.Clear();
                foreach (string col in cabeceras)
                    f6.dgvnomina.Columns.Add(col, col);*/
                
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    dgvconsultar.Rows.Add(celdas);
                }
                btnconsultar.Enabled = true;
                btnconsultarnivel.Enabled = true;
                btnEnviar.Enabled = true;
                btndevolver.Enabled = true;
                btnfiltrar.Enabled = true;
            }
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu f3 = new Menu();
            f3.Show();
            this.Hide();
        }

        private void btnfiltrar_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow fila in dgvconsultar.SelectedRows)
            {
                dgvfiltrado.Rows.Add(fila.Cells[0].Value, fila.Cells[1].Value, fila.Cells[2].Value, fila.Cells[3].Value,
                    fila.Cells[4].Value, fila.Cells[5].Value, fila.Cells[6].Value, fila.Cells[7].Value, fila.Cells[8].Value,
                    fila.Cells[9].Value);
                dgvconsultar.Rows.Remove(fila);
            }
        }

        private void txtfcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtfcedula_TextChanged(object sender, EventArgs e)
        {
            /*BindingSource bs = new BindingSource();
            bs.DataSource = dgvconsultar.DataSource;
            bs.Filter = "Nombre like '"+ txtfcedula.Text + "%'";
            dgvconsultar.DataSource = bs;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dgvfiltrado.SelectedRows)
            {
                dgvconsultar.Rows.Add(fila.Cells[0].Value, fila.Cells[1].Value, fila.Cells[2].Value, fila.Cells[3].Value,
                    fila.Cells[4].Value, fila.Cells[5].Value, fila.Cells[6].Value, fila.Cells[7].Value, fila.Cells[8].Value,
                    fila.Cells[9].Value);
                dgvfiltrado.Rows.Remove(fila);
            }
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            int limitee;
            int I = 0;
            int num;

            limitee = Convert.ToInt32(txtcedula.Text);

            foreach (DataGridViewRow row in dgvconsultar.Rows)
            {
                while (I < 1)
                {
                    o += 1;
                    num = o;
                    try
                    {
                        if (limitee == Convert.ToInt32(dgvconsultar.Rows[o].Cells[0].Value))
                        {
                            dgvfiltrado.Rows.Add(dgvconsultar.Rows[num].Cells[0].Value,
                                dgvconsultar.Rows[num].Cells[1].Value, dgvconsultar.Rows[num].Cells[2].Value,
                                dgvconsultar.Rows[num].Cells[3].Value, dgvconsultar.Rows[num].Cells[4].Value,
                                dgvconsultar.Rows[num].Cells[5].Value, dgvconsultar.Rows[num].Cells[6].Value,
                                dgvconsultar.Rows[num].Cells[7].Value, dgvconsultar.Rows[num].Cells[8].Value,
                                dgvconsultar.Rows[num].Cells[9].Value);
                            dgvconsultar.Rows.Remove(dgvconsultar.Rows[num]);
                            o = -1;
                            I += 1;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("No se encuentra esta Cédula", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        o = -1;
                        I += 1;
                    }                                  
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            CalculoNomina f6 = new CalculoNomina();            
            foreach(DataGridViewRow fila in dgvfiltrado.SelectedRows)
            {
                f6.dgvnomina.Rows.Add(fila.Cells[0].Value, fila.Cells[1].Value, fila.Cells[2].Value, fila.Cells[3].Value,
                    fila.Cells[4].Value, fila.Cells[5].Value, fila.Cells[6].Value, fila.Cells[7].Value, fila.Cells[8].Value,
                    fila.Cells[9].Value);
            }
            f6.Show();
            f6.btncalcularv.Enabled = true;
            f6.btncalcularap.Enabled = false;
            f6.btnvolverc.Enabled = true;
        }

        private void btnconsultarnivel_Click(object sender, EventArgs e)
        {
            int limitee;
            int I = 0;
            int num;

            limitee = Convert.ToInt32(txtnivel.Text);

            foreach (DataGridViewRow row in dgvconsultar.Rows)
            {
                while (I < 1)
                {
                    o += 1;
                    num = o;
                    try
                    {
                        if (limitee == Convert.ToInt32(dgvconsultar.Rows[o].Cells[1].Value))
                        {
                            dgvfiltrado.Rows.Add(dgvconsultar.Rows[num].Cells[0].Value,
                                dgvconsultar.Rows[num].Cells[1].Value, dgvconsultar.Rows[num].Cells[2].Value,
                                dgvconsultar.Rows[num].Cells[3].Value, dgvconsultar.Rows[num].Cells[4].Value,
                                dgvconsultar.Rows[num].Cells[5].Value, dgvconsultar.Rows[num].Cells[6].Value,
                                dgvconsultar.Rows[num].Cells[7].Value, dgvconsultar.Rows[num].Cells[8].Value,
                                dgvconsultar.Rows[num].Cells[9].Value);
                            dgvconsultar.Rows.Remove(dgvconsultar.Rows[num]);
                            o = -1;                          
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Este Nivel no se encuentra registrado\n o se filtraron todos los empleados del Nivel de ARP ", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        o = -1;
                        I += 1;
                    }
                }
            }
        }
    }
}
