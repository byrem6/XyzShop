using ProductServices.Context;
using ProductServices.Handlers.CommandHandlers;
using Xunit;

namespace ProductServicesUnitTest
{
    public class ProductCommandHandlerUnitTest
    {
        ProductServicesDbContext context = null;
        ProductCommandHandler productCommandHandler = null;

        public ProductCommandHandlerUnitTest()
        {
            if (this.context == null)
            {
                this.context = new ProductServicesDbContext(); ;
                this.productCommandHandler = new ProductCommandHandler(context);
            }
        }

        [Fact]
        public void AddProduct()
        {
            var newProduct = productCommandHandler.Save(new CustomerServices.RequestModels.CommandRequestModels.ProductRequestModel()
            {
                Name = "Test",
                Description = "Test Test",
                ImageUrl = "",
                Price = 1,
                TypeId = 0
            });

            Assert.NotNull(newProduct);
        }
    }
}
