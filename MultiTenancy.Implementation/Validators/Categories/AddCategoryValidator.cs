using FluentValidation;
using MultiTenancy.Application.UseCases.Category;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Categories
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryUseCase>
    {
        public AddCategoryValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .Must(x => !context.Categories.Any(y => y.Name == x))
                .WithMessage("Category with the name {PropertyValue} already exists.");
        }
    }
}
