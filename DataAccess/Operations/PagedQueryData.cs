namespace DataAccess.Operations
{
    public abstract class PagedQueryData
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}