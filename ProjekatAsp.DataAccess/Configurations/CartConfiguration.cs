using AspNedelja3Vezbe.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjekatAsp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.DataAccess.Configurations
{
    public class CartConfiguration : EntityConfiguration<Cart>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(x => x.TotalPrice).HasMaxLength(10).IsRequired();

            builder.HasMany(x => x.ProductsCarts)
                    .WithOne(x => x.Cart)
                    .HasForeignKey(x=>x.Cart_id)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
