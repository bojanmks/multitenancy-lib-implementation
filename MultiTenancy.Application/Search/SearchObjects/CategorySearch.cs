﻿using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Search.SearchObjects
{
    public class CategorySearch : BaseSearch
    {
        [QueryProperty(ComparisonType.Contains, "Name")]
        public string? Name { get; set; }
    }
}
