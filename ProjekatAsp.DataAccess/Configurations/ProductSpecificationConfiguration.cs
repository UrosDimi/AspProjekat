using AspNedelja3Vezbe.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.DataAccess.Configurations
{
    public class ProductSpecificationConfiguration : EntityConfiguration<ProductSpecification>
    {
        protected override void ConfigureRules(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder.Property(x => x.value).HasMaxLength(30).IsRequired();

            

        }
    }
}
