namespace DataAccess.Operations
{
    public interface ISingleQuery<in TQueryData, out TQueryResult>
        where TQueryData : QueryData
    {
        TQueryResult Execute(TQueryData queryData);
    }

    public interface ISingleQuery<out TQueryResult>
    {
        TQueryResult Execute();
    }
}