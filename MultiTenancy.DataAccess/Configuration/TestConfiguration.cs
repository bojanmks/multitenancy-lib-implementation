using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.DataAccess.Configuration
{
    public class TestConfiguration : EntityConfiguration<Test>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<Test> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        }
    }
}
