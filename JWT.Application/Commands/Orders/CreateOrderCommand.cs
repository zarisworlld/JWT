using System;
using System.Collections.Generic;
using System.Text;
using JWT.Domain.Entities;
using MediatR;
namespace JWT.Application.Commands.Orders
{
    public record CreateOrderCommand(decimal PayablePrice , decimal? DiscountPrice , ICollection<OrderItem> OrderItems) : IRequest<long>;
}
