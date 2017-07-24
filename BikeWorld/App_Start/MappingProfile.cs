using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BikeWorld.Models;
using BikeWorld.Dto;

namespace BikeWorld.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Bike, BikeDto>();
            Mapper.CreateMap<BikeDto, Bike>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}