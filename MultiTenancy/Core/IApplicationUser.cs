using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenency.Core
{
    public interface IApplicationUser
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
    }

    public interface IApplicationSuperUser : IApplicationUser
    {

    }
}
