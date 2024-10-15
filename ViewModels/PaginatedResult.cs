namespace BankVictor.ViewModels
{
    public class PaginatedResult<T>
    {
        public List<T> Results { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)System.Math.Ceiling((double)TotalRecords / PageSize);
    }
}
