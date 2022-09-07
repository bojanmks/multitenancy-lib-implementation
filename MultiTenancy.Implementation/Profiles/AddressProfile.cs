using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MultiTenancy.Application.DTO;
using MultiTenancy.Domain;

namespace MultiTenancy.Implementation.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>()
                .ForMember(addressDto => addressDto.CountryName,
                    opts => opts.MapFrom(address => address.Country.Name));
            CreateMap<AddressDto, Address>();
        }
    }
}
