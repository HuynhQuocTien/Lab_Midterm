using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess.Seed
{
    public static class BookSeed
    {
        public static async Task SeedAsync(BookContext context)
        {
            if (context.Books.Any())
                return;
            var books = new List<Book>
                {
                     new Book
            {
                Id = 1,
                Title = "Sample Book 1",
                Author = "Author 1",
                Available = true,
                Publisher = false,
                Price = 100000,
                CreatedOn = DateTime.Now,
                IsActive = true,
                GenreId = 1
            },
            new Book
            {
                Id = 2,
                Title = "Sample Book 2",
                Author = "Author 2",
                Available = true,
                Publisher = true,
                Price = 30000,
                CreatedOn = DateTime.Now,
                IsActive = true,
                GenreId = 2
            },
            new Book
            {
                Id = 3,
                Title = "Sample Book 3",
                Author = "Author 1",
                Available = true,
                Publisher = true,
                Price = 20000,
                CreatedOn = DateTime.Now,
                IsActive = true,
                GenreId = 2
            }
                };
            context.Books.AddRange(books);
            await context.SaveChangesAsync();
        }
    }
}
