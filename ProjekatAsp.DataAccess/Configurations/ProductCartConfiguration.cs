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
    public class ProductCartConfiguration : EntityConfiguration<ProductsCart>
    {
        protected override void ConfigureRules(EntityTypeBuilder<ProductsCart> builder)
        {
            builder.Property(x=>x.ProductName).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.ProductPrice).HasMaxLength(10).IsRequired();
            builder.Property(x=>x.ProductAmount).HasMaxLength(10).IsRequired();

            builder.HasOne(x => x.Cart)
                    .WithMany(x => x.ProductsCarts)
                    .HasForeignKey(x => x.Cart_id)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                    .WithMany(x => x.ProductsCarts)
                    .HasForeignKey(x => x.Product_id)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
