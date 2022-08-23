using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Exceptions
{
    public class InvalidSortDirectionException : Exception
    {
        public InvalidSortDirectionException() : base("Sort direction can either be 'asc' or 'desc'.")
        {

        }
    }
}
