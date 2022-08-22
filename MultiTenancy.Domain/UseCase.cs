using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class UseCase : Entity, IMustHaveTenant
    {
        public string UseCaseId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string TenantIdPath => "User";
    }
}
