using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.DataAccess.Configuration
{
    public class AddressConfiguration : EntityConfiguration<Address>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Value).HasMaxLength(200).IsRequired();

        }
    }
}
