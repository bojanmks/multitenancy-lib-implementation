using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Specifications
{
    public class AddSpecificationUseCase : UseCase<SpecificationDto>
    {
        public AddSpecificationUseCase(SpecificationDto data) : base(data)
        {
        }

        public override string Id => "AddSpecificationUseCase";
    }
}
