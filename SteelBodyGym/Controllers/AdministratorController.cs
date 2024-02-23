using Microsoft.AspNetCore.Mvc;

namespace SteelBodyGym.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
