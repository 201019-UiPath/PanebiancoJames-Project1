using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public interface ILocationMapper
    {
        Models.Location ParseLocation (Entities.Location location);

        Entities.Location ParseLocation (Models.Location location);

        List<Models.Location> ParseLocation (ICollection<Entities.Location> location);

        ICollection<Entities.Location> ParseLocation (List<Models.Location> location); 
    }
}