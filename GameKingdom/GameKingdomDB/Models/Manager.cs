using System.Collections.Generic;

namespace GameKingdomDB.Models
{
    /// <summary>
    /// Manager Model
    /// </summary>
    public class Manager : Person
    {
        new public int Id {get; set;}

        public int LocationId {get; set;}
    }
}