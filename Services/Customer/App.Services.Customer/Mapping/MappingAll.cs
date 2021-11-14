using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Customer.DTOs;
using App.Services.Customer.Models;
using AutoMapper;

namespace App.Services.Customer.Mapping
{
    public class MappingAll:Profile
    {
        public MappingAll()
        {
            CreateMap<Models.Customer, CustomerDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Models.Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Models.Customer, CustomerUpdateDto>().ReverseMap();
        }
    }
}
