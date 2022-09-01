using AutoMapper;
using MultiTenancy.Application.DTO;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Profiles
{
    public class SpecificationProfile : Profile
    {
        public SpecificationProfile()
        {
            CreateMap<Specification, SpecificationDto>();
            CreateMap<SpecificationDto, Specification>();
        }
    }
}
