namespace Simple_Asp.Net_Core.Dtos
{
    public class CommentCreateDto
    {
        public string Content { get; set; }

        public Guid BlogId { get; set; }
    }
}
