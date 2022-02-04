using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Validaciones
    {
        [Key]
        public int ValidacionesId { get; set; }

        public bool val_patrimonio_cliente { get; set; }

        public bool val_patrimonio_garante { get; set; }

        public bool val_comportamiento_cliente { get; set; }

        public bool val_comportamiento_garante { get; set; }

        public bool val_historial_cliente { get; set; }

        public bool val_historial_garante { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public Garante Garante { get; set; }
        public int GaranteId { get; set; }

        public Historial_Cliente Historial_Cliente { get; set; }
        public int HistorialClienteId { get; set; }

        public Historial_Garante Historial_Garante { get; set; }
        public int HistorialGaranteId { get; set; }
    }
}
