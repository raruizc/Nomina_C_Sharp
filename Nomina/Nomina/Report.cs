using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Nomina
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        public List<datos> Datos = new List<datos>();
        private void Report_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Datos));
            this.reportViewer1.RefreshReport();
        }
    }
}
