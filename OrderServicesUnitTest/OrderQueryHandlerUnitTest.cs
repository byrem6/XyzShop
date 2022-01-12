using OrderServices.Context;
using OrderServices.Handlers.QueryHandlers;
using Xunit;

namespace OrderServicesUnitTest
{
    public class OrderQueryHandlerUnitTest
    {
        OrderServicesDbContext context = null;
        OrderQueryHandler OrderQueryHandler = null;

        public OrderQueryHandlerUnitTest()
        {
            if (this.context == null)
            {
                this.context = new OrderServicesDbContext(); ;
                this.OrderQueryHandler = new OrderQueryHandler(context);
            }
        }

        [Fact]
        public void OrderList()
        {
            var list = OrderQueryHandler.GetOrders();

            Assert.NotNull(list);

        }
    }
}
