using System;
using System.Collections.Generic;

namespace GameKingdomDB.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            Orderitems = new HashSet<Orderitems>();
        }

        public int Id { get; set; }
        public string Gamename { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orderitems> Orderitems { get; set; }
    }
}
