using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenancy.DataAccess;

namespace MultiTenancy.Api.Core
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        public TestDbContext CreateDbContext(string[] args)
        {
            var config = Configuration.GetConfiguration<AppSettings>();

            var builder = new DbContextOptionsBuilder<TestDbContext>();

            builder.UseSqlServer(config.ConnString, x => x.MigrationsAssembly(this.GetType().Assembly.GetName().Name)).UseLazyLoadingProxies();

            var schema = Guid.NewGuid().ToString();

            return new TestDbContext(builder.Options, null, schema);
        }
    }
}
