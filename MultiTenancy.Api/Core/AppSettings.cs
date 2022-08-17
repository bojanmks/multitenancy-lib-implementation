using MultiTenancy.Api.Core.Jwt;

namespace MultiTenancy.Api.Core
{
    public class AppSettings
    {
        public string ConnString { get; set; }
        public JwtSettings JwtSettings { get; set; }
    }
}
