using System;
using System.Collections.Generic;

namespace GameKingdomDB.Entities
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            Manager = new HashSet<Manager>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Manager> Manager { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
