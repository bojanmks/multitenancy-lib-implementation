using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases
{
    public abstract class EfUseCaseHandler<TUseCase, TOut> : UseCaseHandler<TUseCase, TOut> where TUseCase : IUseCase
    {
        protected readonly ShopDbContext _context;
        public EfUseCaseHandler(ShopDbContext context)
        {
            _context = context;
        }
    }
}
