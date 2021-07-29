using System;
using DataAccess.Operations;

namespace Queries.Posts
{
    public interface IGetPagedPostsQuery : IPagedQuery<GetPagedPostsQueryData, GetPagedPostsQueryResult>
    { }

    public class GetPagedPostsQueryData : PagedQueryData
    {
        public string Title { get; set; }
    }

    public class GetPagedPostsQueryResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}