using Microsoft.AspNetCore.Mvc;

namespace SteelBodyGym.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
