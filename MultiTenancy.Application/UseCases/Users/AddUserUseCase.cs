using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Users
{
    public class AddUserUseCase : UseCase<UserDto>
    {
        public AddUserUseCase(UserDto data) : base(data)
        {
        }

        public override string Id => "AddUserUseCase";
    }
}
