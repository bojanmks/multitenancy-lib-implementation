using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Test
{
    public class ExecuteTestUseCase : UseCase<int>
    {
        public ExecuteTestUseCase(int data) : base(data)
        {
        }

        public override string Id => "ExecuteTestUseCase";
    }
}
