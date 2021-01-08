using Microsoft.SqlServer.Server;
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
    public partial class CalculoNomina : Form
    {
        private static int o = 0;
        double sueldo, basico, auxilio, valorhora, vhed, vhen, vhedd, vhedn, vhrn, transporte = 102854, 
            retefuente = 35607, minimo = 877803;
        double totalextras, total, ibc, salud, pension, fondo, liquidacion, excento, retencion,
            UVT, rf, deducido, neto, ARL, sena, icbf, caja, totalpara, prima, vacaciones, cesantias,
            interes, prestacion, totalnomina, cedula;
        double granhora, grandevengado, grandeducido, granneto, granpara, granprestacion, grannomina;
        int dias, hed, hen, hedd, hedn, hrn, nivel;
        string nombre;

        private void btnenviarcomprobante_Click(object sender, EventArgs e)
        {
            //
            Comprobante f8 = new Comprobante();
            foreach (DataGridViewRow fila in dgvresumen.SelectedRows)
            {
                Convert.ToString(fila);
                f8.gvReporte1.Rows.Add(fila.Cells[0].Value, fila.Cells[1].Value, fila.Cells[2].Value, fila.Cells[3].Value,
                    fila.Cells[4].Value, fila.Cells[5].Value, fila.Cells[6].Value, fila.Cells[7].Value, fila.Cells[8].Value,
                    fila.Cells[9].Value, fila.Cells[10].Value);
            }     
            f8.Show();
            f8.VolverNomina.Enabled = true;
            
            //                   
        }

        

        private void guardarResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();

                List<string> cabeceras = new List<string>();
                foreach (DataGridViewColumn col in dgvresumen.Columns)
                {
                    cabeceras.Add(col.HeaderText);
                }
                string SEP = txtsep.Text;
                filas.Add(String.Join(SEP, cabeceras));

                foreach (DataGridViewRow fila in dgvresumen.Rows)
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
        
        private void btnresumen_Click_1(object sender, EventArgs e)
        {
            Valores();
            foreach (DataGridViewRow fila in dgvresumen.Rows)
            {
                granhora = granhora + Convert.ToDouble(fila.Cells[4].Value);
                grandevengado = grandevengado + Convert.ToDouble(fila.Cells[5].Value);
                grandeducido = grandeducido + Convert.ToDouble(fila.Cells[6].Value);
                granneto = granneto + Convert.ToDouble(fila.Cells[7].Value);
                granpara = granpara + Convert.ToDouble(fila.Cells[8].Value);
                granprestacion = granprestacion + Convert.ToDouble(fila.Cells[9].Value);
                grannomina = grannomina + Convert.ToDouble(fila.Cells[10].Value);
                btnenviarcomprobante.Enabled = true;
            }
            txttotalextras.Text = Convert.ToString(granhora);
            txtdevengado.Text = Convert.ToString(grandevengado);
            txtdeducido.Text = Convert.ToString(grandeducido);
            txtneto.Text = Convert.ToString(granneto);
            txtparafiscales.Text = Convert.ToString(granpara);
            txtprestaciones.Text = Convert.ToString(granprestacion);
            txtnomina.Text = Convert.ToString(grannomina);

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Horas f7 = new Horas();
            foreach (DataGridViewRow fila in dgvvalores.SelectedRows)
            {
                f7.dgvvaloreshora.Rows.Add(fila.Cells[0].Value, fila.Cells[1].Value, fila.Cells[2].Value, fila.Cells[3].Value,
                    fila.Cells[4].Value, fila.Cells[5].Value, fila.Cells[6].Value, fila.Cells[7].Value, fila.Cells[8].Value,
                    fila.Cells[9].Value, fila.Cells[10].Value, fila.Cells[11].Value, fila.Cells[12].Value,
                    fila.Cells[13].Value, fila.Cells[14].Value, fila.Cells[15].Value, fila.Cells[16].Value,
                    fila.Cells[17].Value, fila.Cells[18].Value, fila.Cells[19].Value);
            }
            f7.Show();
            f7.btnvolvernomina.Enabled = true;

        }

        private void guardarApropiacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();

                List<string> cabeceras = new List<string>();
                foreach (DataGridViewColumn col in dgvapropiaciones.Columns)
                {
                    cabeceras.Add(col.HeaderText);
                }
                string SEP = txtsep.Text;
                filas.Add(String.Join(SEP, cabeceras));

                foreach (DataGridViewRow fila in dgvapropiaciones.Rows)
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
        
        private void btncalcularap_Click(object sender, EventArgs e)
        {
            dgvapropiaciones.Rows.Clear();
            foreach (DataGridViewRow fila in dgvnomina.Rows)
            {
                cedula = Convert.ToDouble(fila.Cells[0].Value);
                nombre = Convert.ToString(fila.Cells[2].Value);
                nivel = Convert.ToInt32(fila.Cells[1].Value);
                sueldo = Convert.ToDouble(fila.Cells[3].Value);
                dias = Convert.ToInt32(fila.Cells[4].Value);
                hed = Convert.ToInt32(fila.Cells[5].Value);
                hen = Convert.ToInt32(fila.Cells[6].Value);
                hedd = Convert.ToInt32(fila.Cells[7].Value);
                hedn = Convert.ToInt32(fila.Cells[8].Value);
                hrn = Convert.ToInt32(fila.Cells[9].Value);

                basico = Math.Round((sueldo / 30) * dias, 0);
                if (sueldo <= 2 * minimo)
                {
                    auxilio = Math.Round(transporte / 30 * dias, 0);
                }
                else
                {
                    auxilio = 0;
                }
                valorhora = Math.Round(sueldo / 240, 0);
                vhed = Math.Round(1.25 * valorhora * hed, 0);
                vhen = Math.Round(1.75 * valorhora * hen, 0);
                vhedd = Math.Round(2 * valorhora * hedd, 0);
                vhedn = Math.Round(2.5 * valorhora * hedn, 0);
                vhrn = Math.Round(1.35 * valorhora * hrn, 0);

                totalextras = Math.Round(vhed + vhen + vhedd + vhedn + vhrn, 0);
                total = Math.Round(basico + auxilio + totalextras, 0);
                ibc = Math.Round(total - auxilio, 0);

                salud = Math.Round(ibc * 0.085, 0);
                pension = Math.Round(ibc * 0.12, 0);

                if (nivel == 1)
                {
                    ARL = Math.Round(ibc * 0.00522, 0);
                }
                else if (nivel == 2)
                {
                    ARL = Math.Round(ibc * 0.01044, 0);
                }
                else if (nivel == 3)
                {
                    ARL = Math.Round(ibc * 0.02436, 0);
                }
                else if (nivel == 4)
                {
                    ARL = Math.Round(ibc * 0.04350, 0);
                }
                else if (nivel == 5)
                {
                    ARL = Math.Round(ibc * 0.06960, 0);
                }
                sena = Math.Round(ibc * 0.02);
                icbf = Math.Round(ibc * 0.03);
                caja = Math.Round(ibc * 0.04);
                totalpara = salud + pension + ARL + sena + icbf + caja;

                prima = Math.Round(total * dias/360);
                vacaciones = Math.Round(basico * 0.0417);
                cesantias = Math.Round(total * dias / 360);
                interes = Math.Round(cesantias * 0.12);
                prestacion = prima + vacaciones + cesantias + interes;

                totalnomina = totalpara + prestacion;

                dgvapropiaciones.Rows.Add(cedula, nivel, nombre, salud, pension, ARL, sena,
                    icbf, caja, totalpara, prima, vacaciones, cesantias, interes, prestacion, totalnomina);
            }

            //btnenviarcomprobante.Enabled = true;
            btnEnviar.Enabled = true;
            btnresumen.Enabled = true;
        }

        private void btnvolverc_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guardarValoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> filas = new List<string>();

                List<string> cabeceras = new List<string>();
                foreach (DataGridViewColumn col in dgvvalores.Columns)
                {
                    cabeceras.Add(col.HeaderText);
                }
                string SEP = txtsep.Text;
                filas.Add(String.Join(SEP, cabeceras));

                foreach (DataGridViewRow fila in dgvvalores.Rows)
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
                dgvnomina.Columns.Clear();
                foreach (string c in cabeceras)
                    dgvnomina.Columns.Add(c, c);

                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] celdas = lineas[i].Split(new[] { SEP }, StringSplitOptions.None);
                    dgvnomina.Rows.Add(celdas);
                }
                btncalcularv.Enabled = true;
            }
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
               

        private void AgregarFondo()
        {
            dgvvalores.Rows.Add(cedula, nivel, nombre, basico, auxilio, valorhora, vhed, vhen, vhedd, vhedn,
                vhrn, totalextras, total, ibc, salud, pension, fondo, rf, deducido, neto);
        }
        private void Retefuente()
        {


            liquidacion = Math.Round(total - pension - salud - fondo);
            excento = Math.Round(liquidacion * 0.25, 0);
            retencion = liquidacion - excento;
            UVT = retencion / retefuente;

            if (UVT >= 0 && UVT <= 95)
            {
                rf = 0;
            }
            else if (UVT > 95 && UVT <= 150)
            {
                rf = Math.Round(((UVT - 95) * 0.19) * retefuente, 0);
            }
            else if (UVT > 150 && UVT <= 360)
            {
                rf = Math.Round((((UVT - 150) * 0.28) + 10) * retefuente, 0);
            }
            else if (UVT > 360 && UVT <= 640)
            {
                rf = Math.Round((((UVT - 360) * 0.33) + 69) * retefuente, 0);
            }
            else if (UVT > 640 && UVT <= 945)
            {
                rf = Math.Round((((UVT - 640) * 0.35) + 162) * retefuente, 0);
            }
            else if (UVT > 945 && UVT <= 2300)
            {
                rf = Math.Round((((UVT - 945) * 0.37) + 268) * retefuente, 0);
            }
            else if (UVT > 2300)
            {
                rf = Math.Round((((UVT - 2300) * 0.39) + 770) * retefuente, 0);
            }
        }
        public CalculoNomina()
        {
            InitializeComponent();
        }
        
        private void Nomina_Load(object sender, EventArgs e)
        {
            o = 0;
        }

        
        private void btncalcularv_Click(object sender, EventArgs e)
        {
            int I = 0;
            double limite = 0;
            dgvvalores.Rows.Clear();
            foreach(DataGridViewRow fila in dgvnomina.Rows)
            {
                cedula = Convert.ToDouble(fila.Cells[0].Value);
                nombre = Convert.ToString(fila.Cells[2].Value);
                nivel = Convert.ToInt32(fila.Cells[1].Value);
                sueldo = Convert.ToDouble(fila.Cells[3].Value);
                dias = Convert.ToInt32(fila.Cells[4].Value);
                hed = Convert.ToInt32(fila.Cells[5].Value);
                hen = Convert.ToInt32(fila.Cells[6].Value);
                hedd = Convert.ToInt32(fila.Cells[7].Value);
                hedn = Convert.ToInt32(fila.Cells[8].Value);
                hrn = Convert.ToInt32(fila.Cells[9].Value);

                basico = Math.Round((sueldo/30) * dias, 0);
                if (sueldo <= 2 * minimo)
                {
                    auxilio = Math.Round(transporte/30 * dias, 0);
                }
                else
                {
                    auxilio = 0;
                }
                valorhora = Math.Round(sueldo / 240, 0);
                vhed = Math.Round(1.25 * valorhora * hed, 0);
                vhen = Math.Round(1.75 * valorhora * hen, 0);
                vhedd = Math.Round(2 * valorhora * hedd, 0);
                vhedn = Math.Round(2.5 * valorhora * hedn, 0);
                vhrn = Math.Round(1.35 * valorhora * hrn, 0);

                totalextras = Math.Round(vhed + vhen + vhedd + vhedn + vhrn, 0);
                total = Math.Round(basico + auxilio + totalextras, 0);
                ibc = Math.Round(total - auxilio, 0);
                salud = Math.Round(0.04 * ibc, 0);
                pension = Math.Round(0.04 * ibc, 0);

                
                
                /*liquidacion = Math.Round(total - pension - salud - fondo);
                excento = Math.Round(liquidacion * 0.25, 0);
                retencion = liquidacion - excento;
                UVT = retencion / retefuente;

                if (UVT >= 0 && UVT <= 95)
                {
                    rf = 0;
                }
                else if (UVT > 95 && UVT <= 150)
                {
                    rf = Math.Round(((UVT - 95) * 0.19) * retefuente, 0);
                }
                else if (UVT > 150 && UVT <= 360)
                {
                    rf = Math.Round((((UVT - 150) * 0.28) + 10) * retefuente,0);
                }
                else if (UVT > 360 && UVT <= 640)
                {
                    rf = Math.Round((((UVT - 360) * 0.33) + 69) * retefuente, 0);
                }
                else if (UVT > 640 && UVT <= 945)
                {
                    rf = Math.Round((((UVT - 640) * 0.35) + 162) * retefuente, 0);
                }
                else if (UVT > 945 && UVT <= 2300)
                {
                    rf = Math.Round((((UVT - 945) * 0.37) + 268) * retefuente, 0);
                }
                else if (UVT > 2300)
                {
                    rf = Math.Round((((UVT - 2300) * 0.39) + 770) * retefuente, 0);
                }*/
                /*Calculo retefuente
             * Total - Salud - Pension - Fondo
             * Base de liquidación
             * Excento = base de liquidacion * 0.25 (25%)
             * Base de retencion = Base liquidacion - Excento
             * UVT = Base de Retencion / 35607
             * Si UVT 0 - 95 = Retencion Fuente = 0% * 35607
             * Sí UVT >95 - 150 = RF = (Ingreso UVT - 95) * 19% * 35607
             * Sí UVT >150 - 360 = RF = (((Ingreso UVT - 150) * 28%) + 10)* 35607
             * Si UVT >360 - 640 = RF = (((Ingreso UVT - 360) * 33%) + 69)* 35607
             * Si UVT >640 - 945 = RF = (((Ingreso UVT - 640) * 35%) + 162)* 35607
             * Si UVT >945 - 2300 = RF = (((Ingreso UVT - 945) * 37%) + 268)* 35607
             * Si UVT >2300 .... = RF = (((Ingreso UVT - 2300) * 39%) + 770)* 35607
             * 
             */
                limite = ibc * 1;
                if (limite >= 4 * minimo && limite < 16 * minimo)
                {
                    fondo = Math.Round(0.01 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    AgregarFondo();
                }
                else if (limite >= 16 * minimo && limite < 17 * minimo)
                {
                    fondo = Math.Round(0.012 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    AgregarFondo();
                }
                else if (limite >= 17 * minimo && limite < 18 * minimo)
                {
                    fondo = Math.Round(0.014 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    AgregarFondo();
                }
                else if (limite >= 18 * minimo && limite < 19 * minimo)
                {
                    fondo = Math.Round(0.016 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    AgregarFondo();
                }
                else if (limite >= 19 * minimo && limite < 20 * minimo)
                {
                    fondo = Math.Round(0.018 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    AgregarFondo();
                }
                else if (limite >= 20 * minimo)
                {
                    fondo = Math.Round(0.02 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    AgregarFondo();
                }
                else if (limite < 4* minimo)
                {
                    fondo = 0;
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    AgregarFondo();
                }

                btncalcularap.Enabled = true;
            }
            
        }
        private void Apropiaciones()
        {
            salud = Math.Round(ibc * 0.085, 0);
            pension = Math.Round(ibc * 0.12, 0);

            if (nivel == 1)
            {
                ARL = Math.Round(ibc * 0.00522, 0);
            }
            else if (nivel == 2)
            {
                ARL = Math.Round(ibc * 0.01044, 0);
            }
            else if (nivel == 3)
            {
                ARL = Math.Round(ibc * 0.02436, 0);
            }
            else if (nivel == 4)
            {
                ARL = Math.Round(ibc * 0.04350, 0);
            }
            else if (nivel == 5)
            {
                ARL = Math.Round(ibc * 0.06960, 0);
            }
            sena = Math.Round(ibc * 0.02);
            icbf = Math.Round(ibc * 0.03);
            caja = Math.Round(ibc * 0.04);
            totalpara = salud + pension + ARL + sena + icbf + caja;

            prima = Math.Round(total * dias / 360);
            vacaciones = Math.Round(basico * 0.0417);
            cesantias = Math.Round(total * dias / 360);
            interes = Math.Round(cesantias * 0.12);
            prestacion = prima + vacaciones + cesantias + interes;

            totalnomina = totalpara + prestacion;
        }
        private void Resumen()
        {
            dgvresumen.Rows.Add(cedula, nivel, nombre, dias, totalextras, total, deducido, neto, totalpara,
                prestacion, totalnomina);
        }
        private void Valores()
        {
            double limite = 0;
            foreach (DataGridViewRow fila in dgvnomina.Rows)
            {
                cedula = Convert.ToDouble(fila.Cells[0].Value);
                nombre = Convert.ToString(fila.Cells[2].Value);
                nivel = Convert.ToInt32(fila.Cells[1].Value);
                sueldo = Convert.ToDouble(fila.Cells[3].Value);
                dias = Convert.ToInt32(fila.Cells[4].Value);
                hed = Convert.ToInt32(fila.Cells[5].Value);
                hen = Convert.ToInt32(fila.Cells[6].Value);
                hedd = Convert.ToInt32(fila.Cells[7].Value);
                hedn = Convert.ToInt32(fila.Cells[8].Value);
                hrn = Convert.ToInt32(fila.Cells[9].Value);

                basico = Math.Round((sueldo / 30) * dias, 0);
                if (sueldo <= 2 * minimo)
                {
                    auxilio = Math.Round(transporte / 30 * dias, 0);
                }
                else
                {
                    auxilio = 0;
                }
                valorhora = Math.Round(sueldo / 240, 0);
                vhed = Math.Round(1.25 * valorhora * hed, 0);
                vhen = Math.Round(1.75 * valorhora * hen, 0);
                vhedd = Math.Round(2 * valorhora * hedd, 0);
                vhedn = Math.Round(2.5 * valorhora * hedn, 0);
                vhrn = Math.Round(1.35 * valorhora * hrn, 0);

                totalextras = Math.Round(vhed + vhen + vhedd + vhedn + vhrn, 0);
                total = Math.Round(basico + auxilio + totalextras, 0);
                ibc = Math.Round(total - auxilio, 0);
                salud = Math.Round(0.04 * ibc, 0);
                pension = Math.Round(0.04 * ibc, 0);

                limite = ibc * 1;
                if (limite >= 4 * minimo && limite < 16 * minimo)
                {
                    fondo = Math.Round(0.01 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    Apropiaciones();
                    Resumen();

                }
                else if (limite >= 16 * minimo && limite < 17 * minimo)
                {
                    fondo = Math.Round(0.012 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    Apropiaciones();
                    Resumen();

                }
                else if (limite >= 17 * minimo && limite < 18 * minimo)
                {
                    fondo = Math.Round(0.014 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    Apropiaciones();
                    Resumen();

                }
                else if (limite >= 18 * minimo && limite < 19 * minimo)
                {
                    fondo = Math.Round(0.016 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    Apropiaciones();
                    Resumen();

                }
                else if (limite >= 19 * minimo && limite < 20 * minimo)
                {
                    fondo = Math.Round(0.018 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    Apropiaciones();
                    Resumen();

                }
                else if (limite >= 20 * minimo)
                {
                    fondo = Math.Round(0.02 * ibc, 0);
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    Apropiaciones();
                    Resumen();

                }
                else if (limite < 4 * minimo)
                {
                    fondo = 0;
                    Retefuente();
                    deducido = salud + pension + rf + fondo;
                    neto = total - deducido;
                    Apropiaciones();
                    Resumen();
                }
                
            }
        }
        
    }
}
