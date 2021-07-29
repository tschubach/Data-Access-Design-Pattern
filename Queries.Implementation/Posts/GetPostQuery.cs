using Queries.Posts;
using System.Linq;
using DataAccess.Contexts;

namespace Queries.Implementation.Posts
{
    public class GetPostQuery : IGetPostQuery
    {
        private readonly ApplicationDbContext _context;

        public GetPostQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public GetPostQueryResult Execute(GetPostQueryData queryData)
        {
            var post = _context.Posts
                .Where(x => x.Id == queryData.PostId)
                .Select(x => new GetPostQueryResult
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt
                })
                .FirstOrDefault();

            return post;
        }
    }
}