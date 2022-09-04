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
    public class DeleteTenantValidator : AbstractValidator<DeleteTenantUseCase>
    {
        public DeleteTenantValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Tenant Id is required.")
                .Must(id => context.Tenants.Any(x => x.Id == id))
                .WithMessage("Tenant with an Id of {PropertyValue} does not exist.")
                .Must(id =>
                {
                    var tenant = context.Tenants.Find(id);

                    return !(tenant.Categories.Any(x => x.IsActive.Value)
                         || tenant.Specifications.Any(x => x.IsActive.Value)
                         || tenant.Users.Any(x => x.IsActive.Value));
                })
                .WithMessage("Tenant cannot be deleted.");
        }
    }
}
