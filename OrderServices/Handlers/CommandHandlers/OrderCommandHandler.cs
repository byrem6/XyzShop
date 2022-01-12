using OrderServices.CommandRequestModels;
using OrderServices.Context;
using OrderServices.Contracts.CommandHandler;
using OrderServices.Models;
using OrderServices.RequestModels.CommandRequestModels;
using System;
using System.Threading.Tasks;

namespace OrderServices.Handlers.CommandHandlers
{
    public class OrderCommandHandler : IOrderCommandHandler
    {
        private OrderServicesDbContext _db;

        public OrderCommandHandler(OrderServicesDbContext db)
        {
            _db = db;
        }



        public async Task<Order> Save(OrderRequestModel requestModel)
        {

            var Order = new Order()
            {
                ProductId = requestModel.ProductId,
                CustomerId = requestModel.CustomerId,
                Total = requestModel.Total,
                CreatedDate = DateTime.Now,
                IsRemoved = false,
                UpdatedDate = DateTime.Now
            };


            _db.Order.Add(Order);
            await _db.SaveChangesAsync();

            return Order;
        }

        public async Task<Order> UpdateOrder(OrderUpdateRequestModel OrderUpdateRequestModel)
        {
            var Order = _db.Order.Find(OrderUpdateRequestModel.Id);
            Order.ProductId = OrderUpdateRequestModel.Order.ProductId;
            Order.CustomerId = OrderUpdateRequestModel.Order.CustomerId;
            Order.Total = OrderUpdateRequestModel.Order.Total;
            Order.UpdatedDate = DateTime.Now;

            await _db.SaveChangesAsync();

            return Order;
        }
    }
}
