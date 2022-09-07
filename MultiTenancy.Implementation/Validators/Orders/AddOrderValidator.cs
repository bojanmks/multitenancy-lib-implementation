using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MultiTenancy.Application.UseCases.Orders;
using MultiTenancy.DataAccess;

namespace MultiTenancy.Implementation.Validators.Orders
{
    public class AddOrderValidator : AbstractValidator<AddOrderUseCase>
    {
        public AddOrderValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data.AddressId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Address Id is required.")
                .Must(addressId => context.Addresses.Any(x => x.Id == addressId))
                .WithMessage("Address with an Id of {PropertyValue} does not exist.");


            RuleFor(x => x.Data.Items)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(items => items.All(item => context.Products.Any(x => x.Id == item.ProductId)))
                .WithMessage("Some of the products provided do not exist.")
                .Must(items => items.All(item => items.Where(x => x.ProductId == item.ProductId).Count() == 1))
                .WithMessage("Product Ids must be unique.")
                .Must(items => items.All(item => item.Quantity > 0))
                .WithMessage("Quantity must always be higher than 0.");

        }
    }
}
