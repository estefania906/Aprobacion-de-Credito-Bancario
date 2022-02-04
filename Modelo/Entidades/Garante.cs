using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Garante
    {
        [Key]
        public int GaranteId { get; set; }
        public string NombreGarante { get; set; }
        public string ApellidoGarante { get; set; }
        public string CedulaGarante { get; set; }
        public string TelefonoGarante { get; set; }

        public List<Garante_Det> Garante_Det { get; set; }

        public Cliente Cliente { get; set; }
   

        //La relacion con declaracion patrimonio cliente

        public List<Historial_Garante> Historial_Garante { get; set; }

        public List<Validaciones> Validaciones { get; set; }
    }
}
