using RedditInCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditInCS.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationContext applicationContext;

        public PostService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void AddNewBlogpost(BlogPostInput blogPostInput)
        {
            var BlogPost = new Models.BlogPost
            {
                Title = blogPostInput.Title,
                Url = blogPostInput.Url
            };
            applicationContext.Add(BlogPost);
            applicationContext.SaveChanges();
        }

        public BlogPost FindBlogPostById(long id)
        {
            var blogPost = applicationContext.BlogPosts.SingleOrDefault(bP => bP.BlogPostId == id);
            if (blogPost == null)
            {
                throw new ArgumentNullException();
            }
            return blogPost;
        }

        public void DeleteBlogPost(long id)
        {
            applicationContext.Remove(FindBlogPostById(id));
            applicationContext.SaveChanges();
        }

        public void DownVote(long id)
        {
            FindBlogPostById(id).Count -= 1;
            applicationContext.SaveChanges();
        }

        public List<BlogPost> ListAll()
        {
            var blogPosts = applicationContext.BlogPosts.OrderByDescending(bp => bp.Count).ToList();
            return blogPosts;
        }

        public void Upvote(long id)
        {
            FindBlogPostById(id).Count += 1;
            applicationContext.SaveChanges();
        }
    }
}
