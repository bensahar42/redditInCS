using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using RedditInCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditInCS
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
    }
}
