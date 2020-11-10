using System.Collections.Generic;

namespace GameKingdomDB.Mappers
{
    public interface ICustomerMapper
    {

        Models.Customer ParseCustomer (Entities.Customer customer);

        Entities.Customer ParseCustomer (Models.Customer customer);

        List<Models.Customer> ParseCustomer (ICollection<Entities.Customer> customers);

        ICollection<Entities.Customer> ParseCustomer (List<Models.Customer> customers);
    }
}