using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.DTO;

namespace MultiTenancy.Application.UseCases.Cart
{
    public class AddCartItemUseCase : UseCase<CartItemDto>
    {
        public AddCartItemUseCase(CartItemDto data) : base(data)
        {
        }

        public override string Id => "AddCartItemUseCase";
    }
}
