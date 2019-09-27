using Microsoft.AspNetCore.Mvc;
using RedditInCS.Models;
using RedditInCS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditInCS.Controllers
{
    public class RedditController : Controller
    {
        private readonly IPostService postService;

        public RedditController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var blogPosts = postService.ListAll();
            return View(blogPosts);
        }

        [HttpGet("/submit")]
        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost("/add")]
        public IActionResult AddNewBlogPost(BlogPostInput blogPostInput)
        {
            postService.AddNewBlogpost(blogPostInput);
            return Redirect("/");
        }

        [HttpPost("/delete")]
        public IActionResult DeleteBlogPost(long id)
        {
            postService.DeleteBlogPost(id);
            return Redirect("/");
        }

        [HttpPost("/upVote")]
        public IActionResult UpVote(long id)
        {
            postService.Upvote(id);
            return Redirect("/");
        }

        [HttpPost("/downVote")]
        public IActionResult DownVote(long id)
        {
            postService.DownVote(id);
            return Redirect("/");
        }
    }
}
