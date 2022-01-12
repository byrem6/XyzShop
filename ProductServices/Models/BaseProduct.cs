using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.Models
{
    public abstract class BaseProduct : BaseModelObj
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public string Description { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }
    }
}
