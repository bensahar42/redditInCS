using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditInCS.Models
{
    public class BlogPost
    {
        public long BlogPostId { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
