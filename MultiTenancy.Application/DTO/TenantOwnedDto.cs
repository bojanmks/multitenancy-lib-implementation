using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public abstract class TenantOwnedDto : BaseDto
    {
        public int TenantId { get; set; }
    }
}
