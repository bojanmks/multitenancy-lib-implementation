using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Products
{
    public class FindProductUseCase : UseCase<int>
    {
        public FindProductUseCase(int data) : base(data)
        {
        }

        public override string Id => throw new NotImplementedException();
    }
}
