namespace Simple_Asp.Net_Core.Dtos
{
    public class BlogReadDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public UserReadDto User { get; set; }

        public DateTime InputDate { get; set; }

        public IList<CommentReadDto> Comments { get; set; }
        public IList<BlogLabelReadDto> BlogLabels { get; set; }
    }
}
