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
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryUseCase>
    {
        public DeleteCategoryValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Category Id is required.")
                .Must(id => context.Categories.Any(x => x.Id == id))
                .WithMessage("Category with an Id of {PropertyValue} does not exist.")
                .Must(id => !context.Categories.Find(id).Products.Where(p => p.IsActive.Value).Any())
                .WithMessage("Category cannot be deleted because there are products in this category.");
        }
    }
}
