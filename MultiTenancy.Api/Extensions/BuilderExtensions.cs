using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MultiTenancy.Api.Core;
using MultiTenancy.Api.Core.Jwt;
using MultiTenancy.Application.Enums;
using MultiTenency.Core;
using Newtonsoft.Json;
using System.Text;

namespace MultiTenancy.Api.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddApplicationUser(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IApplicationUser>(x => {
                var accessor = x.GetService<IHttpContextAccessor>();

                var claims = accessor.HttpContext?.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var role = Enum.Parse<UserRole>(claims.FindFirst("Role").Value);

                var userType = UserTypeMap.GetType(role);

                var user = Activator.CreateInstance(userType) as ApplicationUser;

                user.UserId = Int32.Parse(claims.FindFirst("UserId").Value);
                user.TenantId = Int32.Parse(claims.FindFirst("UserId").Value);
                user.Identity = claims.FindFirst("Identity").Value;
                user.Email = claims.FindFirst("Email").Value;
                user.UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value);

                return user;
            });
        }

        public static void AddJwt(this WebApplicationBuilder builder, AppSettings settings)
        {
            builder.Services.AddTransient(x =>
            {
                return new JwtManager(settings.JwtSettings);
            });


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
