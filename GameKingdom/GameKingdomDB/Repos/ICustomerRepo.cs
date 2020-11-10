using GameKingdomDB.Models;
using System.Collections.Generic;

namespace GameKingdomDB.Repos
{
    public interface ICustomerRepo
    {
        /// <summary>
        /// Adds a Customer to the DB
        /// </summary>
        /// <param name="customer"></param>
        void AddACustomer(Customer customer);

        /// <summary>
        /// Get a Customer from the DB
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Customer SignInCustomer (string name, string password);

        Customer GetCustomer(string name, string password);

        List<Customer> GetAllCustomers();
    }
}