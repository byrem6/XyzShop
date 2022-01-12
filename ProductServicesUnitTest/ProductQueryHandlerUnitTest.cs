using ProductServices.Context;
using ProductServices.Handlers.QueryHandlers;
using Xunit;

namespace ProductServicesUnitTest
{
    public class ProductQueryHandlerUnitTest
    {
        ProductServicesDbContext context = null;
        ProductQueryHandler ProductQueryHandler = null;

        public ProductQueryHandlerUnitTest()
        {
            if (this.context == null)
            {
                this.context = new ProductServicesDbContext(); ;
                this.ProductQueryHandler = new ProductQueryHandler(context);
            }
        }

        [Fact]
        public void ProductList()
        {
            var list = ProductQueryHandler.GetProducts();
            Assert.NotNull(list);
        }
    }
}
