﻿using Microsoft.AspNetCore.Mvc;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using SteelBodyGym.Services;

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

        [HttpPost]
        public IActionResult UploadUser([FromBody] User user){

            var vResult = _AdministratorService.UploadUser(user);
            return Ok(vResult);


        }

    
}
}