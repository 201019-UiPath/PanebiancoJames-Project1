using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public interface IManagerMapper
    {

        Models.Manager ParseManager (Entities.Manager manager);

        Entities.Manager ParseManager (Models.Manager manager);

        List<Models.Manager> ParseManager (ICollection<Entities.Manager> managers);

        ICollection<Entities.Manager> ParseManager (List<Models.Manager> managers);

    }
}