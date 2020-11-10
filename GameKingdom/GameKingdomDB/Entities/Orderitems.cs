using System;
using System.Collections.Generic;

namespace GameKingdomDB.Entities
{
    public partial class Orderitems
    {
        public int Id { get; set; }
        public int Totalitems { get; set; }
        public int? Productid { get; set; }
        public int? Orderid { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
