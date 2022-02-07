using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Configuracion
    {
        public string BancoNombre { get; set; }
        public VigenciaTasaAnual Vigencia { get; set; }
        public int VigenciaTasaAnualId { get; set; }
        public double meses_tope { get; set; }
    }
}
