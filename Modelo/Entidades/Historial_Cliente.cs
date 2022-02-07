using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Historial_Cliente
    {
        
        public int Historial_ClienteId { get; set; }
        public double NumeroCuota { get; set; }
        public DateTime FechaPagoReal { get; set; }
        public DateTime FechaPagoSolicitada { get; set; }
        public double CantidadPagada { get; set; }
        public double CantidadSolicitada { get; set; }
        public double Saldo { get; set; }
        public double DiasRetrasoCliente { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public List<Validaciones> Validaciones { get; set; }

    }
}
