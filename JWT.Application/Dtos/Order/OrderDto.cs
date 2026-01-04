using JWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Dtos.Order
{
    public class OrderDto
    {
        public decimal PayablePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
