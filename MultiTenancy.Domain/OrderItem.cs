﻿using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class OrderItem : Entity, IMustHaveTenant
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

        public string TenantIdPath => "Order.User";
    }
}
