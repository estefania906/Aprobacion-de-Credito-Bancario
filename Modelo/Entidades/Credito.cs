
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Credito
    {
       
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public Costo_Cuota Costo_Cuota { get; set; }
        public int Costo_CuotaId { get; set; }

    }
}
