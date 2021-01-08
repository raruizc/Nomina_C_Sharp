using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Asignacion : Form
    {

        private static int a = 0;
        private static int contador = 0;
        private static int o = -1;
        private int n = 0;
        //private int i = 0;
        private void deshabilitar()
        {
            btnagregar.Enabled = false; btnnuevo.Enabled = false; txtnombre.Enabled = false;
            txtnivel.Enabled = false; txtcedula.Enabled = false; txtsueldo.Enabled = false;
            txtdias.Enabled = false; txthed.Enabled = false; txthen.Enabled = false;
            txthedd.Enabled = false; txthedn.Enabled = false; txthedn.Enabled = false; txthrn.Enabled = false;
        }
        private void habilitar()
        {
            txtnombre.Enabled = true; txtnivel.Enabled = true; txtcedula.Enabled = true; txtsueldo.Enabled = true;
            txtdias.Enabled = true; txthed.Enabled = true; txthen.Enabled = true; txthedd.Enabled = true;
            txthedn.Enabled = true; txthedn.Enabled = true; txthrn.Enabled = true;
        }
        private void habilitarbotones()
        {
            if (txtcedula.Text != "" && txtnivel.Text != "" && txtnombre.Text != "" &&
                txtdias.Text != "" && txtsueldo.Text != "" && txthed.Text != "" &&
                txthen.Text != "" && txthedd.Text != "" && txthedn.Text != "" &&
                txthrn.Text != "")
            {
                btnagregar.Enabled = true;
                btnnuevo.Enabled = true;
            }
            else
            {
                btnnuevo.Enabled = false;
                btnagregar.Enabled = false;
            }
        }
        private void Limpiar()
        {
            txtcedula.Clear(); txtnombre.Clear(); txtsueldo.Clear(); txtdias.Clear();
            txthed.Clear(); txthen.Clear(); txthedd.Clear(); txthedn.Clear(); txthrn.Clear();
        }
        private void Llenar()
        {
            int n = dgvempleados.Rows.Add();
            dgvempleados.Rows[n].Cells[0].Value = txtcedula.Text; dgvempleados.Rows[n].Cells[1].Value = txtnivel.Text;
            dgvempleados.Rows[n].Cells[2].Value = txtnombre.Text; dgvempleados.Rows[n].Cells[3].Value = txtsueldo.Text;
            dgvempleados.Rows[n].Cells[4].Value = txtdias.Text; dgvempleados.Rows[n].Cells[5].Value = txthed.Text;
            dgvempleados.Rows[n].Cells[6].Value = txthen.Text; dgvempleados.Rows[n].Cells[7].Value = txthedd.Text;
            dgvempleados.Rows[n].Cells[8].Value = txthedn.Text; dgvempleados.Rows[n].Cells[9].Value = txthrn.Text;
        }
        public Asignacion()
        {
            InitializeComponent();
        }

        private void Asignacion_Load(object sender, EventArgs e)
        {
            label10.Text = "";
            deshabilitar();
            label15.Text = "";
            a = 0;
            contador = 0;
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            Menu f3 = new Menu();
            f3.Show();
            this.Hide();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            int cont;
            cont = Convert.ToInt32(txtnumero.Text);
            label10.Text = Convert.ToString(cont);
            txtcedula.Enabled = true;
            txtcedula.Focus();
            txtnumero.Enabled = false;
            btnaceptar.Enabled = false;
            MessageBox.Show("Recuerde dar 'Enter' cuando digite la cédula", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 47 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 13)
            {
                int limitee;
                int I = 0;
                int num;

                limitee = Convert.ToInt32(txtcedula.Text);

                foreach (DataGridViewRow row in dgvempleados.Rows)
                {
                    while (I < 1)
                    {
                        o += 1;
                        num = o;
                        try
                        {
                            if (limitee == Convert.ToInt32(dgvempleados.Rows[o].Cells[0].Value))
                            {
                                MessageBox.Show("Está Cédula ya se encuentra Registrada", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                o = -1;
                                I += 1;
                                txtcedula.Text = "";
                                
                            }                                   
                            
                        }
                        catch (Exception ex)
                        {
                            habilitar();
                            txtcedula.ReadOnly = true;
                            txtnivel.Focus();
                            o = -1;
                            I += 1;
                            dgvempleados.AllowUserToAddRows = false;
                        }
                    }
                }
            }
           

            
        }



        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtsueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 47 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtdias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txthed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txthen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txthedd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txthedn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txthrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();            
        }

        
        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void txtsueldo_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void txtdias_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void txthed_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void txthen_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void txthedd_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void txthedn_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void txthrn_TextChanged(object sender, EventArgs e)
        {
            habilitarbotones();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            int b;
            int limit;

            limit = Convert.ToInt32(txtnumero.Text);
            b = Convert.ToInt32(txtnumero.Text);

            while (contador < b)
            {
                a += 1;
                label15.Text = Convert.ToString(a);
                b = a;
                contador += 1;
                Llenar();
                Limpiar();
                deshabilitar();
                txtcedula.Enabled = true;
                txtcedula.Focus();
                txtcedula.ReadOnly = false;
            }
            if (b == limit)
            {
                MessageBox.Show("Llegó al limite de registros");
                deshabilitar();
                btnagregarmas.Visible = true;
                btnagregarmas.Enabled = true;
                Limpiar();
                //this.Hide();
                //Menu f3 = new Menu();
                //f3.Show();
            }

        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Recuerde que al regresar el menú no se le guardarán los datos\n ¿Desea volver al Menú?", "Nomina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                Menu f3 = new Menu();
                f3.Show();
                this.Hide();
            }
        }

        private void volverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Recuerde que al regresar al menú no se le guardarán los datos\n ¿Desea volver al Menú?", "Nomina", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                Menu f3 = new Menu();
                f3.Show();
                this.Hide();
            }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();

                List<string> cabeceras = new List<string>();
                foreach (DataGridViewColumn col in dgvempleados.Columns)
                {
                    cabeceras.Add(col.HeaderText);
                }
                string SEP = txtsep.Text;
                filas.Add(String.Join(SEP, cabeceras));

                foreach (DataGridViewRow fila in dgvempleados.Rows)
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

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string SEP = txtsep.Text;

                string[] lineas = File.ReadAllLines(ofd.FileName);
                string[] cabeceras = lineas[0].Split(new[] { SEP }, StringSplitOptions.None);
                dgvempleados.Columns.Clear();
                foreach (string c in cabeceras)
                    dgvempleados.Columns.Add(c, c);

                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    dgvempleados.Rows.Add(celdas);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int b;


            if (label10.Text == "")
            {
                if (n != -1)
                {
                    dgvempleados.Rows.RemoveAt(n);
                }

            }
            else
            {
                int limit;

                limit = Convert.ToInt32(txtnumero.Text);
                if (n != -1)
                {
                    dgvempleados.Rows.RemoveAt(n);
                    habilitar();
                    a--; contador--;
                    b = limit - 1;
                    label15.Text = Convert.ToString(b);
                    Limpiar();
                    btnagregarmas.Visible = false;
                    btnagregarmas.Enabled = false;
                }
            }

        }

        private void btnagregarmas_Click(object sender, EventArgs e)
        {
            txtnumero.Text = "";
            txtnumero.Enabled = true;
            btnaceptar.Enabled = true;
            txtnumero.Focus();
            btnagregarmas.Visible = false;
            btnagregarmas.Enabled = false;
            Limpiar();
            label15.Text = "";
            a = 0; contador = 0;
        }

        private void txtnivel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar >= 47 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                //MessageBox.Show("Solo números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                //MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnivel_TextChanged_1(object sender, EventArgs e)
        {
            habilitarbotones();
        }
    }
}
