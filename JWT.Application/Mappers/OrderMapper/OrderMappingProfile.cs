using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using JWT.Application.Commands.Items;
using JWT.Application.Commands.Orders;
using JWT.Application.Dtos.ItemDtos;
using JWT.Application.Dtos.Order;
using JWT.Application.Dtos.OrderDtos;
using JWT.Domain.Entities;

namespace JWT.Application.Mappers.OrderMapper

{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<CreateOrderCommand, OrderDto>().ReverseMap();
        }
    }
}
