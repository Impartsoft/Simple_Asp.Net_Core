using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Model.TableConfig
{
    internal class FTPFileEntiyConfiguration : IEntityTypeConfiguration<FTPFile>
    {
        public void Configure(EntityTypeBuilder<FTPFile> builder)
        {
            builder.ToTable("tbFTPFile").HasKey(v => v.Id);
            builder.Property(v => v.FileName).HasMaxLength(250).IsRequired();
            builder.Property(v => v.FileContentType).HasMaxLength(250).IsRequired();
            builder.Property(v => v.FTPFileName).HasMaxLength(250).IsRequired();
            builder.Property(v => v.FTPPath).HasMaxLength(250).IsRequired();
        }
    }
}
