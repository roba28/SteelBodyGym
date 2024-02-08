using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class IdentificationType
    {
        public IdentificationType()
        {
            Users = new HashSet<User>();
        }

        public Guid IdentificationTypeId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
