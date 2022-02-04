using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Garante_Det
    {
        [Key]
        public int GaranteDetId { get; set; }
        public Garante Garante { get; set; }
        public int GaranteId { get; set; }
        public double AvaluoBienParticular { get; set; }
        public double Deuda_otros_bancos { get; set; }
        public double Gastos_garante { get; set; }
        public double ingreso_mensual_garante { get; set; }
       

    }
}
