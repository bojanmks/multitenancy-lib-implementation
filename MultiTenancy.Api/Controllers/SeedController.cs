using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancy.Api.Core;
using MultiTenancy.Api.Core.Jwt;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using MultiTenancy.Domain.Enums;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public SeedController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        // POST api/<SeedController>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post()
        {
            var user1 = new ApplicationUser
            {
                UserId = 1,
                TenantId = 1,
                Username = "fsadmin",
                Email = "fsadmin@mail.com",
                Role = UserRole.SuperUserTenant
            };

            var user2 = new ApplicationUser
            {
                UserId = 2,
                TenantId = 2
            };

            var user3 = new ApplicationUser
            {
                UserId = 3,
                TenantId = 3
            };

            var options = new DbContextOptionsBuilder<ShopDbContext>()
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(_appSettings.ConnString, x => x.MigrationsAssembly("MultiTenancy.Api"))
                    .UseLazyLoadingProxies()
                    .Options;

            #region TenantOne

            var context1 = new ShopDbContext(options, user1, Guid.NewGuid().ToString());

            context1.Tenants.Add(new Tenant
            {
                Id = 1,
                Name = "Furniture Shop"
            });


            context1.SaveChanges();

            #endregion TenantOne



            return StatusCode(StatusCodes.Status201Created);



        }

    }
}
