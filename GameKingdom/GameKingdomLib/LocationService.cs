using GameKingdomDB.Models;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using System;
using Serilog;

namespace GameKingdomLib
{
    public class LocationService
    {
        private ILocationRepo repo;

        public LocationService(ILocationRepo repo)
        {
            this.repo = repo;
        }

        public void AddLocation(Location newLocation)
        {
            repo.AddLocation(newLocation);
        }

        public Location GetLocationById(int id)
        {
            return repo.GetLocationById(id);
        }

        public List<Location> GetAllLocations()
        {
            return repo.GetAllLocations();
        }
    }
}