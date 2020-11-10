using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public interface IOrderMapper
    {
        Models.Orders ParseOrders (Entities.Orders orders);

        Entities.Orders ParseOrders (Models.Orders orders);

        List<Models.Orders> ParseOrders (ICollection<Entities.Orders> orders);

        ICollection<Entities.Orders> ParseOrders (List<Models.Orders> orders);
        
    }
}