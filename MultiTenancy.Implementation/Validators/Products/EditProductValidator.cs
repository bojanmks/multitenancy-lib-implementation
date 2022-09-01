using FluentValidation;
using MultiTenancy.Application.UseCases.Products;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Products
{
    public class EditProductValidator : AbstractValidator<EditProductUseCase>
    {
        public EditProductValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product Id is required.")
                .Must(id => context.Products.Any(x => x.Id == id))
                .WithMessage("Product with an Id of {PropertyValue} does not exist.");

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .Must((useCase, name) => !context.Products.Any(x => x.Name == name && x.Id != useCase.Data.Id))
                .WithMessage("Product with the name {PropertyValue} already exists.");

            RuleFor(x => x.Data.Price)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product price is required.")
                .GreaterThan(0)
                .WithMessage("Product price need to be greater than 0.");

            RuleFor(x => x.Data.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product description is required.")
                .MinimumLength(20)
                .WithMessage("Product description needs to be at least 20 characters long.");

            RuleFor(x => x.Data.ImageId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product image is required.")
                .Must(imageId => context.Images.Any(x => x.Id == imageId))
                .WithMessage("Image with an Id of {PropertyValue} does not exist.");

            RuleFor(x => x.Data.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product category is required.")
                .Must(categoryId => context.Categories.Any(x => x.Id == categoryId))
                .WithMessage("Category with an Id of {PropertyValue} does not exist.");

            When(x => x.Data.Specifications != null, () =>
            {
                RuleFor(x => x.Data.Specifications)
                .Cascade(CascadeMode.Stop)
                .Must(specifications => specifications.All(spec => context.Specifications.Any(x => x.Id == spec.SpecificationId)))
                .WithMessage("Some of the specifications provided do not exist.")
                .Must(specifications => specifications.All(spec => specifications.Where(x => x.SpecificationId == spec.SpecificationId).Count() == 1))
                .WithMessage("Specification Ids must be unique.")
                .Must((useCase, specifications) => specifications.All(
                    spec => context.CategorySpecifications.Any(x => x.SpecificationId == spec.SpecificationId && x.CategoryId == useCase.Data.CategoryId)))
                .WithMessage("Some of the specifications provided are not compatible with the product category.");
            });
        }
    }
}
