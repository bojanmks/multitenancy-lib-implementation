using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Test
{
    public class AddTestUseCase : UseCase<TestDto>
    {
        public AddTestUseCase(TestDto data) : base(data)
        {
        }

        public override string Id => "AddTestUseCase";
    }
}
