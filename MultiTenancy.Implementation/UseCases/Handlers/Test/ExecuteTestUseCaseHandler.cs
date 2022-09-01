
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Test;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases.Handlers.Test
{
    public class ExecuteTestUseCaseHandler : EfUseCaseHandler<ExecuteTestUseCase, Empty>
    {
        public ExecuteTestUseCaseHandler(ShopDbContext context) : base(context)
        {
        }

        public override Empty Handle(ExecuteTestUseCase useCase)
        {
            _context.Test.Add(new Domain.Test
            {
                Name = "Test " + useCase.Data.ToString()
            });

            _context.SaveChanges();

            return new Empty();
        }
    }
}
