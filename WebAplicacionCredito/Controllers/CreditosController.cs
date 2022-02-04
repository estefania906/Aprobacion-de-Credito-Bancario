using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModeloDB;
using Modelo;

namespace WebAplicacionCredito.Controllers
{
    public class CreditosController : Controller
    {
        private readonly ModeloDB.ModeloDB db;
        public CreditosController(ModeloDB.ModeloDB db) {

            this.db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Credito> listaCreditos = db.credito;
            return View(listaCreditos);
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
