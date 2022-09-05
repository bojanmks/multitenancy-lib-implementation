using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Addresses
{
    public class DeleteAddressUseCase : UseCase<int>
    {
        public DeleteAddressUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteAddressUseCase";
    }
}
