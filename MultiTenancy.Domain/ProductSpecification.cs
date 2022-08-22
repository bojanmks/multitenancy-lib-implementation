using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class ProductSpecification : Entity, IMustHaveTenant
    {
        public string Value { get; set; }
        public int SpecificationId { get; set; }
        public int ProductId { get; set; }

        public virtual Specification Specification { get; set; }
        public virtual Product Product { get; set; }

        public string TenantIdPath => "Specification";
    }
}
