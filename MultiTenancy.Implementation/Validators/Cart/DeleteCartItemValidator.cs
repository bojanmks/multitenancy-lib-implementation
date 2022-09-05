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
    public class DeleteCartItemValidator : AbstractValidator<DeleteCartItemUseCase>
    {
        public DeleteCartItemValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Cart Item Id is required.")
                .Must(id => context.CartItems.Any(x => x.Id == id))
                .WithMessage("Cart Item with an Id of {PropertyValue} does not exist.");
        }
    }
}
