using MultiTenency.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public class Product : Entity, IMustHaveTenant
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int ImageId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }


        public string TenantIdPath => "Category";
    }
}
