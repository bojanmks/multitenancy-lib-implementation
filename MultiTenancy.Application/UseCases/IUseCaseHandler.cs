using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases
{
    public interface IUseCaseHandler<TUseCase, TOut> where TUseCase : IUseCase
    {
        public TOut Handle(TUseCase useCase);
    }
}
