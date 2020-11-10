using GameKingdomDB.Models;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using System;
using Serilog;

namespace GameKingdomLib
{
    public class OrderItemService
    {
        private IOrderItemsRepo repo;

        public OrderItemService(IOrderItemsRepo repo)
        {
            this.repo = repo;
        }

        public void AddToOrderItems(OrderItems orderItems)
        {
            repo.AddToOrderItems(orderItems);
        }

        public void UpdateOrderItems(OrderItems orderItems, int quantity)
        {
            repo.UpdateOrderItems(orderItems, quantity);
        }

        public OrderItems GetOrderItemById(int id)
        {
            return repo.GetOrderItemById(id);
        }

        public OrderItems GetOrderItemByOrderId(int id)
        {
            return repo.GetOrderItemByOrderId(id);
        }

        public OrderItems GetOrderItemByProductId(int id)
        {
            return repo.GetOrderItemByProductId(id);
        }

        public OrderItems GetOrderItemByOrderAndProductId(int orderId, int productId)
        {
            return repo.GetOrderItemByOrderAndProductId(orderId, productId);
        }

        public List<OrderItems> GetOrderItemsById(int id)
        {
            return repo.GetOrderItemsById(id);
        }

        public List<OrderItems> GetOrderItemsByOrderId(int id)
        {
            return repo.GetOrderItemsByOrderId(id);
        }
    }
}