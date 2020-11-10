using GameKingdomDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameKingdomDB.Repos
{
    public interface IManagerRepo
    {
        void AddAManager(Manager manager);

        Manager SignInManager (string name, string password);

        Manager GetManager(string name, string password);

        List<Manager> GetAllManagers();
    }
}