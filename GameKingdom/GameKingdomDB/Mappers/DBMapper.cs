using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public class DBMapper : IMapper
    {
        public Models.Customer ParseCustomer(Entities.Customer customer)
        {
            return new Models.Customer() {
                Name = customer.Name,
                Password = customer.Password,
                Address = customer.Address,
                Id = customer.Id
            };
        }

        public Entities.Customer ParseCustomer(Models.Customer customer)
        {
            return new Entities.Customer() {
                Name = customer.Name,
                Password = customer.Password,
                Address = customer.Address,
                Id = customer.Id
            };
        }

        public List<Models.Customer> ParseCustomer(ICollection<Entities.Customer> customers)
        {
            List<Models.Customer> allCustomers = new List<Models.Customer>();
            foreach(var c in customers)
            {
                allCustomers.Add(ParseCustomer(c));
            }
            return allCustomers;
        }

        public ICollection<Entities.Customer> ParseCustomer(List<Models.Customer> customers)
        {
            ICollection<Entities.Customer> allCustomers = new List<Entities.Customer>();
            foreach(var c in customers)
            {
                allCustomers.Add(ParseCustomer(c));
            }
            return allCustomers;
        }

        public Models.Inventory ParseInventory(Entities.Inventory inventory)
        {
            return new Models.Inventory() {
                Quantity = inventory.Quantity,
                ProductId = (int) inventory.Productid,
                LocationId = (int) inventory.Locationid,
                Id = inventory.Id
            };
        }

        public Entities.Inventory ParseInventory(Models.Inventory inventory)
        {
            return new Entities.Inventory() {
                Quantity = inventory.Quantity,
                Productid = inventory.ProductId,
                Locationid = inventory.LocationId,
                Id = inventory.Id
            };
        }

        public List<Models.Inventory> ParseInventory(ICollection<Entities.Inventory> inventory)
        {
            List<Models.Inventory> allInventories = new List<Models.Inventory>();
            foreach(var i in inventory)
            {
                allInventories.Add(ParseInventory(i));
            }
            return allInventories;
        }

        public ICollection<Entities.Inventory> ParseInventory(List<Models.Inventory> inventory)
        {
            ICollection<Entities.Inventory> allInventories = new List<Entities.Inventory>();
            foreach(var i in inventory)
            {
                allInventories.Add(ParseInventory(i));
            }
            return allInventories;
        }

        public Models.Location ParseLocation(Entities.Location location)
        {
            return new Models.Location() {
                State = location.State,
                City = location.City,
                Street = location.Street,
                Id = location.Id
            };
        }

        public Entities.Location ParseLocation(Models.Location location)
        {
            return new Entities.Location() {
                State = location.State,
                City = location.City,
                Street = location.Street,
                Id = location.Id
            };
        }

        public List<Models.Location> ParseLocation(ICollection<Entities.Location> location)
        {
            List<Models.Location> allLocations = new List<Models.Location>();
            foreach(var l in location)
            {
                allLocations.Add(ParseLocation(l));
            }
            return allLocations;
        }

        public ICollection<Entities.Location> ParseLocation(List<Models.Location> location)
        {
            ICollection<Entities.Location> allLocations = new List<Entities.Location>();
            foreach(var l in location)
            {
                allLocations.Add(ParseLocation(l));
            }
            return allLocations;
        }

        public Models.Manager ParseManager(Entities.Manager manager)
        {
            return new Models.Manager() {
                Name = manager.Name,
                Password = manager.Password,
                LocationId = (int) manager.Locationid,
                Id = manager.Id
            };
        }

        public Entities.Manager ParseManager(Models.Manager manager)
        {
            return new Entities.Manager() {
                Name = manager.Name,
                Password = manager.Password,
                Locationid = manager.LocationId,
                Id = manager.Id
            };
        }

        public List<Models.Manager> ParseManager(ICollection<Entities.Manager> managers)
        {
            List<Models.Manager> allManagers = new List<Models.Manager>();
            foreach(var m in managers)
            {
                allManagers.Add(ParseManager(m));
            }
            return allManagers;
        }

        public ICollection<Entities.Manager> ParseManager(List<Models.Manager> managers)
        {
            ICollection<Entities.Manager> allManagers = new List<Entities.Manager>();
            foreach(var m in managers)
            {
                allManagers.Add(ParseManager(m));
            }
            return allManagers;
        }

        public Models.OrderItems ParseOrderItems(Entities.Orderitems orderItems)
        {
            return new Models.OrderItems() {
                TotalItems = orderItems.Totalitems,
                ProductId = (int) orderItems.Productid,
                OrdersId = (int) orderItems.Orderid,
                Id = orderItems.Id
            };
        }

        public Entities.Orderitems ParseOrderItems(Models.OrderItems orderItems)
        {
            return new Entities.Orderitems() {
                Totalitems = orderItems.TotalItems,
                Productid = orderItems.ProductId,
                Orderid = orderItems.OrdersId,
                Id = orderItems.Id
            };
        }

        public List<Models.OrderItems> ParseOrderItems(ICollection<Entities.Orderitems> orderItems)
        {
            List<Models.OrderItems> allOrderItems = new List<Models.OrderItems>();
            foreach(var oi in orderItems)
            {
                allOrderItems.Add(ParseOrderItems(oi));
            }
            return allOrderItems;
        }

        public ICollection<Entities.Orderitems> ParseOrderItems(List<Models.OrderItems> orderItems)
        {
            ICollection<Entities.Orderitems> allOrderItems = new List<Entities.Orderitems>();
            foreach(var oi in orderItems)
            {
                allOrderItems.Add(ParseOrderItems(oi));
            }
            return allOrderItems;
        }

        public Models.Orders ParseOrders(Entities.Orders orders)
        {
            return new Models.Orders() {
                OrderDate = orders.Date,
                Cost = orders.Cost,
                CustomerId = (int) orders.Customerid,
                LocationId = (int) orders.Locationid,
                Id = orders.Id
            };
        }

        public Entities.Orders ParseOrders(Models.Orders orders)
        {
            return new Entities.Orders() {
                Date = orders.OrderDate,
                Cost = (int) orders.Cost,
                Customerid = orders.CustomerId,
                Locationid = orders.LocationId,
                Id = orders.Id
            };
        }

        public List<Models.Orders> ParseOrders(ICollection<Entities.Orders> orders)
        {
            List<Models.Orders> allOrders = new List<Models.Orders>();
            foreach(var o in orders)
            {
                allOrders.Add(ParseOrders(o));
            }
            return allOrders;
        }

        public ICollection<Entities.Orders> ParseOrders(List<Models.Orders> orders)
        {
            ICollection<Entities.Orders> allOrders = new List<Entities.Orders>();
            foreach(var o in orders)
            {
                allOrders.Add(ParseOrders(o));
            }
            return allOrders;
        }

        public Models.Product ParseProduct(Entities.Product product)
        {
            return new Models.Product() {
                GameName = product.Gamename,
                Price = product.Price,
                Id = product.Id
            };
        }

        public Entities.Product ParseProduct(Models.Product product)
        {
            return new Entities.Product() {
                Gamename = product.GameName,
                Price = product.Price,
                Id = product.Id
            };
        }

        public List<Models.Product> ParseProduct(ICollection<Entities.Product> product)
        {
            List<Models.Product> allProducts = new List<Models.Product>();
            foreach(var p in product)
            {
                allProducts.Add(ParseProduct(p));
            }
            return allProducts;
        }

        public ICollection<Entities.Product> ParseProduct(List<Models.Product> product)
        {
            ICollection<Entities.Product> allProducts = new List<Entities.Product>();
            foreach(var p in product)
            {
                allProducts.Add(ParseProduct(p));
            }
            return allProducts;
        }
    }
}