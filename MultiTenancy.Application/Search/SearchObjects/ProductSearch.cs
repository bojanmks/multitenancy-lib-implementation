using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Search.SearchObjects
{
    public class ProductSearch : BaseSearch
    {
        [QueryProperty(ComparisonType.Contains, "Name", "Description")]
        public string? Keyword { get; set; }

        [QueryProperty(ComparisonType.Equals, "CategoryId")]
        public int? CategoryId { get; set; }

        [QueryProperty(ComparisonType.Equals, "Category.TenantId")]
        public int? TenantId { get; set; }
    }
}
