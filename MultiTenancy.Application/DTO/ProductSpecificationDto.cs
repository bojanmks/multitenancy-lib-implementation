using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public class ProductSpecificationDto : BaseDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
    }
}
