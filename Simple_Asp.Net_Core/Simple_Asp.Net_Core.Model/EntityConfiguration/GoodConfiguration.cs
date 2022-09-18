using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_Asp.Net_Core.Model.EntityConfiguration;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Model.TableConfig
{
    internal class GoodConfiguration : IEntityTypeConfiguration<Goods>
    {
        public void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.ToTable("tbGood");
            builder.SetEntityBase();

            builder.Property(v => v.Code).HasMaxLength(250).IsRequired();
            builder.Property(v => v.Name).HasMaxLength(250).IsRequired();
            builder.Property(v => v.Desc).HasMaxLength(500).IsRequired();
            builder.Property(v => v.Type).HasMaxLength(100).IsRequired();
            builder.Property(v => v.MainImageId).HasMaxLength(500).IsRequired();
            builder.Property(v => v.DBImageIds).HasMaxLength(2000).IsRequired();
        }

    }
}
