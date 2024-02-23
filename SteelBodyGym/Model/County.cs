using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class County
    {
        public County()
        {
            Cities = new HashSet<City>();
            Users = new HashSet<User>();
        }

        public Guid IdCounties { get; set; }
        public string Name { get; set; } = null!;
        public Guid? IdProvince { get; set; }

        public virtual Province? IdProvinceNavigation { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
