using GameKingdomDB.Models;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Serilog;

namespace GameKingdomLib
{
    public class ManagerService
    {
        public IManagerRepo repo;

        public ManagerService(IManagerRepo repo)
        {
            this.repo = repo;
        }

        public void AddManager(Manager newManager)
        {
            repo.AddAManager(newManager);
        }

        public Manager SignInManager(string name, string password)
        {
            List<Manager> getManagers = repo.GetAllManagers();
            foreach(var manager in getManagers)
            {
                if((manager.Name.Equals(name)) && (manager.Password.Equals(password)))
                {
                    return repo.SignInManager(name,password);
                }
                else
                {
                    Log.Error($"Invalid Login. Name: {name} Password: {password}");
                    throw new Exception("\nInvalid Name/Password. Please try again");
                }
            }
            return repo.SignInManager(name,password);
        }

        public Manager GetManager(string name, string password)
        {
            return repo.GetManager(name, password);
        }
        public List<Manager> GetAllManagers()
        {
            return repo.GetAllManagers();
        }
    }
}