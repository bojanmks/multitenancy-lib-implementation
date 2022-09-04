using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Tenants
{
    public class AddTenantUseCase : UseCase<TenantDto>
    {
        public AddTenantUseCase(TenantDto data) : base(data)
        {
        }

        public override string Id => "AddTenantUseCase";
    }
}
