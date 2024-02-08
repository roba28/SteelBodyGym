using System;
using System.Collections.Generic;

namespace SteelBodyGym.Model
{
    public partial class Province
    {
        public Province()
        {
            Counties = new HashSet<County>();
            Users = new HashSet<User>();
        }

        public Guid IdProvince { get; set; }
        public string ProvinceName { get; set; } = null!;

        public virtual ICollection<County> Counties { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
