using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Model.TableConfig
{
    internal class CommandEntiyConfiguration : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.ToTable("tbCommand").HasKey(v => v.Id);
            builder.Property(v => v.HowTo).HasMaxLength(250).IsRequired();
            builder.Property(v => v.Line).IsRequired();
            builder.Property(v => v.Platform).IsRequired();
        }
    }
}
