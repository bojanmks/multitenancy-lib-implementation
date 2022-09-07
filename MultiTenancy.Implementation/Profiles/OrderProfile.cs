using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MultiTenancy.Application.DTO;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using MultiTenancy.Domain.Enums;

namespace MultiTenancy.Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {

            var context = ServiceProviderActivator.Provider.GetService<ShopDbContext>();

            CreateMap<Order, OrderDto>()
                .ForMember(orderDto => orderDto.Items,
                    opts => opts.MapFrom(order => order.OrderItems))
                .ForMember(orderDto => orderDto.Status, 
                    opts => opts.MapFrom(order => Enum.GetName(typeof(OrderStatus), order.StatusId)));

            CreateMap<AddOrderDto, Order>()
                .ForMember(order => order.OrderItems,
                    opts => opts.MapFrom(orderDto => orderDto.Items))
                .ForMember(order => order.DeliveryLocation,
                    opts => opts.MapFrom((orderDto, order) =>
                    {
                        var address = context.Addresses.Find(orderDto.AddressId);
                        return address.Value + ", " + address.Country.Name;
                    }));

            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(orderItem => orderItem.ProductName,
                    opts => opts.MapFrom(orderItemDto => context.Products.Find(orderItemDto.ProductId).Name))
                .ForMember(orderItem => orderItem.UnitPrice,
                    opts => opts.MapFrom(orderItemDto => context.Products.Find(orderItemDto.ProductId).Price));
        }
    }
}
