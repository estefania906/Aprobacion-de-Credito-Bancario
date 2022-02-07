using CargaDatos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CargaDatos.DatosIniciales;
using ModeloDB;
using Microsoft.EntityFrameworkCore;

namespace Consola
{
    public class Grabar
    {
        public void DatosIni()
        {
            DatosIniciales datos = new DatosIniciales();
            var listas = datos.Carga();

            // Extraer del diccionario las listas
            var listaGarante = (List<Garante>)listas[ListasTipo.Garante];
            var listaCliente = (List<Cliente>)listas[ListasTipo.Cliente];
            var listaClienteDet = (List<Cliente_Det>)listas[ListasTipo.ClientesDet];
            var listaGaranteDet = (List<Garante_Det>)listas[ListasTipo.GaranteDet];
            var listaHistorialCliente = (List<Historial_Cliente>)listas[ListasTipo.HistorialCliente];
            var listaHistorialGarante = (List<Historial_Garante>)listas[ListasTipo.HistorialGarante];
            var listaCredito = (List<Credito>)listas[ListasTipo.Credito];
            var listaValidaciones = (List<Validaciones>)listas[ListasTipo.Validaciones];
            var listaVigenciaTasaAnual = (List<VigenciaTasaAnual>)listas[ListasTipo.VigenciaTasaAnual];
            var listaConfiguracion = (List<Configuracion>)listas[ListasTipo.Configuracion];

            //Grabar
            ModeloDB.ModeloDB db = ModeloDBBuilder.Crear();
            db.PreparaDB();

            db.garante.AddRange(listaGarante);
            db.cliente.AddRange(listaCliente);
            db.cliente_det.AddRange(listaClienteDet);
            db.garante_det.AddRange(listaGaranteDet);
            db.historial_cliente.AddRange(listaHistorialCliente);
            db.historial_garante.AddRange(listaHistorialGarante);
            db.credito.AddRange(listaCredito);
            db.validaciones.AddRange(listaValidaciones);
            db.vigencia.AddRange(listaVigenciaTasaAnual);
            db.configuracion.AddRange(listaConfiguracion);

            db.SaveChanges();
        }
    }
}
