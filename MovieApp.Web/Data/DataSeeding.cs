using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {//Development aşamasında uygulama başlatıldığında test verileri oluşturmak için kullanıyoruz.
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();//Uygulama ilk çalıştığında veritabanını kontrol ederek yok ise oluşturma işlemi

            if (context.Database.GetPendingMigrations().Count() == 0)//Bütün migrationlar uygulanmışsa yani bekleyen bir migration yoksa 
            {
                if (context.Movies.Count() == 0)//Daha önceden ilgili movies tablosuna veri eklenmişse yeni test verilerini eklemiyor.
                {
                    context.Movies.AddRange(new List<Movie>()
            {
                new Movie { movie_id = 1,Title = "Film 1", Description = "Açıklama 1", ImageUrl = "1.jpg", genre_id=1},
                new Movie { movie_id = 2,Title = "Film 2", Description = "Açıklama 2", ImageUrl = "2.jpg", genre_id=4},
                new Movie { movie_id = 3,Title = "Film 3", Description = "Açıklama 3", ImageUrl = "3.jpg", genre_id=4},
                new Movie { movie_id = 4,Title = "Film 4", Description = "Açıklama 4", ImageUrl = "4.jpg", genre_id=3},
                new Movie { movie_id = 5,Title = "Film 1", Description = "Açıklama 1", ImageUrl = "1.jpg", genre_id=3},
                new Movie { movie_id = 6,Title = "Film 2", Description = "Açıklama 2", ImageUrl = "2.jpg", genre_id=1},
                new Movie { movie_id = 7,Title = "Film 3", Description = "Açıklama 3", ImageUrl = "3.jpg", genre_id=3},
                new Movie { movie_id = 8,Title = "Film 4", Description = "Açıklama 4", ImageUrl = "4.jpg", genre_id=1}

            }

                        );
                }
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(new List<Genre>()
            {
                new Genre{genre_id = 1, Name="Macera"},
                new Genre{genre_id = 2,Name="Komedi"},
                new Genre{genre_id = 3,Name="Romantik"},
                new Genre{genre_id = 4,Name="Savaş"},
                 new Genre{genre_id = 5,Name="Bilim Kurgu"}
            }
                        );
                }
                context.SaveChanges();
            }
        }
    }
}
