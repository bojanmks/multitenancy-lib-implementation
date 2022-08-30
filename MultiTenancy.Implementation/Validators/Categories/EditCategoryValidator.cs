using FluentValidation;
using MultiTenancy.Application.UseCases.Categories;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Categories
{
    public class EditCategoryValidator : AbstractValidator<EditCategoryUseCase>
    {
        public EditCategoryValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Category Id is required.")
                .Must(id => context.Categories.Any(x => x.Id == id))
                .WithMessage("Category with an Id of {PropertyValue} does not exist.");

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .Must((useCase, name) => !context.Categories.Any(y => y.Name == name && y.Id != useCase.Data.Id))
                .WithMessage("Category with the name {PropertyValue} already exists.");
        }
    }
}
