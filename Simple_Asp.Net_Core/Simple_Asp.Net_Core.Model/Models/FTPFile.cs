using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_Asp.Net_Core.Models
{
    public class FTPFile
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string FileContentType { get; set; }

        public string FTPFileName { get; set; }

        public string FTPPath { get; set; }
    }
}