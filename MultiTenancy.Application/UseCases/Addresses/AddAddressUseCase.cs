using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.DTO;

namespace MultiTenancy.Application.UseCases.Addresses
{
    public class AddAddressUseCase : UseCase<AddressDto>
    {
        public AddAddressUseCase(AddressDto data) : base(data)
        {
        }

        public override string Id => "AddAddressUseCase";
    }
}
