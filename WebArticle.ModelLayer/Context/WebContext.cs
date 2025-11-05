using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebArticle.ModelLayer.Context
{
    public class WebContext:DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Comment> comments { get; set; }
    }
}

