using System.Collections.Generic;

namespace DataAccess.Operations
{
    public interface IQuery<in TQueryData, out TQueryResult>
        where TQueryData : QueryData
    {
        IEnumerable<TQueryResult> Execute(TQueryData queryData);
    }

    public interface IQuery<out TQueryResult>
    {
        IEnumerable<TQueryResult> Execute();
    }
}