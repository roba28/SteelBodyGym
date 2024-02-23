using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using System.Data;

namespace SteelBodyGym.Services
{
    
    public class AdministratorService : IAdministratorService
    {
        public  SteelBodyGymContext _SteelBodyGymContext;

        public AdministratorService()
        {
            this._SteelBodyGymContext = new SteelBodyGymContext();
        }
        public List<Role> GetRoles( )
        {
            return _SteelBodyGymContext.Roles.ToList();
        }
       public List<PaymentType> GetPaymentTypes()
        {
            return _SteelBodyGymContext.PaymentTypes.ToList();
        }
        public List<Province> GetProvinces()
        {
            return _SteelBodyGymContext.Provinces.ToList();
        }

        public List<RoutinesPerUser> GetRoutinesPerUsers()
        {
            return _SteelBodyGymContext.RoutinesPerUsers.ToList();
        }

        public List<User> GetUsers()
        {
            return _SteelBodyGymContext.Users.ToList();
        }

        public List<UserState> GetUserStates()
        {
            return _SteelBodyGymContext.UserStates.ToList();
        }

        public List<ViewsPerRole> GetPerRoles()
        {
            return _SteelBodyGymContext.ViewsPerRoles.ToList();
        }
    }
}



