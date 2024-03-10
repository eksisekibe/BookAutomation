using BookAutomation.Data.Concrete;
using BookAutomation.Entity.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAutomation.API.Extensions
{
    public static class DBSeeder
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
           
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<PostgreSqlContext>();
                
                if (context.Users.Count() == 0)
                {

                    context.Users.AddRange(new List<User>
                    {
                        new User()
                        {
                            FirstName = "Şekibe",
                            LastName = "Ekşi",
                            Username = "sekibe",
                            Password = "12345."
                        },
                        new User()
                        {
                            FirstName = "Ali",
                            LastName = "Demir",
                            Username = "ali",
                            Password = "12345."
                        },
                        new User()
                        {
                            FirstName = "Veli",
                            LastName = "Öztürk",
                            Username = "veli",
                            Password = "12345."
                        },
                        new User()
                        {
                            FirstName = "Fatma",
                            LastName = "Kaya",
                            Username = "fatma",
                            Password = "12345."
                        }
                    });
                    context.SaveChanges();
                }

                if(context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(new List<Category>
                    {
                          new Category()
                        {
                            Name = "Roman",
                            Description = "Bazen kurgu bazen ise gerçekleri anlatan, oldukça uzun kitaplar arasında yer alır.",
                        },
                        new Category()
                        {
                            Name = "Öykü",
                            Description = "Genelde daha çok çocuklar için yazılmış olan, eğlenceli kurguları bulunan kitaplardır. "
                        },
                        new Category()
                        {
                            Name = "Bilim",
                            Description = "Belli başlı bazı konular hakkında bilgi veren ya da tek bir konuyu ele alan kitaplardır.",
                        }
                    });
                    context.SaveChanges();
                    var categoryId = context.Categories.First().Id;

                    context.Categories.AddRange(
                        new Category()
                        {
                            Name = "Suç- Polisiye",
                            Description = "Suç ve ceza",
                            ParentCategoryId = categoryId
                        },
                        new Category()
                        {
                            Name = "Aşk",
                            Description = "Suç ve ceza",
                            ParentCategoryId = categoryId
                        });
                    context.SaveChanges();
                }

                if(context.Books.Count() ==0)
                {
                    context.Books.AddRange(new List<Book>
                    {
                        new Book()
                        {
                            Name = "Kürk Mantolu Madonna",
                            Author = "Sabahattin Ali",
                            Genre = "Roman",
                            PublishDate = new DateTime(1998, 10, 2),
                            LastModifiedBy = "sekibe"
                        },
                        new Book()
                        {
                            Name = "Sırça Köşk",
                            Author = "Sabahattin Ali",
                            Genre = "Öykü",
                            PublishDate = new DateTime(1997, 10, 2),
                            LastModifiedBy = "sekibe"
                        },
                        new Book()
                        {
                            Name = "Kozmoz",
                            Author = "Carl Sagan",
                            Genre = "Bilim",
                            PublishDate = new DateTime(2007, 10, 2),
                            LastModifiedBy = "sekibe"
                        }
                    });
                    context.SaveChanges();
                }


            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}
