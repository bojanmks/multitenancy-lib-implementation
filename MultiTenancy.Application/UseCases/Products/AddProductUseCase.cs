using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Products
{
    public class AddProductUseCase : UseCase<ProductDto>
    {
        public AddProductUseCase(ProductDto data) : base(data)
        {
        }

        public override string Id => "AddProductUseCase";
    }
}
