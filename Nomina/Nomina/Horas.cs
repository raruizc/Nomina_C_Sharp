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
    public partial class Horas : Form
    {
        private static int o = -1;
        public Horas()
        {
            InitializeComponent();
        }

        private void volverMenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Recuerde que al regresar el menú no se le guardarán los datos\n ¿Desea volver al Menú?", "Nomina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                Menu f3 = new Menu();
                f3.Show();
                this.Hide();
            }
        }

        private void btnvolvernomina_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnfiltrar_Click(object sender, EventArgs e)
        {
            double valorhora, hed, hen, hdd, hdn, hrn, subtotalextras, subtotalrecargo,
                subtotaldomincal, totalextras;
            dgvhoras.Rows.Clear();
            foreach (DataGridViewRow fila in dgvvaloreshora.SelectedRows)
            {
                valorhora = Convert.ToDouble(fila.Cells[5].Value);
                hed = Convert.ToDouble(fila.Cells[6].Value);
                hen= Convert.ToDouble(fila.Cells[7].Value);
                hdd = Convert.ToDouble(fila.Cells[8].Value);
                hdn = Convert.ToDouble(fila.Cells[9].Value);
                hrn = Convert.ToDouble(fila.Cells[10].Value);

                subtotalextras = hed + hen;
                subtotalrecargo = hrn;
                subtotaldomincal = hdd + hdn;

                totalextras = hed + hen + hdd + hdn + hrn;

                dgvhoras.Rows.Add(fila.Cells[0].Value, fila.Cells[2].Value, hrn, hed, hen,
                    hdd, hdn, subtotalextras, subtotalrecargo, subtotaldomincal, totalextras);
                
            }
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            int limitee;
            int I = 0;
            int num;

            limitee = Convert.ToInt32(txtcedula.Text);
            dgvhoras.Rows.Clear();
            foreach (DataGridViewRow row in dgvvaloreshora.Rows)
            {
                
                while (I < 1)
                {
                    o += 1;
                    num = o;
                    try
                    {
                        if (limitee == Convert.ToInt32(dgvvaloreshora.Rows[o].Cells[0].Value))
                        {
                            double valorhora, hed, hen, hdd, hdn, hrn, subtotalextras, subtotalrecargo,
                                    subtotaldomincal, totalextras;
                            valorhora = Convert.ToDouble(dgvvaloreshora.Rows[num].Cells[5].Value);
                            hed = Convert.ToDouble(dgvvaloreshora.Rows[num].Cells[6].Value);
                            hen = Convert.ToDouble(dgvvaloreshora.Rows[num].Cells[7].Value);
                            hdd = Convert.ToDouble(dgvvaloreshora.Rows[num].Cells[8].Value);
                            hdn = Convert.ToDouble(dgvvaloreshora.Rows[num].Cells[9].Value);
                            hrn = Convert.ToDouble(dgvvaloreshora.Rows[num].Cells[10].Value);

                            subtotalextras = hed + hen;
                            subtotalrecargo = hrn;
                            subtotaldomincal = hdd + hdn;

                            totalextras = hed + hen + hdd + hdn + hrn;

                            dgvhoras.Rows.Add(dgvvaloreshora.Rows[num].Cells[0].Value, dgvvaloreshora.Rows[num].Cells[2].Value, hrn, hed, hen,
                                hdd, hdn, subtotalextras, subtotalrecargo, subtotaldomincal, totalextras);
                            o = -1;
                            I += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se encuentra esta Cédula", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        o = -1;
                        I += 1;
                    }
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SEP = txtsep.Text;

                string[] lineas = File.ReadAllLines(ofd.FileName);
                string[] cabeceras = lineas[0].Split(new[] { SEP }, StringSplitOptions.None);
                dgvvaloreshora.Columns.Clear();
                foreach (string c in cabeceras)
                    dgvvaloreshora.Columns.Add(c, c);

                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    dgvvaloreshora.Rows.Add(celdas);
                }
                
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();

                List<string> cabeceras = new List<string>();
                foreach (DataGridViewColumn col in dgvhoras.Columns)
                {
                    cabeceras.Add(col.HeaderText);
                }
                string SEP = txtsep.Text;
                filas.Add(String.Join(SEP, cabeceras));

                foreach (DataGridViewRow fila in dgvhoras.Rows)
                {
                    try
                    {
                        List<string> celdas = new List<string>();
                        foreach (DataGridViewCell c in fila.Cells)
                            celdas.Add(c.Value.ToString());
                        filas.Add(string.Join(SEP, celdas));
                    }
                    catch (Exception ex) { }
                }

                File.WriteAllLines(sfd.FileName, filas);
            }
        }
    }
}
