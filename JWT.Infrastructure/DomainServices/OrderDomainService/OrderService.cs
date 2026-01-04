using AutoMapper;
using JWT.Application.Dtos.Order;
using JWT.Application.Interfaces.Order;
using JWT.Domain.Context;
using JWT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Infrastructure.DomainServices.OrderDomainService
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderService(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<long> CreateOrder(OrderDto orderDto)
        {
           var order = _mapper.Map<Order>(orderDto);
            _dbContext.Set<Order>().Add(order);
            _dbContext.SaveChanges();
            return order.Id;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _dbContext.Set<Order>().AsNoTracking().ToListAsync();
            var mappedOrders = _mapper.Map<List<OrderDto>>(orders);
            return mappedOrders;
        }
    }
}
