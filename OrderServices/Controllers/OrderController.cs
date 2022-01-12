using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderServices.CommandRequestModels;
using OrderServices.Contracts.CommandHandler;
using OrderServices.Contracts.QueryHandlers;
using OrderServices.Models;
using OrderServices.RequestModels.CommandRequestModels;
using OrderServices.RequestModels.QueryRequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderServices.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderCommandHandler _orderCommandHandler;
        private readonly IOrderQueryHandler _orderQueryHandler;

        public OrderController(ILogger<OrderController> logger, IOrderCommandHandler orderCommandHandler, IOrderQueryHandler orderQueryHandler)
        {
            _logger = logger;
            _orderCommandHandler = orderCommandHandler;
            _orderQueryHandler = orderQueryHandler;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _orderQueryHandler.GetOrders();
        }

        [HttpPost("filterByDate")]
        public IEnumerable<Order> GetOrdersFilteredByDate(OrderRequestByDateModel requestByDateModel)
        {
            return _orderQueryHandler.GetOrdersByDateBetween(requestByDateModel);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var Order = await _orderQueryHandler.GetOrder(id);
            return Order != null ? new JsonResult(Order) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderRequestModel Order)
        {
            _logger.LogDebug("Add New Order", new JsonResult(Order));

            var newOrder = await _orderCommandHandler.Save(Order);

            _logger.LogDebug("Success Add New Order", new JsonResult(newOrder));

            return new JsonResult(newOrder);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderUpdateRequestModel orderUpdateRequestModel)
        {
            _logger.LogDebug("Update Order", new JsonResult(orderUpdateRequestModel.Order));

            var updatedOrder = await _orderCommandHandler.UpdateOrder(orderUpdateRequestModel);

            _logger.LogDebug("Success Update Order", new JsonResult(updatedOrder));

            return new JsonResult(updatedOrder);
        }
    }
}
