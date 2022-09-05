using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Users
{
    public class EditUserUseCase : UseCase<UserDto>
    {
        public EditUserUseCase(UserDto data) : base(data)
        {
        }

        public override string Id => "EditUserUseCase";
    }
}
