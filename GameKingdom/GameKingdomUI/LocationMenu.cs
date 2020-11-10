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
    public class LocationMenu : IMenu
    {
        private string userInputLocation;

        private LocationService locationService;
        private InventoryService inventoryService;
        private OrderService orderService;
        private ProductService productService;
        //private CustomerService customerService;
        

        private models.Product selectedProduct;

        private models.Customer customer;

        private IMessagingService service;


        public LocationMenu(models.Customer customer, ILocationRepo locationRepo, IMessagingService service)
        {
            this.customer = customer;
            this.service = service;


            this.locationService = new LocationService(locationRepo);
            this.inventoryService = new InventoryService((IInventoryRepo) locationRepo);
            this.orderService = new OrderService((IOrderRepo) locationRepo);
            this.productService = new ProductService((IProductRepo) locationRepo);
            //this.customerService = new CustomerService((ICustomerRepo) locationRepo);
        }
        
        public void Start()
        {
            do{
                Console.WriteLine("\nPlease choose a Location");
                List<models.Location> locations = locationService.GetAllLocations();
                foreach(var l in locations)
                {
                    Console.WriteLine($"Id: {l.Id}\t State: {l.State}, City: {l.City}, Street: {l.Street}");
                }
                Console.WriteLine("Press [3] to go back to Main Menu");
                userInputLocation = Console.ReadLine();
                switch(userInputLocation)
                {
                    case "1":
                        Log.Information($"User Chose Location Id: {userInputLocation}");
                        Inventory();
                        break;
                    case "2":
                        Log.Information($"User Chose Location Id: {userInputLocation}");
                        Inventory();
                        break;
                    case "3":
                        Log.Information("Back to Customer Menu");
                        service.BackToMainMenuMessage();
                        break;
                    default:
                        Log.Information($"Invalid Input Location Menu: {userInputLocation}");
                        service.InvalidInputMessage();
                        break;
                }
            } while((!userInputLocation.Equals("3")));


        }
       
       /// <summary>
       /// Method asking user whether they want to view orders or not
       /// </summary>
        public void ChooseMenu()
        {
            string userInput;
            bool showMenu = true;
            do {
                Console.WriteLine("\nPlease choose what you want to do.");
                Console.WriteLine("[1] View Orders");
                Console.WriteLine("[2] Back to Location Menu");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        Log.Information("Showing Order");
                        ShowOrder();
                        showMenu = false;
                        break;
                    case "2":
                        Log.Information("Back to Location Menu");
                        showMenu = false;
                        break;
                    default:
                        Log.Information($"Invalid Input Choosing Next Menu: {userInputLocation}");
                        service.InvalidInputMessage();
                        break;
                }
            } while (showMenu);
        }

        /// <summary>
        /// Method to select a Product from Inventory
        /// </summary>
        public void Inventory()
        {
            string inventoryInput;
            do {
                Console.WriteLine("\nSelect a Product");
                List<models.Inventory> items = inventoryService.GetInventoriesByLocationId(int.Parse(userInputLocation));
                foreach(var i in items)
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

                selectedProduct = productService.GetProductById(int.Parse(inventoryInput));

                
                Log.Information($"User Chose Item: {selectedProduct.GameName}");

                NewOrder();
                Log.Information("User Made Order");
                // Ask to show orders
                ChooseMenu();


            } while (!inventoryInput.Equals("0"));
        }
        /// <summary>
        /// Method to place an Order
        /// </summary>
        public void NewOrder()
        {
            string amountBuy;
            Console.WriteLine($"\nHow many games of {selectedProduct.GameName} would you like to buy?");
            amountBuy = Console.ReadLine();
            try{
                inventoryService.RemoveFromInventory(int.Parse(userInputLocation), selectedProduct.Id, int.Parse(amountBuy));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            models.Orders orders = new models.Orders();
            orders.CustomerId = customer.Id;
            orders.LocationId = int.Parse(userInputLocation);
            orders.Cost = selectedProduct.Price * int.Parse(amountBuy);
            orders.OrderDate = DateTime.Now;
            orderService.AddOrder(orders);
        }
        /// <summary>
        /// Method to show your personal Orders
        /// </summary>
        public void ShowOrder()
        {
            string showAOrder;
            models.Location location = locationService.GetLocationById(int.Parse(userInputLocation));
            do{
                System.Console.WriteLine("\nPlease select how you want your orders to be displayed.");
                System.Console.WriteLine("[0] Date Asc");
                System.Console.WriteLine("[1] Date Desc");
                System.Console.WriteLine("[2] Price Asc");
                System.Console.WriteLine("[3] Price Desc");
                System.Console.WriteLine("[4] Back to Location Menu");
                showAOrder = Console.ReadLine();
                switch(showAOrder)
                {
                    case "0":
                        List<models.Orders> ordersDateAsc = orderService.GetAllOrdersDateAsc(customer.Id);
                        foreach(var oda in ordersDateAsc)
                        {
                            Console.WriteLine($"\nDate: {oda.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {oda.Cost}");
                        }
                        break;
                    case "1":
                        List<models.Orders> ordersDateDesc = orderService.GetAllOrdersDateDesc(customer.Id);
                        foreach(var odd in ordersDateDesc)
                        {
                            Console.WriteLine($"\nDate: {odd.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {odd.Cost}");
                        }
                        break;
                    case "2":
                        List<models.Orders> ordersPriceAsc = orderService.GetAllOrdersPriceAsc(customer.Id);
                        foreach(var opa in ordersPriceAsc)
                        {
                            Console.WriteLine($"\nDate: {opa.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {opa.Cost}");
                        }
                        break;
                    case "3":
                        List<models.Orders> ordersPriceDesc = orderService.GetAllOrdersPriceDesc(customer.Id);
                        foreach(var opd in ordersPriceDesc)
                        {
                            Console.WriteLine($"\nDate: {opd.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {opd.Cost}");
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
            /*
            List<models.Orders> orders = orderService.GetAllOrdersByCustomerId(customer.Id);
            foreach(var o in orders)
            {
                Console.WriteLine($"\nDate: {o.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {o.Cost}");
            }
            */
        }

    }
}