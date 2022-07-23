namespace Simple_Asp.Net_Core.Controllers
{
    public class GoodsSearchPageParams
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageSkip => (PageNo - 1) * PageSize;
        public string? Query { get; set; }
        public string? Type { get; set; }
    }
}