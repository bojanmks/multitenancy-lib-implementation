using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Orders;
using MultiTenancy.DataAccess;

namespace MultiTenancy.Implementation.UseCases.Handlers.Orders
{
    public class EditOrderUseCaseHandler : EfUseCaseHandler<EditOrderUseCase, Empty>
    {
        public EditOrderUseCaseHandler(ShopDbContext context) : base(context)
        {
        }

        public override Empty Handle(EditOrderUseCase useCase)
        {
            var data = useCase.Data;

            var order = _context.Orders.Find(data.Id);
            order.StatusId = data.StatusId;

            _context.SaveChanges();

            return new Empty();
        }
    }
}
