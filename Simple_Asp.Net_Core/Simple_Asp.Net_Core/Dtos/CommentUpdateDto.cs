namespace Simple_Asp.Net_Core.Dtos
{
    public class CommentUpdateDto
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public Guid UserId { get; set; }

        public Guid BlogId { get; set; }
    }
}
