using MultiTenancy.Domain.Enums;
using MultiTenency.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Domain
{
    public interface IApplicationActor : IApplicationUser
    {
        public string Username { get; }
        public string Email { get; }
        public UserRole Role { get; }
        public IEnumerable<string> UseCaseIds { get; }
    }
}
