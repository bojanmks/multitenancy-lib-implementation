using FluentValidation;
using MultiTenancy.Application.UseCases.Specifications;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Specifications
{
    public class DeleteSpecificationValidator : AbstractValidator<DeleteSpecificationUseCase>
    {
        public DeleteSpecificationValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Specification Id is required.")
               .Must(id => context.Specifications.Any(x => x.Id == id))
               .WithMessage("Specification with an Id of {PropertyValue} does not exist.")
               .Must(specificationId => !context.CategorySpecifications.Any(x => x.SpecificationId == specificationId))
               .WithMessage("Specification can not be deleted because there are categories with this specification.")
               .Must(specificationId => !context.ProductSpecifications.Any(x => x.SpecificationId == specificationId))
               .WithMessage("Specification can not be deleted because there are products with this specification.");
        }
    }
}
