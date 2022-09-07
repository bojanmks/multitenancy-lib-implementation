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
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(productDto => productDto.Specifications,
                        opts => opts.MapFrom(product => product.ProductSpecifications))
                .ForMember(productDto => productDto.Image,
                        opts => opts.MapFrom(product => product.Image.Path))
                .ForMember(productDto => productDto.TenantId,
                        opts => opts.MapFrom(product => product.Category.TenantId));
            CreateMap<ProductDto, Product>()
                .ForMember(product => product.Image, opts => opts.Ignore());

            CreateMap<ProductSpecification, ProductSpecificationDto>()
                .ForMember(productSpecificationDto => productSpecificationDto.Name,
                        opts => opts.MapFrom(productSpecification => productSpecification.Specification.Name));
            CreateMap<ProductSpecificationDto, ProductSpecification>();
        }
    }
}
