using OrderServices.Models;
using OrderServices.RequestModels.QueryRequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderServices.Contracts.QueryHandlers
{
    public interface IOrderQueryHandler
    {
        List<Order> GetOrders();
        List<Order> GetOrdersByDateBetween(OrderRequestByDateModel request);
        Task<Order> GetOrder(int id);
    }
}
