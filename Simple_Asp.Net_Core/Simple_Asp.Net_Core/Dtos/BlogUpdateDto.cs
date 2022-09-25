namespace Simple_Asp.Net_Core.Dtos
{
    public class BlogUpdateDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IList<BlogLabelUpdateDto> BlogLabels { get; set; }
    }
}
