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
                new Movie { movie_id = 1, Title = "Film 1", Description = "Açıklama 1", Director = "Yönetmen 1", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "1.jpg", genre_id=1},
                new Movie { movie_id = 2,Title = "Film 2", Description = "Açıklama 2", Director = "Yönetmen 2", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "2.jpg" , genre_id=4},
                new Movie { movie_id = 3,Title = "Film 3", Description = "Açıklama 3", Director = "Yönetmen 3", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "3.jpg" , genre_id=4},
                new Movie { movie_id = 4,Title = "Film 4", Description = "Açıklama 4", Director = "Yönetmen 4", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "4.jpg" , genre_id=3},
                new Movie { movie_id = 5, Title = "Film 1", Description = "Açıklama 1", Director = "Yönetmen 1", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "1.jpg", genre_id=3},
                new Movie { movie_id = 6,Title = "Film 2", Description = "Açıklama 2", Director = "Yönetmen 2", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "2.jpg" , genre_id=1},
                new Movie { movie_id = 7,Title = "Film 3", Description = "Açıklama 3", Director = "Yönetmen 3", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "3.jpg" , genre_id=3},
                new Movie { movie_id = 8,Title = "Film 4", Description = "Açıklama 4", Director = "Yönetmen 4", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "4.jpg" , genre_id=1}

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
            movie.movie_id = _movies.Count() + 1;
            _movies.Add(movie);
        }
        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.movie_id == id);
        }

        public static void Edit(Movie m)
        {
            foreach (var movie in _movies)
            {
                if (movie.movie_id == m.movie_id)
                {
                    movie.Title = m.Title;
                    movie.Description = m.Description;
                    movie.Director = m.Director;
                    movie.ImageUrl = m.ImageUrl;
                    movie.genre_id = m.genre_id;
                    break;
                }
            }
        }

    }

}
