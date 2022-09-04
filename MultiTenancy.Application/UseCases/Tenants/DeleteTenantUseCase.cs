using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Tenants
{
    public class DeleteTenantUseCase : UseCase<int>
    {
        public DeleteTenantUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteTenantUseCase";
    }
}
