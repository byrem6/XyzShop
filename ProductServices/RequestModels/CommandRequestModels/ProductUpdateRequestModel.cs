using CustomerServices.RequestModels.CommandRequestModels;

namespace CustomerServices.CommandRequestModels
{
    public class ProductUpdateRequestModel
    {
        public int Id { get; set; }
        public ProductRequestModel Product { get; set; }
    }
}
