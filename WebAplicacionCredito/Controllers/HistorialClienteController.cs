using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Calculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAplicacionCredito.Controllers
{
    public class HistorialClienteController : Controller
    {
        private readonly ModeloDB.ModeloDB db;
        public HistorialClienteController(ModeloDB.ModeloDB db)
        {

            this.db = db;
        }
        public IActionResult Index(int id)
        {

            IEnumerable<Historial_Cliente> listaHistorialCliente = db.historial_cliente.Include(historial_cliente => historial_cliente.Cliente);
            return View(listaHistorialCliente);
        }
        //Crear una formulario vacio
        [HttpGet]
        public IActionResult Create()
        {
            // Lista de Validaciones
            var listaValidaciones = db.validaciones
                .Select(validaciones => new
                {
                    ValidacionesId = validaciones.ValidacionesId,
                    ValidacionHistorialCliente = validaciones.val_historial_cliente
                    
                }).ToList();


            // Prepara las listas
            var selectListaValidaciones = new SelectList(listaValidaciones, "ValidacionesId", "ValidacionHistorialCliente");

            // Ingreso a ViewBag
            ViewBag.selectListValidaciones = selectListaValidaciones;
           
            return View();
        }
        [HttpPost]

        public IActionResult Create(Historial_Cliente historial_cliente)
        {
            db.historial_cliente.Add(historial_cliente);
            db.SaveChanges();

            TempData["mensaje"] = $"El registro del cliente {historial_cliente.Cliente.NombreCliente + " " + historial_cliente.Cliente.ApellidoCliente} ha sido creado exitosamente";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Historial_Cliente historial_cliente = db.historial_cliente.Find(id);
            return View(historial_cliente);
           
        }
        [HttpPost]
        public IActionResult Edit(Historial_Cliente historial_cliente)
        {
            db.historial_cliente.Update(historial_cliente);
            db.SaveChanges();

            TempData["mensaje"] = $"El registro del cliente {historial_cliente.Cliente.NombreCliente + " " + historial_cliente.Cliente.ApellidoCliente} ha sido actualizada exitosamente";


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Historial_Cliente historial_cliente = db.historial_cliente.Find(id);
            return View(historial_cliente);
        }
        //Actualizar una materia
        [HttpPost]
        public IActionResult Delete(Historial_Cliente historial_cliente)
        {
            db.historial_cliente.Remove(historial_cliente);
            db.SaveChanges();

            TempData["mensaje"] = $"El registro ha sido eliminado exitosamente";

            return RedirectToAction("Index");
        }

     
        public IActionResult Validar(int id)
        {
            var historial_cliente = db.historial_cliente
               .Include(historial_cliente => historial_cliente.Cliente)
               .Include(historial_cliente => historial_cliente.Validaciones)
                 .ThenInclude(validaciones => validaciones.Cliente)
               .Include(historial_cliente => historial_cliente.Validaciones)
                  .ThenInclude(validaciones => validaciones.Historial_Cliente)
                  .ThenInclude(validaciones => validaciones.Cliente)
           .Single(historial_cliente => historial_cliente.Historial_ClienteId == id);

            // .Single(cliente => cliente.ClienteId == id);
            var cliente = db.cliente.Single(cliente => cliente.ClienteId == historial_cliente.Cliente.ClienteId);

            CalHistorialCliente calHistorialCliente = new CalHistorialCliente(cliente);
            ViewBag.CalHistorialCliente = calHistorialCliente;
            return View(historial_cliente);
        }
    }
}
