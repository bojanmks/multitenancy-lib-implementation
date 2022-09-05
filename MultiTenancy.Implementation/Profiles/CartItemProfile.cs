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
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(cartItemDto => cartItemDto.ProductName,
                    opts => opts.MapFrom(cartItem => cartItem.Product.Name));
            CreateMap<CartItemDto, CartItem>();
        }
    }
}
