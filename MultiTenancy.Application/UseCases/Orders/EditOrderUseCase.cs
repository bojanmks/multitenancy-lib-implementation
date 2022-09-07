using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.DTO;

namespace MultiTenancy.Application.UseCases.Orders
{
    public class EditOrderUseCase : UseCase<EditOrderDto>
    {
        public EditOrderUseCase(EditOrderDto data) : base(data)
        {
        }

        public override string Id => "EditOrderUseCase";
    }
}
