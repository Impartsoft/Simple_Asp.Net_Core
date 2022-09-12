using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Model.Models;

namespace Simple_Asp.Net_Core.Model.EntityConfiguration
{
    public class UserEntityTypeConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbUser");
            builder.SetEntityBase();

            builder.Property(v => v.UserName).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Password).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Phone).HasMaxLength(100);
            builder.Property(v => v.Mail).HasMaxLength(100);
        }
    }
}
