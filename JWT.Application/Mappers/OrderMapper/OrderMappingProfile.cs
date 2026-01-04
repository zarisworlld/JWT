using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using JWT.Application.Commands.Orders;
using JWT.Application.Dtos.Order;
using JWT.Domain.Entities;

namespace JWT.Application.Mappers.OrderMapper

{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderCommand,OrderDto>();
        }
    }
}
