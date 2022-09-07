using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Orders
{
    public class FindOrderUseCase : UseCase<int>
    {
        public FindOrderUseCase(int data) : base(data)
        {
        }

        public override string Id => "FindOrderUseCase";
    }
}
