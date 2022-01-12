using CustomerServices.CommandRequestModels;
using CustomerServices.Models;
using CustomerServices.RequestModels.CommandRequestModels;
using System.Threading.Tasks;

namespace CustomerServices.Contracts.CommandHandler
{
    public interface ICustomerCommandHandler
    {
        Task<Customer> Save(CustomerRequestModel requestModel);
        Task<Customer> UpdateCustomer(CustomerUpdateRequestModel customerUpdateDTO);

    }
}
