using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public interface IOrderItemsMapper
    {
        Models.OrderItems ParseOrderItems (Entities.Orderitems orderItems);

        Entities.Orderitems ParseOrderItems (Models.OrderItems orderItems);

        List<Models.OrderItems> ParseOrderItems (ICollection<Entities.Orderitems> orderItems);

        ICollection<Entities.Orderitems> ParseOrderItems (List<Models.OrderItems> orderItems);
    }
}