using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MultiTenancy.Application.UseCases.Addresses;
using MultiTenancy.DataAccess;

namespace MultiTenancy.Implementation.Validators.Addresses
{
    public class AddAddressValidator : AbstractValidator<AddAddressUseCase>
    {
        public AddAddressValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Value)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Address Value is required.");

            RuleFor(x => x.Data.CountryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Address Country is required.")
                .Must(countryId => context.Countries.Any(x => x.Id == countryId))
                .WithMessage("Country with an Id of {PropertyValue} does not exist.");
        }
    }
}
