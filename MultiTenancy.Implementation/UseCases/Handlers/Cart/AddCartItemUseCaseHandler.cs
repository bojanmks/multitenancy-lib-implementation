using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Cart;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;

namespace MultiTenancy.Implementation.UseCases.Handlers.Cart
{
    public class AddCartItemUseCaseHandler : EfUseCaseHandler<AddCartItemUseCase, Empty>
    {
        private readonly IMapper _mapper;

        public AddCartItemUseCaseHandler(ShopDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public override Empty Handle(AddCartItemUseCase useCase)
        {
            var data = useCase.Data;

            var cartItem = _context.CartItems.FirstOrDefault(x => x.ProductId == data.ProductId);

            if (cartItem == null)
            {
                _context.CartItems.Add(_mapper.Map<CartItem>(data));
            }
            else
            {
                cartItem.Quantity += data.Quantity;
            }

            _context.SaveChanges();

            return new Empty();

        }
    }
}
