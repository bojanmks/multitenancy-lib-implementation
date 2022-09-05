using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;

namespace MultiTenancy.Application.Search.SearchObjects
{
    public class AddressSearch : BaseSearch
    {
        [QueryProperty(ComparisonType.Contains, "Value")]
        public string? Keyword { get; set; }
    }
}
