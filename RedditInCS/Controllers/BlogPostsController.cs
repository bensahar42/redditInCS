using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditInCS.Controllers
{
    public class RedditController : Controller
    {
        private ApplicationContext applicationContext;
        public RedditController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var blogPosts = applicationContext.BlogPosts.OrderByDescending(bp => bp.Count).ToList();
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
            var BlogPost = new Models.BlogPost
            {
                Title = blogPostInput.Title,
                Url = blogPostInput.Url
            };
            applicationContext.Add(BlogPost);
            applicationContext.SaveChanges();
            return Redirect("/");
        }

        [HttpPost("/delete")]
        public IActionResult DeleteBlogPost(long id)
        {
            var blogPost = applicationContext.BlogPosts.SingleOrDefault(bp => bp.BlogPostId == id);

            if(blogPost == null)
            {
                return BadRequest();
            }

            applicationContext.Remove(blogPost);
            applicationContext.SaveChanges();

            return Redirect("/");
        }

        [HttpPost("/upVote")]
        public IActionResult UpVote(long id)
        {
            var blogPost = applicationContext.BlogPosts.SingleOrDefault(bp => bp.BlogPostId == id);

            if (blogPost == null)
            {
                return BadRequest();
            }

            blogPost.Count += 1;
            applicationContext.SaveChanges();

            return Redirect("/");
        }

        [HttpPost("/downVote")]
        public IActionResult DownVote(long id)
        {
            var blogPost = applicationContext.BlogPosts.SingleOrDefault(bp => bp.BlogPostId == id);

            if (blogPost == null)
            {
                return BadRequest();
            }

            blogPost.Count -= 1;
            applicationContext.SaveChanges();

            return Redirect("/");
        }

        public class BlogPostInput
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }
    }
}
