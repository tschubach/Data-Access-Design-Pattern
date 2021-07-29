using Queries.Posts;
using DataAccess.Contexts;

namespace Queries.Implementation.Posts
{
    public class DeletePostActionQuery : IDeletePostActionQuery
    {
        private readonly ApplicationDbContext _context;

        public DeletePostActionQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Execute(DeletePostsActionQueryData actionData)
        {
            var post = _context.Posts.Find(actionData.PostId);

            _context.Posts.Remove(post);
        }
    }
}