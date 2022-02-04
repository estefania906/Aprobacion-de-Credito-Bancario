using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Helpers;

namespace CargaDatos
{
    public class DatosIniciales
    {
    
            public enum ListasTipo
        {
            ClientesDet, GaranteDet, CostoCuota,
            HistorialCliente, HistorialGarante, Credito,
            Validaciones
        }

        public Dictionary<ListasTipo, object> Carga()
        {
            Garante MariaSoliz = new Garante()
            {
                NombreGarante = "Maria Fernanda",
                ApellidoGarante = "Soliz Veintimilla",
                CedulaGarante = "1725201136",
                TelefonoGarante = "0999215632"
            };



            //Cliente
            Modelo.Cliente JuanSalazar = new Cliente()
            {
                NombreCliente = "Juan Ignacio",
                ApellidoCliente = "Salazar Delgado",
                CedulaCliente = "1752632215",
                TelefonoCliente = "0999235689",
                Garante = MariaSoliz,


            };

            //Cliente Det
            Cliente_Det cliente_det = new Cliente_Det()
            {
                Cliente = JuanSalazar,
                AvaluoBienParticular = 16000.00,
                Deuda_otros_bancos = 4000.00,
                Gastos_cliente = 100.00,
                ingreso_mensual_cliente = 950.00
            };
            List<Cliente_Det> listaClientesDet = new List<Cliente_Det>() { cliente_det };



            Garante_Det garante_det = new Garante_Det()
            {
                Garante = MariaSoliz,
                AvaluoBienParticular = 20000.00,
                Deuda_otros_bancos = 500.00,
                Gastos_garante = 120.00,
                ingreso_mensual_garante = 950.00
            };
         
            List<Garante_Det> listaGaranteDet = new List<Garante_Det>() { garante_det };


            //Historial Cliente
            Historial_Cliente historial_cliente = new Historial_Cliente()

            {
                DiasRetrasoCliente = 2,
                Cliente = JuanSalazar,
                CantidadPagada = 20,
                CantidadSolicitada = 140,
                FechaPagoReal = new DateTime(2021, 03, 05),
                FechaPagoSolicitada = new DateTime(2021, 03, 20),
                NumeroCuota = 1,
                Saldo = 120
            };
            OpCosto_Cuota retrasodias = new OpCosto_Cuota(historial_cliente);

            //historial_cliente.DiasRetrasoCliente = retrasodias.CalFechaCliente();

            List<Historial_Cliente> listaHistorialCliente = new List<Historial_Cliente>() { historial_cliente };

            Historial_Garante historial_garante = new Historial_Garante()

            {
                DiasRetrasoGarante = 0,
                Garante = MariaSoliz,
                CantidadPagada = 150,
                CantidadSolicitada = 150,
                FechaPagoReal = new DateTime(2021, 02, 22),
                FechaPagoSolicitada = new DateTime(2021, 02, 22),
                NumeroCuota = 1,
                Saldo = 0
            };
            OpCosto_Cuota retrasodiasgarante = new OpCosto_Cuota(historial_garante);

            //historial_garante.DiasRetrasoGarante = retrasodiasgarante.CalFechaGarante();

            List<Historial_Garante> listaHistorialGarante = new List<Historial_Garante>() { historial_garante };

            VigenciaTasaAnual Anio2021 = new VigenciaTasaAnual()
            {
                tasa_anual = 12.00,
                fecha_inicio = new DateTime(2021, 01, 01),
                fecha_fin = new DateTime(2021, 12, 31)
            };

            VigenciaTasaAnual Anio2020 = new VigenciaTasaAnual()
            {
                tasa_anual = 16.00,
                fecha_inicio = new DateTime(2020, 01, 01),
                fecha_fin = new DateTime(2020, 12, 31)
            };

            VigenciaTasaAnual Anio2022 = new VigenciaTasaAnual()
            {
                tasa_anual = 14.00,
                fecha_inicio = new DateTime(2022, 01, 01),
                fecha_fin = new DateTime(2022, 12, 31)
            };

            //Costo Cuota

            Costo_Cuota costo_cuota = new Costo_Cuota()
            {
                MontoSolicitado = 10000,
                NumeroCuotas = 36,
                VigenciaTasaAnual = Anio2022,
                TasaAnual = Anio2022.tasa_anual,
                Cliente = JuanSalazar,

            };
            List<Costo_Cuota> listaCostoCuota = new List<Costo_Cuota>() { costo_cuota };



            OpCosto_Cuota operacion = new OpCosto_Cuota(costo_cuota);

            costo_cuota.CalculoCuota = operacion.CalCuota();
            costo_cuota.CalculoAmortizacion = operacion.CalAmortizacion();
            costo_cuota.InteresMensual = operacion.CalTasaInteres();
            costo_cuota.CalculoPagoTotal = operacion.CalPagoMensual();


            //Configuracion

            Configuracion configuracion = new Configuracion()
            {
                Vigencia = Anio2022,
                meses_tope = 48
            };

            //Credito

            Credito credito = new Credito()
            {
                Cliente = JuanSalazar,
                Costo_Cuota = costo_cuota
            };

            List<Credito> listaCredito = new List<Credito>() { credito };

            //Validaciones 

            OpCosto_Cuota operacion1 = new OpCosto_Cuota(cliente_det);
            OpCosto_Cuota operacion2 = new OpCosto_Cuota(garante_det);
            OpCosto_Cuota operacion3 = new OpCosto_Cuota(historial_cliente);
            OpCosto_Cuota operacion4 = new OpCosto_Cuota(historial_garante);
            OpCosto_Cuota operacion5 = new OpCosto_Cuota(costo_cuota);

            Validaciones validaciones = new Validaciones()
            {

                val_patrimonio_cliente = operacion1.ValPatrimonioCliente(operacion5.CalPatrimonio()),
                val_patrimonio_garante = operacion2.ValPatrimonioGarante(operacion5.CalPatrimonio()),
                val_comportamiento_cliente = operacion1.ValComportamientoCliente(),
                val_comportamiento_garante = operacion2.ValComportamientoGarante(),
                val_historial_cliente = operacion3.ValHistorialCliente(),
                val_historial_garante = operacion4.ValHistorialGarante()
            };
            List<Validaciones> listaValidaciones = new List<Validaciones>() { validaciones };

            JuanSalazar.Cliente_Det = listaClientesDet;
            JuanSalazar.Costo_Cuota = listaCostoCuota;
            JuanSalazar.Historial_Cliente = listaHistorialCliente;
            JuanSalazar.Credito = listaCredito;
            JuanSalazar.Validaciones = listaValidaciones;

            MariaSoliz.Garante_Det = listaGaranteDet;
            MariaSoliz.Historial_Garante = listaHistorialGarante;
            MariaSoliz.Validaciones = listaValidaciones;

            cliente_det.Costo_Cuota = listaCostoCuota;

            historial_cliente.Validaciones = listaValidaciones;

            historial_garante.Validaciones = listaValidaciones;

            Anio2021.Costo_Cuota = listaCostoCuota;
            Anio2020.Costo_Cuota = listaCostoCuota;
            Anio2022.Costo_Cuota = listaCostoCuota;


            costo_cuota.Credito = new List<Credito>();

            Dictionary<ListasTipo, object> dicListasDatos = new Dictionary<ListasTipo, object>()
            {
                { ListasTipo.ClientesDet, listaClientesDet },
                { ListasTipo.GaranteDet, listaGaranteDet },
                { ListasTipo.CostoCuota, listaCostoCuota },
                { ListasTipo.Credito, listaCredito },
                { ListasTipo.HistorialCliente, listaHistorialCliente},
                { ListasTipo.HistorialGarante,listaHistorialGarante },
                { ListasTipo.Validaciones, listaValidaciones }
            };

            return dicListasDatos;

            /*  ModeloDB.ModeloDB repos = new ModeloDB.ModeloDB();

              repos.cliente_det.AddRange(listaClientesDet);
              repos.garante_det.AddRange(listaGaranteDet);
              repos.costo_cuota.AddRange(listaCostoCuota);
              repos.historial_cliente.AddRange(listaHistorialCliente);
              repos.historial_garante.AddRange(listaHistorialGarante);
              repos.credito.AddRange(listaCredito);
              repos.validaciones.AddRange(listaValidaciones);

              Console.WriteLine("Carga de datos iniciales ...");
              repos.SaveChanges();*/
        }
    }
   }


