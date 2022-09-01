using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.DataAccess.Configuration
{
    public class CategorySpecificationConfiguration : EntityConfiguration<CategorySpecification>
    {
        protected override void ConfigureConstraints(EntityTypeBuilder<CategorySpecification> builder)
        {
        }
    }
}
