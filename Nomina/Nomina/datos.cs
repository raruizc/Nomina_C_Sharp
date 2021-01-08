using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina
{
    public class datos
    {
        // 1. Entrada Resumen General
        public string ResCedula { get; set; }
        public string ResNivel { get; set; }
        public string ResNombre { get; set; }
        public string ResDias { get; set; }
        public string ResTotalExtra { get; set; }
        public string ResTotalDevengado { get; set; }
        public string ResTotalDeducido { get; set; }
        public string ResNeto { get; set; }
        public string ResParaFiscales { get; set; }
        public string ResPrestaciones { get; set; }
        public string ResTotalNomina { get; set; }

        //2. Total General TextBox
        public string ToTotalExtra { get; set; }
        public string ToTotalDevengado { get; set; }
        public string ToTotalDeducido { get; set; }
        public string ToTotalNeto { get; set; }
        public string ToTotalParaFiscales { get; set; }
        public string ToTotalPrestaciones { get; set; }
        public string ToTotalNomina { get; set; }
        public string RPNivel { get; set; }

        /*//3. Reporte Comprobante por Empleado
        public string RPCedula { get; set; }
        public string RPNivel { get; set; }
        public string RPNombre { get; set; }
        public string RPDias { get; set; }
        public string RPTotalExtra { get; set; }
        public string RPTotalDevengado { get; set; }
        public string RPTotalDeducido { get; set; }
        public string RPNeto { get; set; }
        public string RPParaFiscales { get; set; }
        public string RPPrestaciones { get; set; }
        public string RPTotalNomina { get; set; }*/
    }
}
