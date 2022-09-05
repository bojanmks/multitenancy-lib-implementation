using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.DataAccess.Configuration
{
    public class CartItemConfiguration : EntityConfiguration<CartItem>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<CartItem> builder)
        {
        }
    }
}
