using MultiTenancy.Api.Core.Jwt;
using MultiTenancy.Domain.Enums;

namespace MultiTenancy.Api.Core
{
    public static class UserTypeMap
    {
        private static Dictionary<UserRole, Type> Map => new Dictionary<UserRole, Type>
        {
            { UserRole.User, typeof(ApplicationUser) },
            { UserRole.SuperUserTenant, typeof(ApplicationSuperUserTenant) },
            { UserRole.SuperUserGlobal, typeof(ApplicationSuperUserGlobal) }
        };

        public static Type GetType(UserRole role) => Map[role];
    }
}
