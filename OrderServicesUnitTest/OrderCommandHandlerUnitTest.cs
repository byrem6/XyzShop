using OrderServices.Context;
using OrderServices.Handlers.CommandHandlers;
using Xunit;

namespace OrderServicesUnitTest
{
    public class OrderCommandHandlerUnitTest
    {
        OrderServicesDbContext context = null;
        OrderCommandHandler orderCommandHandler = null;

        public OrderCommandHandlerUnitTest()
        {
            if (this.context == null)
            {
                this.context = new OrderServicesDbContext(); ;
                this.orderCommandHandler = new OrderCommandHandler(context);
            }
        }

        [Fact]
        public void AddOrder()
        {
            var newOrder = orderCommandHandler.Save(new OrderRequestModel()
            {
                CustomerId = 5,
                ProductId = 1,
                Total = 100
            });

            Assert.NotNull(newOrder);
        }
    }
}
