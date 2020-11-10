using System;

namespace GameKingdomUI
{
    public class MessagingService : IMessagingService
    {
        public void InvalidInputMessage()
        {
            Console.WriteLine("\nInvalid input! Please choose a valid option.");
        }

        public void BackToMainMenuMessage()
        {
            Console.WriteLine("\nGoing back to Main Menu.");
        }
    }
}