using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using System.Data;

namespace SteelBodyGym.Services
{
    
    public class AdministratorService : IAdministratorService
    {
        private readonly SteelBodyGymContext _SteelBodyGymContext;
        public List<Role> GetRoles( )
        {
            return _SteelBodyGymContext.Roles.ToList();
        }
         
        

    }
}
