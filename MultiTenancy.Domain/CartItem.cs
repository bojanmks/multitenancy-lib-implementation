using MultiTenancy.Entities;
using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class CartItem : Entity, IMustHaveTenant, IMustHaveUser
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }

        public string TenantIdPath => "User";

    }
}
