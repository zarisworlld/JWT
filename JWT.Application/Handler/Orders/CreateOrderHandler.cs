using JWT.Application.Commands.Orders;
using JWT.Application.Dtos.Order;
using JWT.Application.Interfaces.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Handler.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand,long>
    {
        private readonly IOrderService _orderService;
        public CreateOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<long> Handle(CreateOrderCommand command , CancellationToken cancellationToken)
        {
            var orderDto = new OrderDto();
            orderDto.PayablePrice = command.PayablePrice;
            orderDto.DiscountPrice = command.DiscountPrice;
            orderDto.OrderItems = command.OrderItems;
            return await this._orderService.CreateOrder(orderDto);
        }
    }
}
