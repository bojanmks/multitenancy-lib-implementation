using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Category
{
    public class AddCategoryUseCase : UseCase<CategoryDto>
    {
        public AddCategoryUseCase(CategoryDto data) : base(data)
        {
        }

        public override string Id => "AddCategoryUseCase";
    }
}
