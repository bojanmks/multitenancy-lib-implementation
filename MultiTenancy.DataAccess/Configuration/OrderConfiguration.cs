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
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.StatusId).HasDefaultValue(0);

            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
