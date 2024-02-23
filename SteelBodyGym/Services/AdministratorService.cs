using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelBodyGym.IServices;
using SteelBodyGym.Model;
using System.Data;

namespace SteelBodyGym.Services
{
    
    public class AdministratorService : IAdministratorService
    {
        public SteelBodyGymContext _SteelBodyGymContext;

        public AdministratorService()
        {
            this._SteelBodyGymContext = new SteelBodyGymContext();
        }
        public List<Role> GetRoles()
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

        public bool? UploadUser(User auser)
        {
            var userData = _SteelBodyGymContext.Users.Where(st => st.IdNumber == auser.IdNumber)
                              .Select(st => st).Single();
            User u = userData;
            if (u != null)
            {
                try
                {
                    u.IdNumber = auser.IdNumber;
                    u.Name = auser.Name;
                    u.Firstname = auser.Firstname;
                    u.LastName = auser.LastName;
                    u.BirthDate = auser.BirthDate;
                    u.Gender = auser.Gender;
                    u.IdRol = auser.IdRol;
                    u.IdentificationTypeId = auser.IdentificationTypeId;
                    u.IdProvince = auser.IdProvince;
                    u.IdCounties = auser.IdCounties;
                    u.IdCities = auser.IdCities;
                    u.Email = auser.Email;
                    u.Phone = auser.Phone;
                    _SteelBodyGymContext.Update(u);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                _SteelBodyGymContext.Users.Add(auser);
                _SteelBodyGymContext.SaveChanges();
            }
            return true;
        }

    }
}



