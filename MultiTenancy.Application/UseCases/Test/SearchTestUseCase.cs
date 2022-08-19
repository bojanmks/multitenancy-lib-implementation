using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Test
{
    public class SearchTestUseCase : UseCase<TestSearch>
    {
        public SearchTestUseCase(TestSearch data) : base(data)
        {
        }

        public override string Id => "SearchTestUseCase";
    }
}
