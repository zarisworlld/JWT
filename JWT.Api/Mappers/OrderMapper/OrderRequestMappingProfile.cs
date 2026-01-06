using AutoMapper;
using JWT.Api.ViewModels.Order;
using JWT.Application.Commands.Orders;
using JWT.Application.Dtos.Order;
using JWT.Application.Dtos.OrderDtos;

namespace JWT.Api.Mappers.OrderMapper
{
    public class OrderRequestMappingProfile : Profile
    {
        public OrderRequestMappingProfile()
        {
            CreateMap<OrderViewModel, CreateOrderCommand>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemViewModel, CreateOrderItemCommand>();
        }
    }
}
