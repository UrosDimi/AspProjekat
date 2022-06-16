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
    public class ProductsConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Desc).HasMaxLength(100).IsRequired();

            builder.HasIndex(x=>x.Name);

            builder.HasMany(x => x.Categories).WithMany(x => x.Products);

            builder.HasMany(x=>x.ProductSpecifications)
                    .WithOne(x=>x.Product)
                    .HasForeignKey(x=>x.Product_id)
                    .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
