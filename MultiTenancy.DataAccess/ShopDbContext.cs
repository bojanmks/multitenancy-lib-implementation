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
    public class ShopDbContext : MultiTenancyContext
    {
        public ShopDbContext(DbContextOptions options, IApplicationActor user, string schema) : base(options, user, schema)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            AddQueryFilterEntry<Entity>(e => e.IsActive.Value);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = (_user is IApplicationActor um) ? um.Username : "/";
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            e.DeletedAt = DateTime.UtcNow;
                            e.DeletedBy = (_user is IApplicationActor ud) ? ud.Username : "/";
                            e.IsActive = false;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Test> Test { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<CategorySpecification> CategorySpecifications { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
