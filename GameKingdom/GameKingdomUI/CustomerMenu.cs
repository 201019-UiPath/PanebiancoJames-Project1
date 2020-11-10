using System;
using models = GameKingdomDB.Models;
using GameKingdomDB.Entities;
using GameKingdomDB.Mappers;
using GameKingdomDB.Repos;
using GameKingdomLib;
using System.Collections.Generic;
using Serilog;

namespace GameKingdomUI
{
    public class CustomerMenu : IMenu
    {
        private string userInput;

        private LocationMenu locationMenu;

        private CustomerOrderMenu customerOrderMenu;

        private models.Customer customer;

        private IMessagingService service;

        private CustomerService customerService;
      
        
        public CustomerMenu(ICustomerRepo repo, IMessagingService service)
        {
            this.service = service;
            
            this.customer = new models.Customer();
            
            this.customerService = new CustomerService(repo);
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("\nWelcome Customer! What would you like to do?");
                Console.WriteLine("[0] Signup?");
                Console.WriteLine("[1] Login?");
                Console.WriteLine("[2] Go back to the main menu?");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        try{
                            SignUp();
                        } catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        Log.Information("New Customer Created");
                        // Sets customer id
                        customer = customerService.GetCustomer(customer.Name, customer.Password);
                        Log.Information("Moved to Location Menu");
                        locationMenu = new LocationMenu(customer, (ILocationRepo) customerService.repo, new MessagingService());
                        locationMenu.Start(); 
                        break;
                    case "1":
                        //call create a customer, get customer details
                        models.Customer loginCustomer = SignIn();
                        try{
                            customerService.GetCustomer(loginCustomer.Name,loginCustomer.Password);
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        customer = customerService.GetCustomer(loginCustomer.Name, loginCustomer.Password);
                        customerOrderMenu = new CustomerOrderMenu(customer, (ICustomerRepo) customerService.repo, new MessagingService());
                        customerOrderMenu.Start();
                        break;
                    case "2":
                        //back to main menu message
                        Log.Information("Back to Main Menu");
                        service.BackToMainMenuMessage();
                        break;
                    default:
                        //invalid input message;
                        Log.Information($"Invalid Input Customer Menu: {userInput}");
                        service.InvalidInputMessage();
                        break;
                }
            } while (!userInput.Equals("2"));
        }

        /// <summary>
        /// Gets user input for a new Customer
        /// </summary>
        /// <returns></returns>
        public void SignUp()
        {

            Console.Write("\nEnter Your Name: ");
            customer.Name = Console.ReadLine();
            Console.Write("Enter Your Address: ");
            customer.Address = Console.ReadLine();
            Console.Write("Enter Your Password: ");
            customer.Password = Console.ReadLine();

            customerService.AddCustomer(customer);
        }

        /// <summary>
        /// Gets user input for existing Customer
        /// </summary>
        /// <returns></returns>
        public models.Customer SignIn()
        {
            models.Customer customer = new models.Customer();
            Console.Write("\nEnter Your Name: ");
            customer.Name = Console.ReadLine();
            Console.Write("Enter Your Password: ");
            customer.Password = Console.ReadLine();
            return customer;
        }

    }
}