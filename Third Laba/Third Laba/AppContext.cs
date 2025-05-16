using Microsoft.EntityFrameworkCore;
using Third_Laba.Models;

namespace Third_Laba
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<BookAndGenre> BooksAndGenres => Set<BookAndGenre>();
        
        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
