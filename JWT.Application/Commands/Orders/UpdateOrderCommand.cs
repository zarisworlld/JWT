using JWT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Commands.Orders
{
    public record UpdateOrderCommand(decimal PayablePrice , decimal? DiscountPrice , ICollection<OrderItem> OrderItems) : IRequest<long>;
}
