using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Search
{
    public abstract class BaseSearch : ISearchObject
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 1;
        public bool Paginate { get; set; } = false;
    }
}
