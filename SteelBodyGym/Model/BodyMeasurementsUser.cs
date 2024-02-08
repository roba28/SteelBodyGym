using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class BodyMeasurementsUser
    {
        public Guid IdMeasure { get; set; }
        public Guid? IdUser { get; set; }
        public DateTime MeasurementDate { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Waist { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}
