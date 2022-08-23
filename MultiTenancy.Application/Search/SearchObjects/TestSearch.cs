using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Search.SearchObjects
{
    public class TestSearch : BaseSearch
    {
        public TestSearch()
        {
            AddCustomSortElement("customSortTest", "x => x.Name");
        }

        [QueryProperty(ComparisonType.LessThanOrEqual, "Id")]
        public int? Id { get; set; }

        [QueryProperty(ComparisonType.Contains, "Name")]
        public string? Name { get; set; }
    }
}
