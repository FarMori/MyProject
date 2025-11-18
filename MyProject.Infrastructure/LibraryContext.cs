using Microsoft.EntityFrameworkCore;
using MyProject.Core;

namespace MyProject.Infrastructure
{
    public class LibraryContext : DbContext 
    {public LibraryContext(DbContextOptions<LibraryContext> options) ///конструктор (Обязательно) /// миграция базы данных
        : base(options)
        {
        }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book>  Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<AuthorBook>()
            .HasOne(ab => ab.Author)
            .WithMany(a => a.AuthorBooks)
            .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<AuthorBook>()
            .HasOne(ab => ab.Book)
            .WithMany(b => b.AuthorBooks)
            .HasForeignKey(ab => ab.BookId);
        }

    }
}
/// ред флаг!!!