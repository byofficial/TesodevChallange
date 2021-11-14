using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Order.DTOs;
using App.Services.Order.Models;
using AutoMapper;

namespace App.Services.Order.Mapping
{
    public class MappingAll:Profile
    {
        public MappingAll()
        {
            CreateMap<Models.Order, OrderDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Models.Order, OrderCreateDto>().ReverseMap();
            CreateMap<Models.Order, OrderUpdateDto>().ReverseMap();
        }
    }
}
