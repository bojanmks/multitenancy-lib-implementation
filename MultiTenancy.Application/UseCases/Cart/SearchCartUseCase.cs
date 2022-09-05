using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.Search.SearchObjects;

namespace MultiTenancy.Application.UseCases.Cart
{
    public class SearchCartUseCase : UseCase<CartSearch>
    {
        public SearchCartUseCase(CartSearch data) : base(data)
        {
        }

        public override string Id => "SearchCartUseCase";
    }
}
