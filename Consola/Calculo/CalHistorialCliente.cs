using Consola;
using ModeloDB;
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
 
        public int idCliente { get; set; }
        Cliente cliente { get; set; }
   
        public CalHistorialCliente(Cliente cliente) {

             this.idCliente = cliente.ClienteId;
           
        }

        public double Promedio(List<Historial_Cliente> listaHistorialCliente) 
        {
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
