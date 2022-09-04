using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Tenants
{
    public class FindTenantUseCase : UseCase<int>
    {
        public FindTenantUseCase(int data) : base(data)
        {
        }

        public override string Id => "FindTenantUseCase";
    }
}
