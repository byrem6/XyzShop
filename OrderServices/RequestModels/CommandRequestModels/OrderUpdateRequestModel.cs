using OrderServices.RequestModels.CommandRequestModels;

namespace OrderServices.CommandRequestModels
{
    public class OrderUpdateRequestModel
    {
        public int Id { get; set; }
        public OrderRequestModel Order { get; set; }
    }
}
