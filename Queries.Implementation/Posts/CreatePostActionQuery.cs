using DataAccess.Entities;
using Queries.Posts;
using System;
using DataAccess.Contexts;

namespace Queries.Implementation.Posts
{
    public class CreatePostActionQuery : ICreatePostActionQuery
    {
        private readonly ApplicationDbContext _context;

        public CreatePostActionQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public Guid Execute(CreatePostActionQueryData actionData)
        {
            var newPost = _context.Posts.Add(new Post
            {
                Id = Guid.NewGuid(),
                Title = actionData.Title,
                Content = actionData.Content,
                CreatedAt = DateTime.Now
            });

            return newPost.Entity.Id;
        }
    }
}