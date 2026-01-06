using AutoMapper;
using JWT.Application.Commands.Orders;
using JWT.Application.Dtos.Order;
using JWT.Application.Interfaces.Order;
using JWT.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Handler.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand,long>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public CreateOrderHandler(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        public async Task<long> Handle(CreateOrderCommand command , CancellationToken cancellationToken)
        {
            var mappedResult = _mapper.Map<OrderDto>(command);
            return await this._orderService.CreateOrder(mappedResult);
        }
    }
}
