using AspNedelja3Vezbe.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.DataAccess.Configurations
{
    public class AvailableDataConfiguration : EntityConfiguration<AvailableData>
    {
        protected override void ConfigureRules(EntityTypeBuilder<AvailableData> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ProductSpecification)
                   .WithOne(x => x.AvailableData)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
