using BookAutomation.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Data.Concrete
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>().HasData(
                new User() 
                { 
                    Id = 1, 
                    FirstName = "Şekibe", 
                    LastName = "Ekşi", 
                    Username = "sekibe", 
                    Password = "12345." 
                },
                new User() 
                { 
                    Id = 2, 
                    FirstName = "Ali", 
                    LastName = "Demir", 
                    Username = "ali", 
                    Password = "12345." 
                },
                new User() 
                { 
                    Id = 3, 
                    FirstName = "Veli", 
                    LastName = "Öztürk", 
                    Username = "veli", 
                    Password = "12345." 
                },
                new User() 
                { 
                    Id = 4, 
                    FirstName = "Fatma", 
                    LastName = "Kaya", 
                    Username = "fatma", 
                    Password = "12345." 
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() 
                { 
                    Id = 1, 
                    Name = "Roman", 
                    Description = "Bazen kurgu bazen ise gerçekleri anlatan, oldukça uzun kitaplar arasında yer alır.",
                },
                new Category() 
                { 
                    Id = 2, 
                    Name = "Öykü", 
                    Description = "Genelde daha çok çocuklar için yazılmış olan, eğlenceli kurguları bulunan kitaplardır. " 
                },
                new Category()
                {
                    Id = 3,
                    Name = "Bilim",
                    Description = "Belli başlı bazı konular hakkında bilgi veren ya da tek bir konuyu ele alan kitaplardır.",
                    SubCategory = "Uzay",
                    //Subcategories = new List<Category>
                    //{
                    //    new Category() 
                    //    { 
                    //        Id = 4, 
                    //        Name = "Kimya", 
                    //        Description = "Kimya kitapları" },
                    //    new Category() 
                    //    { 
                    //        Id = 5, 
                    //        Name = "Fizik", 
                    //        Description = "Fizik kitapları" },
                    //    new Category() 
                    //    { 
                    //        Id = 6, 
                    //        Name = "Matematik", 
                    //        Description = "Matematik kitapları" },
                    //    new Category() 
                    //    { 
                    //        Id = 7, 
                    //        Name = "Türkçe", 
                    //        Description = "Türkçe kitapları" }
                    //}
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Name = "Kürk Mantolu Madonna",
                    Author = "Sabahattin Ali",
                    Genre = "Roman",
                    PublishDate = new DateTime(1998, 10, 2),
                    CategoryId = 1,
                    LastModifiedById = 1
                },
                new Book()
                {
                    Id = 2,
                    Name = "Sırça Köşk",
                    Author = "Sabahattin Ali",
                    Genre = "Öykü",
                    PublishDate = new DateTime(1997, 10, 2),
                    CategoryId = 2,
                    LastModifiedById = 2
                },
                new Book()
                {
                    Id = 3,
                    Name = "Kozmoz",
                    Author = "Carl Sagan",
                    Genre = "Bilim",
                    PublishDate = new DateTime(2007, 10, 2),
                    CategoryId = 3,
                    LastModifiedById = 3
                }
            );

        }
    }
}
