using FluentValidation;
using MultiTenancy.Application.UseCases.Products;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductUseCase>
    {
        public DeleteProductValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Product Id is required.")
                .Must(id => context.Products.Any(x => x.Id == id))
                .WithMessage("Product with an Id of {PropertyValue} does not exist.")
                .Must(productId => !context.OrderItems.Any(x => x.ProductId == productId))
                .WithMessage("Product can not be deleted as it has already been ordered at least once.");
        }
    }
}
