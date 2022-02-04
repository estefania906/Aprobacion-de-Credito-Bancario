using Consola;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Modelo.Calculo
{
    public class CalHistorialCliente
    {
        public double diasRetraso { get; set; }

        public int idCliente { get; set; }
        Cliente cliente { get; set; }
   
        public CalHistorialCliente( Cliente cliente) {

            this.idCliente = cliente.ClienteId;
      
        }

        public double Promedio(Historial_Cliente historial_cliente) {

                 var listaHistorialCliente = new List<Historial_Cliente>()
                                .Where(historial_cliente => historial_cliente.ClienteId == idCliente);

                double suma = 0;
                foreach (var item in listaHistorialCliente)
                {
                    suma += item.DiasRetrasoCliente;
                }
                double promedio = 0;

                promedio = suma / listaHistorialCliente.Count();

                return promedio;
            
        }
    }
}
