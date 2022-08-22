﻿using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MultiTenancy.Api.Core.Jwt;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Test;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using MultiTenancy.Domain.Enums;
using MultiTenancy.Implementation.UseCases.Handlers.Test;
using MultiTenancy.Implementation.Validators.Test;
using Newtonsoft.Json;
using System.Text;

namespace MultiTenancy.Api.Core.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddApplicationActor(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IApplicationActor>(x => {
                var accessor = x.GetService<IHttpContextAccessor>();

                var claims = accessor.HttpContext?.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymousUser();
                }

                var role = Enum.Parse<UserRole>(claims.FindFirst("Role").Value);

                var userType = UserTypeMap.GetType(role);

                var user = Activator.CreateInstance(userType) as ApplicationUser;

                user.UserId = Int32.Parse(claims.FindFirst("UserId").Value);
                user.TenantId = Int32.Parse(claims.FindFirst("UserId").Value);
                user.Username = claims.FindFirst("Username").Value;
                user.Email = claims.FindFirst("Email").Value;
                user.UseCaseIds = JsonConvert.DeserializeObject<List<string>>(claims.FindFirst("UseCases").Value);

                return user;
            });
        }

        public static void AddJwt(this WebApplicationBuilder builder, AppSettings settings)
        {
            builder.Services.AddTransient(x =>
            {
                var context = x.GetService<ShopDbContext>();

                return new JwtManager(settings.JwtSettings, context);
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

        public static void AddDbContext(this WebApplicationBuilder builder, AppSettings settings)
        {
            builder.Services.AddTransient(x =>
            {
                var options = new DbContextOptionsBuilder<ShopDbContext>()
                                    .EnableSensitiveDataLogging()
                                    .UseSqlServer(settings.ConnString, x => x.MigrationsAssembly("MultiTenancy.Api"))
                                    .UseLazyLoadingProxies()
                                    .Options;

                var user = x.GetService<IApplicationActor>();
                var schema = Guid.NewGuid().ToString();

                var context = new ShopDbContext(options, user, schema);

                return context;
            });

            var config = Configuration.GetConfiguration<AppSettings>();

            builder.Services.AddDbContext<ShopDbContext>(x =>
            {
                x.UseSqlServer(config.ConnString, x => x.MigrationsAssembly("MultiTenancy.Api"))
                .UseLazyLoadingProxies();
            });
        }

        public static void AddUseCaseValidators(this WebApplicationBuilder builder)
        {
            //builder.Services.AddTransient<IValidator<AddTestUseCase>, AddTestValidator>();

            var type = typeof(IValidator);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract && p.Namespace.StartsWith("MultiTenancy.Implementation.Validators"));

            foreach(var t in types)
            {
                if(t.BaseType != null)
                {
                    builder.Services.AddTransient(t.BaseType, t);
                }
            }
        }

        public static void AddUseCaseHandlers(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUseCaseHandler<ExecuteTestUseCase, Empty>, ExecuteTestUseCaseHandler>();
        }
    }
}
