using FluentValidation;
using MultiTenancy.Application.UseCases.Tenants;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Tenants
{
    public class AddTenantValidator : AbstractValidator<AddTenantUseCase>
    {
        public AddTenantValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Tenant name is required.")
                .Must(name => !context.Tenants.Any(x => x.Name == name))
                .WithMessage("Tenant with the name {PropertyValue} already exists.");
        }
    }
}
