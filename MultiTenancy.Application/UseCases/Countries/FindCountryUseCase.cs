using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Countries
{
    public class FindCountryUseCase : UseCase<int>
    {
        public FindCountryUseCase(int data) : base(data)
        {
        }

        public override string Id => "FindCountryUseCase";
    }
}
