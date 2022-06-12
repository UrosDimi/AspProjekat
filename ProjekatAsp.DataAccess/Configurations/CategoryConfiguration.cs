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
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Desc).HasMaxLength(100).IsRequired(true);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Desc);

            builder.HasMany(x => x.Child_categories)
                   .WithOne(x => x.Parent_category)
                   .HasForeignKey(x=>x.parent_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Specifications).WithMany(x => x.Categories);

        }
    }
}
