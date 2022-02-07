using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAplicacionCredito.Controllers
{
    public class ConfiguracionController : Controller
    {
        private readonly ModeloDB.ModeloDB db;
        public ConfiguracionController(ModeloDB.ModeloDB db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Configuracion> listaConfiguracion = db.configuracion;
            return View(listaConfiguracion);
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
