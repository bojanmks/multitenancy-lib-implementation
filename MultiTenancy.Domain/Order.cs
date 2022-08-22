using MultiTenancy.Entities;
using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class Order : Entity, IMustHaveUser, IMustHaveTenant
    {
        public byte StatusId { get; set; }
        public string DeliveryLocation { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public string TenantIdPath => "User";
    }
}
