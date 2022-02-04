using Microsoft.AspNetCore.Mvc;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAplicacionCredito.Controllers
{
    public class VigenciaTasaAnualController : Controller
    {
        private readonly ModeloDB.ModeloDB db;
        public VigenciaTasaAnualController(ModeloDB.ModeloDB db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<VigenciaTasaAnual> listaVigenciaTasaAnual = db.vigencia;
            return View(listaVigenciaTasaAnual);
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
