using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Products
{
    public class DeleteProductUseCase : UseCase<int>
    {
        public DeleteProductUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteProductUseCase";
    }
}
