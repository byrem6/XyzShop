using OrderServices.CommandRequestModels;
using OrderServices.Models;
using OrderServices.RequestModels.CommandRequestModels;
using System.Threading.Tasks;

namespace OrderServices.Contracts.CommandHandler
{
    public interface IOrderCommandHandler
    {
        Task<Order> Save(OrderRequestModel requestModel);
        Task<Order> UpdateOrder(OrderUpdateRequestModel OrderUpdateDTO);

    }
}
