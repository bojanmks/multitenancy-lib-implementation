using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Products
{
    public class EditProductUseCase : UseCase<ProductDto>
    {
        public EditProductUseCase(ProductDto data) : base(data)
        {
        }

        public override string Id => "EditProductUseCase";
    }
}
