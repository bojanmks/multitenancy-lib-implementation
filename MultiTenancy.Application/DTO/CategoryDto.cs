﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public IEnumerable<int> SpecificationIds { get; set; }
    }
}
