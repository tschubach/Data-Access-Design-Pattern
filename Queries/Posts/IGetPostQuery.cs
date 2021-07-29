using System;
using DataAccess.Operations;

namespace Queries.Posts
{
    public interface IGetPostQuery : ISingleQuery<GetPostQueryData, GetPostQueryResult>
    { }

    public class GetPostQueryData : QueryData
    {
        public Guid PostId { get; set; }
    }

    public class GetPostQueryResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}