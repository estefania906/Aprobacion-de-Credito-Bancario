using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Historial_Garante
    {
        [Key]
        public int HistorialGaranteId { get; set; }
        public double NumeroCuota { get; set; }
        public DateTime FechaPagoReal { get; set; }
        public DateTime FechaPagoSolicitada { get; set; }
        public double CantidadPagada { get; set; }
        public double CantidadSolicitada { get; set; }
        public double Saldo { get; set; }
        public int DiasRetrasoGarante { get; set; }

        public Garante Garante { get; set; }
        public int GaranteId { get; set; }
        public List<Validaciones> Validaciones { get; set; }
    }
}
