using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Categories
{
    public class EditCategoryUseCase : UseCase<CategoryDto>
    {
        public EditCategoryUseCase(CategoryDto data) : base(data)
        {
        }

        public override string Id => "EditCategoryUseCase";
    }
}
