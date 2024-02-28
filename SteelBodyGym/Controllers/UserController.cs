using Microsoft.AspNetCore.Mvc;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using SteelBodyGym.Services;

namespace SteelBodyGym.Controllers
{
    public class UserController : Controller
    {
        public IActionResult RoutinesPerUSer()
        {
            return View();
        }

        public IActionResult BodyMeasurmentsUser()
        {
            return View();
        }
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
