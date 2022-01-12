using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderServices.Models
{
    [Table("Tbl_Orders")]
    public class Order : BaseModelObj
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int CustomerId { get; set; }

        public decimal Total { get; set; }
    }
}
