using System;
using GameKingdomDB;
using entities= GameKingdomDB.Entities;
using models = GameKingdomDB.Models;
using GameKingdomLib;
using GameKingdomDB.Mappers;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using Serilog;

namespace GameKingdomUI
{
    public class ManagerMenu : IMenu
    {
        private string userInput;

        private models.Manager manager;

        private ManagerInventoryMenu managerInventoryMenu;

        private IMessagingService service;

        private ManagerService managerService;
        
        public ManagerMenu(IManagerRepo repo, IMessagingService service)
        {
            this.manager = new models.Manager();
            this.service = service;
            this.managerService = new ManagerService(repo);
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("\nWelcome Manager! What would you like to do?");
                Console.WriteLine("[0] Login?");
                Console.WriteLine("[1] Go back to the main menu?");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        models.Manager loginManager = SignIn();
                        try{
                            managerService.SignInManager(loginManager.Name,loginManager.Password);
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        manager = managerService.GetManager(loginManager.Name, loginManager.Password);
                        managerInventoryMenu = new ManagerInventoryMenu(manager, (IManagerRepo) managerService.repo, new MessagingService());
                        managerInventoryMenu.Start();
                        break;
                    case "1":
                        //back to main menu message
                        service.BackToMainMenuMessage();
                        break;          
                    default:
                        //invalid input message;
                        service.InvalidInputMessage();
                        break;
                }
            } while (!userInput.Equals("1"));
        }

        public models.Manager SignIn()
        {
            models.Manager manager = new models.Manager();
            Console.Write("\nEnter Your Name: ");
            manager.Name = Console.ReadLine();
            Console.Write("Enter Your Password: ");
            manager.Password = Console.ReadLine();
            return manager;
        }
    }
}