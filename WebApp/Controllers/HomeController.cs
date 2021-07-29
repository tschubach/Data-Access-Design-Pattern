using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Queries.Posts;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IGetPostQuery _getPostQuery;
        private readonly IGetPagedPostsQuery _getPagedPostsQuery;
        private readonly ICreatePostActionQuery _createPostActionQuery;
        private readonly IDeletePostActionQuery _deletePostActionQuery;

        public HomeController(ILogger<HomeController> logger,
            IGetPostQuery getPostQuery,
            IGetPagedPostsQuery getPagedPostsQuery,
            ICreatePostActionQuery createPostActionQuery,
            IDeletePostActionQuery deletePostActionQuery)
        {
            _logger = logger;

            _getPostQuery = getPostQuery;
            _getPagedPostsQuery = getPagedPostsQuery;
            _createPostActionQuery = createPostActionQuery;
            _deletePostActionQuery = deletePostActionQuery;
        }

        public IActionResult Index()
        {
            // Get single post
            var singlePost = _getPostQuery.Execute(new GetPostQueryData
            {
                PostId = Guid.Parse("920241CA-8DFB-4A8F-A370-3C0B6AFC195B")
            });

            // Get paged posts
            var pagedResult = _getPagedPostsQuery.Execute(new GetPagedPostsQueryData
            {
                Title = "Lorem",
                PageNumber = 2,
                PageSize = 4
            });

            var pagedPosts = pagedResult.Data;

            // Create post and get its Id
            var newPostId = _createPostActionQuery.Execute(new CreatePostActionQueryData
            {
                Title = "New Post Title",
                Content = "Lots of content"
            });

            // Delete post
            _deletePostActionQuery.Execute(new DeletePostsActionQueryData { PostId = Guid.NewGuid() });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}