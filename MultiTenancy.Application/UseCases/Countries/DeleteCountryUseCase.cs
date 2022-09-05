using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Countries
{
    public class DeleteCountryUseCase : UseCase<int>
    {
        public DeleteCountryUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteCountryUseCase";
    }
}
