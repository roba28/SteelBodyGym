using Microsoft.AspNetCore.Mvc;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using System.Net.NetworkInformation;

namespace SteelBodyGym.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdministratorService _AdministratorService;
        public LoginController(IAdministratorService administratorService) { 
         this._AdministratorService = administratorService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateLogin([FromBody] User user)
        {

            User vResult = _AdministratorService.GetUserInfo(user.IdNumber);



            if (vResult != null)
            {
                Role vrol = _AdministratorService.GetRoleByGUID(vResult.IdRol);
                if (vResult.Password == user.Password) {
                    
                    return Ok(new { Message = "El Usuario se encontro", Res = true, Rol =vrol.RolName });
                }
                else
                {
                    return Ok(new { Message = "Contraseña incorrecta", Res = false, Rol = vrol.RolName });
                }

            }
            else
            {
                return Ok(new { Message = "El Usuario no se encuentra en la base de datos", Res = false,Rol="" });
            }

        }
    }
}
