using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Test
{
    public class DeleteTestUseCase : UseCase<int>
    {
        public DeleteTestUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteTestUseCase";
    }
}
