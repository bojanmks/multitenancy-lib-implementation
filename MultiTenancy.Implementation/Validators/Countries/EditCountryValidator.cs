using FluentValidation;
using MultiTenancy.Application.UseCases.Countries;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Countries
{
    public class EditCountryValidator : AbstractValidator<EditCountryUseCase>
    {
        public EditCountryValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Country Id is required.")
                .Must(id => context.Countries.Any(x => x.Id == id))
                .WithMessage("Country with an Id of {PropertyValue} does not exist.");

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Country name is required.")
                .Must((useCase, name) => !context.Countries.Any(x => x.Name == name && x.Id != useCase.Data.Id))
                .WithMessage("Country with the name {PropertyValue} already exists.");
        }
    }
}
