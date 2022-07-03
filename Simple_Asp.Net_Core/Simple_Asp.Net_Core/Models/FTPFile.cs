using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_Asp.Net_Core.Models
{

    [Table("FTPFiles")]
    public class FTPFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(250)]
        public string FileContentType { get; set; }

        [Required]
        [MaxLength(250)]
        public string FTPFileName { get; set; }

        [Required]
        [MaxLength(250)]
        public string FTPPath { get; set; }
    }
}