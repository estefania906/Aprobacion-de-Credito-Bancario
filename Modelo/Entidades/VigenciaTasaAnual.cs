using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class VigenciaTasaAnual
    {
        
        public int VigenciaTasaAnualId { get; set; }

        public double tasa_anual { get; set; }


        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        public List<Costo_Cuota> Costo_Cuota { get; set; }
    }
}
