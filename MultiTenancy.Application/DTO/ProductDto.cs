using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public class ProductDto : TenantOwnedDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ImageId { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<ProductSpecificationDto> Specifications { get; set; }
    }
}
