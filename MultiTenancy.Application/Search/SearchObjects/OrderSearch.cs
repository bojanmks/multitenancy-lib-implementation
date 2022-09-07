using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;

namespace MultiTenancy.Application.Search.SearchObjects
{
    public class OrderSearch : BaseSearch
    {
        [WithAnyProperty(ComparisonType.Contains, "OrderItems", "ProductName")]
        public string? Keyword { get; set; }
    }
}
