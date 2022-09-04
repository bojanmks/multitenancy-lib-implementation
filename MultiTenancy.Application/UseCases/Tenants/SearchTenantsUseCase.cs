using MultiTenancy.Application.Search.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Tenants
{
    public class SearchTenantsUseCase : UseCase<TenantSearch>
    {
        public SearchTenantsUseCase(TenantSearch data) : base(data)
        {
        }

        public override string Id => "SearchTenantsUseCase";
    }
}
