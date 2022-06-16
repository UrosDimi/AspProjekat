using AspNedelja3Vezbe.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ProjekatAsp.DataAccess.Configurations
{
    public class SpecificationConfiguration : EntityConfiguration<Specification>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Specification> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Name);

            builder.HasMany(x=>x.AvailableDatas)
                   .WithOne(x=>x.Specification)
                   .HasForeignKey(x=>x.Specification_id)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x=>x.ProductSpecifications)
                   .WithOne(x=>x.Specification)
                   .HasForeignKey(x=>x.Specification_id)
                   .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
