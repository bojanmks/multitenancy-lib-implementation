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
    public class AddCartItemValidator : AbstractValidator<AddCartItemUseCase>
    {
        public AddCartItemValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product Id is required.")
                .Must(pId => context.Products.Any(x => x.Id == pId))
                .WithMessage("Product with the Id {PropertyValue} doesn't exist.");


            RuleFor(x => x.Data.Quantity)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Quantity is required.")
                .GreaterThan(0)
                .WithMessage("Quantity needs to be greater than 0.");
        }
    }
}
