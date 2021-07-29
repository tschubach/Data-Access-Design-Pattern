using System;
using DataAccess.Operations;

namespace Queries.Posts
{
    public interface IDeletePostActionQuery : INoResultAction<DeletePostsActionQueryData>
    { }

    public class DeletePostsActionQueryData : ActionData
    {
        public Guid PostId { get; set; }
    }
}