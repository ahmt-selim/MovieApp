using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;
        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie { movie_id = 1, Tilte = "Film 1", Description = "Açıklama 1", Director = "Yönetmen 1", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "1.jpg"},
                new Movie { movie_id = 2,Tilte = "Film 2", Description = "Açıklama 2", Director = "Yönetmen 2", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "2.jpg" },
                new Movie { movie_id = 3,Tilte = "Film 3", Description = "Açıklama 3", Director = "Yönetmen 3", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "3.jpg" },
                new Movie { movie_id = 4,Tilte = "Film 4", Description = "Açıklama 4", Director = "Yönetmen 4", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "4.jpg" },
                new Movie { movie_id = 5, Tilte = "Film 1", Description = "Açıklama 1", Director = "Yönetmen 1", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "1.jpg"},
                new Movie { movie_id = 6,Tilte = "Film 2", Description = "Açıklama 2", Director = "Yönetmen 2", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "2.jpg" },
                new Movie { movie_id = 7,Tilte = "Film 3", Description = "Açıklama 3", Director = "Yönetmen 3", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "3.jpg" },
                new Movie { movie_id = 8,Tilte = "Film 4", Description = "Açıklama 4", Director = "Yönetmen 4", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "4.jpg" }

            };
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }
        public static void Add(Movie movie)
        {
            _movies.Add(movie);
        }
        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.movie_id == id);
        }


    }

}
