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
    public class CustomerOrderMenu : IMenu
    {
        private string userInput;

        private LocationService locationService;

        private OrderService orderService;

        private ProductService productService;

        private CustomerService customerService;

        private LocationMenu locationMenu;


        private IMessagingService service;

        private models.Customer customer;

        public CustomerOrderMenu(models.Customer customer, ICustomerRepo customerRepo, IMessagingService service)
        {
            this.customer = customer;
            this.service = service;

            this.customerService = new CustomerService(customerRepo);
            this.locationService = new LocationService((ILocationRepo) customerRepo);
            this.orderService = new OrderService((IOrderRepo) customerRepo);
            this.productService = new ProductService((IProductRepo) customerRepo);
        }

        public void Start()
        {
            do{
                Console.WriteLine("\nPlease decide what you would like to do.");
                Console.WriteLine("[1] View Order History");
                Console.WriteLine("[2] Browse Locations");
                Console.WriteLine("[3] Back to Customer Menu");
                userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "1":
                        Log.Information($"Customer Name: {customer.Name} began Viewing Order History");
                        viewOrders();
                        break;
                    case "2":
                        locationMenu = new LocationMenu(customer, (ILocationRepo) customerService.repo, new MessagingService());
                        Log.Information($"Customer Name: {customer.Name} began Browsing Locations");
                        locationMenu.Start();
                        break;
                    case "3":
                        Log.Information("Back to Customer Menu");
                        break;
                    default:
                        Log.Information($"Invalid Input Location Menu: {userInput}");
                        service.InvalidInputMessage();
                        break;
                }
            } while((!userInput.Equals("3")));
        }

        /// <summary>
        /// Method for customer to view orders
        /// </summary>
        public void viewOrders()
        {
            string showAOrder;
            //models.Location location = locationService.GetLocationById(manager.LocationId);
            do{
                System.Console.WriteLine("\nPlease select how you want your orders to be displayed.");
                System.Console.WriteLine("[0] Date Asc");
                System.Console.WriteLine("[1] Date Desc");
                System.Console.WriteLine("[2] Price Asc");
                System.Console.WriteLine("[3] Price Desc");
                System.Console.WriteLine("[4] Back to Customer Menu");
                showAOrder = Console.ReadLine();
                switch(showAOrder)
                {
                    case "0":
                        List<models.Orders> ordersDateAsc = orderService.GetAllOrdersDateAsc(customer.Id);
                        foreach(var oda in ordersDateAsc)
                        {
                            models.Location location = locationService.GetLocationById(oda.LocationId);
                            Console.WriteLine($"\nDate: {oda.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {oda.Cost}");
                        }
                        break;
                    case "1":
                        List<models.Orders> ordersDateDesc = orderService.GetAllOrdersDateDesc(customer.Id);
                        foreach(var odd in ordersDateDesc)
                        {
                            models.Location location = locationService.GetLocationById(odd.LocationId);
                            Console.WriteLine($"\nDate: {odd.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {odd.Cost}");
                        }
                        break;
                    case "2":
                        List<models.Orders> ordersPriceAsc = orderService.GetAllOrdersPriceAsc(customer.Id);
                        foreach(var opa in ordersPriceAsc)
                        {
                            models.Location location = locationService.GetLocationById(opa.LocationId);
                            Console.WriteLine($"\nDate: {opa.OrderDate}\nLocation:\n\tState: {location.State}\n\tCity: {location.City}\n\tStreet: {location.Street}\nCost: {opa.Cost}");
                        }
                        break;
                    case "3":
                        List<models.Orders> ordersPriceDesc = orderService.GetAllOrdersPriceDesc(customer.Id);
                        foreach(var opd in ordersPriceDesc)
                        {
                            models.Location location = locationService.GetLocationById(opd.LocationId);
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
        }
    }
}