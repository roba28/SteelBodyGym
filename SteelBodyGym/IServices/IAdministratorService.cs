using SteelBodyGym.Model;

namespace SteelBodyGym.IServices
{
    public interface IAdministratorService
    {
        List<Role> GetRoles();
        List<PaymentType> GetPaymentTypes();
        List<Province> GetProvinces();

        List<RoutinesPerUser> GetRoutinesPerUsers();

        List<User> GetUsers();

        List<UserState> GetUserStates();

        List<ViewsPerRole> GetPerRoles();
        bool UpdateUser(User auser);
        bool InsertUser(User auser);
        User GetUserInfo(string aIdNumber);
        Role GetRoleByGUID(Guid aRolGUID);

        bool DeleteClientByIDNumner(string aIDNumber);
    }
}
