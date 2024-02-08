using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class ViewsPerRole
    {
        public Guid IdViewsPerRoles { get; set; }
        public Guid IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; } = null!;
    }
}
