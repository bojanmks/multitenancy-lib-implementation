using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Specifications
{
    public class DeleteSpecificationUseCase : UseCase<int>
    {
        public DeleteSpecificationUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteSpecificationUseCase";
    }
}
