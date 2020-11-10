using System;
using GameKingdomDB.Entities;
using GameKingdomDB.Mappers;
using GameKingdomDB.Repos;
using Serilog;

namespace GameKingdomUI
{
    public class MainMenu : IMenu
    {
        // stores user input
        private string userInput;
        private CustomerMenu customerMenu;
        private ManagerMenu managerMenu;
        private IMessagingService service;
        private GameKingdomContext context;
        private IMapper mapper;
        
   
        public MainMenu(GameKingdomContext context, IMapper mapper, IMessagingService service)
        {
            this.context = context;
            this.mapper = mapper;
            this.service = service;
        }
        
        public void Start()
        {
            do{
                Console.WriteLine("\nWelcome to GameKingdom! Are you a Customer or a Manager?");
                Console.WriteLine("[0] Customer?");
                Console.WriteLine("[1] Manager?");
                Console.WriteLine("[2] Exit?");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        //call the customer menu;
                        customerMenu = new CustomerMenu(new DBRepo(context,mapper), service);
                        Log.Information("Customer Menu Launched");
                        customerMenu.Start();
                        break;
                    case "1":
                        //call the manager menu;
                        managerMenu = new ManagerMenu(new DBRepo(context,mapper), service);
                        Log.Information("Manager Menu Launched");
                        managerMenu.Start();
                        break;
                    case "2":
                        Log.Information("Program Exited");
                        Console.WriteLine("Have a good day!");
                        break;
                    default:
                        //call the invalid message
                        Log.Information($"Invalid Input Main Menu: {userInput}");
                        service.InvalidInputMessage();
                        break;
                }

            }while(!(userInput.Equals("2")));
        }
    }
}