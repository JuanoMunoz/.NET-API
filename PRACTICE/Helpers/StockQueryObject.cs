namespace PRACTICE.Helpers
{
    public class StockQueryObject
    {
        public string? CompanyName { get; set; } = null;
        public string? Industry {  get; set; } = null;

        public string? SortBy {  get; set; } = null;

        public bool IsDescending { get; set; } = false;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
