using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.DataAccess.Configuration
{
    public class ProductSpecificationConfiguration : EntityConfiguration<ProductSpecification>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder.Property(x => x.Value).HasMaxLength(30).IsRequired();
        }
    }
}
