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
            Validaciones, Garante, Cliente, VigenciaTasaAnual, Configuracion
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

            List<Garante> listaGarantes = new List<Garante>() { MariaSoliz };


            //Cliente
            Cliente JuanSalazar = new Cliente()
            {
               
                NombreCliente = "Juan Ignacio",
                ApellidoCliente = "Salazar Delgado",
                CedulaCliente = "1752632215",
                TelefonoCliente = "0999235689",
                Garante = MariaSoliz,


            };
            List<Cliente> listaClientes = new List<Cliente>() { JuanSalazar };

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

                Cliente = JuanSalazar,
                CantidadPagada = 20,
                CantidadSolicitada = 140,
                FechaPagoReal = new DateTime(2021, 03, 05),
                FechaPagoSolicitada = new DateTime(2021, 03, 20),
                NumeroCuota = 1,
                Saldo = 120
            };


            Historial_Cliente historialJuan1 = new Historial_Cliente()

            {

                Cliente = JuanSalazar,
                CantidadPagada = 50,
                CantidadSolicitada = 150,
                FechaPagoReal = new DateTime(2021, 03, 05),
                FechaPagoSolicitada = new DateTime(2021, 03, 07),
                NumeroCuota = 2,
                Saldo = 100

            };


            Historial_Cliente historialJuan2 = new Historial_Cliente()

            {

                Cliente = JuanSalazar,
                CantidadPagada = 56,
                CantidadSolicitada = 150,
                FechaPagoReal = new DateTime(2021, 03, 05),
                FechaPagoSolicitada = new DateTime(2021, 03, 06),
                NumeroCuota = 3,
                Saldo = 94

            };

            OpCosto_Cuota retrasodias = new OpCosto_Cuota(historial_cliente);

            OpCosto_Cuota retrasodiasJuan2 = new OpCosto_Cuota(historialJuan2);

            OpCosto_Cuota retrasodiasJuan1 = new OpCosto_Cuota(historialJuan1);

            historial_cliente.DiasRetrasoCliente = retrasodias.CalFechaCliente();

            historialJuan1.DiasRetrasoCliente = retrasodiasJuan1.CalFechaCliente();

            historialJuan2.DiasRetrasoCliente = retrasodiasJuan2.CalFechaCliente();

            List<Historial_Cliente> listaHistorialCliente = new List<Historial_Cliente>() { historial_cliente, historialJuan1, historialJuan2 };

            //Historial Garante

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

            //Vigencia Tasa Anual
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

            List<VigenciaTasaAnual> listaVigenciaTasaAnual = new List<VigenciaTasaAnual>() { Anio2020, Anio2021, Anio2022 };

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

            //Validaciones
            OpCosto_Cuota operacion1 = new OpCosto_Cuota(cliente_det);
            OpCosto_Cuota operacion2 = new OpCosto_Cuota(garante_det);
            OpCosto_Cuota operacion3 = new OpCosto_Cuota(historial_cliente);
            OpCosto_Cuota operacion4 = new OpCosto_Cuota(historial_garante);
            OpCosto_Cuota operacion5 = new OpCosto_Cuota(costo_cuota);
            OpCosto_Cuota opvalidaciones1 = new OpCosto_Cuota(historialJuan1);
            OpCosto_Cuota opvalidaciones2 = new OpCosto_Cuota(historialJuan2);
            OpCosto_Cuota retraso_dias = new OpCosto_Cuota(listaHistorialCliente);

            Validaciones validaciones = new Validaciones()
            {

                val_patrimonio_cliente = operacion1.ValPatrimonioCliente(operacion5.CalPatrimonio()),
                val_patrimonio_garante = operacion2.ValPatrimonioGarante(operacion5.CalPatrimonio()),
                val_comportamiento_cliente = operacion1.ValComportamientoCliente(),
                val_comportamiento_garante = operacion2.ValComportamientoGarante(),
                val_historial_cliente = operacion3.ValHistorialCliente(),
                val_historial_garante = operacion4.ValHistorialGarante(),
                Historial_Cliente = historial_cliente
            };

            Validaciones validacionesJuan1 = new Validaciones()
            {

                val_patrimonio_cliente = operacion1.ValPatrimonioCliente(operacion5.CalPatrimonio()),
                val_patrimonio_garante = operacion2.ValPatrimonioGarante(operacion5.CalPatrimonio()),
                val_comportamiento_cliente = operacion1.ValComportamientoCliente(),
                val_comportamiento_garante = operacion2.ValComportamientoGarante(),
                val_historial_garante = operacion4.ValHistorialGarante(),
                val_historial_cliente = opvalidaciones1.ValHistorialCliente(),
                Historial_Cliente = historialJuan1
            };

            Validaciones validacionesJuan2 = new Validaciones()
            {

                val_patrimonio_cliente = operacion1.ValPatrimonioCliente(operacion5.CalPatrimonio()),
                val_patrimonio_garante = operacion2.ValPatrimonioGarante(operacion5.CalPatrimonio()),
                val_comportamiento_cliente = operacion1.ValComportamientoCliente(),
                val_comportamiento_garante = operacion2.ValComportamientoGarante(),
                val_historial_cliente = opvalidaciones2.ValHistorialCliente(),
                val_historial_garante = operacion4.ValHistorialGarante(),
                Historial_Cliente = historialJuan2
            };

            validaciones.dias_retraso = retrasodias.CalDiasRetraso(listaHistorialCliente);
            validacionesJuan1.dias_retraso = retrasodias.CalDiasRetraso(listaHistorialCliente);
            validacionesJuan2.dias_retraso = retrasodias.CalDiasRetraso(listaHistorialCliente);

            //Validaciones 

            List<Validaciones> listaValidaciones = new List<Validaciones>() { validaciones, validacionesJuan1, validacionesJuan2 };

            //Configuracion

            Configuracion configuracion = new Configuracion()
            {
                BancoNombre = "Banco Proyecto S.A.",
                Vigencia = Anio2022,
                meses_tope = 48
            };

            List<Configuracion> listaConfiguracion = new List<Configuracion>() { configuracion };

            //Credito

            Credito credito = new Credito()
            {
                Cliente = JuanSalazar,
                Costo_Cuota = costo_cuota
            };

            List<Credito> listaCredito = new List<Credito>() { credito };
                 
            //Listas a cada uno de sus clientes y garantes
            JuanSalazar.Cliente_Det = listaClientesDet;
            JuanSalazar.Costo_Cuota = listaCostoCuota;
            JuanSalazar.Historial_Cliente = listaHistorialCliente;
            JuanSalazar.Credito = listaCredito;
            JuanSalazar.Validaciones = listaValidaciones;

            MariaSoliz.Garante_Det = listaGaranteDet;
            MariaSoliz.Historial_Garante = listaHistorialGarante;
            MariaSoliz.Validaciones = listaValidaciones;

            cliente_det.Costo_Cuota = listaCostoCuota;

            historial_garante.Validaciones = listaValidaciones;

            Anio2021.Costo_Cuota = listaCostoCuota;
            Anio2020.Costo_Cuota = listaCostoCuota;
            Anio2022.Costo_Cuota = listaCostoCuota;


            costo_cuota.Credito = new List<Credito>();

            Dictionary<ListasTipo, object> dicListasDatos = new Dictionary<ListasTipo, object>()
            {
                { ListasTipo.Garante, listaGarantes },
                { ListasTipo.Cliente, listaClientes },
                { ListasTipo.ClientesDet, listaClientesDet },
                { ListasTipo.GaranteDet, listaGaranteDet },
                { ListasTipo.CostoCuota, listaCostoCuota },
                { ListasTipo.Credito, listaCredito },
                { ListasTipo.HistorialCliente, listaHistorialCliente},
                { ListasTipo.HistorialGarante,listaHistorialGarante },
                { ListasTipo.Validaciones, listaValidaciones },
                { ListasTipo.VigenciaTasaAnual, listaVigenciaTasaAnual },
                { ListasTipo.Configuracion, listaConfiguracion }
            };

           return dicListasDatos;

      }
    }
   }


