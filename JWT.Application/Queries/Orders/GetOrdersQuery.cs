using MediatR;
using JWT.Application.Dtos.Order;

namespace JWT.Application.Queries.Orders
{
    public record GetOrdersQuery() : IRequest<List<OrderDto>>;
}
