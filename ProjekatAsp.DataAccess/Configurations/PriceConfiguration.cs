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
    public class PriceConfiguration : EntityConfiguration<Price>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Price> builder)
        {
            builder.Property(x => x.price).HasMaxLength(5).IsRequired();

            builder.HasOne(x => x.Product)
                    .WithMany(x => x.ProductsPrice)
                    .HasForeignKey(x => x.Product_id)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
