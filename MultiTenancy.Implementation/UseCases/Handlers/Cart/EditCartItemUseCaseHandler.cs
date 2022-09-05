using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Cart;
using MultiTenancy.DataAccess;

namespace MultiTenancy.Implementation.UseCases.Handlers.Cart
{
    public class EditCartItemUseCaseHandler : EfUseCaseHandler<EditCartItemUseCase, Empty>
    {
        public EditCartItemUseCaseHandler(ShopDbContext context) : base(context)
        {
        }

        public override Empty Handle(EditCartItemUseCase useCase)
        {

            var data = useCase.Data;

            var cartItem = _context.CartItems.Find(data.Id);

            cartItem.Quantity = data.Quantity;

            _context.SaveChanges();

            return new Empty();
        }
    }
}
