using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Exceptions
{
    public class InvalidSortFormatException : Exception
    {
        public InvalidSortFormatException() : base("Invalid sort string format. (PropertyName1.Direction,PropertyName2.Direction,...)")
        {

        }
    }
}
