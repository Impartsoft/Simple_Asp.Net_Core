namespace Simple_Asp.Net_Core.Data
{
    public class SearchPageParams
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageSkip => (PageNo - 1) * PageSize;
        public string? Query { get; set; }
    }
}
