using GameKingdomDB.Models;
using System.Collections.Generic;

namespace GameKingdomDB.Repos
{
    public interface IOrderItemsRepo
    {
        void AddToOrderItems(OrderItems orderItems);

        void UpdateOrderItems(OrderItems orderItems, int quantity);

        OrderItems GetOrderItemById(int id);

        OrderItems GetOrderItemByOrderId(int id);

        OrderItems GetOrderItemByProductId(int id);

        OrderItems GetOrderItemByOrderAndProductId(int orderId, int productId);

        List<OrderItems> GetOrderItemsById(int id);

        List<OrderItems> GetOrderItemsByOrderId(int id);
    }
}