using Microsoft.EntityFrameworkCore;

namespace BookStoreX.Models
{
    public class BookContext : DbContext
    {

        public DbSet<Book> Books { get; set;}
        public DbSet<Purchase> Purchases { get; set; }

        public BookContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bookStore.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id= 1, Name="Война и мир", Author = "Л. Толстой", Price = 155 },
                new Book { Id = 2, Name = "Отцы и дети", Author = "И. Тургенев", Price = 130 },
                new Book { Id = 3, Name = "Чайка", Author = "А. Чехов", Price = 59 },
                new Book { Id = 4, Name = "Мы", Author = "Е. Замятин", Price = 88 });

        }
    }
}
