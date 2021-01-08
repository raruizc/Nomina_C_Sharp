using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private static int a = 0;
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            int contador;
            string username, contraseña;

            username = Convert.ToString(txtusuario.Text);
            contraseña = Convert.ToString(txtpassword.Text);

            contador = 0;

            while (contador < 1)
            {
                if (username == "usuario_1" && contraseña == "12345" || username == "USUARIO_1" && contraseña == "12345")
                {
                    MessageBox.Show("BIENVENIDO/A (USUARIO)", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    contador = 1;
                    this.Hide();
                    Menu f3 = new Menu();
                    f3.Show();
                }
                else
                {
                    
                    a ++;
                    contador += 1;
                    MessageBox.Show("Vuelva intentarlo, tiene " + a + " intento(s) de 3", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtusuario.Clear();
                    txtpassword.Clear();
                    txtusuario.Focus();
                    if (a == 3)
                    {
                        MessageBox.Show("Has agotado todos sus (3) intentos (La Aplicacion se cerrara", "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        Application.Exit();
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario: usuario_1 \n" +
                "\nContraseña: 12345" , "Nomina", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea salir de la aplicación", "Nomina", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (r == DialogResult.Yes)
            {
                Close();
                this.Hide();
                Application.Exit();
            }
            
                           
        }
    }
}
