using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Test
{
    public class UpdateTestUseCase : UseCase<TestDto>
    {
        public UpdateTestUseCase(TestDto data) : base(data)
        {
        }

        public override string Id => "UpdateTestUseCase";
    }
}
