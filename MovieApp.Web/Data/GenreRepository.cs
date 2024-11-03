using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre{genre_id = 1, Name="Macera"},
                new Genre{genre_id = 2,Name="Komedi"},
                new Genre{genre_id = 3,Name="Romantik"},
                new Genre{genre_id = 4,Name="Savaş"},
                 new Genre{genre_id = 5,Name="Bilim Kurgu"}
            };
        }

        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(g => g.genre_id == id);
        }
    }
}
