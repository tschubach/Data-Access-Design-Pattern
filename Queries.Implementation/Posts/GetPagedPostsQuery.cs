using Queries.Posts;
using System.Linq;
using DataAccess.Contexts;
using DataAccess.Operations;

namespace Queries.Implementation.Posts
{
    public class GetPagedPostsQuery : IGetPagedPostsQuery
    {
        private readonly ApplicationDbContext _context;

        public GetPagedPostsQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public PagedQueryResult<GetPagedPostsQueryResult> Execute(GetPagedPostsQueryData queryData)
        {
            // Build the query but not execute it
            var posts = _context.Posts
                .Where(x => x.Title.Contains(queryData.Title))
                .Select(x => new GetPagedPostsQueryResult
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt
                });

            // Build paged result
            var pagedResult = new PagedQueryResult<GetPagedPostsQueryResult>(posts, queryData.PageSize, queryData.PageNumber);

            // Return
            return pagedResult;
        }
    }
}