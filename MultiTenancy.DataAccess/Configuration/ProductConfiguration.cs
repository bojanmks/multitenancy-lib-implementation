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
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.ProductSpecifications).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
