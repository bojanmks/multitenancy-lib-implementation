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
    public class AddSpecificationValidator : AbstractValidator<AddSpecificationUseCase>
    {
        public AddSpecificationValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Specification name is required.")
                .Must(x => !context.Specifications.Any(y => y.Name == x))
                .WithMessage("Specification with the name {PropertyValue} already exists.");
        }
    }
}
