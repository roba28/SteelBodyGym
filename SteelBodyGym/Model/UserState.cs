using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class UserState
    {
        public UserState()
        {
            Users = new HashSet<User>();
        }

        public Guid IdState { get; set; }
        public string StateName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
