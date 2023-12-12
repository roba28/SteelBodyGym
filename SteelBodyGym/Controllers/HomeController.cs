using Microsoft.AspNetCore.Mvc;
using SteelBodyGym.Models;
using System.Diagnostics;

namespace SteelBodyGym.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult contacto()
        {
            return View();
        }
        public IActionResult Servicios()
        {
            return View();
        }
        public IActionResult AcercaDeNosotros()
        {
            return View();
        }
        public IActionResult Clases()
        {
            return View();
        }
        public IActionResult Ingresar()
        {
            return View();
        }
    }
}