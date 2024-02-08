using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class GymMachine
    {
        public GymMachine()
        {
            RoutinesPerUsers = new HashSet<RoutinesPerUser>();
        }

        public Guid IdMachine { get; set; }
        public string MachineName { get; set; } = null!;

        public virtual ICollection<RoutinesPerUser> RoutinesPerUsers { get; set; }
    }
}
