using System;

namespace CustomerServices.Models
{
    public abstract class BaseModelObj
    {
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
