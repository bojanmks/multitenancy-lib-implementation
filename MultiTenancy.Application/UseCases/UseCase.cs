using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases
{
    public abstract class UseCase<T> : IUseCase
    {
        public T Data { get; }

        public UseCase(T data)
        {
            Data = data;
        }

        public abstract string Id { get; }
        public virtual string Description { get; }
    }
}
