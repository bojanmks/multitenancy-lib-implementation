using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenancy.Api.Core.Jwt;
using MultiTenancy.DataAccess;

namespace MultiTenancy.Api.Core
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {
            var config = Configuration.GetConfiguration<AppSettings>();

            var builder = new DbContextOptionsBuilder<ShopDbContext>();

            builder.UseSqlServer(config.ConnString, x => x.MigrationsAssembly(this.GetType().Assembly.GetName().Name)).UseLazyLoadingProxies();

            var schema = Guid.NewGuid().ToString();

            return new ShopDbContext(builder.Options, new AnonymousUser(), schema);
        }
    }
}
