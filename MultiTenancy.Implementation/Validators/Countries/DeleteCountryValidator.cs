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
    public class DeleteCountryValidator : AbstractValidator<DeleteCountryUseCase>
    {
        public DeleteCountryValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Country Id is required.")
                .Must(id => context.Countries.Any(x => x.Id == id))
                .WithMessage("Country with an Id of {PropertyValue} does not exist.")
                .Must(id => !context.Countries.Find(id).Addresses.Any())
                .WithMessage("Country cannot be deleted.");
        }
    }
}
