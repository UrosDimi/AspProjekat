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
    public class CommentConfiguration : EntityConfiguration<Comment>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Comments).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(20).IsRequired();

            builder.HasIndex(x => x.Title);

            builder.HasMany(x => x.Child_comments)
                   .WithOne(x => x.Parent_comment)
                   .HasForeignKey(x => x.Parent_comment_id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.User)
                    .WithMany(x=>x.Comments)
                    .HasForeignKey(x=>x.User_id)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
