using FluentValidation;
using MultiTenancy.Application.UseCases.Users;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Users
{
    public class RegisterValidator : AbstractValidator<RegisterUseCase>
    {
        public RegisterValidator(ShopDbContext context, IApplicationActor user)
        {
            RuleFor(x => x.Data.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .Must(email => !context.Users.Any(x => x.Email == email))
                .WithMessage("Email {PropertyValue} is already taken.");

            RuleFor(x => x.Data.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Username is required.")
                .Matches(@"^[A-Za-z0-9-_]{5,}$")
                .WithMessage("Username can only contain letters, numbers, dashes, underscores and needs to be at least 5 characters long.")
                .Must(username => !context.Users.Any(x => x.Username == username))
                .WithMessage("Username {PropertyValue} is already taken.");

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
        }
    }
}
