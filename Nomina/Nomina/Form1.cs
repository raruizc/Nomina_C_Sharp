using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (this.Opacity > 0)
            {
                this.Opacity -= 0.00001;
            }
            this.Hide();
            Login f2 = new Login();
            f2.Show();
            timer1.Stop();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 5500;
            timer1.Start();
        }
    }
}
