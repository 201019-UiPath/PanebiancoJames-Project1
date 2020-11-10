using System;
using GameKingdomDB;
using models = GameKingdomDB.Models;
using GameKingdomDB.Entities;
using GameKingdomDB.Mappers;
using GameKingdomDB.Repos;
using GameKingdomLib;
using System.Collections.Generic;
using Serilog;

namespace GameKingdomUI
{
    public class ManagerInventoryMenu : IMenu
    {
        private string userInput;

        private LocationService locationService;

        private InventoryService inventoryService;

        private OrderService orderService;

        private ProductService productService;

        private ManagerService managerService;

        private IMessagingService service;


        private models.Manager manager;

        public ManagerInventoryMenu(models.Manager manager, IManagerRepo managerRepo, IMessagingService service)
        {
            this.manager = manager;
            this.service = service;

            this.managerService = new ManagerService(managerRepo);
            this.locationService = new LocationService((ILocationRepo) managerRepo);
            this.inventoryService = new InventoryService((IInventoryRepo) managerRepo);
            this.orderService = new OrderService((IOrderRepo) managerRepo);
            this.productService = new ProductService((IProductRepo) managerRepo);
        }

        public void Start()
        {
            do{
                Console.WriteLine("\nPlease decide what you would like to do.");
                Console.WriteLine("[1] View Location Inventory");
                Console.WriteLine("[2] View Location Orders");
                Console.WriteLine("[3] Back to Manager Menu");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        Log.Information("User Chose to View Location Inventory");
                        viewInventory();
                        break;
                    case "2":
                        Log.Information("User Chose to View Location Orders");
                        viewOrders();
                        break;
                    case "3":
                        Log.Information("Back to Manager Menu");
                        break;
                    default:
                        Log.Information($"Invalid Input Location Menu: {userInput}");
                        service.InvalidInputMessage();
                        break;
                }
            } while((!userInput.Equals("3")));
        }

        /// <summary>
        /// Method for managers see the inventory of the location
        /// </summary>
        public void viewInventory()
        {
            string inventoryInput;
            string amount;
            do {
                List<models.Inventory> currentInventory = inventoryService.GetInventoriesByLocationId(manager.LocationId);
                Console.WriteLine("\nSelect which product to replenish");
                foreach(var i in currentInventory)
                {
                    models.Product product = productService.GetProductById(i.ProductId);
                    Console.WriteLine($"Id: {product.Id}.\t Name: {product.GameName}, Price: {product.Price}, Quantity: {i.Quantity}");
                }

                Console.WriteLine("Press [0] to go back.");

                inventoryInput = Console.ReadLine();

                if (inventoryInput.Equals("0"))
                {
                    break;
                }

                models.Product selectedProduct = productService.GetProductById(int.Parse(inventoryInput));

                Console.WriteLine($"\nPlease enter how many game's of {selectedProduct.GameName} you would like to add to inventory");

                amount = Console.ReadLine();

                inventoryService.AddToInventory(manager.LocationId, selectedProduct.Id, int.Parse(amount));


            } while(!inventoryInput.Equals("0"));
        }

        /// <summary>
        /// Method for a manager to see the orders of the location
        /// </summary>
        public void viewOrders()
        {
            string showAOrder;
            models.Location location = locationService.GetLocationById(manager.LocationId);
            do{
                System.Console.WriteLine("\nPlease select how you want your orders to be displayed.");
                System.Console.WriteLine("[0] Date Asc");
                System.Console.WriteLine("[1] Date Desc");
                System.Console.WriteLine("[2] Price Asc");
                System.Console.WriteLine("[3] Price Desc");
                System.Console.WriteLine("[4] Back to Manager Menu");
                showAOrder = Console.ReadLine();
                switch(showAOrder)
                {
                    case "0":
                        List<models.Orders> ordersDateAsc = orderService.GetAllLocationOrdersDateAsc(manager.LocationId);
                        foreach(var oda in ordersDateAsc)
                        {
                            Console.WriteLine($"\nDate: {oda.OrderDate}\nCost: {oda.Cost}\nCustomer Id: {oda.CustomerId}");
                        }
                        break;
                    case "1":
                        List<models.Orders> ordersDateDesc = orderService.GetAllLocationOrdersDateDesc(manager.LocationId);
                        foreach(var odd in ordersDateDesc)
                        {
                            Console.WriteLine($"\nDate: {odd.OrderDate}\nCost: {odd.Cost}\nCustomer Id: {odd.CustomerId}");
                        }
                        break;
                    case "2":
                        List<models.Orders> ordersPriceAsc = orderService.GetAllLocationOrdersPriceAsc(manager.LocationId);
                        foreach(var opa in ordersPriceAsc)
                        {
                            Console.WriteLine($"\nDate: {opa.OrderDate}\nCost: {opa.Cost}\nCustomer Id: {opa.CustomerId}");
                        }
                        break;
                    case "3":
                        List<models.Orders> ordersPriceDesc = orderService.GetAllLocationOrdersPriceDesc(manager.LocationId);
                        foreach(var opd in ordersPriceDesc)
                        {
                            Console.WriteLine($"\nDate: {opd.OrderDate}\nCost: {opd.Cost}\nCustomer Id: {opd.CustomerId}");
                        }
                        break;
                    case "4":
                        break;
                    default:
                        Log.Information($"Invalid Input Choosing Order Details: {showAOrder}");
                        service.InvalidInputMessage();
                        break;
                }
            } while(!showAOrder.Equals("4"));
        }
    }
}