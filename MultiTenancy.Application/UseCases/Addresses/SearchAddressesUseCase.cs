using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.Search.SearchObjects;

namespace MultiTenancy.Application.UseCases.Addresses
{
    public class SearchAddressesUseCase : UseCase<AddressSearch>
    {
        public SearchAddressesUseCase(AddressSearch data) : base(data)
        {
        }

        public override string Id => "SearchAddressesUseCase";
    }
}
