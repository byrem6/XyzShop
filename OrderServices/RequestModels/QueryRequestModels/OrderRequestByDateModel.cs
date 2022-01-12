using System;

namespace OrderServices.RequestModels.QueryRequestModels
{
    public class OrderRequestByDateModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
