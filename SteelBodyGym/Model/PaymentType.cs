using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            PaymentsPerUsers = new HashSet<PaymentsPerUser>();
        }

        public Guid IdPaymentType { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<PaymentsPerUser> PaymentsPerUsers { get; set; }
    }
}
