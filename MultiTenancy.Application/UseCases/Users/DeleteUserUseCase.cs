using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Users
{
    public class DeleteUserUseCase : UseCase<int>
    {
        public DeleteUserUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteUserUseCase";
    }
}
