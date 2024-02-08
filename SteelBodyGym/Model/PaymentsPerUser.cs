using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class PaymentsPerUser
    {
        public Guid IdPaymentsPerUser { get; set; }
        public Guid? IdUser { get; set; }
        public DateTime PaymentDay { get; set; }
        public decimal Amount { get; set; }
        public Guid? IdPaymentType { get; set; }
        public Guid? IdMembershipRegistrationTypes { get; set; }

        public virtual MembershipRegistrationType? IdMembershipRegistrationTypesNavigation { get; set; }
        public virtual PaymentType? IdPaymentTypeNavigation { get; set; }
        public virtual User? IdUserNavigation { get; set; }
    }
}
