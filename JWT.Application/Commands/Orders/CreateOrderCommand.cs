using System;
using System.Collections.Generic;
using System.Text;
using JWT.Application.Dtos.Order;
using JWT.Application.Dtos.OrderDtos;
using JWT.Domain.Entities;
using MediatR;
namespace JWT.Application.Commands.Orders
{
    public class CreateOrderCommand : IRequest<long>
    {
        public long Id { get; set; }


        public DateTime CreateDate { get; set; }
        public decimal PayablePrice { get; set; }
        public decimal? DiscountPrice { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
