using GameKingdomDB.Models;
using System;
using System.Collections.Generic;

namespace GameKingdomDB.Repos
{
    public interface IOrderRepo
    {
        void AddOrder(Orders order);
        
        Orders GetOrdersById(int id);

        Orders GetOrdersByCustomerId(int id);

        Orders GetOrdersByLocationId(int id);

        Orders GetOrdersByDate(DateTime date);

        List<Orders> GetAllOrdersByCustomerId(int id);

        List<Orders> GetAllOrdersByLocationId(int id);

        List<Orders> GetAllOrdersDateAsc(int userId);
        List<Orders> GetAllOrdersDateDesc(int userId);
        List<Orders> GetAllOrdersPriceAsc(int userId);
        List<Orders> GetAllOrdersPriceDesc(int userId);
        List<Orders> GetAllLocationOrdersDateAsc(int locationId);
        List<Orders> GetAllLocationOrdersDateDesc(int locationId);
        List<Orders> GetAllLocationOrdersPriceAsc(int locationId);
        List<Orders> GetAllLocationOrdersPriceDesc(int locationId);
        
    }
}