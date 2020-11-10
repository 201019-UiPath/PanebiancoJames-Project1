using System.Collections.Generic;

namespace GameKingdomDB.Models
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class Customer : Person
    {
        new public int Id {get; set;}

        public string Address {get; set;}
    }
}