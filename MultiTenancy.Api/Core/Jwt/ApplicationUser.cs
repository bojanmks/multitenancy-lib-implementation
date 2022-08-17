using MultiTenancy.Application.Enums;
using MultiTenency.Core;

namespace MultiTenancy.Api.Core.Jwt
{
    public class ApplicationUser : IApplicationUser
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public string Identity { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
    }

    public class ApplicationSuperUserTenant : ApplicationUser, IApplicationSuperUserWithinTenant
    {

    }

    public class ApplicationSuperUserGlobal : ApplicationSuperUserTenant, IApplicationSuperUserGlobal
    {

    }

    public class AnonimousUser : IApplicationUser
    {
        public int UserId => 0;
        public int TenantId => 0;
        public string Identity => null;
        public string Email => null;
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
    }
}
