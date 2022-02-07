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
    public class CostoCuotaController : Controller
    {
        private readonly ModeloDB.ModeloDB db;
        public CostoCuotaController(ModeloDB.ModeloDB db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Costo_Cuota> listaCostoCuota = db.costo_cuota
                                          .Include(costo_cuota => costo_cuota.Cliente)
                                          .Include(costo_cuota => costo_cuota.VigenciaTasaAnual);

           
            CalCostoCuota calCostoCuota = new CalCostoCuota(listaCostoCuota);
            ViewBag.CalCostoCuota = calCostoCuota;

            return View(listaCostoCuota);

        }

        [HttpGet]
        public IActionResult Create()
        {
            // Lista de Clientes
            var listaClientes = db.cliente
                .Select(cliente => new
                {
                    ClienteId = cliente.ClienteId,
                    Nombres = cliente.NombreCliente,
                    Apellidos = cliente.ApellidoCliente
                }).ToList();


            // Prepara las listas
            var selectListaClientes = new SelectList(listaClientes, "ClienteId", "Nombres", "Apellidos");

            var listaVigencia = db.vigencia
                .Select(vigencia => new
                {
                    VigenciaId = vigencia.VigenciaTasaAnualId,
                    TasaAnual = vigencia.tasa_anual
                }).ToList();


            // Prepara las listas
            var selectListaVigencia = new SelectList(listaVigencia, "VigenciaId", "TasaAnual");

            // Ingreso a ViewBag
            ViewBag.selectListVigencia = selectListaVigencia;
            ViewBag.selectListClientes = selectListaClientes;
            return View();
        }
        //Grabar un cliente
        [HttpPost]
        public IActionResult Create(Costo_Cuota costo_cuota)
        {
          
            db.costo_cuota.Add(costo_cuota);
            db.SaveChanges();

            TempData["mensaje"] = $"La cuota {costo_cuota.Costo_CuotaId} ha sido creada exitosamente";

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Costo_Cuota costo_cuota = db.costo_cuota.Find(id);
            return View(costo_cuota);
        }
        //Actualizar una materia
        [HttpPost]
        public IActionResult Edit(Costo_Cuota costo_cuota)
        {
            db.costo_cuota.Update(costo_cuota);
            db.SaveChanges();

            TempData["mensaje"] = $"La cuota  {costo_cuota.Costo_CuotaId} ha sido actualizada exitosamente";


            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Costo_Cuota costo_cuota = db.costo_cuota.Include(costo_cuota => costo_cuota.Cliente)
                                            .Single(costo_cuota => costo_cuota.Costo_CuotaId == id);
            return View(costo_cuota);
        }
        //Actualizar una materia
        [HttpPost]
        public IActionResult Delete(Costo_Cuota costo_cuota)
        {
            db.costo_cuota.Remove(costo_cuota);
            db.SaveChanges();

            TempData["mensaje"] = $"La cuota ha sido eliminada exitosamente";

            return RedirectToAction("Index");
        }
    }
}
