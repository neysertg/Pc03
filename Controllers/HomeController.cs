using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pc03.Data;
using Pc03.Models;

namespace Pc03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
             _context = context;
        }

         public IActionResult Busco()
        { 

            var productos = _context.Productos.ToList();
            return View(productos);
        }
        public IActionResult Index()
        {
          DateTime fecha= DateTime.Today.AddDays(-7);
            var productos = _context.Productos.Where(p => p.addDate == fecha).ToList();
            return View();
        }

       public IActionResult Producto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Producto(Producto p)
        {
            if(ModelState.IsValid){
                _context.Add(p);
                _context.SaveChanges();
                 Console.WriteLine("Producto añadido");
                return RedirectToAction("Busco");
            }
            return View(p);
        }
        
         [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var productos = _context.Productos.FirstOrDefault(p => p.id == id);
            _context.Remove(productos);
            _context.SaveChanges();
            return RedirectToAction("Busco");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
