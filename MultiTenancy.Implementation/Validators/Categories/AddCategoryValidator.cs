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

            When(x => x.Data.SpecificationIds != null, () =>
            {
                RuleFor(x => x.Data.SpecificationIds)
                .Cascade(CascadeMode.Stop)
                .Must(specificationIds => specificationIds.All(id => context.Specifications.Any(x => x.Id == id)))
                .WithMessage("Some of the specifications provided do not exist.")
                .Must(specificationIds => specificationIds.Count() == specificationIds.Distinct().Count())
                .WithMessage("Specification Ids must be unique.");
            });
        }
    }
}
