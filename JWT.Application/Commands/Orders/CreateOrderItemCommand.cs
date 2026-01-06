using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Commands.Orders
{
    public record CreateOrderItemCommand(long ItemId , long OrderId , decimal SalesPrice , decimal? ItemDiscount , decimal Quantity) : IRequest<long>;
}
