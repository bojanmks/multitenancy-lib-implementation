using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Test
{
    public class FindTestUseCase : UseCase<int>
    {
        public FindTestUseCase(int data) : base(data)
        {
        }

        public override string Id => "FindTestUseCase";
    }
}
