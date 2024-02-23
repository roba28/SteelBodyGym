using SteelBodyGym.IServices;
using SteelBodyGym.Model;

namespace SteelBodyGym.Services
{
    public class GlobalServices : IGlobalServices
    {
        public SteelBodyGymContext _SteelBodyGymContext;
        public GlobalServices()
        {
            this._SteelBodyGymContext = new SteelBodyGymContext();
        }

        public List<Province> GetProvinces()
        {
            return _SteelBodyGymContext.Provinces.ToList();
        }

        public List<County> Getcounties()
        {
            return _SteelBodyGymContext.Counties.ToList();
        }

        public List<City> GetCities()
        {
            return _SteelBodyGymContext.Cities.ToList();
        }

        public List<IdentificationType> GetIdentificationType()
        {
            return _SteelBodyGymContext.IdentificationTypes.ToList();
        }

        public List<UserState> GetUserState()
        {
            return _SteelBodyGymContext.UserStates.ToList();
        }

        public List<Role> GetRoles()
        {
            return _SteelBodyGymContext.Roles.ToList();
        }
    }
}
