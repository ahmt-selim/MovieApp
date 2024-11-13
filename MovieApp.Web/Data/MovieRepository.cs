using MovieApp.Web.Entity;
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
                new Movie { movie_id = 1,Title = "Film 1", Description = "Açıklama 1", ImageUrl = "1.jpg"},
                new Movie { movie_id = 2,Title = "Film 2", Description = "Açıklama 2", ImageUrl = "2.jpg"},
                new Movie { movie_id = 3,Title = "Film 3", Description = "Açıklama 3", ImageUrl = "3.jpg"},
                new Movie { movie_id = 4,Title = "Film 4", Description = "Açıklama 4", ImageUrl = "4.jpg"},
                new Movie { movie_id = 5,Title = "Film 1", Description = "Açıklama 1", ImageUrl = "1.jpg"},
                new Movie { movie_id = 6,Title = "Film 2", Description = "Açıklama 2", ImageUrl = "2.jpg"},
                new Movie { movie_id = 7,Title = "Film 3", Description = "Açıklama 3", ImageUrl = "3.jpg"},
                new Movie { movie_id = 8,Title = "Film 4", Description = "Açıklama 4", ImageUrl = "4.jpg"}

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
                    movie.ImageUrl = m.ImageUrl;
                    break;
                }
            }
        }

        public static void Delete(int movie_id)
        {
            var movie = GetById(movie_id);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }
    }

}
