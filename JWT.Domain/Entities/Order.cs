using JWT.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Domain.Entities
{
    public class Order : BaseEntity<long>
    {
        public decimal PayablePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
    }
}
