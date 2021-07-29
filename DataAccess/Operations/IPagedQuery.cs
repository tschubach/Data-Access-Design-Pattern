namespace DataAccess.Operations
{
    public interface IPagedQuery<TQueryData, TQueryResult>
        where TQueryData : PagedQueryData
    {
        PagedQueryResult<TQueryResult> Execute(TQueryData queryData);
    }
}