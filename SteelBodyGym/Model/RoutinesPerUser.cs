using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class RoutinesPerUser
    {
        public Guid RoutinesPerPersonId { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdRoutine { get; set; }
        public int? Weight { get; set; }
        public int? Quantity { get; set; }
        public Guid? IdMachine { get; set; }
        public DateTime? Time { get; set; }

        public virtual GymMachine? IdMachineNavigation { get; set; }
        public virtual GymRoutine IdRoutineNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
