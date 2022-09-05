using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MultiTenancy.Application.UseCases.Cart;
using MultiTenancy.DataAccess;

namespace MultiTenancy.Implementation.Validators.Cart
{
    public class EditCartItemValidator : AbstractValidator<EditCartItemUseCase>
    {
        public EditCartItemValidator(ShopDbContext context)
        {

            RuleFor(x => x.Data.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Cart Item Id is required.")
                .Must(id => context.CartItems.Any(x => x.Id == id))
                .WithMessage("Cart Item with an Id of {PropertyValue} does not exist.");

            RuleFor(x => x.Data.Quantity)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Quantity is required.")
                .GreaterThan(0)
                .WithMessage("Quantity needs to be greater than 0.");
        }
    }
}
