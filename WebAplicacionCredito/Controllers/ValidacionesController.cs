using Microsoft.AspNetCore.Mvc;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAplicacionCredito.Controllers
{
    public class ValidacionesController : Controller
    {
        private readonly ModeloDB.ModeloDB db;
        public ValidacionesController(ModeloDB.ModeloDB db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Validaciones> listaValidaciones = db.validaciones;
            return View(listaValidaciones);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
