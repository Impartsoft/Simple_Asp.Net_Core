namespace Simple_Asp.Net_Core.Dtos
{
    public class BlogUpdateDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public IList<CommentUpdateDto> Comments { get; set; }
    }
}
