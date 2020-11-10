using GameKingdomDB.Models;
using System.Collections.Generic;

namespace GameKingdomDB.Repos
{
    public interface ILocationRepo
    {
        void AddLocation(Location location);

        Location GetLocationById(int id);

        List<Location> GetAllLocations();
    }
}