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
    public class AddCountryValidator : AbstractValidator<AddCountryUseCase>
    {
        public AddCountryValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Country name is required.")
                .Must(name => !context.Countries.Any(x => x.Name == name))
                .WithMessage("Country with the name {PropertyValue} already exists.");
        }
    }
}
