using CustomerServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServices.Contracts.QueryHandlers
{
    public interface ICustomerQueryHandler
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
    }
}
