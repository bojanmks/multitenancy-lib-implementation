using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public class CategoryDto : TenantOwnedDto
    {
        public string Name { get; set; }
        public IEnumerable<int> SpecificationIds { get; set; }
        public IEnumerable<string>? Specifications { get; set; }
    }
}
