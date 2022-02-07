using Microsoft.AspNetCore.Mvc;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAplicacionCredito.Controllers
{
    public class GaranteControler : Controller
    {
        private readonly ModeloDB.ModeloDB db;
        public GaranteControler(ModeloDB.ModeloDB db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Garante> listaGarante = db.garante;
            return View(listaGarante);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Garante garante)
        {
            db.garante.Add(garante);
            db.SaveChanges();

            TempData["mensaje"] = $"El garante {garante.NombreGarante + " " + garante.ApellidoGarante} ha sido creado exitosamente";

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Garante garante = db.garante.Find(id);
            return View(garante);
        }

        [HttpPost]
        public IActionResult Edit(Garante garante)
        {
            db.garante.Update(garante);
            db.SaveChanges();

            TempData["mensaje"] = $"El garante {garante.NombreGarante + " " + garante.ApellidoGarante} ha sido actualizada exitosamente";


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Garante garante = db.garante.Find(id);
            return View(garante);
        }
        //Actualizar una materia
        [HttpPost]
        public IActionResult Delete(Garante garante)
        {
            db.garante.Remove(garante);
            db.SaveChanges();

            TempData["mensaje"] = $"El garante ha sido eliminado exitosamente";

            return RedirectToAction("Index");
        }
    }
}
