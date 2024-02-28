using Microsoft.AspNetCore.Mvc;
using SteelBodyGym.IServices;

namespace SteelBodyGym.Controllers
{
    public class CoachController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult User()
        {
            return View();
        }
        public IActionResult GymMachines()
        {
            return View();
        }
        public IActionResult Routines()
        {
            return View();
        }
    }
}
