using FluentValidation;
using MultiTenancy.Application.UseCases.Users;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Users
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserUseCase>
    {
        public DeleteUserValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("User Id is required.")
                .Must(id => context.Users.Any(x => x.Id == id))
                .WithMessage("User with an Id of {PropertyValue} does not exist.");
        }
    }
}
