using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente_Det
    {
      
        public int Cliente_DetId { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public double AvaluoBienParticular { get; set; }
        public double Deuda_otros_bancos { get; set; }
        public double Gastos_cliente { get; set; }
        public double ingreso_mensual_cliente { get; set; }


        
        public List<Costo_Cuota> Costo_Cuota { get; set; }


    }
}
