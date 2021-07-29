using System;
using DataAccess.Operations;

namespace Queries.Posts
{
    public interface ICreatePostActionQuery
        : ISingleAction<CreatePostActionQueryData, Guid>
    { }

    public class CreatePostActionQueryData : ActionData
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}