using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Enums
{
    public enum UserRole
    {
        User = 0,
        SuperUserTenant = 1,
        SuperUserGlobal = 2
    }
}
