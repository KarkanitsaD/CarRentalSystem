namespace Business.FilterModels
{
    public class FilterModel
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public bool? InAscendingOrder { get; set; }
    }
}
