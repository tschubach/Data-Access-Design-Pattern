using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Operations
{
    public class PagedQueryResult<T>
    {
        private readonly IQueryable<T> _queryableData;

        public int PageSize { get; }
        public int PreviousPage => CurrentPage > 1 ? CurrentPage - 1 : -1;
        public int NextPage => CurrentPage < TotalPages ? CurrentPage + 1 : -1;
        public int TotalRecords { get; }
        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);
        public int CurrentPage { get; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public IEnumerable<T> Data => GetPagedResult();

        public PagedQueryResult(IQueryable<T> queryableData, int pageSize = 5, int pageNumber = 1)
        {
            _queryableData = queryableData;

            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalRecords = queryableData.Count();
        }

        private IEnumerable<T> GetPagedResult()
        {
            var result = _queryableData
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize);

            // Return
            return result;
        }
    }
}