using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using MultiTenancy;
using MultiTenancy.Core;
using MultiTenancy.Entities;
using MultiTenancy.Extensions;
using MultiTenency;
using MultiTenency.Core;
using MultiTenency.Entities;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace MultiTenancy
{
    public abstract class MultiTenancyContext : DbContext
    {
        protected readonly IApplicationUser _user;
        public string Schema { get; }
        protected virtual List<IQueryFilterEntry> QueryFilterEntries { get; }

        public MultiTenancyContext(DbContextOptions options, IApplicationUser user, string schema) : base(options)
        {
            _user = user;
            Schema = schema;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ReplaceService<IModelCacheKeyFactory, MultiTenancyModelCacheKeyFactory>();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                       .ToList()
                       .ForEach(entityType =>
                       {
                           if (typeof(IMustHaveTenant).IsAssignableFrom(entityType.ClrType))
                           {
                               var type = entityType.ClrType;
                               var instance = Activator.CreateInstance(entityType.ClrType);
                               var tenantIdPath = (instance as IMustHaveTenant).TenantIdPath;

                               var lambdaParserGenericType = typeof(LambdaParser<>).MakeGenericType(type);
                               dynamic lambdaParserInstance = Activator.CreateInstance(lambdaParserGenericType);

                               var expression = lambdaParserInstance.ParseLambda(tenantIdPath, _user);

                               EntityTypeBuilderExtensions.AddQueryFilter(modelBuilder.Entity(entityType.ClrType), expression);
                           }



                           if (typeof(IMustHaveUser).IsAssignableFrom(entityType.ClrType))
                           {
                               EntityTypeBuilderExtensions.AddQueryFilter<IMustHaveUser>(modelBuilder.Entity(entityType.ClrType), e => (_user is IApplicationSuperUser) || e.UserId == _user.UserId);
                           }



                           foreach(var item in QueryFilterEntries ?? Enumerable.Empty<IQueryFilterEntry>())
                           {
                               if (item.Type.IsAssignableFrom(entityType.ClrType))
                               {
                                   Type entryGenericType = typeof(QueryFilterEntry<>).MakeGenericType(item.Type);
                                   dynamic entry = Convert.ChangeType(item, entryGenericType);

                                   EntityTypeBuilderExtensions.AddQueryFilter(modelBuilder.Entity(entityType.ClrType), entry.Expression);
                               }
                           }
                       });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is ITenantOwnedEntity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.TenantId = _user.TenantId;
                            break;
                    }
                }

                if (entry.Entity is IMustHaveUser eUser)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            eUser.UserId = _user.UserId;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}