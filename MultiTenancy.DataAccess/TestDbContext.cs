using Microsoft.EntityFrameworkCore;
using MultiTenancy.Domain;
using MultiTenency.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.DataAccess
{
    public class TestDbContext : MultiTenancyContext
    {
        public TestDbContext(DbContextOptions options, IApplicationActor user, string schema) : base(options, user, schema)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Test> Test { get; set; }
    }
}
