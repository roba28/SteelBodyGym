using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class MembershipRegistrationType
    {
        public MembershipRegistrationType()
        {
            PaymentsPerUsers = new HashSet<PaymentsPerUser>();
        }

        public Guid IdMembershipRegistrationTypes { get; set; }
        public string RegistrationTypeName { get; set; } = null!;

        public virtual ICollection<PaymentsPerUser> PaymentsPerUsers { get; set; }
    }
}
