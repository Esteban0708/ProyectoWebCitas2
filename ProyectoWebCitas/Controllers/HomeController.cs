using Microsoft.AspNetCore.Mvc;
using ProyectoWebCitas.Models;
using System.Diagnostics;


namespace ProyectoWebCitas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult iniciosesion()
        {
            return View();
        }
        public IActionResult olvidocontraseña()
        {
            return View();
        }

        public IActionResult IngresarCodigo()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}