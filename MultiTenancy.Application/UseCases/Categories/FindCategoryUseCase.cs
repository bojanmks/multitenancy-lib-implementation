using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Categories
{
    public class FindCategoryUseCase : UseCase<int>
    {
        public FindCategoryUseCase(int data) : base(data)
        {
        }

        public override string Id => "FindCategoryUseCase";
    }
}
