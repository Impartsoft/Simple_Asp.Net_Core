using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Asp.Net_Core.Model.Models
{
    public class BlogLabel
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public Guid BlogId { get; set; }
    }
}
