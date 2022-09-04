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
    public class EditTenantValidator : AbstractValidator<EditTenantUseCase>
    {
        public EditTenantValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Tenant Id is required.")
                .Must(id => context.Tenants.Any(x => x.Id == id))
                .WithMessage("Tenant with an Id of {PropertyValue} does not exist.");

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Tenant name is required.")
                .Must((useCase, name) => !context.Tenants.Any(x => x.Name == name && x.Id != useCase.Data.Id))
                .WithMessage("Tenant with the name {PropertyValue} already exists.");
        }
    }
}
