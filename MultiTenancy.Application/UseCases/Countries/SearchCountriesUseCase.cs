using MultiTenancy.Application.Search.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Countries
{
    public class SearchCountriesUseCase : UseCase<CountrySearch>
    {
        public SearchCountriesUseCase(CountrySearch data) : base(data)
        {
        }

        public override string Id => "SearchCountriesUseCase";
    }
}
