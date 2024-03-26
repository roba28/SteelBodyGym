using Microsoft.AspNetCore.Mvc;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using System;
using System.Linq;

namespace SteelBodyGym.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IGlobalServices _GlobalServices;
        private readonly IAdministratorService _AdministratorService;

        public AdministratorController(IGlobalServices GlobalServices, IAdministratorService administratorService)
        {
            this._GlobalServices = GlobalServices;
            _AdministratorService = administratorService;
        }

        public IActionResult Users()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetProvinces()
        {
            var vResult = _GlobalServices.GetProvinces();
            return Ok(vResult);
        }

        [HttpPost]
        public IActionResult GetCounties()
        {
            var vResult = _GlobalServices.Getcounties();
            return Ok(vResult);
        }

        [HttpPost]
        public IActionResult GetCities()
        {
            var vResult = _GlobalServices.GetCities();
            return Ok(vResult);
        }

        [HttpPost]
        public IActionResult GetIdentificationType()
        {
            var vResult = _GlobalServices.GetIdentificationType();
            return Ok(vResult);
        }

        [HttpPost]
        public IActionResult GetUserSates()
        {
            var vResult = _GlobalServices.GetUserState();
            return Ok(vResult);
        }

        [HttpPost]
        public IActionResult GetRoles()
        {
            var vResult = _GlobalServices.GetRoles();
            return Ok(vResult);
        }

 
        public IActionResult InsertUser([FromBody] User user){
            
                var vResult = _AdministratorService.InsertUser(user);
                return Ok( vResult );
            
        }

        [HttpPost]
        public IActionResult UploadUser([FromBody] User user)
        {
                var vResult = _AdministratorService.UpdateUser(user);
                return Ok( vResult );
            

        }

        [HttpPost]
        public IActionResult GetUserData()
        {
            var vDraw = Request.Form["draw"][0];
            var vStartRec = Convert.ToInt32(Request.Form["start"][0]);
            var vPageSize = Convert.ToInt32(Request.Form["length"][0]);
            var vUserList = _AdministratorService.GetUsers();
            var vTotalRecords = vUserList.Count;
            var vRecFilter = vUserList.Count;
            vUserList = vUserList.Skip(vStartRec).Take(vPageSize).ToList();
            var result = new
            {
                draw = Convert.ToInt32(vDraw),
                recordsTotal = vTotalRecords,
                recordsFiltered = vRecFilter,
                data = vUserList
            };

            return Ok(result);
        }
        [HttpPost]
        public IActionResult DeleteUser([FromBody] string  aIdNumber)
        {

            var vResult = _AdministratorService.DeleteClientByIDNumner(aIdNumber);
            return Ok(new { data = vResult });


        }

        [HttpPost]
        public IActionResult GetUserInfoByIDNumber([FromBody] string aIdNumber)
        {

            User vResult = _AdministratorService.GetUserInfo(aIdNumber);
            return Ok(vResult);

        }

    }
}
