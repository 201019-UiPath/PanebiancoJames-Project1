using System.Collections.Generic;

namespace GameKingdomDB.Models
{
    /// <summary>
    /// Location Model
    /// </summary>
    public class Location
    {
        public int Id {get; set;}
        
        public string State {get; set;}
        public string City {get; set;}
        public string Street {get; set;}
        
    }
}