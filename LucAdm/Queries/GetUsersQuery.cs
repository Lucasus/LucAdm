namespace LucAdm
{
    public class GetUsersQuery : IValidatable
    {
        public string SearchTerm { get; set; }
        public string SortType { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}