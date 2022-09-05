using FluentValidation;
using MultiTenancy.Application.UseCases.Users;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using MultiTenancy.Domain.Enums;
using MultiTenency.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Users
{
    public class EditUserValidator : AbstractValidator<EditUserUseCase>
    {
        public EditUserValidator(ShopDbContext context, IApplicationActor actor)
        {
            When(x => actor is IApplicationSuperUserGlobal, () =>
            {
                RuleFor(x => x.Data.Email)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Email is required.")
                    .EmailAddress()
                    .WithMessage("Invalid email format.")
                    .Must((useCase, email) => !context.Users.Any(x => x.Email == email && x.TenantId == useCase.Data.TenantId && x.Id != useCase.Data.Id))
                    .WithMessage("Email {PropertyValue} is already taken.");
            })
            .Otherwise(() =>
            {
                RuleFor(x => x.Data.Email)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Email is required.")
                    .EmailAddress()
                    .WithMessage("Invalid email format.")
                    .Must((useCase, email) => !context.Users.Any(x => x.Email == email && x.Id != useCase.Data.Id))
                    .WithMessage("Email {PropertyValue} is already taken.");
            });

            When(x => actor is IApplicationSuperUserGlobal, () =>
            {
                RuleFor(x => x.Data.Username)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Username is required.")
                    .Matches(@"^[A-Za-z0-9-_]{5,}$")
                    .WithMessage("Username can only contain letters, numbers, dashes, underscores and needs to be at least 5 characters long.")
                    .Must((useCase, username) => !context.Users.Any(x => x.Username == username && x.TenantId == useCase.Data.TenantId && x.Id != useCase.Data.Id))
                    .WithMessage("Username {PropertyValue} is already taken.");
            })
            .Otherwise(() =>
            {
                RuleFor(x => x.Data.Username)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Username is required.")
                    .Matches(@"^[A-Za-z0-9-_]{5,}$")
                    .WithMessage("Username can only contain letters, numbers, dashes, underscores and needs to be at least 5 characters long.")
                    .Must((useCase, username) => !context.Users.Any(x => x.Username == username && x.Id != useCase.Data.Id))
                    .WithMessage("Username {PropertyValue} is already taken.");
            });

            RuleFor(x => x.Data.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Password is required.")
                .Matches(@"^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9!@#\$%\^&\*-_]{8,}$")
                .WithMessage("Password needs to contain at least one letter, one number, and be at least 8 characters long.");

            RuleFor(x => x.Data.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Full name is required.")
                .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})+$")
                .WithMessage("Invalid full name format.");

            When(x => actor is IApplicationSuperUserGlobal, () =>
            {
                RuleFor(x => x.Data.RoleId)
                    .Must(roleId => Enum.IsDefined(typeof(UserRole), (int)roleId))
                    .WithMessage("Role with and Id of {PropertyValue} does not exist.");
            })
            .Otherwise(() =>
            {
                RuleFor(x => x.Data.RoleId)
                    .Cascade(CascadeMode.Stop)
                    .Must(roleId => Enum.IsDefined(typeof(UserRole), (int)roleId))
                    .WithMessage("Role with and Id of {PropertyValue} does not exist.")
                    .Must(roleId => roleId != (byte)UserRole.SuperUserGlobal)
                    .WithMessage("You cannot create a user with that role.");
            });

            When(x => actor is IApplicationSuperUserGlobal, () =>
            {
                RuleFor(x => x.Data.TenantId)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Tenant Id is required.")
                    .Must(tenantId => context.Tenants.Any(y => y.Id == tenantId))
                    .WithMessage("Tenant with an Id of {PropertyValue} does not exist.");
            });
        }
    }
}
