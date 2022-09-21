using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Model.EntityConfiguration
{
    public class CommentEntityTypeConfigration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("tbComment");

            builder.Property(v => v.Content).IsRequired().HasMaxLength(1000);
            builder.Property(v => v.UserId).IsRequired();
            builder.Property(v => v.BlogId).IsRequired();
            builder.Property(v => v.CreateTime).IsRequired();

            builder.HasOne(v => v.User).WithMany().HasForeignKey(v => v.UserId);
        }
    }
}
