using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class User
    {
        public User()
        {
            BodyMeasurementsUsers = new HashSet<BodyMeasurementsUser>();
            PaymentsPerUsers = new HashSet<PaymentsPerUser>();
            RoutinesPerUsers = new HashSet<RoutinesPerUser>();
        }

        public Guid IdUser { get; set; }
        public string IdNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        public Guid IdRol { get; set; }
        public Guid IdentificationTypeId { get; set; }
        public Guid IdState { get; set; }
        public Guid? IdProvince { get; set; }
        public Guid? IdCounties { get; set; }
        public Guid? IdCities { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }

        public virtual City? IdCitiesNavigation { get; set; }
        public virtual County? IdCountiesNavigation { get; set; }
        public virtual Province? IdProvinceNavigation { get; set; }
        public virtual Role IdRolNavigation { get; set; } = null!;
        public virtual UserState IdStateNavigation { get; set; } = null!;
        public virtual IdentificationType IdentificationType { get; set; } = null!;
        public virtual ICollection<BodyMeasurementsUser> BodyMeasurementsUsers { get; set; }
        public virtual ICollection<PaymentsPerUser> PaymentsPerUsers { get; set; }
        public virtual ICollection<RoutinesPerUser> RoutinesPerUsers { get; set; }
    }
}
