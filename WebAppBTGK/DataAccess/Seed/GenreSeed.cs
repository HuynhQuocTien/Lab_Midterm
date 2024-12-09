using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess.Seed
{
    public static class GenreSeed
    {
        public static async Task SeedAsync(BookContext context)
        {
            if (context.Genres.Any())
                return;
            var genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Hoạt hình",
                    Description = "Thể loại Hoạt hình"
                },
                new Genre
                {
                    Name = "Cổ tích",
                    Description = "Thể loại cổ tích"
                },
                new Genre
                {
                    Name = "Hài",
                    Description = "Thể loại hài"
                },
                new Genre
                {
                    Name = "Tiểu thuyết",
                    Description = "Thể loại tiểu thuyết"
                },
                new Genre
                {
                    Name = "Trinh thám",
                    Description = "Thể loại trinh thám"
                }
            };
            context.Genres.AddRange(genres);
            await context.SaveChangesAsync();
        }
    }
}
