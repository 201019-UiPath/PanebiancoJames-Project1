using GameKingdomDB.Models;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using System;
using Serilog;

namespace GameKingdomLib
{
    public class OrderService
    {
        private IOrderRepo repo;

        private ProductService productService;

        private LocationService locationService;

        public OrderService(IOrderRepo repo)
        {
            this.repo = repo;

            this.locationService = new LocationService((ILocationRepo) repo);
            this.productService = new ProductService((IProductRepo) repo);
        }

        public void AddOrder(Orders newOrder)
        {
            repo.AddOrder(newOrder);
        }

        public Orders GetOrdersById(int id)
        {
            return repo.GetOrdersById(id);
        }
        
        public Orders GetOrdersByCustomerId(int id)
        {
            return repo.GetOrdersByCustomerId(id);
        }

        public Orders GetOrdersByLocationId(int id)
        {
            return repo.GetOrdersByLocationId(id);
        }

        public Orders GetOrdersByDate(DateTime date)
        {
            return repo.GetOrdersByDate(date);
        }

        public List<Orders> GetAllOrdersByCustomerId(int id)
        {
            return repo.GetAllOrdersByCustomerId(id);
        }

        public List<Orders> GetAllOrdersByLocationId(int id)
        {
            return repo.GetAllOrdersByLocationId(id);
        }

        public List<Orders> GetAllOrdersDateAsc(int customerId)
        {
            return repo.GetAllOrdersDateAsc(customerId);
        }
        public List<Orders> GetAllOrdersDateDesc(int customerId)
        {
            return repo.GetAllOrdersDateDesc(customerId);
        }
        public List<Orders> GetAllOrdersPriceAsc(int customerId)
        {
            return repo.GetAllOrdersPriceAsc(customerId);
        }
        public List<Orders> GetAllOrdersPriceDesc(int customerId)
        {
            return repo.GetAllOrdersPriceDesc(customerId);
        }
        public List<Orders> GetAllLocationOrdersDateAsc(int locatoinId)
        {
            return repo.GetAllLocationOrdersDateAsc(locatoinId);
        }
        public List<Orders> GetAllLocationOrdersDateDesc(int locatoinId)
        {
            return repo.GetAllLocationOrdersDateDesc(locatoinId);
        }
        public List<Orders> GetAllLocationOrdersPriceAsc(int locatoinId)
        {
            return repo.GetAllLocationOrdersPriceAsc(locatoinId);
        }
        public List<Orders> GetAllLocationOrdersPriceDesc(int locatoinId)
        {
            return repo.GetAllLocationOrdersPriceDesc(locatoinId);
        }
    }
}