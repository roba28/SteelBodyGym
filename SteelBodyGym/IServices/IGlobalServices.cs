using SteelBodyGym.Model;

namespace SteelBodyGym.IServices
{
    public interface IGlobalServices
    {
        List<Province> GetProvinces();
        List<County> Getcounties();
        List<City> GetCities();
        List<IdentificationType> GetIdentificationType();
        List<UserState> GetUserState();

        List<Role> GetRoles();

    }
}
