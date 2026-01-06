using AutoMapper;
using JWT.Application.Dtos.ItemDtos;
using JWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Mappers.ItemMapper
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<ItemDto, Item>();
            CreateMap<Item, ItemDto>();
        }
    }
}
