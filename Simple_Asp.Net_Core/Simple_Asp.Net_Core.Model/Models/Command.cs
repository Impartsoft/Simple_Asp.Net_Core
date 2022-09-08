using System.ComponentModel.DataAnnotations;

namespace Simple_Asp.Net_Core.Models
{
    public class Command
    {

        public Guid Id { get; set; }


        public string HowTo { get; set; }


        public string Line { get; set; }


        public string Platform { get; set; }
    }
}