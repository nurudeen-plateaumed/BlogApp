using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.DbContextData
{
    public class BlogAppDbContext: DbContext
    {
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options) : base(options) { }
        public DbSet<Contents> contents { get; set; }
    }
}
