using MultiTenancy.Application.Search.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Specifications
{
    public class SearchSpecificationsUseCase : UseCase<SpecificationSearch>
    {
        public SearchSpecificationsUseCase(SpecificationSearch data) : base(data)
        {
        }

        public override string Id => "SearchSpecificationsUseCase";
    }
}
