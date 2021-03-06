namespace Application.Common.QueryString
{
    public class QueryParameters
    {
        private const int MaxPageSize = 250;
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string OrderBy { get; set; }

        public string Search { get; set; } = String.Empty;
    }
}