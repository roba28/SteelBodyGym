using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        public Guid IdCities { get; set; }
        public string Name { get; set; } = null!;
        public Guid? IdCounties { get; set; }

        public virtual County IdCitiesNavigation { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
