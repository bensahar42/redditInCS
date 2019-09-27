using RedditInCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditInCS.Services
{
    public interface IPostService
    {
        List<BlogPost> ListAll();

        BlogPost FindBlogPostById(long id);

        void AddNewBlogpost(BlogPostInput blogPostInput);

        void DeleteBlogPost(long id);

        void Upvote(long id);

        void DownVote(long id);
    }
}
