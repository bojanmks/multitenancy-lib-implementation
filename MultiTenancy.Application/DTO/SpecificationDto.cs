﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public class SpecificationDto : TenantOwnedDto
    {
        public string Name { get; set; }
    }
}
