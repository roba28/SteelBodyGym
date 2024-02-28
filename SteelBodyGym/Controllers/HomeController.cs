using Microsoft.AspNetCore.Mvc;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using SteelBodyGym.Models;
using System.Diagnostics;

namespace SteelBodyGym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdministratorService _AdministratorService;

        public HomeController(ILogger<HomeController> logger, IAdministratorService AdministratorService)
        {
            _logger = logger;
            _AdministratorService= AdministratorService;
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

        

        public IActionResult _LayoutAdmin()
        {
            return PartialView();
        }
        public IActionResult _LayoutCoach()
        {
            return PartialView();
        }
    }
}