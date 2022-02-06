using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, //Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2022, 1, 24)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, // Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2021, 6, 16)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2, // Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2020, 2, 14)
                    }
                );

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Ömer",
                        Surname = "Umutlu",
                        DateOfBirth = new DateTime(2002,7,16)
                    },
                    new Author
                    {
                        Name = "Selim Can",
                        Surname = "Umutlu",
                        DateOfBirth = new DateTime(1997, 8, 2)
                    },
                    new Author
                    {
                        Name = "Ece",
                        Surname = "Demir",
                        DateOfBirth = new DateTime(2008, 8, 9)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
