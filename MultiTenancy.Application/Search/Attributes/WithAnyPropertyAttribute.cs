using MultiTenancy.Application.Search.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Search.Attributes
{
    public class WithAnyPropertyAttribute : QueryPropertyAttribute
    {
        public WithAnyPropertyAttribute(ComparisonType comparisonType, params string[] properties) : base(comparisonType, properties)
        {
        }
    }
    public class WithAnyPropertyAndAttribute : QueryPropertyAttribute, IAndAttribute
    {
        public WithAnyPropertyAndAttribute(ComparisonType comparisonType, params string[] properties) : base(comparisonType, properties)
        {
        }
    }
}
