using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Exceptions
{
    public class ForbiddenUseCaseException : Exception
    {
        public ForbiddenUseCaseException(string useCaseId, string identity) :
            base($"User {identity} has tried to execute {useCaseId} without authorization.")
        {

        }
    }
}
