using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public class AddressDto : BaseDto
    {
        public string Value { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? UserId { get; set; }
    }
}
