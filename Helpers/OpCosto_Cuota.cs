using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Data.SqlClient;
using Modelo;


namespace Helpers
{
    public class OpCosto_Cuota
    {
        Costo_Cuota costo_cuota { get; set; }
        Historial_Cliente historial_cliente { get; set; }
        Historial_Garante historial_garante { get; set; }
        Cliente_Det cliente_det { get; set; }
        Garante_Det garante_det { get; set; }
        Validaciones validaciones { get; set; }

        public OpCosto_Cuota(Validaciones validaciones) {

            this.validaciones = validaciones;
        }

        
            public  OpCosto_Cuota (Costo_Cuota costo_cuota) {

            this.costo_cuota = costo_cuota;
        
        }

        public OpCosto_Cuota(Cliente_Det cliente_det)
        {

            this.cliente_det = cliente_det;

        }

        public OpCosto_Cuota(Garante_Det garante_det)
        {

            this.garante_det = garante_det;

        }

        public OpCosto_Cuota(Historial_Cliente historial_cliente)
        {

            this.historial_cliente = historial_cliente;

        }
        public OpCosto_Cuota(Historial_Garante historial_garante)
        {

            this.historial_garante = historial_garante;

        }

        public double CalCuota(){
            double a = Math.Pow(((1 + (costo_cuota.TasaAnual) / 100)), 0.083);
            double d = 1 / costo_cuota.NumeroCuotas;
            double c = costo_cuota.MontoSolicitado * a  *(1-(1/(Math.Pow(1 + a,d))));
            return c;

        }

       public double CalAmortizacion ()
        {
            double a = Math.Pow(((1 + (costo_cuota.TasaAnual) / 100)), 0.083);
            double d = 1 / costo_cuota.NumeroCuotas;
            double c = costo_cuota.MontoSolicitado * a * (1 - (1 / (Math.Pow(1 + a, d))));

            double f = c - ((a / 100) * costo_cuota.MontoSolicitado);
            return f;


        }

        public double CalTasaInteres()
        {
            double r = ((Math.Pow (((1 + (costo_cuota.TasaAnual) / 100)) , 0.083))-1)*100;
           
            return r;
            

        }
        public double CalPagoMensual()
        {

            double a = Math.Pow(((1 + (costo_cuota.TasaAnual) / 100)), 0.083);
            double d = 1 / costo_cuota.NumeroCuotas;
            double c = costo_cuota.MontoSolicitado * a * (1 - (1 / (Math.Pow(1 + a, d))));
            double f = c - ((a / 100) * costo_cuota.MontoSolicitado);
            double p = f + (a*100) + 10;
            return p;


        }

        public double CalPatrimonio()
        {

            double dp =  costo_cuota.MontoSolicitado * 0.4;
            return dp;
        }

        public bool ValPatrimonioCliente(double p)
        {
            bool ag  ;
            ag = (cliente_det.AvaluoBienParticular >= p);
            return ag;
        }
    
        public bool ValPatrimonioGarante(double p)
        {
            bool pg;
         
            pg = garante_det.AvaluoBienParticular >= p;
            return pg;
        }

        public bool ValComportamientoCliente()
        {
            bool cc;
            cc = (0.4 * cliente_det.ingreso_mensual_cliente) >= (cliente_det.Deuda_otros_bancos + cliente_det.Gastos_cliente);
            return cc;
        }

        public bool ValComportamientoGarante()
        {
            bool cg;
            cg = (0.4 * garante_det.ingreso_mensual_garante) >= (garante_det.Deuda_otros_bancos + garante_det.Gastos_garante)  ;
            return cg;
        }
      /*  public int CalFechaCliente() {

            int cf;
            cf = Convert.ToInt32(historial_cliente.FechaPagoSolicitada - historial_cliente.FechaPagoReal) ;
            return cf;

        }
        public int CalFechaGarante()
        {

            int cf;
            cf = Convert.ToInt32(historial_garante.FechaPagoSolicitada - historial_garante.FechaPagoReal) ;
            return cf;

        }*/

        /*public int sum()
        {
            string connectionString = "Data Source = ACER\\MSSQLSERVER2; Integrated Security = true; Initial Catalog = Northwind";
            SqlConnection conn = new SqlConnection(connectionString);
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter
                    (
                    "SELECT AVG (ALL DiasRetrasoCliente)" + " FROM Historial_Cliente " ,
                    "WHERE ClienteId = '" +historial_cliente.ClienteId +"'" ,
                    conn
                    );

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Historial_Cliente");

                foreach (DataRow fila in dataSet.Tables["Historial_Cliente"].Rows)

                {
                    int val = fila.Field<int>("val_historial_cliente");
                    Console.WriteLine("Suma: " + validaciones.val_historial_cliente);
                }

            }

            return historial_cliente.;

        }*/
        public bool ValHistorialCliente()
        {
            bool cg;
            cg = (historial_cliente.DiasRetrasoCliente)<7;
            return cg;


        }

        public bool ValHistorialGarante()
        {
            bool cg;
            cg = (historial_garante.DiasRetrasoGarante) < 7;
            return cg;


        }
    }
}
