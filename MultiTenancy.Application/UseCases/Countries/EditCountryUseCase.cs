using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Countries
{
    public class EditCountryUseCase : UseCase<CountryDto>
    {
        public EditCountryUseCase(CountryDto data) : base(data)
        {
        }

        public override string Id => "EditCountryUseCase";
    }
}
