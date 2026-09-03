namespace Business.Query
{
    public class QueryModel
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; }

        public bool IsValidPagination => PageSize > 0 && PageIndex >= 0;
    }
}