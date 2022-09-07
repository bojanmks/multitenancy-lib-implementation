using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.Search.SearchObjects;

namespace MultiTenancy.Application.UseCases.Orders
{
    public class SearchOrdersUseCase : UseCase<OrderSearch>
    {
        public SearchOrdersUseCase(OrderSearch data) : base(data)
        {
        }

        public override string Id => "SearchOrdersUseCase";
    }
}
