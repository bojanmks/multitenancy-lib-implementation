using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.DataAccess.Configuration
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.UpdatedBy).HasMaxLength(30);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            ConfigureConstraints(builder);
        }

        protected abstract void ConfigureConstraints(EntityTypeBuilder<T> builder);
    }
}
