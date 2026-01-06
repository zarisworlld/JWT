using JWT.Application.Dtos.OrderDtos;
using JWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Dtos.Order
{
    public class OrderDto
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal PayablePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
