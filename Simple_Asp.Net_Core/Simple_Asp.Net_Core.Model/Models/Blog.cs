using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Model.Models
{
    public class Blog : EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
