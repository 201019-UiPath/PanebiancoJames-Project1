using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public interface IProductMapper
    {
        Models.Product ParseProduct (Entities.Product product);

        Entities.Product ParseProduct (Models.Product product);

        List<Models.Product> ParseProduct (ICollection<Entities.Product> product);

        ICollection<Entities.Product> ParseProduct (List<Models.Product> product);
    }
}