using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Costo_Cuota
    {
       
        public int Costo_CuotaId { get; set; }
        public double CalculoCuota { get; set; }
        public double CalculoAmortizacion { get; set; }
        public double TasaAnual { get; set; }
        public double InteresMensual { get; set; }
        public double CalculoPagoTotal { get; set; }
        public double MontoSolicitado { get; set; }
        public double NumeroCuotas { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public VigenciaTasaAnual VigenciaTasaAnual { get; set; }
        public int VigenciaTasaAnualId { get; set; }
        public List<Credito> Credito { get; set; }

    }
}
