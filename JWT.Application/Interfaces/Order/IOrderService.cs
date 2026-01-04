using JWT.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Interfaces.Order
{
    public interface IOrderService
    {
        public Task<long> CreateOrder(OrderDto order);
        public Task<List<OrderDto>> GetAllOrders();
    }
}
