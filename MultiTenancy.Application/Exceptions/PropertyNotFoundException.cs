using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string propName) : base($"Property with the name {propName} does not exist.")
        {

        }
    }
}
