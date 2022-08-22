using MultiTenancy.Entities;
using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class Address : Entity, IMustHaveUser, IMustHaveTenant
    {
        public string Value { get; set; }

        public int UserId { get; set; }
        public int CountryId { get; set; }
        public virtual User User { get; set; }
        public virtual Country Country { get; set; }

        public string TenantIdPath => "User";
    }
}
