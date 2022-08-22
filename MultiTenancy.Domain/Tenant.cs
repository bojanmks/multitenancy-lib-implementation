using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class Tenant : Entity
    {
        public string Name { get; set; }
    }
}
