using AutoMapper;
using MultiTenancy.Application.DTO;
using MultiTenancy.Domain;
using MultiTenancy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(user => user.Password,
                        x => x.MapFrom(registerDto => BCrypt.Net.BCrypt.HashPassword(registerDto.Password)))
                .AfterMap((registerDto, user) => user.RoleId = (byte)UserRole.User);
        }
    }
}
