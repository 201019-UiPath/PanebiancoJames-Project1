using GameKingdomDB.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameKingdomDB.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using GameKingdomDB.Models;

namespace GameKingdomDB.Repos
{
    public class DBRepo : ICustomerRepo, IManagerRepo, IOrderRepo, IProductRepo, ILocationRepo, IInventoryRepo, IOrderItemsRepo
    {
        private readonly GameKingdomContext context;

        private readonly IMapper mapper;
        
        public DBRepo(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddACustomer(Models.Customer customer)
        {
            context.Customer.Add(mapper.ParseCustomer(customer));
            context.SaveChanges();
        }

        public Models.Customer SignInCustomer(string name, string password)
        {
            return mapper.ParseCustomer(context.Customer.First(x => x.Name == name && x.Password == password));
        }

        public void AddAManager(Models.Manager manager)
        {
            context.Manager.Add(mapper.ParseManager(manager));
            context.SaveChanges();
        }

        public List<Models.Customer> GetAllCustomers()
        {
            return mapper.ParseCustomer(context.Customer.ToList());
        }

        public void AddOrder(Models.Orders order)
        {
            context.Orders.Add(mapper.ParseOrders(order));
            context.SaveChanges();
        }

        public Models.Orders GetOrdersById(int id)
        {
            return mapper.ParseOrders(context.Orders.First(x => x.Id == id));
        }

        public Models.Orders GetOrdersByCustomerId(int id)
        {
            return mapper.ParseOrders(context.Orders.First(x => x.Customerid == id));
        }

        public Models.Orders GetOrdersByLocationId(int id)
        {
            return mapper.ParseOrders(context.Orders.First(x => x.Locationid == id));
        }

        public Models.Orders GetOrdersByDate(DateTime date)
        {
            return mapper.ParseOrders(context.Orders.First(x => x.Date == date));
        }

        public List<Models.Orders> GetAllOrdersByCustomerId(int id)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Customerid == id).ToList());
        }

        public List<Models.Orders> GetAllOrdersByLocationId(int id)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Locationid == id).ToList());
        }

        public void AddProduct(Models.Product product)
        {
            context.Product.Add(mapper.ParseProduct(product));
            context.SaveChanges();
        }

        public Models.Product GetProductById(int id)
        {
            return mapper.ParseProduct(context.Product.First(x => x.Id == id));
        }

        public Models.Product GetProductByName(string name)
        {
            return mapper.ParseProduct(context.Product.First(x => x.Gamename == name));
        }

        public List<Models.Product> GetAllProducts()
        {
            return mapper.ParseProduct(context.Product.ToList());
        }

        public List<Models.Product> GetAllProductsById(int id)
        {
            return mapper.ParseProduct(context.Product.Where(x => x.Id == id).ToList());
        }

        public void AddLocation(Models.Location location)
        {
            context.Location.Add(mapper.ParseLocation(location));
            context.SaveChanges();
        }

        public Models.Location GetLocationById(int id)
        {
            return mapper.ParseLocation(context.Location.First(x => x.Id == id));
        }

        public List<Models.Location> GetAllLocations()
        {
            return mapper.ParseLocation(context.Location.ToList());
        }

        public void AddToInventory(Models.Inventory inventoryItem)
        {
            context.Inventory.Add(mapper.ParseInventory(inventoryItem));
            context.SaveChanges();
        }

        public void RemoveFromInventory(int locationId, int productId, int quantity)
        {
            context.Inventory.Single(x => x.Locationid == locationId && x.Productid == productId).Quantity -= quantity;
            context.SaveChanges();
        }

        public void AddToInventory(int locationId, int productId, int quantity)
        {
            context.Inventory.Single(x => x.Locationid == locationId && x.Productid == productId).Quantity += quantity;
            context.SaveChanges();
        }

        public Models.Inventory GetInventoryById(int id)
        {
            return mapper.ParseInventory(context.Inventory.First(x => x.Id == id));
        }

        public Models.Inventory GetInventoryByLocationId(int id)
        {
            return mapper.ParseInventory(context.Inventory.First(x => x.Locationid == id));
        }

        public Models.Inventory GetProductByLocationAndProductId(int locationId, int productId)
        {
            return mapper.ParseInventory(context.Inventory.First(x => x.Locationid == locationId && x.Productid == productId));
        }

        public List<Models.Inventory> GetInventoriesById(int id)
        {
            return mapper.ParseInventory(context.Inventory.Where(x => x.Id == id).ToList());
        }

        public List<Models.Inventory> GetInventoriesByLocationId(int id)
        {
            return mapper.ParseInventory(context.Inventory.Where(x => x.Locationid == id).ToList());
        }

        public Models.Customer GetCustomer(string name, string password)
        {
            return mapper.ParseCustomer(context.Customer.First(x => x.Name == name && x.Password == password));
        }

        public void AddToOrderItems(OrderItems orderItems)
        {
            context.Orderitems.Add(mapper.ParseOrderItems(orderItems));
            context.SaveChanges();
        }

        public void UpdateOrderItems(OrderItems orderItems, int quantity)
        {
            context.Orderitems.Single(x => x.Id == orderItems.Id).Totalitems += quantity;
            context.SaveChanges();
        }

        public OrderItems GetOrderItemById(int id)
        {
            return mapper.ParseOrderItems(context.Orderitems.First(x => x.Id == id));
        }

        public OrderItems GetOrderItemByOrderId(int id)
        {
            return mapper.ParseOrderItems(context.Orderitems.First(x => x.Orderid == id));
        }

        public OrderItems GetOrderItemByProductId(int id)
        {
            return mapper.ParseOrderItems(context.Orderitems.First(x => x.Productid == id));
        }

        public OrderItems GetOrderItemByOrderAndProductId(int orderId, int productId)
        {
            return mapper.ParseOrderItems(context.Orderitems.First(x => x.Orderid == orderId && x.Productid == productId));
        }

        public List<OrderItems> GetOrderItemsById(int id)
        {
            return mapper.ParseOrderItems(context.Orderitems.Where(x => x.Id == id).ToList());
        }

        public List<OrderItems> GetOrderItemsByOrderId(int id)
        {
            return mapper.ParseOrderItems(context.Orderitems.Where(x => x.Orderid == id).ToList());
        }

        public List<Models.Orders> GetAllOrdersDateAsc(int customerId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Customerid == customerId).OrderBy(x => x.Date).ToList());
        }

        public List<Models.Orders> GetAllOrdersDateDesc(int customerId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Customerid == customerId).OrderByDescending(x => x.Date).ToList());
        }

        public List<Models.Orders> GetAllOrdersPriceAsc(int customerId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Customerid == customerId).OrderBy(x => x.Cost).ToList());
        }

        public List<Models.Orders> GetAllOrdersPriceDesc(int customerId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Customerid == customerId).OrderByDescending(x => x.Cost).ToList());
        }

        public List<Models.Orders> GetAllLocationOrdersDateAsc(int locationId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Locationid == locationId).OrderBy(x => x.Date).ToList());
        }

        public List<Models.Orders> GetAllLocationOrdersDateDesc(int locationId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Locationid == locationId).OrderByDescending(x => x.Date).ToList());
        }

        public List<Models.Orders> GetAllLocationOrdersPriceAsc(int locationId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Locationid == locationId).OrderBy(x => x.Cost).ToList());
        }

        public List<Models.Orders> GetAllLocationOrdersPriceDesc(int locationId)
        {
            return mapper.ParseOrders(context.Orders.Where(x => x.Locationid == locationId).OrderByDescending(x => x.Cost).ToList());
        }

        public Models.Manager SignInManager(string name, string password)
        {
            return mapper.ParseManager(context.Manager.First(x => x.Name == name && x.Password == password));
        }

        public List<Models.Manager> GetAllManagers()
        {
            return mapper.ParseManager(context.Manager.ToList());
        }

        public Models.Manager GetManager(string name, string password)
        {
            return mapper.ParseManager(context.Manager.First(x => x.Name == name && x.Password == password));
        }
    }
}