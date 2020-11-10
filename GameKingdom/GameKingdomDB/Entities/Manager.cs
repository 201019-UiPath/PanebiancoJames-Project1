using System;
using System.Collections.Generic;

namespace GameKingdomDB.Entities
{
    public partial class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int? Locationid { get; set; }

        public virtual Location Location { get; set; }
    }
}
