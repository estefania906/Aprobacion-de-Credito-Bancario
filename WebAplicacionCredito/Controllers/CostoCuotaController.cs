using Microsoft.AspNetCore.Mvc;
using Modelo;
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

            IEnumerable<Costo_Cuota> listaCostoCuota = db.costo_cuota;
            return View(listaCostoCuota);
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
