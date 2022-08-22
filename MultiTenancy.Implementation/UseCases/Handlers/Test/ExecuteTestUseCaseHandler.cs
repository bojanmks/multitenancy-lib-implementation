
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
    public class ExecuteTestUseCaseHandler : IUseCaseHandler<ExecuteTestUseCase, Empty>
    {
        private readonly ShopDbContext _context;
        public ExecuteTestUseCaseHandler(ShopDbContext context)
        {
            _context = context;
        }
        public Empty Handle(ExecuteTestUseCase useCase)
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
