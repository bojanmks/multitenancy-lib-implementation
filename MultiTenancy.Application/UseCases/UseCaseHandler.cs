using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases
{
    public abstract class UseCaseHandler<TUseCase, TOut> : IUseCaseHandler where TUseCase : IUseCase
    {
        public abstract TOut Handle(TUseCase useCase);
    }
}
