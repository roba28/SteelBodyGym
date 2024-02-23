using System;
using System.Collections.Generic;

namespace SteelBodyGym.Models
{
    public partial class User
    {
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
    }
}
