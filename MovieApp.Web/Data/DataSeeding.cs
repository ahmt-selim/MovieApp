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

            var genres = new List<Genre>()
                    {
                        new Genre{Name="Macera", Movies= new List<Movie>(){new Movie{Title="Yeni macera filmi 1",Description="Açıklama1", ImageUrl="1.jpg" },
                                                                            new Movie{Title="Yeni macera filmi 2", Description="Açıklama2", ImageUrl="2.jpg"} } },
                        new Genre{Name="Komedi"},
                        new Genre{Name="Romantik"},
                        new Genre{Name="Savaş"},
                        new Genre{Name="Bilim Kurgu"}
                    };
            var movies = new List<Movie>()
                    {
                        new Movie {Title = "Film 1", Description = "Açıklama 1", ImageUrl = "1.jpg", Genre = genres[0]},
                        new Movie {Title = "Film 2", Description = "Açıklama 2", ImageUrl = "2.jpg", Genre = genres[1]},
                        new Movie {Title = "Film 3", Description = "Açıklama 3", ImageUrl = "3.jpg", Genre = genres[1]},
                        new Movie {Title = "Film 4", Description = "Açıklama 4", ImageUrl = "4.jpg", Genre = genres[3]},
                        new Movie {Title = "Film 1", Description = "Açıklama 1", ImageUrl = "1.jpg", Genre = genres[4]},
                        new Movie {Title = "Film 2", Description = "Açıklama 2", ImageUrl = "2.jpg", Genre = genres[4]},
                        new Movie {Title = "Film 3", Description = "Açıklama 3", ImageUrl = "3.jpg", Genre = genres[3]},
                        new Movie {Title = "Film 4", Description = "Açıklama 4", ImageUrl = "4.jpg", Genre = genres[1]}

                    };
            var users = new List<User>() { new User() { UserName="usera",Email="usera@gmail.com",Password="1234",ImageUrl="person1.jpg" },
                new User { UserName="userb",Email="userb@gmail.com",Password="1234",ImageUrl="person2.jpg" },
                new User { UserName="userc",Email="userc@gmail.com",Password="1234",ImageUrl="person3.jpg", 
                    Person=new Person(){Name="Personel 1",Biography="tanıtım 1" } }, 
            new User
            {
                UserName = "userd",
                Email = "userd@gmail.com",
                Password = "1234",
                ImageUrl = "person4.jpg",
                Person = new Person() { Name = "Personel 2", Biography = "tanıtım 2" }
            } };
            if (context.Database.GetPendingMigrations().Count() == 0)//Bütün migrationlar uygulanmışsa yani bekleyen bir migration yoksa 
            {
                if (context.Movies.Count() == 0)//Daha önceden ilgili movies tablosuna veri eklenmişse yeni test verilerini eklemiyor.
                {
                    context.Movies.AddRange(movies);
                }
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }
                context.SaveChanges();
            }
        }
    }
}
