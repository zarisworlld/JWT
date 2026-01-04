using JWT.Application.Dtos.Order;
using JWT.Application.Interfaces.Order;
using JWT.Application.Queries.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Handler.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery,List<OrderDto>>
    {
        private readonly IOrderService _orderService;
        public GetOrdersHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetAllOrders();
        }
    }
}
