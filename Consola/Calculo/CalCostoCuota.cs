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
    public class CalCostoCuota
    {
        public int idCuota { get; set; }
        Costo_Cuota costo_cuota { get; set; }
   
        public CalCostoCuota(IEnumerable<Costo_Cuota> listaCostoCuota) {

           
        }

        public double CalCuota(List<Costo_Cuota> listaCostoCuota) 
        {
            double c = 0;
            foreach (var item in listaCostoCuota)
            {
                double a = Math.Pow(((1 + (item.TasaAnual) / 100)), 0.083);
                double d = 1 / item.NumeroCuotas;
                c = item.MontoSolicitado * a * (1 - (1 / (Math.Pow(1 + a, d))));
            }
            return c;

        }
        public double CalAmortizacion(List<Costo_Cuota> listaCostoCuota)
        {
            double f = 0;

            foreach (var item in listaCostoCuota)
            {
                double a = Math.Pow(((1 + (item.TasaAnual) / 100)), 0.083);
                double d = 1 / item.NumeroCuotas;
                double c = item.MontoSolicitado * a * (1 - (1 / (Math.Pow(1 + a, d))));

                 f = c - ((a / 100) * item.MontoSolicitado);
            }
            return f;


        }

        public double CalTasaInteres(List<Costo_Cuota> listaCostoCuota)
        {
            double r = 0;

            foreach (var item in listaCostoCuota)
            {
                r = ((Math.Pow(((1 + (item.VigenciaTasaAnual.tasa_anual) / 100)), 0.083)) - 1) * 100;
            }
            return r;


        }
        public double CalPagoMensual(List<Costo_Cuota> listaCostoCuota)
        {
            double p = 0;
            foreach (var item in listaCostoCuota)
            {
                double a = Math.Pow(((1 + (item.TasaAnual) / 100)), 0.083);
                double d = 1 / item.NumeroCuotas;
                double c = item.MontoSolicitado * a * (1 - (1 / (Math.Pow(1 + a, d))));
                double f = c - ((a / 100) * item.MontoSolicitado);
                p = f + (a * 100) + 10;
            }
            return p;


        }

        public double CalPatrimonio(List<Costo_Cuota> listaCostoCuota)
        {
            double dp = 0;
            foreach (var item in listaCostoCuota)
            {
                dp = item.MontoSolicitado * 0.4;
            }
            return dp;
        }
    }
}
