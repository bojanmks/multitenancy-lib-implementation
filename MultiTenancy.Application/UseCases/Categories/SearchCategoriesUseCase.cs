using MultiTenancy.Application.Search.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Categories
{
    public class SearchCategoriesUseCase : UseCase<CategorySearch>
    {
        public SearchCategoriesUseCase(CategorySearch data) : base(data)
        {
        }

        public override string Id => "SearchCategoriesUseCase";
    }
}
