using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_Asp.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Asp.Net_Core.Model.EntityConfiguration
{
    public static class Extentions
    {

        public static void SetEntityBase<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Inputter).HasMaxLength(30);
            builder.Property(v => v.Modifier).HasMaxLength(30);
            builder.Property(v => v.Deleter).HasMaxLength(30);
        }
    }
}
