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
    public class DeleteAddressValidator : AbstractValidator<DeleteAddressUseCase>
    {
        public DeleteAddressValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Address Id is required.");
        }
    }
}
