using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.DTO;

namespace MultiTenancy.Application.UseCases.Orders
{
    public class AddOrderUseCase : UseCase<AddOrderDto>
    {
        public AddOrderUseCase(AddOrderDto data) : base(data)
        {
        }

        public override string Id => "AddOrderUseCase";
    }
}
