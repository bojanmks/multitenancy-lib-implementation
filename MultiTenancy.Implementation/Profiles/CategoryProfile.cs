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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(categoryDto => categoryDto.SpecificationIds,
                        opts => opts.MapFrom(category => category.CategorySpecifications.Select(x => x.SpecificationId)));
            CreateMap<CategoryDto, Category>();
        }
    }
}
