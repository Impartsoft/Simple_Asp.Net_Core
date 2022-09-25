using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_Asp.Net_Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Asp.Net_Core.Model.EntityConfiguration
{
    public class BlogLabelEntityTypeConfigration : IEntityTypeConfiguration<BlogLabel>
    {
        public void Configure(EntityTypeBuilder<BlogLabel> builder)
        {
            builder.ToTable("tbBlogLabel");
            builder.Property(v => v.Label).HasMaxLength(50);
        }
    }
}
