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
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(20);


            builder.HasMany(x => x.Carts)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.User_id)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x=>x.UserUseCases)
                    .WithOne(x=>x.User)
                    .HasForeignKey(x=>x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
