using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using JWT.Application.Commands.Orders;
using JWT.Application.Dtos.Order;
using JWT.Application.Dtos.OrderDtos;
using JWT.Domain.Entities;

namespace JWT.Application.Mappers.OrderMapper

{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(des => des.OrderItems, opt => opt.MapFrom(c => c.OrderItems));
            CreateMap<OrderDto, Order>()
                .ForMember(des => des.OrderItems, opt => opt.MapFrom(c => c.OrderItems));
            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(des => des.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(des => des.Item, opt => opt.MapFrom(src => src.Item));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(des => des.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(des => des.Item, opt => opt.MapFrom(src => src.Item));
        }
    }
}
