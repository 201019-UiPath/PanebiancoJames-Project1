using System;
using GameKingdomDB.Models;
using GameKingdomDB;
using GameKingdomDB.Entities;
using GameKingdomDB.Mappers;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace GameKingdomUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Revature_Workspace\PanebiancoJames-Project0\GameKingdom\GameKingdomDB\log.txt",
                outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            
            if (Log.Logger == null) {throw new Exception("Logger isn't working.");}

            Log.Information("Program has started");

            IMenu main = new MainMenu(new GameKingdomContext(), new DBMapper(), new MessagingService());
            main.Start();
        }
    }
}
