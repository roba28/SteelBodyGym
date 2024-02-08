using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class GymRoutine
    {
        public GymRoutine()
        {
            RoutinesPerUsers = new HashSet<RoutinesPerUser>();
        }

        public Guid IdRoutine { get; set; }
        public string RoutineName { get; set; } = null!;

        public virtual ICollection<RoutinesPerUser> RoutinesPerUsers { get; set; }
    }
}
