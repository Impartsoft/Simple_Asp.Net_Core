namespace Simple_Asp.Net_Core.Dtos
{
    public class BlogCreateDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public IList<BlogLabelCreateDto> BlogLabels { get; set; }
    }
}
