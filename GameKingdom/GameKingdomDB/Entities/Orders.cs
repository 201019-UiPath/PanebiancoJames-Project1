using System;
using System.Collections.Generic;

namespace GameKingdomDB.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            Orderitems = new HashSet<Orderitems>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
        public int? Customerid { get; set; }
        public int? Locationid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Orderitems> Orderitems { get; set; }
    }
}
