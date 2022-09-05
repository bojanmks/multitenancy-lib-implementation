using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Countries
{
    public class AddCountryUseCase : UseCase<CountryDto>
    {
        public AddCountryUseCase(CountryDto data) : base(data)
        {
        }

        public override string Id => "AddCountryUseCase";
    }
}
