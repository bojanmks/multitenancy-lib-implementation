using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancy.Domain;

namespace MultiTenancy.DataAccess.Configuration
{
    public class OrderItemConfiguration : EntityConfiguration<OrderItem>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<OrderItem> builder)
        {
            
        }
    }
}
