using MultiTenancy.Application.Search.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Products
{
    public class SearchProductsUseCase : UseCase<ProductSearch>
    {
        public SearchProductsUseCase(ProductSearch data) : base(data)
        {
        }

        public override string Id => "SearchProductsUseCase";
    }
}
