namespace Data.Query
{
    public class PaginationRule
    {
        public int Index { get; set; } = 0;
        public int? Size { get; set; }
        public bool IsValid => Size != null && Index >= 0 && Size > 0;
    }
}