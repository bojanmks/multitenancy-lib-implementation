using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Specifications
{
    public class EditSpecificationUseCase : UseCase<SpecificationDto>
    {
        public EditSpecificationUseCase(SpecificationDto data) : base(data)
        {
        }

        public override string Id => "EditSpecificationUseCase";
    }
}
