using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_Asp.Net_Core.Models
{
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(30)]
        public string? Inputter { get; set; }

        public DateTime InputDate { get; set; }

        [MaxLength(30)]
        public string? Modifier { get; set; }

        public DateTime ModifyDate { get; set; }

        public DeleteTag DeleteTag { get; set; }

        [MaxLength(30)]
        public string? Deleter { get; set; }

        public DateTime DeleteDate { get; set; }

    }

    public enum DeleteTag
    {
        None=0,
        NotDeleted = 1,
        Deleted = 2,
    }
}