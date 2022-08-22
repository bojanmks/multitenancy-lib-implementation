using MultiTenancy.Domain;
using MultiTenancy.Domain.Enums;
using MultiTenency.Core;

namespace MultiTenancy.Api.Core.Jwt
{
    public class ApplicationUser : IApplicationActor
    {
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<string> UseCaseIds { get; set; } = new List<string>();
    }

    public class ApplicationSuperUserTenant : ApplicationUser, IApplicationSuperUserWithinTenant
    {

    }

    public class ApplicationSuperUserGlobal : ApplicationSuperUserTenant, IApplicationSuperUserGlobal
    {

    }

    public class AnonymousUser : IApplicationActor
    {
        public int UserId => 0;
        public int TenantId => 0;
        public string Username => null;
        public string Email => null;
        public UserRole Role => UserRole.Anonymous;
        public IEnumerable<string> UseCaseIds { get; set; } = new List<string>();
    }
}
