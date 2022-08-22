using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class User : Entity, ITenantOwnedEntity
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte RoleId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<CartItem> CartItems{ get; set; }
        public virtual ICollection<UseCase> UseCases { get; set; }

        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
