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
    public class EditSpecificationsValidator : AbstractValidator<EditSpecificationUseCase>
    {
        public EditSpecificationsValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Specification Id is required.")
                .Must(id => context.Specifications.Any(x => x.Id == id))
                .WithMessage("Specification with an Id of {PropertyValue} does not exist.");

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Specification name is required.")
                .Must((useCase, name) => !context.Specifications.Any(y => y.Name == name && y.Id != useCase.Data.Id))
                .WithMessage("Specification with the name {PropertyValue} already exists.");
        }
    }
}
