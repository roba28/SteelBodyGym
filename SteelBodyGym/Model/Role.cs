using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            ViewsPerRoles = new HashSet<ViewsPerRole>();
        }

        public Guid IdRol { get; set; }
        public string RolName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<ViewsPerRole> ViewsPerRoles { get; set; }
    }
}
