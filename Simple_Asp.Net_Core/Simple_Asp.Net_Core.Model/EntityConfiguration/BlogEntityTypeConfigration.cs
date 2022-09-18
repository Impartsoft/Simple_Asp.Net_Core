using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Model.EntityConfiguration
{
    public class BlogEntityTypeConfigration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("tbBlog");
            builder.SetEntityBase();

            builder.Property(v => v.Title).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Content).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(v => v.UserId).IsRequired();

            builder.HasMany(v => v.Comments).WithOne().HasForeignKey(v=>v.BlogId);

            // 没有关联属性，直接使用泛型进行匹配
            builder.HasOne<User>().WithMany().HasForeignKey(v => v.UserId);
        }
    }
}
