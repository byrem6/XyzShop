namespace OrderServices.RequestModels.CommandRequestModels
{
    public class OrderRequestModel
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
    }
}
