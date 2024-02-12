using SteelBodyGym.Model;

namespace SteelBodyGym.IServices
{
    public interface IAdministratorService
    {
        List<Role> GetRoles();

        List<BodyMeasurementsUser> GetBodyMeasurementsUsers();

        List<City> GetCity();

        List<County> GetCounties();

        List<GymMachine> GetGymMachines();

        List<GymRoutine> GetGymRoutine();

        List<IdentificationType> GetIdentificationTypes();

        List<MembershipRegistrationType> GetMembershipRegistrationTypes();

        List<PaymentsPerUser> GetPaymentsPerUsers();
    }
}
