using System;
using System.Collections.Generic;
using System.Text;
using JWT.Application.Dtos.Order;
using JWT.Application.Dtos.OrderDtos;
using JWT.Domain.Entities;
using MediatR;
namespace JWT.Application.Commands.Orders
{
    public record CreateOrderCommand(long Id,decimal PayablePrice , decimal? DiscountPrice , ICollection<CreateOrderItemCommand> OrderItems) : IRequest<long>;
}
