using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Cart
{
    public class DeleteCartItemUseCase : UseCase<int>
    {
        public DeleteCartItemUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteCartItemUseCase";
    }
}
