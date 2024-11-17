using AuthorBookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebApi.Data
{
    public class Context:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
